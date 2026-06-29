window.registerModalResetHandler = (modalId, dotNetRef) => {
    const modalEl = document.getElementById(modalId);
    if (!modalEl) return;

    modalEl.addEventListener('show.bs.modal', () => {
        dotNetRef.invokeMethodAsync('ResetForm');
    });
};