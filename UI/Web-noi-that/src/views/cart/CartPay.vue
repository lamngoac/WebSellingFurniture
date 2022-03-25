<template>
<div>
    <section class="cards container">
        <div class="row">
            <div class="col-lg-6">
               <span class="title_cards title-address">Thông tin  nhận hàng</span>
               <h-input type="text" class="h-mt-20" :title="'Họ và tên'"  v-model="params.userName" placeholder="Họ và tên"/>
               <h-input type="text" class="h-mt-20" :title="'Số điện thoại'" v-model="params.phoneNumber" placeholder="Số điện thoại"/>
               <h-input type="text" class="h-mt-20" :title="'Địa chỉ nhận hàng'"  v-model="params.address" placeholder="Địa chỉ nhận hàng"/>
               <h-textarea :title="'Ghi chú'" class="h-mt-20"  v-model="params.note" rows="3" placeholder="Ghi chú"/>
            </div>
            <div class="col-lg-6 set-table mt-3 mt-lg-0" v-if="orders && orders.length >= 1">
                <span class="title_cards title_cards_set">Đơn hàng của bạn</span>
                <div class="tables-alls tables-prds__carts ">
                    <table class=" table">
                        <thead>
                            <tr>
                                <th> Hình ảnh</th>
                                <th> Sản phẩm </th>
                                <th> Số  lượng </th>
                                <th>Thành tiền</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(order,index) in orders" :key="index" class="tr"> 
                                <td>
                                    <div class="img-prds__img ">
                                        <div title="" class="d-block">
                                            <img :src="require('@/assets/content/images/'+order.product.productImage)" alt="" class="img-fluid" />
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="items-prds__carts">
                                    <div class="intros-prds__carts">
                                            <h3> <a href="#" class="names-prds__carts titles-md__alls fs-16s" title=""> {{ order.product.productName }} </a>
                                            </h3>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <p class="main-price-cart price-cart"> <strong class="price d-block main-price" data-price="0">{{ order.amount }}</strong> </p>
                                </td>
                                <td>
                                    <p class="main-price-cart price-cart"> <strong class="price prices d-block subtotal">{{order.product.productSalePrice * order.amount | formatMoney}}đ</strong> </p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div>
             <div class="box-card box-oder  ">
                    <p class=" item_total item_arena item_boder"> Tổng tiền <span class="price_d"> {{ totalMoney | formatMoney}}đ</span></p>
                    <p class=" item_arena item_boder"> Phí vận chuyển <span class=""> {{ 20000 | formatMoney}}</span></p>
                    <p class=" item_arena item_boder"> Tổng giá trị thanh toán <span class="price"> {{ totalMoney + 20000 | formatMoney}}đ</span> </p>
                </div>
                <div class="btn-oder btn-confirm" title="Xác nhận đặt hàng" @click="confirmOrder">Xác nhận đặt hàng</div>
                <div class="btn-oder btn-cancel" title="Hủy" @click="cancelOrder">Hủy</div>
        </div>
    </section>
</div>
</template>

<script>
import {
    mapActions
} from 'vuex';
import {
    ModuleOrder,ModuleUser
} from '@/store/module-const';

export default {
    data() {
        return {
            orders: [],
            params:{ 
            },
            user : {}
        }
    },
    async created() {
       const me = this;
       await me.getOrders();
       await me.getUser();
    },
    computed:{
        totalAmount() {
            const me = this;
            if (me.orders && me.orders.length > 1) {
                return me.orders.reduce((a, {
                    amount
                }) => a + amount, 0);
            }
            if (me.orders && me.orders.length == 1) {
                return me.orders[0].amount;
            }
            return null;
        },
        totalMoney() {
            const me = this;
            if (me.orders && me.orders.length > 1) {
                return me.orders.reduce((a, {
                    amount,
                    product
                }) => a + amount * product.productSalePrice, 0);
            }
            if (me.orders && me.orders.length == 1) {
                return me.orders[0].amount * me.orders[0].product.productSalePrice;
            }
            return null;
        },

    },
    async beforeDestroy(){
        const me = this;
        await me.getCartByUser(me.user.userName);
    },
    methods: {
        ...mapActions(ModuleOrder, ["addOrderPayment"]),
        ...mapActions(["getCartByUser"]),
        ...mapActions(ModuleUser, ["getUserByUserName"]),

        /**
         * Lấy đanh sách đơn hàng trrong giỏ
         */
        async getOrders() {
            const me = this;
            let userName = me.$commonFunc.getUserName();
            let res = await me.getCartByUser(userName);
            if (res) {
                me.orders = [...res.filter(x => x.selected)];
            }
        },

        async getUser(){
           const me = this;
           let user = await me.getUserByUserName(me.$commonFunc.getUserName());
           if(user){
              me.user = {...user};
              me.params = {...user};
           }
        },
        /**
         * Hàng sử lí xác nhận đơn hàng
         */
        async confirmOrder(){ 
            const me = this;
            let params = {
                order: {
                    userId : me.user.userId,
                    userName : me.user.userName,
                    fullName : me.params.userName,
                    address : me.params.address,
                    phoneNumber : me.params.phoneNumber,
                    note : me.params.note,
                    paymentMedthods : me.params.paymentMedthods,
                    statusOrder : me.$enum.OrderStatus.WaitConfirm
                },
                orderDetail: me.orders.map((order)=>{
                        return {
                            amount: order.amount,
                            productId : order.product.productId,
                            productName : order.product.productName,
                            price : order.product.productSalePrice,
                        }
                    })
            }
            await me.addOrderPayment(params);
            me.resetCart();
            me.$router.push("/cart");
        },

        cancelOrder(){
            const me = this;
            me.$router.push("/cart");
        },

        resetCart() {
            const me = this;
            if (me.$commonFunc.getUserName()) {
                me.$commonFunc.updateCartByUser(me.$commonFunc.getUserName());
            }
        },
    }
}
</script>

<style  scoped>
thead, tbody, tfoot, tr, td, th{
    border-style: none !important;
}
tr{
    border-bottom: 1px solid #e5e5e5 !important;
}
tr td,tr th{
    border-left:1px solid #e5e5e5 !important ;
}
.btn-confirm,.btn-cancel{
    cursor: pointer;
    border-radius:6px;
}
.btn-confirm:hover{
    background: orange;
}
.btn-cancel:hover{
    background: #e5e5e5;
}

</style>
