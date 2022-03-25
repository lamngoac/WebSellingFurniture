<template>
<div class="container p-5 h-content-table-admin">
    <div class="row">
        <div class="col-md-offset-1">
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Danh sách tin tuyển dụng</h3>
                        </div>
                        <div style="width:300px;">
                            <h-input v-model="params.Filter" placeholder="Tìm kiếm" @keyup="filterData"/>
                        </div>
                        <div class="col col-xs-6 text-right" style="justify-content: flex-end; display: flex">
                            <div class="btn btn-sm btn-add h-display-flex" @click="addRecruitment">
                                <div>Thêm mới</div>
                            </div>
                        </div>
                    </div>
                </div>
                <h-grid 
                    :columns="columns"
                    :data="recruitments"
                    :pageSize="params.PageSize"
                    :pageIndex="params.PageIndex"
                    :fieldId="'recruitmentId'"
                    @deleteData="deleteRecruitment"
                    @editData="editRecruitment"
                >
                </h-grid>
                <div class="h-pagination">
                    <h-pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'tuyen dung'" />
                </div>
            </div>
        </div>
    </div>
    <RecruitmentDetail :isShow="isShow" @closePopup="setStatePopup(false)" @showPopup="setStatePopup(true)" :recruitment="recruitment" :mode="mode" @loadData="getData" />
</div>
</template>

<script>
import {
    mapActions
} from "vuex";
import {
    ModuleRecruitment
} from "@/store/module-const";

import {
    Recruitment
} from "@/common/models/models";
import RecruitmentDetail from "./RecruitmentDetail.vue";
import _ from 'lodash';
export default {
    components: {
        RecruitmentDetail,
    },
    created() {
        const me = this;
        me.getData();
    },
    data() {
        return {
            recruitments: [],
            params: {
                PageIndex: 1,
                PageSize: 10,
                TotalRecord: 0,
                TotalPages: 0,
                Filter: "",
            },
            isShow: false,
            recruitment: Recruitment(),

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
                    text :"Tiêu đề tuyển dụng",
                    width : 200,
                    dataField :"recruitmentTitle"
                },
                {
                    text :"Nội dung tuyển dụng",
                    width : 200,
                    dataField :"recruitmentContent"
                },
                {
                    text :"Ảnh",
                    dataField :"linkImage",
                    image:true
                },
            ]
        };
    },
    methods: {
        ...mapActions(ModuleRecruitment, [
            "getRecruitmentsPagging",
            "getRecruitmentById",
            "deleteRecruitmentAsync",
        ]),
        async getData() {
            const me = this;
            if(me.$refs.pagination){
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getRecruitmentsPagging(me.params);
            if (res) {
                me.recruitments = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.recruitments = [];
                me.params = {
                    PageIndex: 1,
                    PageSize: 10,
                    TotalRecord: 0,
                    TotalPages: 0,
                    Filter: me.params.Filter,
                };
            }

        },

        /**
         * Hàm sử lí click button thêm mới
         */
        async addRecruitment() {
            const me = this;
            me.showPopup();
            me.mode = "add";
        },
        // bịp vl vcl

        async editRecruitment(id) {
            const me = this;
            // Lấy Recruitment theo id

            me.recruitment = await me.getRecruitmentById(id);

            // Show popup
            me.showPopup();
            me.mode = "edit";
        },
        async deleteRecruitment(id) {
            const me = this;
            await me.deleteRecruitmentAsync(id);
            if (me.recruitments && me.recruitments.length == 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD - 1;
            } else if (me.recruitments && me.recruitments.length > 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getRecruitmentsPagging(me.params);
            if (res) {
                me.recruitments = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.recruitments = [];
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
            me.recruitment = Recruitment();
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
