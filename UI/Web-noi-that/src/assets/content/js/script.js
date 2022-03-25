var PROGRAM = (function() {
    var slideHome = function(){
        var slide = new Swiper(".section_slide .swiper-container",{
            slidesPerView: 1,
            loop: true,
            draggable: true,
            pagination: {
                el: ".section_slide .swiper-pagination",
                clickable: true,
            }
        });
    }
    var slideLike = function(){
        var slide = new Swiper(".slide_like",{
            slidesPerView: 5,
            autoHeight:false,
            loop: true,
            draggable: true,
            spaceBetween:15,
            autoplay: {
                delay: 3000,
                disableOnInteraction:false,
                pauseOnMouseEnter:true,
            },
              navigation:{
              nextEl: ".section_category_like .next",
              prevEl: ".section_category_like .prev"
            },
            breakpoints: {
                    0: {
                        slidesPerView: 1.5,
                        spaceBetween: 5,
                        freeMode:true,
                    },
                    575: {
                        slidesPerView: 1.5,
                        spaceBetween: 10
                    },
                    768: {
                        slidesPerView: 3,
                        spaceBetween: 10
                    },
                    991: {
                        slidesPerView: 4,
                        spaceBetween: 15
                    },
                    1200: {
                        slidesPerView: 5,
                        spaceBetween: 15
                    }
            },
        });
    }
    var salePrdSlider = function () {
        var swiper = new Swiper(".sale-prd__slider > .swiper-container", {
            navigation: {
                nextEl: ".--sale-prd.swiper-button-next",
                prevEl: ".--sale-prd.swiper-button-prev",
            },
            slidesPerView: 1,
            breakpoints: {
                992: {
                    slidesPerView: 4,
                    spaceBetween: 32
                },
                768: {
                    slidesPerView: 3,
                    spaceBetween: 25
                },
                400: {
                    slidesPerView: 2,
                    spaceBetween: 20
                }
            }
        });
    }
    var watchedPrdSlider = function () {
        var swiper = new Swiper(".watched-prd__slider > .swiper-container", {
            navigation: {
                nextEl: ".--watched-prd.swiper-button-next",
                prevEl: ".--watched-prd.swiper-button-prev",
            },
            slidesPerView: 1,
            breakpoints: {
                992: {
                    slidesPerView: 4,
                    spaceBetween: 32
                },
                768: {
                    slidesPerView: 3,
                    spaceBetween: 25
                },
                400: {
                    slidesPerView: 2,
                    spaceBetween: 20
                }
            }
        });
    }
     var slideProduct = function(){
        var slideProductThumb = new Swiper(".slide_product_thumb .swiper-container",{
            speed: 500,
            direction: 'vertical',
            grabCursor: true,
            autoHeight:true,
            spaceBetween: 10,
            autoplay: false,
            // autoplay: {
            //     delay: 3000,
            //     disableOnInteraction:false,
            //     pauseOnMouseEnter:true,
            // },
            slidesPerView: 3,
        });
        var slideProduct = new Swiper(".slide_product .swiper-container",{
            // autoplay: true,
            speed: 500,
            // autoplay: {
            //     delay: 3000,
            //     disableOnInteraction:false,
            //     pauseOnMouseEnter:true,
            // },
            slidesPerView: 1,
            grabCursor: true,
             thumbs:{
                swiper: slideProductThumb
            },
            on:{
                slideNextTransitionEnd:function(event){
                    // slideProductThumb.slideNext();
                },
                slidePrevTransitionEnd:function(event){
                    // slideProductThumb.slidePrev();
                }
            }
        });
    }
     var slideProject = function(){
        var slideProjectOne = new Swiper(".slide-projec-one", {
            spaceBetween: 16,
            slidesPerView: 4,
            freeMode: true,
            watchSlidesVisibility: true,
            watchSlidesProgress: true,
          });
          var slideProjectTwo = new Swiper(".slide-projec-two", {
            spaceBetween: 0,
            navigation: {
              nextEl: ".swiper-button-next",
              prevEl: ".swiper-button-prev",
            },
            thumbs: {
              swiper: slideProjectOne,
            },
          });
    }
    var initAnimation = function(){
        var wow = new WOW();
        wow.init();
    }
    return {
        _: function() {
            slideHome();
            slideLike();
            salePrdSlider();
            watchedPrdSlider();
            slideProduct();
            slideProject();
            initAnimation();
        }
    };
    })();
window.onload = function()
{
    PROGRAM._();
};