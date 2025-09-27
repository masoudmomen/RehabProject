
window.bootstrap = window.bootstrap || {};
window.bootstrap.Lightbox = {
    open: function () {
        var modal = new bootstrap.Modal(document.getElementById('lightboxModal'));
        modal.show();
    }
}

document.addEventListener("DOMContentLoaded", function () {
    // هندل کلیک روی لینک‌ها
    document.querySelectorAll("a").forEach(function (link) {
        link.addEventListener("click", function () {
            window.scrollTo({ top: 0, behavior: 'auto' });
        });
    });
});


// فوتر را در پایین صفحه ثابت می‌کند
function checkFooterPosition() {
    const footer = document.querySelector('.footer-bottom');
    const scrollY = window.scrollY;
    const triggerHeight = 200;

    if (scrollY >= triggerHeight) {
        footer.classList.add('fixed-footer');
    } else {
        footer.classList.remove('fixed-footer');
    }
}

document.addEventListener("scroll", checkFooterPosition);
window.addEventListener("load", checkFooterPosition);
