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
    sr.reveal(".scroll-reveal", { duration: 500, distance: "20px" });

    $(".sidebar-nav .dropdown-menu li").mouseover(function () {
        var widthdiff = $(this).width() - $(this).parent().width();
        if( widthdiff > 0 ) {
            $("a", this).css({
                "-webkit-transform":"translate(-" + widthdiff + "px,0px)",
                "-ms-transform":"translate(-" + widthdiff + "px,0px)",
                "transform":"translate(-" + widthdiff + "px,0px)"
            })
        }
    });

    $(".sidebar-nav .dropdown-menu li").mouseout(function () {
        $("a", this).css({
            "-webkit-transform": "none",
            "-ms-transform": "none",
            "transform": "none"
        })
    });

    $(".data-table").DataTable();
    $('textarea#Html').froalaEditor({
        //paragraphStyles: {
        //    class1: 'Class 1',
        //    class2: 'Class 2'
        //},
        heightMin: 300,
        toolbarButtons: ['bold', 'italic', 'underline', 'strikeThrough', 'insertLink', 'insertTable', 'fontFamily', 'fontSize', '|', 'paragraphStyle', 'paragraphFormat', 'align', 'undo', 'redo', 'html']
    });
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