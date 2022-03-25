var menuMobile = {
    init: function () {
        this.toggle();
        this.render();
        this.extendMenu();
    },
    plusSvg: '<span class="ext_menu"><svg width="19" height="17" viewBox="0 0 19 17" fill="none" xmlns="http://www.w3.org/2000/svg">' +
        '<path class="stick-1" d="M9.44727 3.83334V13.1667" stroke="#888888" stroke-width="1.3" stroke-linecap="round" stroke-linejoin="round"/>' +
        '<path class="stick-2" d="M4.39648 8.5H14.4981" stroke="#888888" stroke-width="1.3" stroke-linecap="round" stroke-linejoin="round"/>' +
        '</svg></span>',
    toggle: function () {
        $('.btn__menu').click(function (e) {
            e.preventDefault();
            menuMobile.active();
        })
    },
    active: function () {
        $('body').toggleClass('no-scroll');
        $('.header__middle, .btn__menu').toggleClass('active');
    },
    extendMenu: function(){
        $('.ext_menu').click(function(){
            $(this).toggleClass('active');


            var parent = $(this).parent();
            var ul = parent.find('>ul');
            ul.toggle('fadeOut');
        });
    },
    /* In ra dau cong cho cac phan tu cha */
    /* Menu chinh va menu ngon ngu */
    render: function(){
        $('.middle_menu li, .web_lang li').has('ul').append(this.plusSvg);
    }
}
menuMobile.init();