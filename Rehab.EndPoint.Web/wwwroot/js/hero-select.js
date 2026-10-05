// Homepage hero search dropdowns (State / City / Condition): browser-side bits Blazor can't do on its own.
// Loaded as an ES module from HeroSection.razor; UI only.

const active = new WeakMap();

export function open(root, input, dotnet, key) {
    close(root);

    // click/tap anywhere outside the field closes the panel
    const onPointerDown = e => {
        if (!root.contains(e.target)) dotnet.invokeMethodAsync('CloseDropdownFromOutside', key);
    };
    // the search box sits inside the <form>: Enter must pick an option, not submit; arrows must not move the caret
    const onKeyDown = e => {
        if (e.key === 'Enter' || e.key === 'ArrowDown' || e.key === 'ArrowUp') e.preventDefault();
    };

    document.addEventListener('pointerdown', onPointerDown, true);
    input.addEventListener('keydown', onKeyDown);
    active.set(root, () => {
        document.removeEventListener('pointerdown', onPointerDown, true);
        input.removeEventListener('keydown', onKeyDown);
    });

    input.focus({ preventScroll: true });
}

export function close(root) {
    const off = root && active.get(root);
    if (off) {
        off();
        active.delete(root);
    }
}

// scroll only the list (scrollIntoView would also scroll the page)
export function scrollActive(root) {
    const list = root && root.querySelector('.hero-select-list');
    const item = list && list.querySelector('.hero-select-option.is-active');
    if (!item) return;
    const top = item.offsetTop, bottom = top + item.offsetHeight;
    if (top < list.scrollTop) list.scrollTop = top - 8;
    else if (bottom > list.scrollTop + list.clientHeight) list.scrollTop = bottom - list.clientHeight + 8;
}
