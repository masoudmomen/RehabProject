const dataSources = {
    centerName: ["Health Center", "Wellness Center", "Medical Center", "Fitness Center"],
    stateName: ["California", "Texas", "Florida", "New York", "Washington"],
    cityName: ["Los Angeles", "Houston", "Miami", "Seattle", "Austin"],
    condition: ["Good", "Fair", "Poor", "Excellent"],
    // More filters used in FacilityFilter
    amenities: ["Accommodations", "Housekeeping", "Fitness"],
    acceptedinsurance: ["Medicare", "Medicaid", "Private Insurance"],
    accreditations: ["JCAHO", "CARF", "NCQA"],
    hilightedPrograms: ["Physical Therapy", "Occupational Therapy", "Speech Therapy"],
    WhoWeTreat: ["Adults", "Children", "Seniors"],
    Treatments: ["Inpatient", "Outpatient", "Telehealth"],
    SubstanceWeTreat: ["Alcohol", "Opioids", "Tobacco"]
};

// Core implementation that can be reused for both single and multiple instances
function setupAutocompleteOnElements(container, input, list, data, options = { multi: false }) {
    let selectedItems = [];

    let tagsContainer;
    if (options.multi) {
        tagsContainer = container.querySelector('.selected-items');
        if (!tagsContainer) {
            tagsContainer = document.createElement('div');
            tagsContainer.classList.add('selected-items');
            container.appendChild(tagsContainer);
        }
    }

    input.addEventListener('input', function () {
        const value = this.value.toLowerCase();
        list.innerHTML = '';
        if (!value) return;

        const filtered = data.filter(item => item.toLowerCase().includes(value)
            && (!options.multi || !selectedItems.includes(item))
        );

        filtered.forEach(item => {
            const div = document.createElement('div');
            div.classList.add('autocomplete-item');
            div.textContent = item;
            div.onclick = () => {
                if (options.multi) {
                    if (!selectedItems.includes(item)) {
                        selectedItems.push(item);
                        addTag(item);
                    }
                    input.value = "";
                } else {
                    input.value = item;
                }
                list.innerHTML = '';
            };
            list.appendChild(div);
        });
    });
    function addTag(item) {
        const tag = document.createElement('div');
        tag.classList.add('tag-item');
        tag.textContent = item;

        const removeBtn = document.createElement('span');
        removeBtn.innerHTML = '<i class="fas fa-times closebtn"></i>';
        removeBtn.classList.add('remove-tag');
        removeBtn.onclick = () => {
            selectedItems = selectedItems.filter(i => i !== item);
            tag.remove();
        };

        tag.appendChild(removeBtn);
        tagsContainer.appendChild(tag);
    }
    document.addEventListener('click', function (e) {
        if (!e.target.closest('.autocomplete-container')) list.innerHTML = '';
    });
}

// Backwards-compatible helper used for the main search modal (IDs are unique there)
function setupAutocomplete(inputId, data, options = { multi: false }) {
    const rootInput = document.getElementById(inputId);
    if (!rootInput) return;

    const container = rootInput.closest('.autocomplete-container');
    if (!container) return;

    const input = container.querySelector('input');
    const list = container.querySelector('.autocomplete-list');
    if (!input || !list) return;

    setupAutocompleteOnElements(container, input, list, data, options);
}

// Initialize autocomplete for each FacilityFilter instance on the page
function initFacilityFilterAutocompletes() {
    const mappings = {
        amenities: 'amenities',
        acceptedinsurance: 'acceptedinsurance',
        accreditations: 'accreditations',
        hilights: 'hilightedPrograms',
        wwt: 'WhoWeTreat',
        Treatments: 'Treatments',
        swt: 'SubstanceWeTreat'
    };

    document.querySelectorAll('.facility-filter-container').forEach(container => {
        Object.entries(mappings).forEach(([fieldName, sourceKey]) => {
            const input = container.querySelector(`input[data-field="${fieldName}"]`);
            if (!input) return;

            const autocompleteContainer = input.closest('.autocomplete-container');
            if (!autocompleteContainer) return;

            const list = autocompleteContainer.querySelector('.autocomplete-list');
            if (!list) return;

            setupAutocompleteOnElements(
                autocompleteContainer,
                input,
                list,
                dataSources[sourceKey] || [],
                { multi: true }
            );
        });
    });
}
// Initialize all autocompletes after the page has fully loaded
window.addEventListener('load', function () {
    // Search modal autocompletes (IDs are unique, so this remains ID-based)
    setupAutocomplete('centerName', dataSources.centerName);
    setupAutocomplete('stateName', dataSources.stateName);
    setupAutocomplete('cityName', dataSources.cityName);
    setupAutocomplete('condition', dataSources.condition);

    // FacilityFilter autocompletes (support multiple instances per page)
    try {
        initFacilityFilterAutocompletes();
    } catch (e) {
        console && console.error && console.error('Error initializing FacilityFilter autocompletes', e);
    }
});
