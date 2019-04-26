$(window).load(function() {

    "use strict";
    /* ==============================================
    PRELOADER
    =============================================== */
    var preloaderDelay = 500;
    var preloaderFadeOutTime = 800;
    var startPage = 0;

    function hidePreloader() {
        var loadingAnimation = $('#loading-animation');
        var preloader = $('#preloader');

        loadingAnimation.fadeOut();
        preloader.delay(preloaderDelay).fadeOut(preloaderFadeOutTime, function() {
            setTimeout(startPage, 1500);
         });
    }

    hidePreloader();

});

//jQuery to collapse the navbar on scroll
$(window).scroll(function() {
    if ($(".navbar").offset().top > 50) {
        $(".navbar-fixed-top").addClass("top-nav-collapse");
    } else {
        $(".navbar-fixed-top").removeClass("top-nav-collapse");
    }
});

$(document).ready(function(){
    $( ".btn-extras" ).click(function() {
        $(this).next().toggle("slow");
    });


    $('.equipe_home').slick({
        dots: false,
        arrows: false,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 5000,
        speed: 1000,
        fade: true,
        cssEase: 'linear'
    });


    $('a.page-scroll').bind('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});

