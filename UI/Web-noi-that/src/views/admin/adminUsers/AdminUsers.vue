<template>
<div class="container p-5 h-content-table-admin">
    <div class="row">
        <div class="col-md-offset-1">
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Danh sách user</h3>
                        </div>
                        <div style="width:300px;">
                            <h-input v-model="params.Filter" placeholder="Tìm kiếm" @keyup="filterData"/>
                        </div>
                        <div class="col col-xs-6 text-right" style="justify-content: flex-end; display: flex">
                            <div class="btn btn-sm btn-add h-display-flex" @click="addUser">
                                <div>Thêm mới</div>
                            </div>
                        </div>
                    </div>
                </div>
                <h-grid 
                    :columns="columns"
                    :data="users"
                    :pageSize="params.PageSize"
                    :pageIndex="params.PageIndex"
                    :fieldId="'userId'"
                    @deleteData="deleteUser"
                    @editData="editUser"
                >
                </h-grid>
                <div class="h-pagination">
                    <h-pagination ref="pagination" @getData="getDataUser" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'tài khoản'" />
                </div>
            </div>
        </div>
    </div>
    <UserDetail :isShow="isShow" @closePopup="setStatePopup(false)" @showPopup="setStatePopup(true)" :user="user" :mode="mode" @loadData="getDataUser" />
</div>
</template>

<script>
import {
    mapActions
} from "vuex";
import {
    ModuleUser
} from "@/store/module-const";

import {
    User
} from "@/common/models/models";
import UserDetail from "./AdminUserDetail.vue";
import _ from 'lodash'
export default {
    components: {
        UserDetail,
    },
    created() {
        const me = this;
        me.getDataUser();
    },
    data() {
        return {
            users: [],
            params: {
                PageIndex: 1,
                PageSize: 10,
                TotalRecord: 0,
                TotalPages: 0,
                Filter: "",
            },
            isShow: false,
            user: User(),

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
                    text :"Tài khoản",
                    width : 200,
                    dataField :"userName"
                },
                {
                    text :"Họ tên",
                    width : 200,
                    dataField :"fullName"
                },
                {
                    text :"Địa chỉ",
                    width : 200,
                    dataField :"address"
                },
                {
                    text : "Số điện thoại",
                    width : 200,
                    dataField :"phoneNumber"
                }

            ]
        };
    },
    methods: {
        ...mapActions(ModuleUser, [
            "getUsersPagging",
            "getUserById",
            "deleteUserAsync",
        ]),
        async getDataUser() {
            const me = this;
            if (me.$refs.pagination) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getUsersPagging(me.params);
            if (res) {
                me.users = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.users = [];
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
        async addUser() {
            const me = this;
            me.showPopup();
            me.mode = "add";
        },
        async editUser(id) {
            const me = this;
            // Lấy user theo id
            me.user = await me.getUserById(id);
            // Show popup
            me.isShow = true;
            me.mode = "edit";
        },
        async deleteUser(id) {
            const me = this;
            // if(me.users.length == 1 && me.users){
            //     me.params.PageIndex -= 1;
            // }
            //Xóa user theo Id
            await me.deleteUserAsync(id);
            if (me.users && me.users.length == 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD - 1;
            } else if (me.users && me.users.length > 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getUsersPagging(me.params);
            if (res) {
                me.users = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.users = [];
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
            me.user = User();
        },
        filterData: _.debounce(function () {
          this.getDataUser();
        }, 500),
    },
};
</script>

<style scoped>
@import "../../../assets/content/css/common/tableAdmin.css";
</style>
