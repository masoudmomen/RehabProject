const dataSources = {
    centerName: ["Health Center", "Wellness Center", "Medical Center", "Fitness Center"],
    stateName: ["California", "Texas", "Florida", "New York", "Washington"],
    cityName: ["Los Angeles", "Houston", "Miami", "Seattle", "Austin"],
    condition: ["Good", "Fair", "Poor", "Excellent"],
    //More filters
    amenities: ["Accommodations", "Housekeeping", "Fitness"],
    acceptedinsurance: ["Medicare", "Medicaid", "Private Insurance"],
    accreditations: ["JCAHO", "CARF", "NCQA"],
    hilightedPrograms: ["Physical Therapy", "Occupational Therapy", "Speech Therapy"],
    WhoWeTreat: ["Adults", "Children", "Seniors"],
    Treatments: ["Inpatient", "Outpatient", "Telehealth"],
    SubstanceWeTreat: ["Alcohol", "Opioids", "Tobacco"]
}

function setupAutocomplete(inputId, data, options = { multi: false }) {
    const container = document.getElementById(inputId).closest('.autocomplete-container');
    const input = container.querySelector('input');
    const list = container.querySelector('.autocomplete-list');

    let selectedItems = [];

    let tagsContainer;
    if (options.multi) {
        tagsContainer = container.querySelector('.selected-items');
        if (!tagsContainer) {
            tagsContainer = document.createElement('div');
            tagsContainer.classList.add('.selected-items');
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
setupAutocomplete('centerName', dataSources.centerName);
setupAutocomplete('stateName', dataSources.stateName);
setupAutocomplete('cityName', dataSources.cityName);
setupAutocomplete('condition', dataSources.condition);
setupAutocomplete('amenities', dataSources.amenities, { multi: true });
setupAutocomplete('acceptedinsurance', dataSources.acceptedinsurance, { multi: true });
setupAutocomplete('accreditations', dataSources.accreditations, { multi: true });
setupAutocomplete('hilights', dataSources.hilightedPrograms, { multi: true });
setupAutocomplete('wwt', dataSources.WhoWeTreat, { multi: true });
setupAutocomplete('Treatments', dataSources.Treatments, { multi: true });
setupAutocomplete('swt', dataSources.SubstanceWeTreat, { multi: true });
