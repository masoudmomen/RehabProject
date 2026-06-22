
window.addEventListener('DOMContentLoaded', () => {
    console.log("START FAQ");
    const faqToggle = document.getElementById('faqToggle');
    const faqContent = document.getElementById('faqContent');
    if (faqToggle && faqContent) {
        console.log("FINDDDD");
        faqToggle.addEventListener('click', () => {
            const isOpen = faqToggle.getAttribute('aria-expanded') === 'true';
            faqToggle.setAttribute('aria-expanded', String(!isOpen));
            faqContent.classList.toggle('collapsed', isOpen);

        });
    } else {
        console.log("FAQ NOT FOUND");
    }
   
    if (faqToggle && faqContent) {
        faqToggle.setAttribute('aria-expanded', 'false');
        faqContent.classList.add('collapsed');
    }
});
 