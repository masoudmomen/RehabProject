// Blog filter bar (BlogFilterBar.razor): "More topics" popover / bottom sheet and the scrolling chip row.
// Loaded as an ES module; UI only. Open/closed state lives in the component; this file handles
// focus, keyboard, outside clicks, scroll lock and the edge fade.

const SHEET_QUERY = '(max-width: 767.98px)';
const opened = new WeakMap();
const rows = new WeakMap();

const isSheet = () => window.matchMedia(SHEET_QUERY).matches;
const isShown = el => el.getClientRects().length > 0;
// panel items whose row is hidden (chip topics that did not overflow) are skipped
const items = root => Array.from(root.querySelectorAll('.more-topics-item')).filter(isShown);
const button = root => root.querySelector('.more-topics-btn');
const panel = root => root.querySelector('.more-topics-panel');

// ---- chip row ----
// 768px and up: chips that don't fit on the line are hidden (data-overflow) and their entry in the
//   "More topics" panel is shown instead, so no chip is ever cut off. The active chip always stays.
// Below 768px: every chip stays in a sideways-scrolling row, faded at the end while there is more.
// Only data-* attributes are touched here; Blazor never renders them, so a re-render keeps them.

export function initRow(wrap) {
    const scroller = wrap && wrap.querySelector('.topic-scroll');
    const row = wrap && wrap.parentElement;
    if (!scroller || !row || rows.has(wrap)) return;

    const fade = () => updateFade(wrap, scroller);
    const relayout = () => layout(wrap);
    scroller.addEventListener('scroll', fade, { passive: true });
    // observe the row, whose width does not depend on how many chips are shown
    const ro = new ResizeObserver(relayout);
    ro.observe(row);
    // web fonts change chip widths once they arrive
    document.fonts?.ready.then(() => { if (rows.has(wrap)) relayout(); });

    rows.set(wrap, () => {
        scroller.removeEventListener('scroll', fade);
        ro.disconnect();
    });

    relayout();

    // keep the active chip in view on narrow screens
    if (isSheet()) {
        const active = scroller.querySelector('.filter-pill.active');
        if (active && active !== scroller.firstElementChild) {
            const left = active.offsetLeft - scroller.offsetLeft;
            if (left + active.offsetWidth > scroller.clientWidth) scroller.scrollLeft = left - 16;
        }
        fade();
    }
}

export function layout(wrap) {
    const scroller = wrap && wrap.querySelector('.topic-scroll');
    const row = wrap && wrap.parentElement;
    if (!scroller || !row) return;

    const more = row.querySelector('.more-topics');
    const chips = Array.from(scroller.querySelectorAll('.filter-pill[data-slug]'));
    const base = Number(more?.dataset.base || 0);

    // measure with every chip shown
    chips.forEach(c => c.removeAttribute('data-overflow'));

    if (isSheet() || !more) {
        applyOverflow(row, more, chips, new Set(), base);
        updateFade(wrap, scroller);
        return;
    }

    scroller.scrollLeft = 0;
    const gap = parseFloat(getComputedStyle(scroller).columnGap) || 0;
    const rowGap = parseFloat(getComputedStyle(row).columnGap) || 0;
    const width = el => el.getBoundingClientRect().width;
    const lead = width(scroller.firstElementChild); // "All Articles" always stays
    const widths = chips.map(width);
    const rowWidth = row.clientWidth;
    const allChips = lead + widths.reduce((sum, w) => sum + gap + w, 0);

    // everything fits and the panel would be empty: no "More topics" button at all
    if (base === 0 && allChips <= rowWidth + 0.5) {
        applyOverflow(row, more, chips, new Set(), base);
        updateFade(wrap, scroller);
        return;
    }

    const activeIndex = chips.findIndex(c => c.classList.contains('active'));
    const pick = available => {
        const overflow = new Set();
        let used = lead + (activeIndex >= 0 ? gap + widths[activeIndex] : 0);
        let full = false;
        chips.forEach((_, i) => {
            if (i === activeIndex) return;
            // once one chip doesn't fit, the rest go too, so the visible chips keep their order
            if (!full && used + gap + widths[i] <= available + 0.5) used += gap + widths[i];
            else { full = true; overflow.add(i); }
        });
        return overflow;
    };

    // the button's width depends on its count, so settle it in a couple of passes
    setCount(row, more, Math.max(base, 1));
    let overflow = new Set();
    for (let pass = 0; pass < 3; pass++) {
        overflow = pick(rowWidth - width(more) - rowGap);
        const before = more.dataset.count;
        setCount(row, more, base + overflow.size);
        if (more.dataset.count === before) break;
    }

    applyOverflow(row, more, chips, overflow, base);
    updateFade(wrap, scroller);
}

