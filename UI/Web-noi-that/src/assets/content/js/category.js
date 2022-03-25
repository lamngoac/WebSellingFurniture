var category = {
    init: function () {
        this.category_filter.init();
        this.category_desc.init();
    },
    category_filter: {
        init: function () {
            this.toggle();
        },
        toggle: function () {
            $('.filter__funnel').click((e) => {
                e.preventDefault();
                this.active();
            });
        },
        active: function () {
            $('.category__filter').toggleClass('active');
            $('body').toggleClass('no-scroll');
        }
    },
    category_desc: {
        init: function () {
            this.toggle();
        },
        showMore: 'Xem thêm',
        hiding: 'Rút gọn',
        isActive: function () {
            if ($('.page_category-desc').hasClass('active')) {
                return true;
            } else {
                return false;
            }
        },
        toggle: function () {
            $('.page_category-desc ._desc-direct').click((e) => {
                e.preventDefault();
                $('.page_category-desc').toggleClass('active');

                // Lấy chiều cao hiện tại của page_catogory
                let categoryHeight = $('.page_category-desc').outerHeight();

                // lấy vị trị hiện tại theo trục y của page_cateogory
                let category_y_pos = $('.page_category-desc').offset().top - categoryHeight/2;

                // Cuộn ngược về vị trí ban đầu của category
                if (!this.isActive()) {
                    window.scrollTo(0, category_y_pos);
                }

                let direct = $('.page_category-desc ._desc-direct__text');
                if (this.isActive()) {
                    direct.text(this.hiding);
                } else {
                    direct.text(this.showMore);
                }

            });
        }
    }
}

category.init();