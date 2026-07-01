mergeInto(LibraryManager.library, {
    RedirectToUrl: function(url) {
        window.location.href = UTF8ToString(url);
    }
});