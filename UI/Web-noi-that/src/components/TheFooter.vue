<template>
<div>
    <div class="section_all section_benefits">
        <div class="container">
            <div class="row overflow-hidden">
                <div class="col-lg-3 mb-lg-0 mb-4">
                    <div class="item_benefit mb-lg-4 mb-3">
                        <div class="box_content text-end">
                            <p class="title wow fadeInLeft">MẪU MÃ ĐA DẠNG</p>
                            <div class="short wow fadeInLeft">
                                Cung cấp đa dạng loại sản phẩm được ưa chuộng trên thị trường
                            </div>
                        </div>
                        <div class="img wow bounceIn">
                            <img src="../assets/content/images/icon1.png" alt="" class="img-fluid" />
                        </div>
                    </div>
                    <div class="item_benefit">
                        <div class="box_content text-end">
                            <p class="title wow fadeInLeft">GIÁ TRỊ VÀ NIỀM TIN</p>
                            <div class="short wow fadeInLeft">
                                Cung cấp đa dạng loại sản phẩm được ưa chuộng trên thị trường
                            </div>
                        </div>
                        <div class="img wow bounceIn">
                            <img src="../assets/content/images/icon2.png" alt="" class="img-fluid" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 mb-lg-0 mb-4">
                    <div @click="buyNow" title="" class="img d-block wow fadeInUp">
                        <img src="../assets/content/images/banner_.jpg" alt="" class="img-fluid" />
                    </div>
                </div>
                <div class="col-lg-3 mb-lg-0 mb-4">
                    <div class="item_benefit flex-row-reverse mb-lg-4 mb-3">
                        <div class="box_content text-left">
                            <p class="title wow fadeInRight">HỖ TRỢ 24/7</p>
                            <div class="short wow fadeInRight">
                                Cung cấp đa dạng loại sản phẩm được ưa chuộng trên thị trường
                            </div>
                        </div>
                        <div class="img wow bounceIn">
                            <img src="../assets/content/images/icon3.png" alt="" class="img-fluid" />
                        </div>
                    </div>
                    <div class="item_benefit flex-row-reverse">
                        <div class="box_content text-left">
                            <p class="title wow fadeInRight">MIỄN PHÍ VẬN CHUYỂN</p>
                            <div class="short wow fadeInRight">
                                Cung cấp đa dạng loại sản phẩm được ưa chuộng trên thị trường
                            </div>
                        </div>
                        <div class="img wow bounceIn">
                            <img src="../assets/content/images/icon4.png" alt="" class="img-fluid" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <div class="container h-mg-t100 h-footer-contact">
            <i @click="scrollToTop" class="fa fa-chevron-circle-up icon-arrow-top-page" aria-hidden="true"></i>
            <div class="row">
                <div class="col-lg-4 h-width-3/10 h-mg-l3%">
                    <a href="" class="d-block smooth logo_desktop">
                        <img src="../assets/content/images/logo2.png" alt="" class="img-fluid" />
                    </a>

                    <div class="social text-center">
                        <a href="https://www.facebook.com/hien.van.nguyen0408.mta17" title="Facebook" class="smooth" target="_blank">
                            <i class="fa fa-facebook-square" aria-hidden="true"></i>
                        </a>
                        <a href="" title="twitter" class="smooth" target="_blank">
                            <i class="fa fa-twitter" aria-hidden="true"></i>
                        </a>
                        <a href="" title="skype" class="smooth" target="_blank">
                            <i class="fa fa-skype" aria-hidden="true"></i>
                        </a>
                    </div>
                    <p class="copy_right text-center">
                        © 2021 GEM
                    </p>
                </div>
                <div class="col h-width-3/10 h-mg-l3%">
                    <div class="des_form mb-3 h-mg-t30">
                        Quý khách có thể cung cấp các ý kiến phản hồi về GEM Theo
                        mẫu bên dưới
                    </div>
                    <form action="" method="POST" accept-charset="utf-8" class="frm_sub">
                        <input type="" name="" class="" placeholder="Nhập email" />
                        <button type="submit">
                            <img src="../assets/content/images/plain.svg" alt="Gửi đi" />
                        </button>
                    </form>
                </div>
                <div class="col h-width-3/10 h-mg-l3%">
                    <div class="box_content">
                        <p class="name">ĐỊA CHỈ</p>
                        <div class="description">
                            234 Hoàng Quốc Việt, Nghĩa Tân, Bắc Từ Liêm , Hà Nội
                        </div>
                    </div>
                    <div class="box_content">
                        <p class="name">LIÊN HỆ TƯ VẤN</p>
                        <div class="description">
                            <div class="s-content">
                                <p>(+84)338 392 897</p>
                                <p>039 7413 566 (Zalo/Whatsapp/Line: Mr Hiến)</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
export default {
    methods: {
        scrollToTop() {
            window.scrollTo(0, 0);
        },
        buyNow() {
            const me = this;
            me.$router.push(`/category`);
        }
    },
};
</script>

<style scoped>
.h-footer-contact {
    position: relative;
    max-width: none !important;
    margin-bottom: 20px;
}

.icon-arrow-top-page {
    position: absolute;
    bottom: 0px;
    right: 10px;
    font-size: 50px;
    color: green;
}

.icon-arrow-top-page:hover {
    font-size: 60px;
}
</style>
