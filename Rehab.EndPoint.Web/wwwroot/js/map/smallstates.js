// Keep track of which elements we've already wired up to avoid duplicate handlers
const initializedItems = new WeakSet();
const initializedStates = new WeakSet();

let mapObserverSetup = false;
let mapInitializationTimeout = null;

function initializeSmallStatesMap() {
    const smallStates = document.querySelectorAll('.state-shape');
    const items = document.querySelectorAll('#state-list li');

    // If required elements are not present, do nothing
    if (!smallStates.length || !items.length) {
        return;
    }

    items.forEach(item => {
        if (initializedItems.has(item)) return;
        initializedItems.add(item);

        item.addEventListener('mouseover', () => {
            const stateId = item.dataset.state;
            const stateEl = document.getElementById(stateId);
            if (!stateEl) return;

            stateEl.classList.add('hovered');
            item.classList.add('hovered');
        });

        item.addEventListener('mouseout', () => {
            const stateId = item.dataset.state;
            const stateEl = document.getElementById(stateId);
            if (!stateEl) return;

            stateEl.classList.remove('hovered');
            item.classList.remove('hovered');
        });
    });

    smallStates.forEach(state => {
        if (initializedStates.has(state)) return;
        initializedStates.add(state);

        state.addEventListener('mouseover', () => {
            const item = document.querySelector(`#state-list li[data-state="${state.id}"]`);
            if (!item) return;

            item.classList.add('hovered');
            state.classList.add('hovered');
        });

        state.addEventListener('mouseout', () => {
            const stateId = state.id;
            const item = document.querySelector(`#state-list li[data-state='${stateId}']`);
            if (!item) return;

            item.classList.remove('hovered');
            state.classList.remove('hovered');
        });
    });
}

function setupMapMutationObserver() {
    if (mapObserverSetup) return;
    mapObserverSetup = true;

    const observer = new MutationObserver(() => {
        const smallStates = document.querySelectorAll('.state-shape');
        const items = document.querySelectorAll('#state-list li');

        if (!smallStates.length || !items.length) {
            return;
        }

        if (mapInitializationTimeout) {
            clearTimeout(mapInitializationTimeout);
        }

        mapInitializationTimeout = setTimeout(() => {
            initializeSmallStatesMap();
        }, 50);
    });

    observer.observe(document.body, {
        childList: true,
        subtree: true
    });
}

// Initialize when DOM is ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', () => {
        initializeSmallStatesMap();
        setupMapMutationObserver();
    });
} else {
    initializeSmallStatesMap();
    setupMapMutationObserver();
}

// Handle browser back/forward navigation (including bfcache restores)
window.addEventListener('pageshow', function () {
    setTimeout(() => {
        initializeSmallStatesMap();
        setupMapMutationObserver();
    }, 50);
});

// Extra safety: run again on history navigation events
window.addEventListener('popstate', function () {
    setTimeout(() => {
        initializeSmallStatesMap();
        setupMapMutationObserver();
    }, 50);
});

// Expose for manual calls if ever needed from Blazor
window.initializeSmallStatesMap = initializeSmallStatesMap;