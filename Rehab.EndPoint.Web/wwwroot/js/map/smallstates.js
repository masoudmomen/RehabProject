const smallStates = document.querySelectorAll('.state-shape');
const items = document.querySelectorAll('#state-list li');

items.forEach(item => { 
    item.addEventListener('mouseover', () => {  
        const stateId = item.dataset.state;
        document.getElementById(stateId).classList.add('hovered');
        item.classList.add('hovered');
    });
    item.addEventListener('mouseout', () => {
        const stateId = item.dataset.state;
        document.getElementById(stateId).classList.remove('hovered');
        item.classList.remove('hovered');
    });
});
smallStates.forEach(state => {
    state.addEventListener('mouseover', () => {
        const item = document.querySelector(`#state-list li[data-state="${state.id}"]`);
        item.classList.add('hovered');
        state.classList.add('hovered');
    });
    state.addEventListener('mouseout', () => {
        const stateId = state.id;
        const item = document.querySelector(`#state-list li[data-state='${stateId}']`);
        item.classList.remove('hovered');
        state.classList.remove('hovered');
    });
});