const states = [
    "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut",
    "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa",
    "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan",
    "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire",
    "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio",
    "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota",
    "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia",
    "Wisconsin", "Wyoming"
];

function initializeAlphabetFilter() {
    const alphabetDiv = document.getElementById('alphabet-filter');
    const statesListDiv = document.getElementById('states-list');

    // Check if elements exist
    if (!alphabetDiv || !statesListDiv) {
        return;
    }

    // Clear existing content to prevent duplicates
    alphabetDiv.innerHTML = '';
    statesListDiv.innerHTML = '';

    const availableLetters = [...new Set(states.map(s => s[0].toUpperCase()))].sort();

    availableLetters.forEach(letter => {
        const btn = document.createElement('button');
        btn.textContent = letter;
        btn.classList.add('btn_alphabet');
        btn.onclick = () => showStates(letter, btn);
        alphabetDiv.appendChild(btn);
    });
}

function showStates(letter, btn) {
    const statesListDiv = document.getElementById('states-list');
    if (!statesListDiv) return;

    document.querySelectorAll('.btn_alphabet').forEach(b => b.classList.remove('active'));
    btn.classList.add('active');
    const filtered = states.filter(s => s.startsWith(letter));
    statesListDiv.innerHTML = filtered
        .map(s => {
            const url = s.toLowerCase().replace(/\s+/g, '-');
            return `<div><a target="_blank" class="state-link" href="/states/${url}"> 
            <i class="fa-solid fa-location-dot"></i> ${s} </a>
            </div>`;
        })
        .join('');
}

// Track if observer is already set up to prevent duplicates
let observerSetup = false;
let initializationTimeout = null;

function setupMutationObserver() {
    if (observerSetup) return;
    observerSetup = true;

    // Use MutationObserver to watch for when elements appear in DOM
    const observer = new MutationObserver(function(mutations, obs) {
        const alphabetDiv = document.getElementById('alphabet-filter');
        const statesListDiv = document.getElementById('states-list');
        
        if (alphabetDiv && statesListDiv) {
            // Debounce initialization to avoid multiple rapid calls
            if (initializationTimeout) {
                clearTimeout(initializationTimeout);
            }
            initializationTimeout = setTimeout(function() {
                // Check if buttons already exist to avoid unnecessary re-initialization
                const existingButtons = alphabetDiv.querySelectorAll('.btn_alphabet');
                if (existingButtons.length === 0) {
                    initializeAlphabetFilter();
                }
            }, 50);
        }
    });

    // Start observing the document body for changes
    observer.observe(document.body, {
        childList: true,
        subtree: true
    });
}

// Initialize on DOM ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', function() {
        initializeAlphabetFilter();
        setupMutationObserver();
    });
} else {
    // DOM is already ready
    initializeAlphabetFilter();
    setupMutationObserver();
}

// Re-initialize on page show (handles back/forward navigation)
window.addEventListener('pageshow', function(event) {
    // Always try to initialize, not just for persisted pages
    // Blazor SSR might re-render even if not persisted
    setTimeout(function() {
        initializeAlphabetFilter();
    }, 100);
});

// Also listen for popstate (back/forward button)
window.addEventListener('popstate', function() {
    setTimeout(function() {
        initializeAlphabetFilter();
    }, 100);
});

// Expose function globally for manual initialization if needed
window.initializeAlphabetFilter = initializeAlphabetFilter;