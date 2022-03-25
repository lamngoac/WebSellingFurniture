<template>
<div class="h-popup" v-if="isShow">
    <h-popup @closePopup="closePopup" :width="600" :height="500">
        <template slot="header">
            <div class="h-titlte">
                Thống kê doanh số
            </div>
        </template>
        <template slot="content">
            <div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                        <h-input-date :title="'Từ ngày'" v-model="params.fromDate"/>
                    </div>
                </div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                        <h-input-date :title="'Đến ngày'" v-model="params.toDate"/>
                    </div>
                </div>
                <div v-if="params && params.revenue">
                    Doanh số từ ngày {{ params.fromDate | formatDate }} đến ngày {{ params.toDate | formatDate}} là : {{ params.revenue | formatMoney }}
                </div>
            </div>
        </template>
        <template slot="footer">
            <div style="width: 100%">
                <div class="h-display-flex jus-end">
                    <div class="h-button h-btn-save" @click="revenueStatistic">Thống kê</div>
                </div>
            </div>
        </template>
    </h-popup>
</div>
</template>

<script>
import {
    mapActions
} from "vuex";
import {
    ModuleOrder,ModuleOrderDetail
} from "@/store/module-const";

export default {
    components: {},
    name: "RevenueStatistic",
    props: {
        isShow: {
            typeof: Boolean,
            default: false,
        },
    },
    data() {
        return {
            params :{},
            orders : [],
            orderDetails : [],
        };
    },
    computed: {
        titlleMode() {
            const me = this;
            if (me.mode == 0) {
                return me.$t("i18nOrder.addOrder");
            }
            if (me.mode == 1) {
                return me.$t("i18nOrder.editOrder");
            }
            return "";
        },

        fromDate:{
            get(){
                return  this.moment(this.params.fromDate).format("DD/MM/YYYY");
            },
            set(val){
                this.params.fromDate = this.moment(val).format("YYYY-MM-DD")
            }
        },

        toDate:{
            get(){
                return  this.moment(this.params.toDate).format("DD/MM/YYYY");
            },
            set(val){
                this.params.toDate = this.moment(val).format("YYYY-MM-DD")
            }
        }


    },
    created(){
    },
    methods: {
        ...mapActions(ModuleOrder, [
            "getOrders",
        ]), 
        ...mapActions(ModuleOrderDetail, [
            "getOrderDetails",
        ]),
        async getDataOrders(){
            const me = this;
            let res = await me.getOrders();
            if(res){
                me.orders = [...res];
            }
        },
        async getDataOrderDetails(){
            const me = this;
            let res = await me.getOrderDetails();
            if(res){
                me.orderDetails = [...res];
            }
        },
        async revenueStatistic(){
            const me = this;
            await me.getDataOrders();
            await me.getDataOrderDetails();
            if(me.orders && me.params && me.params.fromDate && me.params.toDate){
                // Lấy danh sách đơn hàng đã được giao thanh công từ ngày đến ngày 
                me.params.fromDate = new Date(me.params.fromDate);
                me.params.fromDate.setHours(0);
                me.params.toDate = new Date(me.params.toDate);
                me.params.toDate.setHours(23);
                me.params.toDate.setMinutes(59);
                me.params.toDate.setSeconds(59);
            
                me.orders = me.orders.filter(o => me.comparaDate(o.createdDate,me.params.fromDate) 
                    && !me.comparaDate(o.createdDate,me.params.toDate) 
                    && o.statusOrder == me.$enum.OrderStatus.Success);

                if(me.orders && me.orders.length > 0 && me.orderDetails && me.orderDetails.length > 0){
                    let orderIds = me.orders.map(o => o.orderId);
                    //Lấy ra các danh sách chi tiết của các đơn hàng trên
                    me.orderDetails = me.orderDetails.filter(od => orderIds.indexOf(od.orderId) >= 0);

                    if (me.orderDetails && me.orderDetails.length > 1) {
                        me.params.revenue = me.orderDetails.reduce((a, { amount, price }) => a + amount * price, 0);
                    }
                    if (me.orderDetails && me.orderDetails.length == 1) {
                         me.params.revenue = me.orderDetails[0].amount * me.orderDetails[0].price;
                    }
                }
            }
        },
        comparaDate(a,b){
            a = new Date(a);
            b = new Date(b);
            return this.convertDateISO(a) >= this.convertDateISO(b);
        },
        convertDateISO(date){
            date = new Date(date);
            return date.toISOString().replace("Z","");
        },
        closePopup() {
            const me = this;
            me.params = {};
            me.$emit("closePopup");
        },
    },
};
</script>

<style scoped>
.h-popup {}

.h-titlte {
    font-weight: bold;
    font-size: 18px;
}

.h-row {
    margin-bottom: 10px;
}
</style>
