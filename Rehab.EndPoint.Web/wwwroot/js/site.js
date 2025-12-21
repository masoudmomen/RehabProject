
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



window.ToggleListOfCategoriesJs = function (id) {
    alert(id);

    AddDnoneToAllCategoriesList(id);
    const tagClasses = document.getElementById(id).classList;
    if (tagClasses.contains("d-none")) {
        tagClasses.remove("d-none");
    }
    else {
        tagClasses.add("d-none");
    }

}

function AddDnoneToAllCategoriesList(id) {
    for (var i = 1; i < 8; i++) {
        if (i == id) continue; 
        if (!document.getElementById(i).classList.contains("d-none")) document.getElementById(i).classList.add("d-none");
    }
}

window.ToggleSelectItemsJs = function (id) {
    const elementClasses = document.getElementById(id).classList;
    if (elementClasses.contains("selected")) {
        elementClasses.remove("selected")
    } else {
        elementClasses.add("selected");
    }
}
