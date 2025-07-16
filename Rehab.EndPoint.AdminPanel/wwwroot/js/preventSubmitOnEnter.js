window.preventSubmitOnEnter = function (element) {
    if (!element) return;
    element.addEventListener('keydown', function (e) {
        if (e.key === 'Enter') {
            e.preventDefault();
        }
    });
};