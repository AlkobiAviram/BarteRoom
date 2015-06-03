$(document).ready(function () {
    
    $(window).scroll(function (event) {
        var topY = $(this).scrollTop();

        if (topY < 5) {

            $('#img-scroll').addClass('animatePhone');
           // $('#Square2').addClass('animate');

        }
    })

    /* $("#Square").click(function () {
        //$(this).hide();
        $('#Square').addClass('animate');
        $('#Square2').addClass('animate');
    });*/
});