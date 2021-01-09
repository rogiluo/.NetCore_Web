// Preloader
$(window).on('load', function () {
    if ($('#preloader').length) {
        $('#preloader').delay(300).fadeOut('slow', function () {
            $(this).remove();
        });
    }
});