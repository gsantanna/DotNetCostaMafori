$(document).ready(function () {
    /*----------------------------
    START - Smooth scroll animation
    ------------------------------ */
    $('.video-down-link').on('click', function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '')
		&& location.hostname == this.hostname) {
            var $target = $(this.hash);
            $target = $target.length && $target
            || $('[name=' + this.hash.slice(1) + ']');
            if ($target.length) {
                var targetOffset = $target.offset().top;
                $('html,body')
                .animate({ scrollTop: targetOffset }, 2000);
                return false;
            }
        }
    });

    /*----------------------------
    START - Video effect
    ------------------------------ */
    $('.video-back').parent().click(function () {
        if ($(this).children(".video-back").get(0).paused) {
            $(this).children(".video-back").get(0).play();
            $(this).children(".playpause").fadeOut();
        } else {
            $(this).children(".video-back").get(0).pause();
            $(this).children(".playpause").fadeIn();
        }
    });

    $(".dropdown").click(function () {
        $(this).find('.drop-menuu').first().toggle();
    });



    $('.dropdown').hover(function () {
        if ((window.innerWidth) < 760) return;
        $(this).find('.drop-menuu').first().stop(true, true).delay(100).slideDown();
    }, function () {
        if ((window.innerWidth) < 760) return;
        $(this).find('.drop-menuu').first().stop(true, true).delay(100).slideUp()
    });






    /*----------------------------
    START - WOW JS animation
    ------------------------------ */
    new WOW().init();
});