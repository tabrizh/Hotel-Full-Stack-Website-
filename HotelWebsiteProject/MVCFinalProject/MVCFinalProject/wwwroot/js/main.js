/* -------------------------------------------

Name: 		Kinsley
Version:  1.0
Author:		Nazar Miller (millerDigitalDesign)
Portfolio:  https://themeforest.net/user/millerdigitaldesign/portfolio?ref=MillerDigitalDesign

p.s. I am available for Freelance hire (UI design, web development). mail: miller.themes@gmail.com

------------------------------------------- */

window.addEventListener("load",()=>{
  $(function () {
    $.each(function () {
      $(this).load(file, function () {
        $("body").imagesLoaded().progress(onProgress);
      });
    });
  });

  function onProgress(imgLoad, image) {
    var $item = $(image.img).parents(".imgLoad");
    $item.addClass("loaded");
  }
});


$(".container").on("DOMNodeInserted", ".imgLoad", function () {
  const observer = lozad();
  observer.observe();
});

window.addEventListener("scroll",function(){
  if(this.pageYOffset>60){
      document.querySelector(".hotel-top-bar").classList.add("sticky");
  }else{
      document.querySelector(".hotel-top-bar").classList.remove("sticky");
  }
});

$(function() {

  "use strict";

  /***************************

  preloader

  ***************************/
  $(document).ready(function() {
    $(".hotel-preloader").animate({
      opacity: 1
    }, {
      duration: 400,
    });
    setTimeout(function() {
      $('.hotel-preloader-number').each(function() {
        var $this = $(this),
          countTo = $this.attr('data-count');
        $({
          countNum: $this.text()
        }).animate({
          countNum: countTo
        }, {
          duration: 800,
          easing: 'swing',
          step: function() {
            $this.text(Math.floor(this.countNum));
          },
        });
      });
      $(".hotel-preloader-bar").animate({
        width: '100%'
      }, {
        duration: 800,
        complete: function() {
          $(".hotel-preloader-frame").addClass('hotel-hidden')
        }
      });
    }, 1000);
  });
  /***************************

  popup

  ***************************/
  $('#book-popup , #book-popup-2').on("click", function() {
    $('.hotel-popup-frame').toggleClass('hotel-active')
  });
  $('.hotel-close-popup').on("click", function() {
    $('.hotel-popup-frame').removeClass('hotel-active')
  });

  $('#book-popup , #book-popup-2').on("click", function() {
    $('.hotel-popup-frame').toggleClass('hotel-active')
  });
  $('.hotel-close-popup').on("click", function() {
    $('.hotel-popup-frame').removeClass('hotel-active')
  });
  /***************************

  scrollspy and smooth scroll

  ***************************/
  $('.hotel-side-menu a , .knsk-s-s').on("click", function() {
    $(".hotel-active").removeClass("hotel-active");
    $(this).closest('li a').addClass("hotel-active");
    var theClass = $(this).attr("class");
    $('.' + theClass).parent('li a').addClass('hotel-active');
    $('html, body').stop().animate({
      scrollTop: $($(this).attr('href')).offset().top - 170
    }, 600);
    return false;
  });
  /***************************

  parallax

  ***************************/
  $(window).on('scroll', parallax)

  function parallax() {
    var s = $(window).scrollTop();

    function parallaxDown(e, t) {
      $(e).css({
        'position': 'relative',
        'top': (s * t) + 'px'
      });
    }
    parallaxDown('.hotel-parallax', .4);
  }
  /***************************

  menu

  ***************************/
  $('.hotel-menu-btn').on('click', function() {
    $('.hotel-menu-btn , .hotel-right-side').toggleClass('hotel-active');
  })
  $('.hotel-menu ul li a').on('click', function() {
    $('.hotel-menu-btn , .hotel-right-side').removeClass('hotel-active');
  })
  /***************************

  nice select

  ***************************/
  $(document).ready(function() {
    $('select').niceSelect();
  });
  /***************************

  datepicker

  ***************************/
  $('.datepicker-here').datepicker({
    language: 'en',
    minDate: new Date()
  })
  /***************************

  about slider

  ***************************/
  // var swiper = new Splide( '.hotel-about-slider', {
  //   perPage: 3,
  //   breakpoints: {
  //     '640': {
  //       perPage: 2,
  //       gap    : '1rem',
  //     },
  //     '480': {
  //       perPage: 1,
  //       gap    : '1rem',
  //     },
  //   }
  // } ).mount();

  var swiper = new Swiper('.hotel-about-slider', {
    slidesPerView: 2,
    spaceBetween: 20,
    parallax: true,
    calculateHeight: true,
    updateOnWindowResize: true,
    initialSlide: 1,
    centeredSlides: true,
    speed: 800,
    pagination: {
      el: '.hotel-about-slider-1-pagination',
      type: "fraction",
    },
    navigation: {
      prevEl: '.hotel-about-slider-1-prev',
      nextEl: '.hotel-about-slider-1-next',
    },
    breakpoints: {
      1600: {
        slidesPerView: 2,
      },
      768: {
        slidesPerView: 1,
      },
    },
  });
  

	
  /***************************

  testimonials slider

  ***************************/
  var swiper = new Swiper('.hotel-testimonials-slider', {
    slidesPerView: 1,
    spaceBetween: 20,
    parallax: true,
    calculateHeight: true,
    updateOnWindowResize: true,
    initialSlide: 1,
    centeredSlides: true,
    speed: 800,
    pagination: {
      el: '.hotel-testimonials-slider-1-pagination',
      type: "fraction",
    },
    navigation: {
      prevEl: '.hotel-testimonials-slider-1-prev',
      nextEl: '.hotel-testimonials-slider-1-next',
    },
  });
  /***************************

  rooms slider

  ***************************/
  var swiper = new Swiper('.hotel-uni-slider', {
    slidesPerView: 3,
    spaceBetween: 20,
    parallax: true,
    calculateHeight: true,
    updateOnWindowResize: true,
    speed: 800,
    pagination: {
      el: '.hotel-uni-slider-pagination',
      type: "fraction",
    },
    navigation: {
      prevEl: '.hotel-uni-slider-prev',
      nextEl: '.hotel-uni-slider-next',
    },
    breakpoints: {
      1200: {
        slidesPerView: 2,
      },
      768: {
        slidesPerView: 1,
      },
    },
  });
  /***************************

  room details

  ***************************/
  var swiper1 = new Swiper(".hotel-rd-slider-1", {
    loop: true,
    spaceBetween: 10,
    slidesPerView: 4,
    freeMode: true,
    watchSlidesVisibility: true,
    watchSlidesProgress: true,
  });
  var swiper2 = new Swiper(".hotel-rd-slider-2", {
    loop: true,
    effect: 'fade',
    parallax: true,
    thumbs: {
      swiper: swiper1,
    },
  });
  /***************************

  fancybox

  ***************************/
  $('[data-fancybox]').fancybox({
    animationEffect: "zoom-in-out",
    animationDuration: 200,
    transitionDuration: 800,
    buttons: [
      "zoom",
      "slideShow",
      "thumbs",
      "close",
    ],
  });
  /***************************

  scroll animation

  ***************************/
  $(window).scroll(function() {
    $('.hotel-scroll-animation').each(function(i) {
      var bottom_of_object = $(this).offset().top - 380 + $(this).outerHeight();
      var bottom_of_window = $(window).scrollTop() + $(window).height();
      if (bottom_of_window > bottom_of_object) {
        $(this).addClass('hotel-active-el');
      }
      if (bottom_of_window < bottom_of_object) {
        $(this).removeClass('hotel-active-el');
      }
    });
  });
  /***************************

  counters

  ***************************/
  var count = 0;
  if ($('.hotel-counters-card').length) {
    $(window).scroll(function() {
      var oTop = $('.hotel-counters-card').offset().top - window.innerHeight;
      if (count == 0 && $(window).scrollTop() > oTop) {
        $('.hotel-counter-number').each(function() {
          var $this = $(this),
            countTo = $this.attr('data-count');
          $({
            countNum: $this.text()
          }).animate({
            countNum: countTo
          }, {
            duration: 3000,
            easing: 'swing',
            step: function() {
              $this.text(Math.floor(this.countNum) + '+');
            },
            complete: function() {
              $this.text((this.countNum) + '+');
            }
          });
        });
        count = 1;
      }
    });
  }
  /***************************

  sticky

  ***************************/
  var sticky = new Sticky('.hotel-sticky');
  if ($(window).width() < 992) {
    sticky.destroy();
  }
  /***************************

  map

  ***************************/
  $(".hotel-lock").on('click', function() {
    $('.hotel-map').toggleClass('hotel-active');
    $('.hotel-lock').toggleClass('hotel-active');
    $('.hotel-lock .fas').toggleClass('fa-unlock');
  });
  if ($("div").is("#map")) {
    mapboxgl.accessToken = 'pk.eyJ1Ijoic3Rvc2NhciIsImEiOiJja2VpbDE4b2UwbDg3MnNwY2d3YzlvcDV5In0.e26tLedpKwxrkOmPkWhQlg';
    var map = new mapboxgl.Map({
      container: 'map',
      style: 'mapbox://styles/stoscar/ckr3l0wj625iz17mhhfrwf7oo',
      center: [-70.00133907824335, 18.49315226156898],
      zoom: 9
    });
    var marker = new mapboxgl.Marker()
      .setLngLat([-70.00133907824335, 18.49315226156898])
      .addTo(map);
  }
  /***************************

  isotope

  ***************************/
  $('.hotel-filter a').on('click', function() {
    $('.hotel-filter .hotel-current').removeClass('hotel-current');
    $(this).addClass('hotel-current');

    var selector = $(this).data('filter');
    $('.hotel-masonry-grid').isotope({
      filter: selector
    });
    return false;
  });
  $(document).ready(function() {
    $('.hotel-masonry-grid').isotope({
      filter: '*',
      itemSelector: '.hotel-masonry-grid-item',
      percentPosition: true,
      masonry: {
        columnWidth: '.hotel-grid-sizer'
      }
    });
  });
});
