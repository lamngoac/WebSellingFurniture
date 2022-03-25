<template>
<section class="news">
     <div class="section__title text-center text-uppercase wow fadeInUp">Tin tức</div>
    <div class="container">
        <a-tabs default-active-key="1" @change="callback">
            <a-tab-pane key="1" tab="Tin sản phẩm">
                <div class="row news__list gy-sm-3 gy-2">
                    <div class="col-12 col-sm-6 col-lg-4 wow fadeInUp" v-for="(data,index) in newsproduct" :key="index">
                        <div class="news__item" @click="viewNews(data.newsId)">
                            <a class="news__item__img mb-lg-3 mb-sm-2 mb-1 d-block" title="">
                                <img :src="require('@/assets/content/images/' + data.linkImage)" class="_img img-fluid" />
                            </a>
                            <div class="news__item__author mb-lg-3 mb-sm-2 mb-1">
                                <span class="_posted-by">
                                    <img src="../../assets/content/images/profile.svg" alt="" class="_img img-fluid svg-icon">
                                    Admin
                                </span>
                                <span class="_date ms-lg-3 ms-md-2 ms-1">
                                    <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon">
                                    {{ data.createdDate | moment("DD/MM/YYYY")}}
                                </span>
                            </div>
                            <a class="news__item__title  d-block mb-lg-3 mb-sm-2 mb-1">
                                {{ data.newsTitle }}
                            </a>
                            <div class="news__item__content">
                                {{ data.newsContent }}
                            </div>
                        </div>
                    </div>
                </div>
            </a-tab-pane>
            <a-tab-pane key="2" tab="Tin khuyến mãi" force-render>
                  <div class="row news__list gy-sm-3 gy-2">
                    <div class="col-12 col-sm-6 col-lg-4 wow fadeInUp" v-for="(data,index) in newssale" :key="index">
                        <div class="news__item" @click="viewNews(data.newsId)">
                            <a class="news__item__img mb-lg-3 mb-sm-2 mb-1 d-block" title="">
                                <img :src="require('@/assets/content/images/' + data.linkImage)" class="_img img-fluid" />
                            </a>
                            <div class="news__item__author mb-lg-3 mb-sm-2 mb-1">
                                <span class="_posted-by">
                                    <img src="../../assets/content/images/profile.svg" alt="" class="_img img-fluid svg-icon">
                                    Admin
                                </span>
                                <span class="_date ms-lg-3 ms-md-2 ms-1">
                                    <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon">
                                    {{ data.createdDate | moment("DD/MM/YYYY")}}
                                </span>
                            </div>
                            <a class="news__item__title  d-block mb-lg-3 mb-sm-2 mb-1">
                                {{ data.newsTitle }}
                            </a>
                            <div class="news__item__content">
                                {{ data.newsContent }}
                            </div>
                        </div>
                    </div>
                </div>
            </a-tab-pane>
            <a-tab-pane key="3" tab="Tin sự kiện">
                  <div class="row news__list gy-sm-3 gy-2">
                    <div class="col-12 col-sm-6 col-lg-4 wow fadeInUp" v-for="(data,index) in newsevent" :key="index">
                        <div class="news__item" @click="viewNews(data.newsId)">
                            <a class="news__item__img mb-lg-3 mb-sm-2 mb-1 d-block" title="">
                                <img :src="require('@/assets/content/images/' + data.linkImage)" class="_img img-fluid" />
                            </a>
                            <div class="news__item__author mb-lg-3 mb-sm-2 mb-1">
                                <span class="_posted-by">
                                    <img src="../../assets/content/images/profile.svg" alt="" class="_img img-fluid svg-icon">
                                    Admin
                                </span>
                                <span class="_date ms-lg-3 ms-md-2 ms-1">
                                    <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon">
                                    {{ data.createdDate | moment("DD/MM/YYYY")}}
                                </span>
                            </div>
                            <a class="news__item__title  d-block mb-lg-3 mb-sm-2 mb-1">
                                {{ data.newsTitle }}
                            </a>
                            <div class="news__item__content">
                                {{ data.newsContent }}
                            </div>
                        </div>
                    </div>
                </div>
            </a-tab-pane>
        </a-tabs>
    </div>
</section>
</template>

<script>
import {
    mapActions
} from 'vuex';
import {
    ModuleNews
} from '@/store/module-const';
export default {
    created() {
        const me = this;
        me.getData();
    },
    data() {
        return {
            newsproduct: [],
            newssale: [],
            newsevent: [],
        }
    },
    methods: {
        ...mapActions(ModuleNews, ['getNewsProduct', 'getNewsSale', 'getNewsEvent']),
        async getData() {
            const me = this;
            let resproduct = await me.getNewsProduct();
            if (resproduct) {
                me.newsproduct = [...resproduct];
            }
            let ressale = await me.getNewsSale();
            if (ressale) {
                me.newssale = [...ressale];
            }
            let resevent = await me.getNewsEvent();
            if (resevent) {
                me.newsevent = [...resevent];
            }
        },
        callback(key) {
            console.log(key);
        },
        viewNews(id) {
            const me = this;
            me.$router.push(`/new-detail/${id}`);
        },
    }
}
</script>

<style scoped>

</style>
