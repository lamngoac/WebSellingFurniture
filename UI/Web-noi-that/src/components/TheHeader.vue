<template>

    <div id="#header" class="h-header">
    <div id="ytWidget"></div>
    <script type="application/javascript" defer src="https://translate.yandex.net/website-widget/v1/widget.js?widgetId=ytWidget&pageLang=vi&widgetTheme=light&autoMode=false"></script> 
        <div class="header__top">
            <div class="container">
                <div class="row" style="height:40px">
                    <div class="col-lg-2 col-5 d-flex pt-2">
                         <a href="" class="d-block smooth logo_desktop pt-2">
                        <img src="../assets/content/images/logo2.png" alt="" height="200px" width="200px">
                        </a>
                    </div>
                    <div class="col-lg-8 col-6 align-self-center pt-1">
                        <div class="text-log-res">
                            <ul class="h-display-flex" v-if="!userName">
                                <li class="text-login"><router-link to="/login" title="">{{ i18n.Login }}</router-link></li>
                                <li class="text-register"><router-link to="/register" title="">{{ i18n.Register }}</router-link></li>
                            </ul>
                            <ul class="h-display-flex" v-if="userName">
                                <li class="text-login">Xin chào!   <span style="font-weight:bold;margin-left:20px">{{ userName }}</span></li>
                                <li class="text-logout"><div @click="logOut" title="">{{ i18n.Logout }}</div></li>
                                <li class="text-logout"><div @click="history" title="">{{ i18n.HistoryOrder }}</div></li>
                            </ul>
                            <div class="h-cart">
                                <div @click="viewCart" title="" class="cart__icon h-icon-cart" data-count="12">
                                    <img src="../assets/content/images/cart.svg" :alt="i18n.Cart">
                                </div>
                                <div v-if="getOrders && getOrders.length > 0" class="cart__current amount-order-cart">{{ getOrders.length }}</div>
                            </div>
                        </div>
                        <!-- <form action="" method="" class="form_search">
                            <input type="" name="" class="" :placeholder="i18n.Search">
                            <button type="submit"><img src="../assets/content/images/search.svg" :alt="i18n.Search"></button>
                        </form> -->
                    </div>
                    
                    <div class="col-lg-2 col-1 align-self-center d-lg-flex justify-content-end align-items-center pt-1">
                    </div>
                </div>
            </div>
        </div>
        <div class="header__middle">
            <div class="container">
                <div class="middle_menu menu__mobile">
                    <ul class="font-bold">
                        <li><router-link to="/" title="">{{ i18n.Home }}</router-link></li>
                        <li><router-link to="/about" title="">{{ i18n.Introduce }}</router-link></li>
                        <li><router-link to="/category">{{ i18n.Furniture}}</router-link></li>
                        <li><router-link to="/project" title="">{{ i18n.Project }}</router-link></li>
                        <li><router-link to="/news" title="">{{ i18n.News }}</router-link></li>
                        <li><router-link to="/recruiment" title="">{{ i18n.Recruitment }}</router-link></li>
                        <li><router-link to="/contact" title="">{{ i18n.Contact }}</router-link></li>
                    </ul>
                </div>
            </div>
            <div class="web_lang menu__mobile d-lg-none">
                <ul>
                    <li><a href="">Ngôn ngữ</a>
                        <ul>
                            <li><a href="">Ngôn ngữ</a></li>
                            <li><a href="">Ngôn ngữ</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>

</div>
</template>

<script>
import dataFake from '@/enum/header/dataFake';
import {
    mapActions, mapGetters
} from 'vuex';
import {ModuleUser} from '@/store/module-const';
export default {
    data(){
        return{
            menus : dataFake.menus,
            routers : dataFake.routers,
            respone : {},
            i18n : {...this.$t('i18nHeader')},
            userName :"",
        }
    },
    async created(){
        const me = this;
        let name = localStorage.getItem("userName");
        if(name){
            me.userName = name;
            await me.getOrdersForUser(name);
        }
        
    },
    computed:{
        ...mapGetters(["getOrders"]),
    },
    methods: {
        ...mapActions(ModuleUser, ["getUserByUserName"]),
        ...mapActions(["getCartByUser"]),
        async getOrdersForUser(userName) {
            const me = this;
            let res = await me.getCartByUser(userName);
            if (res) {
                me.orders = [...res];
            }
        },

        logOut(){
            const me = this;
            localStorage.removeItem("userName");
            me.$router.push("/login");
        },
        // xem giỏ hàng
        viewCart(){
            const me = this;
            if(me.userName){
                me.$router.push("/cart");
            }
            else{
                me.$router.push("/login");
            }
        },
        history(){
            const me = this;
            me.$router.push("/history-order");
        },
    },
}
</script>

<style  scoped>
.h-header{
    position: sticky;
    top: 0px;
    background: #e2f0e9;
    z-index: 10000;
}
.text-log-res{
    position: fixed;
    right: 10px;
    top: 5px;
}
.text-login{
    padding-right:10px;
    border-right: 1px solid #fff;
}
.text-register{
    margin-left:10px;
}
.h-cart{
    display: flex;
    justify-content: flex-end;
}
.h-cart:hover{
    font-size: 120%;
}
.h-icon-cart{
    cursor: pointer;
}
.text-logout{
    margin-left: 10px;
    cursor: pointer;
}
.text-logout:hover{
    color: orange;
}
.amount-order-cart{
    color: #fff;
    background: green;
    height: 100%;
}
/deep/#yt-widget .yt-servicelink {
  visibility: hidden !important;
}
</style>
