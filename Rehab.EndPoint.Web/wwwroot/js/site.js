
window.bootstrap = window.bootstrap || {};
window.bootstrap.Lightbox = {
    open: function () {
        var modal = new bootstrap.Modal(document.getElementById('lightboxModal'));
        modal.show();
    }
}

document.addEventListener("DOMContentLoaded", function () {

    document.querySelectorAll("a").forEach(function (link) {
        link.addEventListener("click", function () {
            window.scrollTo({ top: 0, behavior: 'auto' });
        });
    });


    // Handle mobile mega menu toggle for Recovery Centers
    const recoveryCentersLink = document.querySelector('.recovery-centers-link');
    const recoveryCentersNavItem = document.querySelector('#recovery-centers-nav-item');
    
    if (recoveryCentersLink && recoveryCentersNavItem) {
        recoveryCentersLink.addEventListener('click', function(e) {
            // Only prevent default and toggle on mobile (screen width <= 991.98px)
            if (window.innerWidth <= 991.98) {
                e.preventDefault();
                e.stopPropagation();
                recoveryCentersNavItem.classList.toggle('mobile-mega-open');
            }
        });
    }

    // Handle mobile mega menu toggle for Treatment By
    const treatmentByLink = document.querySelector('.treatment-by-link');
    const treatmentByNavItem = document.querySelector('#treatment-by-nav-item');
    
    if (treatmentByLink && treatmentByNavItem) {
        treatmentByLink.addEventListener('click', function(e) {
            // Only prevent default and toggle on mobile (screen width <= 991.98px)
            if (window.innerWidth <= 991.98) {
                e.preventDefault();
                e.stopPropagation();
                treatmentByNavItem.classList.toggle('mobile-mega-open');
            }
        });
    }

    // Close open mega menus when clicking outside (mobile only)
    document.addEventListener('click', function (e) {
        if (window.innerWidth > 991.98) {
            return; // desktop: use hover, don't interfere
        }

        // If click is inside any mega nav item, do nothing
        const closestMegaItem = e.target.closest('.nav-item-mega');
        if (closestMegaItem) {
            return;
        }

        // Otherwise, remove mobile-mega-open from all mega nav items
        document.querySelectorAll('.nav-item-mega.mobile-mega-open')
            .forEach(function (item) {
                item.classList.remove('mobile-mega-open');
            });
    });
});



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



