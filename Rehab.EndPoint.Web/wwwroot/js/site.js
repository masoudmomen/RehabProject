
window.bootstrap = window.bootstrap || {};
window.bootstrap.Lightbox = {
    open: function () {
        var modal = new bootstrap.Modal(document.getElementById('lightboxModal'));
        modal.show();
    }
}
//Scroll To Top
//document.addEventListener("DOMContentLoaded", function () {

//    document.querySelectorAll("a").forEach(function (link) {
//        link.addEventListener("click", function () {
//            window.scrollTo({ top: 0, behavior: 'auto' });
//        });
//    });
//});

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

    // "Find Treatment By" trigger: a <button> that opens/closes its mega menu on click,
    // Enter or Space (desktop also shows it on hover via CSS), keeping aria-expanded in sync.
    // Escape closes it, and so does tabbing out of it.
    // Delegated so it keeps working after Blazor re-renders.
    function setMegaMenuOpen(navItem, open) {
        navItem.classList.toggle('mobile-mega-open', open);
        const trigger = navItem.querySelector('.treatment-by-link');
        if (trigger) {
            trigger.setAttribute('aria-expanded', open ? 'true' : 'false');
        }
    }

    document.addEventListener('click', function (e) {
        const trigger = e.target.closest('.treatment-by-link');
        const navItem = trigger && trigger.closest('#treatment-by-nav-item');
        if (!navItem) {
            return;
        }

        setMegaMenuOpen(navItem, !navItem.classList.contains('mobile-mega-open'));
    });

    document.addEventListener('keydown', function (e) {
        if (e.key !== 'Escape') {
            return;
        }

        const navItem = document.querySelector('#treatment-by-nav-item.mobile-mega-open');
        if (!navItem) {
            return;
        }

        const hadFocus = navItem.contains(document.activeElement);
        setMegaMenuOpen(navItem, false);
        if (hadFocus) {
            navItem.querySelector('.treatment-by-link').focus();
        }
    });

    document.addEventListener('focusout', function (e) {
        const navItem = e.target.closest && e.target.closest('#treatment-by-nav-item.mobile-mega-open');
        // relatedTarget is null for clicks on non-focusable content; outside clicks are handled below.
        if (!navItem || !e.relatedTarget || navItem.contains(e.relatedTarget)) {
            return;
        }

        setMegaMenuOpen(navItem, false);
    });

    // Center the clicked "Find Treatment By" tab title in its scrollable strip (mobile only).
    // Delegated so it keeps working after Blazor re-renders; scrolls only the strip, not the page.
    document.addEventListener('click', function (e) {
        if (window.innerWidth > 991.98) {
            return;
        }

        const tab = e.target.closest('#treatmentTabs .nav-link');
        if (!tab) {
            return;
        }

        const strip = tab.closest('#treatmentTabs');
        const stripRect = strip.getBoundingClientRect();
        const tabRect = tab.getBoundingClientRect();
        const offset = (tabRect.left + tabRect.width / 2) - (stripRect.left + stripRect.width / 2);

        strip.scrollTo({ left: strip.scrollLeft + offset, behavior: 'smooth' });
    });

    // Close open mega menus when clicking outside
    document.addEventListener('click', function (e) {
        // If click is inside any mega nav item, do nothing
        const closestMegaItem = e.target.closest('.nav-item-mega');
        if (closestMegaItem) {
            return;
        }

        // Otherwise, close all mega nav items
        document.querySelectorAll('.nav-item-mega.mobile-mega-open')
            .forEach(function (item) {
                setMegaMenuOpen(item, false);
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


window.setCheckboxState = (elementId, state) => {
    const el = document.getElementById(elementId);
    if (el) {
        el.checked = state;
    }
};
window.UnCheckAllCheckbox = () => {
    document.querySelectorAll('input').forEach(i => {
        i.checked = false;
    });
};


window.infiniteScroll = {
    initialize: function (elementId, dotnetHelper) {

        const observer = new IntersectionObserver(entries => {
            if (entries[0].isIntersecting) {
                dotnetHelper.invokeMethodAsync("LoadMore");
            }
        });

        const element = document.getElementById(elementId);

        if (element) {
            observer.observe(element);
        }
    }
};
//scroll to top button
const scrollBtn = document.getElementById("scrollToTopBtn");

scrollBtn.addEventListener("click", function () {
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
});

// Show button only after scrolling
window.addEventListener("scroll", function () {
    if (window.scrollY > 200) {
        scrollBtn.style.display = "flex";
    } else {
        scrollBtn.style.display = "none";
    }
});

// Hide initially
scrollBtn.style.display = "none";

//Handle Sidebar on Mobile
function handleMobile() {
    const toggle = document.getElementById('sidebarToggle');
    if (window.innerWidth <= 768) {
        toggle.checked = true;
    }
}

window.addEventListener('load', handleMobile);
window.addEventListener('resize', handleMobile);



//window.scrollToElement = (id) => {
//    const el = document.getElementById(id);
//    if (el) {
//        el.scrollIntoView({ behavior: "smooth" });
//    }
//};
function scrollToElement(elementId) {
    const el = document.getElementById(elementId);
    if (el) {
        el.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }
}