<template>
<div class="container p-5 h-content-table-admin">
    <div class="row">
        <div class="col-md-offset-1">
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Danh sách hàng đã mua</h3>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <table class="h-table">
                        <thead class="h-th-table">
                            <tr>
                                <th class="hidden-xs">Số thứ tự</th>
                                <th class="min-w-200px">Người mua</th>
                                <th>Số điện thoại</th>
                                <th>Địa chỉ</th>
                                <th>Chi tiết sản phẩm</th>
                                <th>Trạng thái đơn hàng</th>
                                <th>Thời gian mua</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(his, index) in histories" :key="index">
                                <td class="hidden-xs">
                                    {{ params.PageSize * (params.PageIndex - 1) + index + 1 }}
                                </td>
                                <td>{{ his.order.fullName }}</td>
                                <td>{{ his.order.phoneNumber  }}</td>
                                <td>{{ his.order.address  }}</td>
                                <td>
                                    <ul v-for="(order,index1) in his.orderDetails" :key="index1">
                                        <li>Sản phẩm : {{ order.productName }} - Số lượng : {{ order.amount }}</li>
                                    </ul>
                                </td>
                                <td>{{ his.order.statusOrder | orderStatus }}</td>
                                <td>{{ his.order.modifiedDate | formatDate }}</td>
                                <th v-if="his.order.statusOrder == $enum.OrderStatus.WaitConfirm">
                                    <div class="h-cancel-order" @click="cancelOrder(his.order.orderId)">   
                                        Hủy đơn hàng
                                    </div>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="h-pagination">
                    <Pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'đơn hàng'" />
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import Pagination from '../components/pagination/Pagination.vue'
import {
    mapActions
} from "vuex";
import {
    ModuleOrder,
    ModuleUser
} from "@/store/module-const";
export default {
    components: {
        Pagination,
    },
    async created() {
        const me = this;
        let res = await me.getUserByUserName(me.$commonFunc.getUserName());
        if (res) {
            me.params.UserId = res.userId;
        }
        await me.getData();
    },
    data() {
        return {
            orderDetails: [],
            params: {
                PageIndex: 1,
                PageSize: 10,
                TotalRecord: 0,
                TotalPages: 0,
            },
            histories: [],
        };
    },
    methods: {
        ...mapActions(ModuleOrder, [
            "getHistoriesOrder",
            "deleteOrderAsync",
            "cancelOrderAsync"
        ]),
        ...mapActions(ModuleUser, ["getUserByUserName"]),
        async getData() {
            const me = this;
            if (me.$refs.pagination) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            
            let res = await me.getHistoriesOrder(me.params);
            if (res) {
                me.histories = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.histories = [];
                me.params = {
                    PageIndex: 1,
                    PageSize: 10,
                    TotalRecord: 0,
                    TotalPages: 0,
                };
            }

        },
        async cancelOrder(orderId){
            const me = this;
            await me.deleteOrderAsync(orderId);
            me.params.PageIndex = 1; 
            me.params.PageSize = 10;
            
            let res = await me.getHistoriesOrder(me.params);
            if (res) {
                me.histories = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
             if (!res) {
                me.histories = [];
                me.params = {
                    PageIndex: 1,
                    PageSize: 10,
                    TotalRecord: 0,
                    TotalPages: 0,
                };
            }
        },
    },
};
</script>

<style scoped>
@import "../../assets/content/css/common/tableAdmin.css";

.h-content-table-admin {
    max-height: none !important;
    min-height: 100vh !important;
    overflow: hidden !important;
    padding-top: 0 px !important;
}
.h-cancel-order{
    text-align: center;
    background: #e5e5e5;
    cursor: pointer;
    border-radius: 6px;
}
.h-cancel-order:hover{
    background: #adacac;
}
</style>
