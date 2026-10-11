// Blog filter bar (BlogFilterBar.razor): "More topics" popover / bottom sheet and the scrolling chip row.
// Loaded as an ES module; UI only. Open/closed state lives in the component; this file handles
// focus, keyboard, outside clicks, scroll lock and the edge fade.

const SHEET_QUERY = '(max-width: 767.98px)';
const opened = new WeakMap();
const rows = new WeakMap();

const isSheet = () => window.matchMedia(SHEET_QUERY).matches;
const items = root => Array.from(root.querySelectorAll('.more-topics-item'));
const button = root => root.querySelector('.more-topics-btn');
const panel = root => root.querySelector('.more-topics-panel');

// ---- chip row: fade before the pinned button while there is more to scroll ----

export function initRow(wrap) {
    const scroller = wrap && wrap.querySelector('.topic-scroll');
    if (!scroller || rows.has(wrap)) return;

    const update = () => {
        const more = scroller.scrollWidth - scroller.clientWidth - scroller.scrollLeft > 1;
        wrap.classList.toggle('can-scroll-end', more);
    };
    scroller.addEventListener('scroll', update, { passive: true });
    const ro = new ResizeObserver(update);
    ro.observe(scroller);

    // keep the active chip in view on narrow screens
    const active = scroller.querySelector('.filter-pill.active');
    if (active && active !== scroller.firstElementChild) {
        const left = active.offsetLeft - scroller.offsetLeft;
        if (left + active.offsetWidth > scroller.clientWidth) scroller.scrollLeft = left - 16;
    }
    update();

    rows.set(wrap, () => {
        scroller.removeEventListener('scroll', update);
        ro.disconnect();
    });
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
            const focusables = Array.from(p.querySelectorAll('a[href], button'));
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
