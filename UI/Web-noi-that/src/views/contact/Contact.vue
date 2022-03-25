<template>
<div>
    
    <section class="section contact__content container">
        <div class="row overflow-hidden">
            <div class="col-lg-6 col-12 contact__info__wrapper fadeInLeft wow">
                <div class="contact__info">
                    <div class="section__title text-uppercase">
                        Liên hệ với chúng tôi
                    </div>
                    <div class="contact__element contact__phone-numb d-flex align-items-center border-bottom border-gray">
                        <div class="_icon">
                            <img src="images/phone.svg" alt="" class="_img img-fluid">
                        </div>
                        <div class="_info">
                            <p class="_info-title fw-bold">Số điện thoại</p>
                            <div class="_info-numb text-grayv1">
                                <a href="tel:0210 626 5656">033 839 2897</a>
                            </div>
                        </div>
                    </div>
                    <div class="contact__element contact__address d-flex align-items-center border-bottom border-gray">
                        <div class="_icon">
                            <img src="images/map-pin.svg" alt="" class="_img img-fluid">
                        </div>
                        <div class="_info">
                            <p class="_info-title fw-bold ">Địa chỉ</p>
                            <ul class="_info-address mb-0 ps-3">
                                <li>Ngõ 43 Cổ nhuế, Bắc Từ Liêm, Hà Nội</li>
                                <li>234 Hoàng Quốc Việt, Nghĩa Tân, Cầu Giấy, Hà Nội</li>
                            </ul>
                        </div>
                    </div>
                    <div class="contact__element contact__email d-flex align-items-center border-bottom border-gray">
                        <div class="_icon">
                            <img src="images/mail.svg" alt="" class="_img img-fluid">
                        </div>
                        <div class="_info">
                            <p class="_info-title fw-bold ">Email</p>
                            <a class="_info-email" href="mailto:tasawood@tasaceramic.vn" title="">hien.van.nguyen0408@gmail.com</a>
                        </div>
                    </div>
                    <div class="contact__element contact__social mt-sm-0 mt-2">
                         <div class="news-detail__social">
                            <a href="https://www.facebook.com/hien.van.nguyen0408.mta17" class="_social fs-3 d-inline-block ">
                                <img src="../../assets/content/images/facebook.svg" alt="" class="_img img-fluid">
                            </a>
                            <a href="" class="_social fs-3 d-inline-block ">
                                <img src="../../assets/content/images/twitter.svg" alt="" class="_img img-fluid">
                            </a>
                            <a href="" class="_social fs-3 d-inline-block ">
                                <img src="../../assets/content/images/instagram.svg" alt="" class="_img img-fluid">
                            </a>
                            <a href="" class="_social fs-3 d-inline-block ">
                                <img src="../../assets/content/images/embed.svg" alt="" class="_img img-fluid">
                            </a>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-12 contact__form__wrapper fadeInRight wow">
                <div class="contact__form">
                    <div class="section__title">
                        Liên hệ nhanh
                    </div>
                    <form action="" method="get" accept-charset="utf-8" class="_form">
                        <Input v-model="contact.contactName" placeholder="Họ và tên" class="mb-sm-3 mb-2"/>
                        <Input v-model="contact.ContactPhone" placeholder="Số điện thoại" class="mb-sm-3 mb-2"/>
                        <Input v-model="contact.contactEmail" placeholder="Email" class="mb-sm-3 mb-2"/>
                        <Textarea v-model="contact.contactReminder" placeholder="Lời nhắc" class="mb-sm-3 mb-2"/>
                        <div class="_submit btn rounded-0 mt-lg-4 mt-md-3 mt-2" @click="saveContact">Gửi liên hệ</div>
                    </form>
                </div>
            </div>
        </div>
    </section>
    <section class="section contact__map">
        <iframe class='_map' src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7029.4384518880315!2d105.78494198003997!3d21.044073309680467!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135ab325c9d85ff%3A0x92f275da77aa7354!2zMjM0IEhvw6BuZyBRdeG7kWMgVmnhu4d0LCBD4buVIE5odeG6vywgVOG7qyBMacOqbSwgSMOgIE7hu5lpLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2sus!4v1630465021167!5m2!1svi!2sus" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
        
    </section>
</div>
</template>
<script>
import {
    mapActions
} from "vuex";
import {
    ModuleContact
} from "@/store/module-const";
import Input from '@/views/components/input/Input';
import Textarea from "@/views/components/textarea/Textarea";
export default {
    components: {
        Input,
        Textarea
    },
    created() {
    },
    data() {
        return {
            contact : {}
        };
    },
    methods: {
        ...mapActions(ModuleContact, [
            "addContactAsync",
        ]),
         async saveContact(){
            const me = this;
            // Thêm
            await me.addContactAsync(me.contact);
            // reset 
            me.contact = {};
        },
    },
};
</script>

<style scoped>

</style>
