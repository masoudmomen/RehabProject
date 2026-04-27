window.tinyMceInterop = (function () {
    let loadPromise = null;

    function loadScript() {
        if (window.tinymce) {
            return Promise.resolve();
        }

        if (loadPromise) {
            return loadPromise;
        }

        loadPromise = new Promise((resolve, reject) => {
            const script = document.createElement('script');
            script.src = '/lib/tinymce/js/tinymce/tinymce.min.js';
            script.onload = () => resolve();
            script.onerror = () => reject('TinyMCE load failed');
            document.head.appendChild(script);
        });

        return loadPromise;
    }

    async function init(elementId, initialContent = '') {
        await loadScript();

        const existing = tinymce.get(elementId);
        if (existing) {
            existing.remove();
        }

        const element = document.getElementById(elementId);
        if (!element) return;

        tinymce.init({
            license_key: 'gpl',
            selector: '#' + elementId,
            height: 400,
            menubar: false,
            plugins: 'link lists code',
            toolbar: 'undo redo | bold italic | alignleft aligncenter alignright | bullist numlist | link | code',

            paste_data_images: false,

            setup: function (editor) {
                editor.on('init', function () {
                    editor.setContent(initialContent || '');
                });
            }
        });
    }

    function getContent(elementId) {
        const editor = tinymce.get(elementId);
        return editor ? editor.getContent() : '';
    }

    function setContent(elementId, content) {
        const editor = tinymce.get(elementId);
        if (editor) {
            editor.setContent(content || '');
        }
    }

    function destroy(elementId) {
        const editor = tinymce.get(elementId);
        if (editor) {
            editor.remove();
        }
    }

    return {
        init,
        getContent,
        setContent,
        destroy
    };
})();