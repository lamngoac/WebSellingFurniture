<template>
<div>
    <div class="section_slide has_pagi">
        <div class="swiper-container slide_home">
            <div class="swiper-wrapper">
                <swiper loop :autoplay= 5000 :pagination-clickable="true" :tab-mode-animation="true"> 
                    <div class="swiper-slide">
                        <div class="box_slide text-center">
                            <p class="slide_title wow fadeInLeft">{{ $t('i18nHome.FeaturedContent')}}</p>
                            <div :title="$t('i18nHome.BuyNow' )" class="slide_now d-inline-block smooth btn_all wow fadeInUp" @click="buyNow">{{ $t('i18nHome.BuyNow' )}}</div>
                        </div>
                        <img src="../../assets/content/images/sl1.jpg" class="img-fluid">
                    </div>
                      <div class="swiper-slide" >
                        <div class="box_slide text-center">
                            <p class="slide_title wow fadeInLeft">{{ $t('i18nHome.FeaturedContent')}}</p>
                            <div :title="$t('i18nHome.BuyNow' )" class="slide_now d-inline-block smooth btn_all wow fadeInUp" @click="buyNow">{{ $t('i18nHome.BuyNow' )}}</div>
                        </div>
                        <img src="../../assets/content/images/sl1.jpg" class="img-fluid">
                    </div>
                </swiper>
            </div>
        </div>
        <div class="swiper-pagination"></div>
    </div>
    <div class="section_category__hot section_all">
        <div class="title_all">
            <p class="title_lg wow fadeInUp">{{ $t('i18nHome.Category')}}</p>
        </div>
        <div class="container">
            <div class="row overflow-hidden">
                <div class="col-4 pt-2" v-for="(data,index) in productCategoriesHome" :key="index">
                    <div class="h-categories" @click="viewCategory(data.productCategoryId)">
                        <div class="item_category wow fadeInLeft" >
                            <div title="" class="d-block img">
                                <img :src="require('@/assets/content/images/'+ data.productCategoryImage)" alt="" class="img-fluid">
                            </div>
                            <div class="box_content">
                                <div class="center">
                                    <a class="d-block name" title="">{{data.productCategoryName}}</a>
                                    <div class="d-block short">{{data.productCategoryDescription}}</div>
                                </div>
                                <div class="d-block view_more" title="">
                                    Mua sắm ngay bây giờ
                                    <img src="../../assets/content/images/arrow-right.svg" alt="Xem thêm" class="ms-2">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               
            </div>
        </div>
    </div>
    <div class="section_sale section_all">
        <div class="container">
            <div class="row overflow-hidden">
                <div class="col-lg-6 col-12 mb-lg-0 mb-3">
                    <a href="" title="" class="d-block banner_sale wow fadeInLeft">
                        <img src="../../assets/content/images/sale1.png" alt="" class="img-fluid">
                    </a>
                </div>
                <div class="col-lg-6 col-12 mb-lg-0 mb-3">
                    <a href="" title="" class="d-block banner_sale wow fadeInRight">
                        <img src="../../assets/content/images/sale2.png" alt="" class="img-fluid">
                    </a>
                </div>
            </div>
        </div>
    </div>
   
    <div class="section_all section_project">
        <div class="title_all">
            <span class="d-block title_sm wow fadeInUp">HIGHLIGHTS PROJECTS</span>
            <p class="title_lg wow fadeInUp">DỰ ÁN NỔI BẬT</p>
        </div>
        <div class="container">
            <div class="row">
                <div  v-for="(data,index) in projectsHome" :key="index" class="col-md-6 col-12 mb-lg-4 mb-3" >
                    <div class="item_project wow pulse" :data-wow-delay="`${index*0.1}`+'s'" data-wow-duration="2.5s" @click="viewProject(data.projectId)">
                        <div class="img">
                            <img :src="require('@/assets/content/images/'+data.linkImage)" alt="" class="img-fluid">
                            <div class="box_content">
                                <div class="short">
                                    {{ data.projectContent }}
                                </div>
                            </div>
                            <router-link to="/product-detail" title="" class="d-inline-block smooth btn_all">XEM CHI TIẾT</router-link>
                        </div>
                        <a href="" title="" class="d-block smooth name">{{data.projectTitle}}</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="section_news section_all">
        <div class="title_all">
            <span class="d-block title_sm wow fadeInUp">TRENDING NEWS</span>
            <p class="title_lg wow fadeInUp">TIN TỨC NÓNG</p>
        </div>
        <div class="container">
            <div class="row">
                <div v-for="(data,index) in newsHome" :key="index" class="col-lg-4 col-md-6 col-12 wow fadeInUp" :data-wow-delay="`${index*0.2}`+'s'" data-wow-duration="1.5s">
                    <div class="news__item" @click="viewNews(data.newsId)">
                        <div class="news__item__img mb-lg-3 mb-sm-2 mb-2 d-block" href="" title="">
                            <img :src="require('@/assets/content/images/' + data.linkImage)" alt="" class="img-fluid">
                        </div>
                        <div class="news__item__author mb-lg-3 mb-sm-2 mb-2">
                            <span class="_posted-by">
                                <img src="../../assets/content/images/profile.svg" alt="" class="_img img-fluid svg-icon">
                                Admin
                            </span>
                            <span class="_date ms-lg-3 ms-md-2 ms-1">
                                <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon">
                                {{ data.createdData }}
                            </span>
                        </div>
                        <div href="" class="news__item__title  d-block mb-lg-3 mb-sm-2 mb-2">{{ data.newsTitle }}</div>
                        <div class="news__item__content">
                            {{ data.newsContent }}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import {
    mapActions
} from 'vuex';
import {ModuleProductCategory} from '@/store/module-const';
import { ModuleProject } from "@/store/module-const";
import { ModuleNews } from "@/store/module-const";
import dataFake from '@/enum/home/dataFake';
export default {
    components: {},
    async created(){
        const me = this;
        me.getData();
    },
    data() {
        return {
            textProduct : dataFake.textProduct,
            textFavorites: dataFake.textFavorites,
            url : dataFake.url,
            urlImgCollection : [
                ""
            ],
            indexShow : 0,
            users : [],
            productCategoriesHome : [],
            projectsHome : [],
            newsHome : [],
        }
    },

    methods:{
        ...mapActions(ModuleProductCategory,['getProductCategoriesHome']),
        ...mapActions(ModuleProject,['getProjectsHome']),
        ...mapActions(ModuleNews,['getNewsHome']),
        async getData(){
            const me = this;
            me.productCategoriesHome = await me.getProductCategoriesHome();
            me.projectsHome = await me.getProjectsHome();
            me.newsHome = await me.getNewsHome();
        },

        /**
         * Click button lùi (bên trái)
         * danh mục yêu thích
         */
        clickPrevImageFavorites(){
            let me = this;
            me.$refs.swiperFavorites.prev();
        },
        /**
         * Click button dịch ảnh kế tiếp (bên phải)
         * trong danh danh mục yêu thích
         */
        clickNextImageFavorites(){
            let me = this;
            me.$refs.swiperFavorites.next();
        },

        viewCategory(id){
            const me = this;
            me.$router.push(`/category/${id}`);
        },
        
        viewProject(id){
            const me = this;
            me.$router.push(`/project-detail/${id}`);
        },
        viewNews(id){
            const me = this;
            me.$router.push(`/new-detail/${id}`);
        },
        buyNow(){
            const me = this;
            me.$router.push(`/category`);
        }
    }
}
</script>

<style scoped>

</style>
