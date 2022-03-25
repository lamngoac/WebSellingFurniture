<template>
<div class="container p-5 h-content-table-admin">
    <div class="row">
        <div class="col-md-offset-1">
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Danh sách đơn hàng</h3>
                        </div>
                        <div style="width:300px;">
                            <h-input v-model="params.Filter" placeholder="Tìm kiếm" @keyup="filterData"/>
                        </div>
                        <!-- <div class="col col-xs-6 text-right" style="justify-content: flex-end; display: flex">
                            <div type="button" class="btn btn-sm btn-add h-display-flex" @click="addOrder">
                                <div>Thêm mới</div>
                            </div>
                        </div> -->
                    </div>
                </div>
                <h-grid 
                    :columns="columns"
                    :data="orders"
                    :pageSize="params.PageSize"
                    :pageIndex="params.PageIndex"
                    :fieldId="'orderId'"
                    @editData="editOrder"
                    @deleteData="deleteOrder"
                >
                </h-grid>
                <div class="h-pagination">
                    <h-pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'don hang'" />
                </div>
            </div>
        </div>
    </div>
    <AdminOrderD :isShow="isShow" @closePopup="setStatePopup(false)" @showPopup="setStatePopup(true)" :order="order" :mode="mode" @loadData="getData" />
</div>
</template>

<script>
import {
    mapActions
} from "vuex";
import {
    ModuleOrder,ModuleUser
} from "@/store/module-const";
import AdminOrderD from "./AdminOrderD.vue";

import {
    Order
} from "@/common/models/models";
import _ from 'lodash';
export default {
    components: {
        AdminOrderD,
    },
    created() {
        const me = this;
        me.getData();
    },
    data() {
        return {
            orders: [],
            params: {
                PageIndex: 1,
                PageSize: 10,
                TotalRecord: 0,
                TotalPages: 0,
                Filter: "",
            },
            isShow: false,
            order: Order(),

            mode: "add",
            columns : [
                {
                    text : "",
                    icon : "fa fa-cog",
                    center : "text-center",
                },
                {
                    text :"STT",
                    serial : true,
                    center : "text-center"
                },
                {
                    text :"Tài khoản",
                    dataField :"userName"
                },
                {
                    text :"Họ tên",
                    dataField :"fullName"
                },
                {
                    text : "Số điện thoại",
                    dataField :"phoneNumber"
                },
                {
                    text :"Địa chỉ nhận hàng",
                    dataField :"address"
                },
                {
                    text : "Phương thức thanh toán",
                    dataField :"paymentMethods",
                    format : this.$enum.Format.PaymentMethods
                },
                {
                    text : "Trạng thái đơn hàng",
                    dataField :"statusOrder",
                    format : this.$enum.Format.OrderStatus
                },
                {
                    text :"Ghi chú",
                    dataField :"note"
                },


            ]
        };
    },
    computed:{
    },
    methods: {
        ...mapActions(ModuleOrder, [
            "getOrdersPagging",
            "getOrderById",
            "deleteOrderAsync",
        ]),
        ...mapActions(ModuleUser, [
            "getUserById"
        ]),
        async getData() {
            const me = this;
            if(me.$refs.pagination){
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getOrdersPagging(me.params);
            if (res) {
                me.orders = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.orders = [];
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
        async addOrder() {
            const me = this;
            me.showPopup();
            me.mode = "add";
        },
        async editOrder(id) {
            const me = this;
            console.log(1);
            me.order = await me.getOrderById(id);
            // Show popup
            me.showPopup();
            me.mode = "edit";
        },
        async deleteOrder(id) {
            const me = this;
            await me.deleteOrderAsync(id);
            if (me.orders && me.orders.length == 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD - 1;
            } else if (me.Orders && me.Orders.length > 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getOrdersPagging(me.params);
            if (res) {
                me.orders = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.orders = [];
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
            me.order = Order();
        },

        filterData: _.debounce(function () {
          this.getData();
        }, 500),
    },
};
</script>

<style scoped>
@import "../../../assets/content/css/common/tableAdmin.css";
.btn-edit:hover{
    background: #e5e5e5;
}
</style>
