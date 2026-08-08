 
(function () {
    function initFaqSection() {
        const faqToggle = document.getElementById('faqToggle');
        const faqPanel = document.getElementById('faqPanel');

        if (faqToggle && faqPanel && !faqToggle.dataset.faqBound) {
            faqToggle.dataset.faqBound = 'true';
            faqToggle.addEventListener('click', () => {
                const isOpen = faqToggle.getAttribute('aria-expanded') === 'true';
                faqToggle.setAttribute('aria-expanded', String(!isOpen));
                faqPanel.classList.toggle('is-open', !isOpen);
            });
        }

        const filterButtons = document.querySelectorAll('.faq-nav button');
        const faqItems = document.querySelectorAll('.faq-item');
        const faqGroups = document.querySelectorAll('.faq-group');

        function filterFAQ(category) {
            faqItems.forEach(item => {
                const show = category === 'all' || item.dataset.category === category;
                item.style.display = show ? '' : 'none';
                if (!show) item.removeAttribute('open');
            });
            faqGroups.forEach(group => {
                const visible = group.querySelectorAll('.faq-item:not([style*="display: none"])').length;
                group.style.display = visible ? '' : 'none';
            });
        }

        filterButtons.forEach(btn => {
            if (btn.dataset.faqBound) return;
            btn.dataset.faqBound = 'true';
            btn.addEventListener('click', () => {
                filterButtons.forEach(b => b.classList.remove('active'));
                btn.classList.add('active');
                filterFAQ(btn.dataset.filter);
            });
        });
    }

    document.addEventListener('DOMContentLoaded', initFaqSection);
    // پشتیبانی از Blazor enhanced navigation (Blazor Web App / SSR)
    document.addEventListener('enhancedload', initFaqSection);
    // اگر اسکریپت بعد از DOMContentLoaded لود شد (مثلاً از طریق کامپوننت)
    if (document.readyState === 'interactive' || document.readyState === 'complete') {
        initFaqSection();
    }
})();
