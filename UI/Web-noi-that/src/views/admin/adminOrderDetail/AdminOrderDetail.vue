<template>
<div class="container p-5 h-content-table-admin">
    <div class="row">
        <div class="col-md-offset-1">
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Danh sách chi tiết đơn hàng</h3>
                        </div>
                        <div style="width:300px;">
                          <h-input v-model="params.Filter" placeholder="Tìm kiếm" @keyup="filterData"/>
                        </div>
                        <!-- <div class="col col-xs-6 text-right" style="justify-content: flex-end; display: flex">
                            <div type="button" class="btn btn-sm btn-add h-display-flex" @click="addOrderDetail">
                                <div>Thêm mới</div>
                            </div>
                        </div> -->
                    </div>
                </div>
                <h-grid 
                    :columns="columns"
                    :data="orderDetails"
                    :pageSize="params.PageSize"
                    :pageIndex="params.PageIndex"
                    :fieldId="'orderDetailId'"
                    @deleteData="deleteOrderDetail"
                    @editData="editOrderDetail"
                >
                </h-grid>
                <div class="h-pagination">
                    <h-pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'chi tiet don hang'" />
                </div>
            </div>
        </div>
    </div>
    <OrderDetail :isShow="isShow" @closePopup="setStatePopup(false)" @showPopup="setStatePopup(true)" :orderDetail="orderDetail" :mode="mode" @loadData="getData" />
</div>
</template>

<script>
import {
    mapActions
} from "vuex";
import {
    ModuleOrderDetail
} from "@/store/module-const";
import OrderDetail from "./OrderDetail.vue";
import {
    OrderDetail1
} from "@/common/models/models";
import _ from 'lodash';
export default {
    components: {
        OrderDetail,
    },
    created() {
        const me = this;
        me.getData();
    },
    data() {
        return {
            orderDetails: [],
            params: {
                PageIndex: 1,
                PageSize: 10,
                TotalRecord: 0,
                TotalPages: 0,
                Filter: "",
            },
            isShow: false,
            orderDetail: OrderDetail1(),

            mode: "add",

            columns : [
                {
                    text : "",
                    icon : "fa fa-cog",
                    center : "text-center",
                    width:100
                },
                {
                    text :"STT",
                    serial : true,
                    center : "text-center"
                },
                {
                    text :"Sản phẩm",
                    width : 200,
                    dataField :"productName"
                },
                {
                    text :"Số lượng",
                    width : 200,
                    dataField :"amount"
                },
                {
                    text :"Giá",
                    width : 200,
                    dataField :"price",
                    format:this.$enum.Format.Money
                },
            ]
        };
    },
    methods: {
        ...mapActions(ModuleOrderDetail, [
            "getOrderDetailsPagging",
            "getOrderDetailById",
            "deleteOrderDetailAsync",
        ]),
        async getData() {
            const me = this;
            if(me.$refs.pagination){
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getOrderDetailsPagging(me.params);
            if (res) {
                me.orderDetails = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.orderDetails = [];
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
        async addOrderDetail() {
            const me = this;
            me.showPopup();
            me.mode = "add";
        },
        // bịp vl vcl

        async editOrderDetail(id) {
            const me = this;
            // Lấy OrderDetail theo id
            me.orderDetail = await me.getOrderDetailById(id);
            // Show popup
            me.showPopup();
            me.mode = "edit";
        },
        async deleteOrderDetail(id) {
            const me = this;
            await me.deleteOrderDetailAsync(id);
            if (me.orderDetails && me.orderDetails.length == 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD - 1;
            } else if (me.orderDetails && me.orderDetails.length > 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getOrderDetailsPagging(me.params);
            if (res) {
                me.orderDetails = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.orderDetails = [];
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
            me.orderDetails = OrderDetail1();
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
