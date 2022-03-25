<template>
<div id="app">
    <Page/>
    <!-- <div class="h-language" style="margin-top:100px;margin-left:200px">
        <a-select
            show-search
            option-filter-prop="children"
            style="width: 200px"
            :filter-option="filterOption"
            @focus="handleFocus"
            @blur="handleBlur"
            @change="handleChange"
            :defaultValue="lang"
        >
            <a-select-option value="vi">
                Tiếng việt
            </a-select-option>
            <a-select-option value="en">
                Tiếng anh
            </a-select-option>
            <a-select-option value="ru">
                Tiếng nga
            </a-select-option>
        </a-select>
    </div>
    <div style="margin-top:50px;margin-left:100px;display:flex">
        <div style="width:300px">
            <Textarea placeholder="Nhập văn bản" :height="300" v-model="text" @input="changeHand"> 
            </Textarea>
        </div>
        <div style="margin-left : 200px;width:300px;">
           <Textarea placeholder="Bản dịch" v-model="textTran" :height="300">
            </Textarea>
        </div>
    </div> -->

</div>
</template>

<script>
// import {
//     mapActions
// } from "vuex";
// import {
//     ModuleUser
// } from "@/store/module-const";
// import Textarea from "@/views/components/textarea/Textarea";
import Page from '@/pages/Page'
export default {
    components: {
        Page
        // Textarea
    },
    data() {
        return {
            text: "",
            textTran: "",
            lang: "vi",

            users: [],
        };
    },
    async created(){},
    methods: {

        async handleChange(value) {
            const me = this;
            me.lang = value;
            let res = await me.translateLanguage({
                language: me.lang,
                text: me.text,
            });
            if (res && res.text) {
                me.textTran = res.text[0];
            }
        },
        handleBlur() {
        },
        handleFocus() {
        },
        filterOption(input, option) {
            return (
                option.componentOptions.children[0].text
                .toLowerCase()
                .indexOf(input.toLowerCase()) >= 0
            );
        },
        readFileAsString() {
        },
        async changeHand() {
            const me = this;
            let res = await me.translateLanguage({
                language: me.lang,
                text: me.text,
            });
            if (res && res.text) {
                me.textTran = res.text[0];
            }
        },
    },
};
</script>

<style>
@import "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css";
@import "./assets/content/css/common.css";
@import "./assets/content/css/animate.css";
@import "./assets/content/css/bootstrap.css";
@import "./assets/content/css/reset.css";
@import "./assets/content/css/font-awesome.css";
@import "./assets/content/css/toastr.min.css";
@import "./assets/content/css/swiper.min.css";
@import "./assets/content/scss/login_register.css";
@import "./assets/content/scss/admin.css";
@import "./assets/content/scss/style.css";
@import "./assets/content/scss/news.css";
@import "./assets/content/scss/news_detail.css";
@import "./assets/content/scss/recruiment.css";
@import "./assets/content/scss/category.css";
@import "./assets/content/scss/pro.css";
@import "./assets/content/scss/contact.css";
@import "./assets/content/scss/cart.css";
@import "./assets/content/scss/cart_pay.css";
@import "./assets/content/scss/mobile.css";
@import "./assets/content/scss/menu-mobile.css";
@import "./assets/content/css/common/icon.css";
@import "./assets/content/css/common/button.css";
</style>
