window.scrollToFaq = function (id) {
    const el = document.getElementById(id);

    if (!el) return;

    const yOffset = -80;
    const y = el.getBoundingClientRect().top + window.scrollY + yOffset;

    window.scrollTo({
        top: y,
        behavior: "smooth"
    });
};

document.addEventListener("DOMContentLoaded", function () {

    const sections = document.querySelectorAll(".faq-category");
    const links = document.querySelectorAll(".faq-nav-link");

    function setActive(id) {
        links.forEach(link => {
            link.classList.remove("faq-nav-link-active");

            if (link.getAttribute("onclick")?.includes(id)) {
                link.classList.add("faq-nav-link-active");
            }
        });
    }

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                setActive(entry.target.id);
            }
        });
    }, {
        root: null,
        rootMargin: "-45% 0px -45% 0px",
        threshold: 0.1
    });

    sections.forEach(sec => observer.observe(sec));
});