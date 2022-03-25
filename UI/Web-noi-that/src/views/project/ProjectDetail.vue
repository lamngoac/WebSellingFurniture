<template>
<div>
    <section class="section_breacrumb">
        <div class="container">
            <ul class="breadcrumb clearfix" itemscope="" itemtype="http://schema.org/BreadcrumbList">
                <li itemprop="itemListElement" itemscope="" itemtype="http://schema.org/ListItem">
                    <a itemprop="item" href="">
                        <span itemprop="name">Trang chủ</span>
                    </a>
                    <meta itemprop="position" content="1" />
                </li>
                <li itemprop="itemListElement" itemscope="" itemtype="http://schema.org/ListItem">
                    <a itemprop="item" href="">
                        <span itemprop="name">Chi tiết dự án</span>
                    </a>
                    <meta itemprop="position" content="2" />
                </li>
            </ul>
        </div>
    </section>
    <section class="section news-detail container">
        <div class="row">
            <div class="col-lg-9 col-12" v-if="project">
                <div class="news-detail__content border-bottom pb-lg-4 pb-md-3 pb-2">
                    <h1 class="section__title text-uppercase wow fadeInUp">
                        {{ project.projectTitle }}
                    </h1>
                    <div class="news__item__author wow fadeInUp">
                        <span class="_posted-by d-inline-block">
                            <img src="../../assets/content/images/profile.svg" alt="" class="_img img-fluid svg-icon" />
                            Admin
                        </span>
                        <span class="_date ms-lg-3 ms-md-2 ms-1">
                            <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon" />
                            {{ project.createdDate | moment("DD/MM/YYYY")}}
                        </span>
                    </div>
                    <div class="news-detail__post wow fadeInUp s-content">
                        <img v-if="project.linkImage" :src="require('@/assets/content/images/' + project.linkImage)" class="img-fluid" />

                        <p class="mb-lg-3 mb-2">
                            {{ project.projectContent }}
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
                 <comment :id="project.projectId"></comment>
            </div>
            <div class="col-lg-3 col-12">
                <div class="hot-news mb-lg-5 mb-lg-4 mb-md-3 mb-2 wow fadeInUp">
                    <p class="hot-news__title pb-lg-3 pb-2 mb-lg-3 mb-2 wow fadeInUp">
                        Dự án nổi bật
                    </p>
                    <div class="row row-cols-lg-1 row-cols-2 gy-3">
                        <div v-for="(data, index) in projectsHot" :key="index" class="col wow bounceIn" :data-wow-delay="`${index * 0.1}` + 's'" data-wow-duration="1s">
                            <div class="hot-news__item border-bottom">
                                <a href="" class="_link fw-bold d-block mb-lg-2">{{
                    data.projectTitle
                  }}</a>
                                <div class="news__item__author mb-lg-3 mb-sm-2 mb-1">
                                    <span class="_date">
                                        <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon" />
                                        {{data.createdDate | moment("DD/MM/YYYY")}}}
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
                Dự án liên quan
            </h2>
            <div class="row related-news__list gy-3 gx-3">
                <div v-for="(data, index) in projectsRelateTo" :key="index" class="col-lg-4 col-sm-6 col-12 related-news__item wow fadeInUp" data-wow-delay="<?php echo $i*0.1; ?>s" data-wow-duration="1s">
                    <div @click="viewProject(data.projectId)">
                        <div class="_img-link d-block" title="">
                            <img :src="require('@/assets/content/images/' + data.linkImage)" alt="" class="_main-img img-fluid" />
                        </div>
                        <div class="related-news__author mb-lg-3 mb-2">
                            <span class="_posted-by">
                                <img src="../../assets/content/images/profile.svg" alt="" class="_img img-fluid svg-icon" />
                                Admin
                            </span>
                            <span class="_date ms-lg-3 ms-md-2 ms-1">
                                <img src="../../assets/content/images/clock.svg" alt="" class="_img img-fluid svg-icon" />
                                {{data.createdDate | moment("DD/MM/YYYY")}}}
                            </span>
                        </div>
                        <div class="_title d-block mb-lg-3 mb-2" title="">
                            {{ data.projectTitle }}
                        </div>
                        <div class="_short">
                            {{ data.projectContent }}
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
} from "vuex";
import {
    ModuleProject
} from "@/store/module-const";
import Comment from "../comment/Comment.vue";
export default {
    components: {
        comment: Comment,
    },
    data() {
        return {
            id: "",
            project: null,
            projectsRelateTo: [],
            projectsHot: [],
        };
    },
    async created() {
        const me = this;
        if (me.$route && me.$route.params && me.$route.params.id) {
            let res = await me.getProjectById(me.$route.params.id);
            if (res) {
                me.project = {
                    ...res,
                };
            }
        }
        me.getData();
    },
    methods: {
        ...mapActions(ModuleProject, [
            "getProjectById",
            "getProjectsHome",
            "getProjectsHot",
        ]),
        async getData() {
            const me = this;
            me.projectsRelateTo = await me.getProjectsHome();
            me.projectsHot = await me.getProjectsHot();
        },
        async viewProject(id) {
            const me = this;
            me.$router.push(`/project-detail/${id}`);
              let res = await me.getProjectById(me.$route.params.id);
            if (res) {
                me.project = {
                    ...res,
                };
            }
        },
    },
};
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
