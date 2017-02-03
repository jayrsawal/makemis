$(document).ready(function () {
    var trigger = $('.hamburger'),
        overlay = $('.overlay'),
       isClosed = false;

    trigger.click(function () {
        hamburger_cross();
    });

    function hamburger_cross() {

        if (isClosed == true) {
            overlay.hide();
            trigger.removeClass('is-open');
            trigger.addClass('is-closed');
            isClosed = false;
        } else {
            overlay.show();
            trigger.removeClass('is-closed');
            trigger.addClass('is-open');
            isClosed = true;
        }
    }

    $('[data-toggle="offcanvas"]').click(function () {
        $('#wrapper').toggleClass('toggled');
    });

    $(document).keyup(function (e) {
        if (e.keyCode === 27) {
            if (isClosed) {
                hamburger_cross();
                $('#wrapper').toggleClass('toggled');
            }
        }
    });

    window.sr = ScrollReveal();
    sr.reveal(".scroll-reveal", { duration: 1000, distance: "100px" });
});

function snack(strMessage) {
    $("#snacks").after("<div id='snackbar'></div>");
    var $bar = $("#snackbar").last();
    $bar.html(strMessage);
    $bar.addClass("show");
    addSnackListener();

    setTimeout(function () {
        $bar.removeClass("show");
        setTimeout(function () {
            $bar.remove();
        }, 500);
    }, 3000);
}

function addSnackListener() {
    $("#snackbar").click(function () {
        $(this).remove();
    });
}