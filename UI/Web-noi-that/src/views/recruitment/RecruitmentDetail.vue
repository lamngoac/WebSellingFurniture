<template>
<div>
    <section class="section news-detail container">
        <div class="row">
            <div class="col-lg-9 col-12" v-if="recruitment">
                <div class="news-detail__content border-bottom pb-lg-4 pb-md-3 pb-2">
                    <h1 class="section__title text-uppercase wow fadeInUp">
                        {{ recruitment.recruitmentTitle }}
                    </h1>
                    <div class="news__item__author wow fadeInUp">
                        <span class="_posted-by d-inline-block">
                            <img src="../../assets/content/images/profile.svg" alt="" class="_img img-fluid svg-icon" />
                            Admin
                        </span>
                        <span class="_date ms-lg-3 ms-md-2 ms-1">
                            <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon" />
                            {{ recruitment.createdDate | moment("DD/MM/YYYY") }}
                        </span>
                    </div>
                    <div class="news-detail__post wow fadeInUp s-content">

                        <img v-if="recruitment.linkImage" :src="require('@/assets/content/images/'+ recruitment.linkImage) " class="img-fluid">
                        <p class="mb-lg-3 mb-2">
                            {{ recruitment.recruitmentContent }}
                        </p>

                    </div>
                    <div class="
                _sharing
                d-flex
                align-items-center
                justify-content-end
                mb-lg-4 mb-sm-3 mb-2
                wow
                fadeInUp
              ">
                        <span class="_title d-inline-block me-lg-4 me-sm-3 me-2">Chia sẻ</span>
                        <div class="news-detail__social">
                            <a href="" class="_social fs-3 d-inline-block">
                                <img src="../../assets/content/images/facebook.svg" alt="" class="_img img-fluid" />
                            </a>
                            <a href="" class="_social fs-3 d-inline-block">
                                <img src="../../assets/content/images/twitter.svg" alt="" class="_img img-fluid" />
                            </a>
                            <a href="" class="_social fs-3 d-inline-block">
                                <img src="../../assets/content/images/instagram.svg" alt="" class="_img img-fluid" />
                            </a>
                            <a href="" class="_social fs-3 d-inline-block">
                                <img src="../../assets/content/images/embed.svg" alt="" class="_img img-fluid" />
                            </a>
                        </div>
                    </div>
                </div>
                  <comment :id="recruitment.recruitmentId"></comment>
            </div>
            <div class="col-lg-3 col-12">
                <div class="hot-news mb-lg-5 mb-lg-4 mb-md-3 mb-2 wow fadeInUp">
                    <p class="hot-news__title pb-lg-3 pb-2 mb-lg-3 mb-2 wow fadeInUp">
                        Tin tuyển dụng nổi bật
                    </p>
                    <div class="row row-cols-lg-1 row-cols-2 gy-3">
                        <div v-for="(data,index) in recruitmentHot" :key="index" class="col wow bounceIn" :data-wow-delay="`${index * 0.1}` + 's'" data-wow-duration="1s">
                            <div class="hot-news__item border-bottom" @click="viewRecruitment(data.recruitmentId)">
                                <div href="" class="_link fw-bold d-block mb-lg-2">{{data.recruitmentTitle}}</div>
                                <div class="news__item__author mb-lg-3 mb-sm-2 mb-1">
                                    <span class="_date">
                                        <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon" />
                                        {{data.createdDate | moment("DD/MM/YYYY")}}
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="section related-news">
        <div class="container">
            <h2 class="section__title text-uppercase text-left wow fadeInUp">
                Tin tuyển dụng liên quan
            </h2>
            <div class="row related-news__list gy-3 gx-3">
                <div v-for="(data,index) in recruitmentRelateTo" :key="index" class="col-lg-4 col-sm-6 col-12 related-news__item wow fadeInUp" data-wow-delay="<?php echo $i*0.1; ?>s" data-wow-duration="1s">
                    <div @click="viewRecruitment(data.recruitmentId)">
                        <div class="_img-link d-block" title="">
                            <img :src="require('@/assets/content/images/'+data.linkImage)" alt="" class="_main-img img-fluid">
                        </div>
                        <div class="related-news__author mb-lg-3 mb-2">
                            <span class="_posted-by">
                                <img src="../../assets/content/images/profile.svg" alt="" class="_img img-fluid svg-icon" />
                                Admin
                            </span>
                            <span class="_date ms-lg-3 ms-md-2 ms-1">
                                <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon" />
                                {{data.createdDate | moment("DD/MM/YYYY")}}
                            </span>
                        </div>
                        <div class="_title d-block mb-lg-3 mb-2" title="">{{data.recruitmentTitle}}</div>
                        <div class="_short">
                            {{ data.recruitmentContent }}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
</template>

<script>
import {
    mapActions
} from 'vuex';
import {
    ModuleRecruitment
} from '@/store/module-const';
import Comment from '../comment/Comment.vue';
export default {
    components: {
        comment: Comment,
    },
    data() {
        return {
            id: "",
            recruitment: null,
            recruitmentRelateTo: [],
            recruitmentHot: [],
        }
    },
    async created() {
        const me = this;
        if (me.$route && me.$route.params && me.$route.params.id) {
            let res = await me.getRecruitmentById(me.$route.params.id);
            if (res) {
                me.recruitment = {
                    ...res
                };
            }
        }
        me.getData();
    },
    methods: {
        ...mapActions(ModuleRecruitment, ['getRecruitmentById', "getRecruitmentsHome", "getRecruitmentsHot"]),
        async getData() {
            const me = this;
            me.recruitmentRelateTo = await me.getRecruitmentsHome();
            me.recruitmentHot = await me.getRecruitmentsHot();
        },
        async viewRecruitment(id) {
            const me = this;
            me.$router.push(`/recruiment-detail/${id}`);
            let res = await me.getRecruitmentById(me.$route.params.id);
            if (res) {
                me.recruitment = {
                    ...res
                };
            }
        },
    }
}
</script>

<style scoped>
.related-news__item ._short {
     overflow: hidden;
    text-overflow: ellipsis;
    line-height: 20px;
    -webkit-line-clamp: 3;
    display: -webkit-box;
    -webkit-box-orient: vertical;
}
</style>
