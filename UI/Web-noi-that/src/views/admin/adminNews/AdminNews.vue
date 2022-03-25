<template>
<div class="container p-5 h-content-table-admin">
    <div class="row">
        <div class="col-md-offset-1">
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Danh sách tin tức</h3>
                        </div>
                        <div style="width:300px;">
                            <h-input v-model="params.Filter" placeholder="Tìm kiếm" @keyup="filterData" />
                        </div>
                        <div class="col col-xs-6 text-right" style="justify-content: flex-end; display: flex">
                            <div type="button" class="btn btn-sm btn-add h-display-flex" @click="addNews">
                                <div>Thêm mới</div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- <div class="panel-body">
                    <table class="h-table">
                        <thead class="h-th-table">
                            <tr>
                                <th class="fix h-text-center width-100px">
                                    <em class="fa fa-cog"></em>
                                </th>
                                <th class="hidden-xs">STT</th>
                                <th class="min-w-200px">Tiêu đề tin</th>
                                <th class="min-w-200px">Nội dung tin</th>
                                <th class="min-w-200px">Hình ảnh</th>
                                <th>Tin hot</th>
                                <th>Tin sản phẩm</th>
                                <th>Tin khuyến mại</th>
                                <th>Tin sự kiện</th>
                                <th>Tin trang chủ</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(news, index) in newss" :key="index">
                                <td align="center" class="btn_click">
                                    <a class="btn btn-default" @click="editNews(news.newsId)"><em class="fa fa-pencil"></em></a>
                                    <a class="btn btn-danger" @click="deleteNews(news.newsId)"><em class="fa fa-trash"></em></a>
                                </td>
                                <td class="hidden-xs">
                                    {{ params.PageSize * (params.PageIndex - 1) + index + 1 }}
                                </td>
                                <td>{{ news.newsTitle }}</td>
                                <td>{{ news.newsContent }}</td>
                                <td class="min-w-200px">
                                    <div class="img-prds__img ">
                                        <div title="" class="d-block" v-if="news.linkImage">
                                            <img :src="require('@/assets/content/images/'+ news.linkImage )" alt="" class="img-fluid" />
                                        </div>
                                        <div>
                                            {{news.linkImage }}
                                        </div>
                                    </div>
                                </td>
                                <th>{{ news.newsHot }}</th>
                                <th>{{ news.newsProduct }}</th>
                                <th>{{ news.newsSale }}</th>
                                <th>{{ news.newsEvent }}</th>
                                <th>{{ news.newsHome }}</th>
                            </tr>
                        </tbody>
                    </table>
                </div> -->
                <h-grid 
                    :columns="columns"
                    :data="newss"
                    :pageSize="params.PageSize"
                    :pageIndex="params.PageIndex"
                    :fieldId="'newsId'"
                    @deleteData="deleteNews"
                    @editData="editNews"
                >
                </h-grid>
                <div class="h-pagination">
                    <h-pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'tin tuc'" />
                </div>
            </div>
        </div>
    </div>
    <AdminNewsDetail :isShow="isShow" @closePopup="setStatePopup(false)" @showPopup="setStatePopup(true)" :news="news" :mode="mode" @loadData="getData" />
</div>
</template>

<script>
import {
    mapActions
} from "vuex";
import {
    ModuleNews
} from "@/store/module-const";
import AdminNewsDetail from "./AdminNewsDetail.vue";

import {
    News
} from "@/common/models/models";
import _ from 'lodash';
export default {
    components: {
        AdminNewsDetail,
    },
    created() {
        const me = this;
        me.getData();
    },
    data() {
        return {
            newss: [],
            params: {
                PageIndex: 1,
                PageSize: 10,
                TotalRecord: 0,
                TotalPages: 0,
                Filter: "",
            },
            isShow: false,
            news: News(),

            mode: "add",
            columns : [
                {
                    text : "",
                    icon : "fa fa-cog",
                    center : "text-center"
                },
                {
                    text :"STT",
                    serial : true,
                    center : "text-center"
                },
                {
                    text :"Tiêu đề tin",
                    width : 200,
                    dataField :"newsTitle"
                },
                {
                    text :"Nội dung tin",
                    width : 200,
                    dataField :"newsContent"
                },
                {
                    text :"Ảnh",
                    width : 200,
                    dataField :"linkImage",
                    image:true
                },
                {
                    text : "Tin hot",
                    dataField :"newsHot"
                },
                {
                    text :"Tin sản phẩm",
                    dataField :"newsProduct"
                },
                {
                    text :"Tin khuyến mại",
                    dataField :"newsSale",
                },
                {
                    text : "Tin sự kiện",
                    dataField :"newsEvent"
                }


            ]
        };
    },
    methods: {
        ...mapActions(ModuleNews, [
            "getNewssPagging",
            "getNewsById",
            "deleteNewsAsync",
        ]),
        async getData() {
            const me = this;
            if(me.$refs.pagination){
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getNewssPagging(me.params);
            if (res) {
                me.newss = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.newss = [];
                me.params = {
                    PageIndex: 1,
                    PageSize: 10,
                    TotalRecord: 0,
                    TotalPages: 0,
                    Filter: me.params.Filter,
                };
            }
        },
        async addNews() {
            const me = this;
            me.showPopup();
            me.mode = "add";
        },
        // bịp vl vcl

        async editNews(id) {
            const me = this;
            // Lấy News theo id

            me.News = await me.getNewsById(id);

            // Show popup
            me.showPopup();
            me.mode = "edit";
        },
        async deleteNews(id) {
            const me = this;
            await me.deleteNewsAsync(id);
            if (me.newss && me.newss.length == 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD - 1;
            } else if (me.Newss && me.Newss.length > 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getNewssPagging(me.params);
            if (res) {
                me.newss = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.newss = [];
                me.params = {
                    PageIndex: 1,
                    PageSize: 10,
                    TotalRecord: 0,
                    TotalPages: 0,
                    Filter: me.params.Filter,
                };
            }
            
        },
        showPopup() {
            const me = this;
            me.isShow = true;
        },
        setStatePopup(show) {
            const me = this;
            me.isShow = show;
            if (!show) {
                me.resetData();
            }
        },
        resetData() {
            const me = this;
            me.news = News();
        },

        filterData: _.debounce(function () {
            this.getData();
        }, 500),
    },
};
</script>

<style scoped>
@import "../../../assets/content/css/common/tableAdmin.css";
</style>