function applyOverflow(row, more, chips, overflow, base) {
    const hiddenSlugs = new Set();
    chips.forEach((chip, i) => {
        if (overflow.has(i)) {
            chip.setAttribute('data-overflow', '');
            hiddenSlugs.add(chip.dataset.slug);
        } else {
            chip.removeAttribute('data-overflow');
        }
    });
    if (!more) return;
    more.querySelectorAll('.more-topics-list li[data-chip]').forEach(li => {
        li.toggleAttribute('data-overflow', hiddenSlugs.has(li.dataset.slug));
    });
    setCount(row, more, base + hiddenSlugs.size);
}

function setCount(row, more, count) {
    if (!more) return;
    const value = String(count);
    more.dataset.count = value;
    row.querySelectorAll('.more-topics-count, .more-topics-total').forEach(el => { el.dataset.count = value; });
}

function updateFade(wrap, scroller) {
    const more = scroller.scrollWidth - scroller.clientWidth - scroller.scrollLeft > 1;
    wrap.classList.toggle('can-scroll-end', more);
}

// ---- popover / sheet ----

export function open(root, dotnet) {
    if (!root) return;
    teardown(root);

    const sheet = isSheet();
    const closeFromScript = returnFocus => {
        teardown(root);
        if (returnFocus) button(root)?.focus({ preventScroll: true });
        dotnet.invokeMethodAsync('ClosedFromScript');
    };

    // click/tap outside the button + panel (the sheet backdrop is handled by the component)
    const onPointerDown = e => {
        if (!root.contains(e.target)) closeFromScript(false);
    };

    const onKeyDown = e => {
        if (e.key === 'Escape') {
            e.preventDefault();
            closeFromScript(true);
            return;
        }
        if (e.key === 'ArrowDown' || e.key === 'ArrowUp') {
            if (!root.contains(document.activeElement)) return;
            const list = items(root);
            if (!list.length) return;
            e.preventDefault();
            const i = list.indexOf(document.activeElement);
            const next = i < 0
                ? (e.key === 'ArrowDown' ? 0 : list.length - 1)
                : (i + (e.key === 'ArrowDown' ? 1 : -1) + list.length) % list.length;
            list[next].focus();
            return;
        }
        // the sheet is modal: keep Tab inside it
        if (e.key === 'Tab' && sheet) {
            const p = panel(root);
            const focusables = Array.from(p.querySelectorAll('a[href], button')).filter(isShown);
            if (!focusables.length) return;
            const first = focusables[0], last = focusables[focusables.length - 1];
            if (e.shiftKey && (document.activeElement === first || !p.contains(document.activeElement))) {
                e.preventDefault();
                last.focus();
            } else if (!e.shiftKey && document.activeElement === last) {
                e.preventDefault();
                first.focus();
            }
        }
    };

    // the popover is not modal: tabbing out of it closes it
    const onFocusOut = e => {
        if (sheet) return;
        if (e.relatedTarget && !root.contains(e.relatedTarget)) closeFromScript(false);
    };

    document.addEventListener('pointerdown', onPointerDown, true);
    document.addEventListener('keydown', onKeyDown);
    root.addEventListener('focusout', onFocusOut);

    let unlock = null;
    const p = panel(root);
    if (sheet) {
        p?.setAttribute('aria-modal', 'true');
        unlock = lockScroll();
    } else if (p) {
        // right-aligned to the button; nudge it right if that would run off the left edge
        p.style.removeProperty('--shift');
        const left = p.getBoundingClientRect().left;
        if (left < 16) p.style.setProperty('--shift', `${Math.ceil(16 - left)}px`);
    }

    opened.set(root, () => {
        document.removeEventListener('pointerdown', onPointerDown, true);
        document.removeEventListener('keydown', onKeyDown);
        root.removeEventListener('focusout', onFocusOut);
        panel(root)?.removeAttribute('aria-modal');
        if (unlock) unlock();
    });

    // move focus into the panel: the current topic if it is in here, otherwise the first one
    const list = items(root);
    const target = list.find(a => a.classList.contains('active')) || list[0];
    if (target) target.focus({ preventScroll: !sheet });
}

export function close(root, returnFocus) {
    if (!root) return;
    teardown(root);
    if (returnFocus) button(root)?.focus({ preventScroll: true });
}

export function dispose(wrap, root) {
    if (root) teardown(root);
    const off = wrap && rows.get(wrap);
    if (off) {
        off();
        rows.delete(wrap);
    }
}

function teardown(root) {
    const off = opened.get(root);
    if (off) {
        off();
        opened.delete(root);
    }
}

function lockScroll() {
    const html = document.documentElement;
    const body = document.body;
    const prev = { html: html.style.overflow, body: body.style.overflow, pad: body.style.paddingRight };
    const scrollbar = window.innerWidth - html.clientWidth;
    html.style.overflow = 'hidden';
    body.style.overflow = 'hidden';
    if (scrollbar > 0) body.style.paddingRight = `${scrollbar}px`;
    return () => {
        html.style.overflow = prev.html;
        body.style.overflow = prev.body;
        body.style.paddingRight = prev.pad;
    };
}
