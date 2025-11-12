const states = [
    "Alabama", "alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut",
    "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa",
    "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan",
    "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire",
    "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio",
    "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota",
    "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia",
    "Wisconsin", "Wyoming"
];

const alphabetDiv = document.getElementById('alphabet-filter');
const statesListDiv = document.getElementById('states-list');

 
const availableLetters = [...new Set(states.map(s => s[0].toUpperCase()))].sort();
 
availableLetters.forEach(letter => {
    const btn = document.createElement('button');
    btn.textContent = letter;
    btn.classList.add('btn_alphabet');
    btn.onclick = () => showStates(letter, btn);
    alphabetDiv.appendChild(btn);
});
 
function showStates(letter, btn) {
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