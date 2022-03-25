<template>
<div>
    <section class="cards container">
        <span class="title_cards">Giỏ hàng của bạn</span>
        <span class="card_d" v-if="orders && orders.length >= 1">( {{ orders.length }} sản phẩm) </span>
        <div v-if="getSelectedOrders && getSelectedOrders.length > 0" class="h-text-select">
            <div>
                Đã chọn <span class="font-bold">{{ getSelectedOrders.length }}</span> sản phẩm
            </div>
            <div class="h-display-flex text-center h-delete-orders h-ml-15" @click="deleteCart">
                <div class="icon-46 icon-delete-big"></div>
                <div class="ml-10 font-bold">Xóa</div>
            </div>
        </div>
        <div v-if="orders && orders.length > 0">
            <div class="tables-alls tables-prds__carts mb-lg-4 mb-3">
                <table class=" table">
                    <thead>
                        <tr>
                            <th class="jus-center">
                                <input type="checkbox" style="width:20px;height:20px" v-model="selectMul" @click="clickMultiple"/>
                            </th>
                            <th>Sản phẩm</th>
                            <th> Tên sản phẩm</th>
                            <th> Giá </th>
                            <th> Số lượng</th>
                            <th>Thành tiền</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(order,index) in orders" :key="index" class="tr">
                            <td class="jus-center">
                                <input type="checkbox" style="width:20px;height:20px" v-model="order.selected"/>
                            </td>
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
                                <p class="main-price-cart price-cart"> <strong class="price d-block main-price" data-price="0">{{ order.product.productSalePrice | formatMoney}}đ</strong> </p>
                            </td>
                            <td>
                                <div class="product-many">
                                    <div class="quanty form-group">
                                        <div class="inputNumberMinus value-button down-btns btn-plus" value="Decrease Value" @click="minusOrder(index)">−</div>
                                        <div style="padding-left:15px;padding-right:15px">{{ order.amount }}</div>
                                        <div class="inputNumberPlus value-button up-btns btn-minus" value="Increase Value" @click="plusOrder(index)">+</div>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <p class="main-price-cart price-cart"> <strong class="price prices d-block subtotal">{{ (order.product.productSalePrice * order.amount) | formatMoney }}đ</strong></p>
                            </td>
                            <td>
                                <p class="_tech5s_cart_delete_cart delete-carts__items" @click="removeOrder(index)"> <i class="fa fa-trash-o" aria-hidden="true"></i> </p>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="item">
                <div class="row">
                    <div class="col-lg-6 ">
                        <div class="btn-all d-flex">
                            <div @click="buyProduct" class=" btn-default btn-set bt-img btn-buy-continue"> Tiếp tục mua hàng <img src="../../assets/content/images/arrow-right.svg" alt="Xem thêm" class=""> </div>
                            <div @click="updateCart" class="  btn-default btn-set btl-mr btn-update-cart"> <img src="../../assets/content/images/update.svg" alt="Xem thêm" class=" ml-2">Cập nhật giỏ hàng</div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="box-card ">
                            <p class=" item_total"> Tổng giỏ hàng </p>
                            <p class=" item_arena"> Số lượng <span class="">{{ totalAmount }}</span></p>
                            <p class=" item_arena"> Tổng tiền: <span class="price"> {{ totalMoney | formatMoney}} đ</span> </p>
                            <div class="btn-default  btn-set btn-confirm" @click="confirmPayment"> Tiến hành thanh toán <img src="../../assets/content/images/arrow-right_black.svg" alt="Xem thêm" class="ms-2"> </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div v-else class="not-oder-cart">
            <div>
                <div class="text-not-order">Không có sản phẩm nào trong giỏ hàng của bạn</div>
                <div @click="buyProduct" class=" btn-default btn-set bt-img btn-buy-continue"> Tiếp tục mua hàng <img src="../../assets/content/images/arrow-right.svg" alt="Xem thêm" class=""> </div>
            </div>
        </div>
    </section>
</div>
</template>

<script>
import {
    mapActions
} from 'vuex';
export default {
    data() {
        return {
            orders: [],
            selectMul : false,
            ordersSelect : [],
        }
    },
    created() {
        const me = this;
        me.getOrders();
    },
    beforeDestroy() {
        const me = this;
        me.updateCart();
    },
    mounted() {},
    watch: {
        getSelectedOrders(){
            const me = this;
            if(me.getSelectedOrders && me.getSelectedOrders.length == me.orders.length){
                me.selectMul = true;
            }
            else{
                me.selectMul = false;
            }
        }
    },
    computed: {
        totalAmount() {
            const me = this;
            let orders = [...me.orders.filter(x => x.selected)];
            if (orders && orders.length > 1) {
                return orders.reduce((a, {
                    amount
                }) => a + amount, 0);
            }
            if (orders && orders.length == 1) {
                return orders[0].amount;
            }
            return 0;
        },
        totalMoney() {
            const me = this;
            let orders = [...me.orders.filter(x => x.selected)];
            if (orders && orders.length > 1) {
                return orders.reduce((a, {
                    amount,
                    product
                }) => a + amount * product.productSalePrice, 0);
            }
            if (orders && orders.length == 1){
                return orders[0].amount * orders[0].product.productSalePrice;
            }
            return 0;
        },

        getSelectedOrders(){
            const me = this;
            if(me.orders && me.orders.length > 0){
                let res = [...me.orders.filter(x => x.selected)];
                return res;
            }
            return null;
        }
    },
    methods: {
        ...mapActions(["getCartByUser"]),
        /**
         * Lấy đanh sách đơn hàng trrong giỏ
         */
        async getOrders() {
            const me = this;
            let userName = me.$commonFunc.getUserName()
            let res = await me.getCartByUser(userName);
            if (res) {
                me.orders = res.map((x) => {
                    return{
                        selected : false,
                        amount : x.amount,
                        product : x.product
                    }

                });
                
            }
            
        },
        /**
         * Xóa đơn hàng
         */
        removeOrder(index) {
            const me = this;
            me.orders.splice(index, 1);
        },

        /**
         * Hàm sử lí việc giảm sản phẩm của từng dòng 
         */
        minusOrder(index) {
            const me = this;
            if (me.orders[index].amount > 1) {
                me.orders[index].amount -= 1;
            } else {
                me.removeOrder(index);
            }
        },
        /**
         * Hàm sử lí việc thêm sản phẩm của từng dòng 
         */
        plusOrder(index) {
            const me = this;
            if (me.orders[index].amount <= 100) {
                me.orders[index].amount += 1;
            }
        },

        /**
         * tiếp tục mua
         */
        buyProduct() {
            const me = this;
            me.$router.push("/category")
        },
        
        resetCart() {
            const me = this;
            if (me.$commonFunc.getUserName()) {
                me.$commonFunc.resetCartByUser(me.$commonFunc.getUserName());
            }
        },
        /**
         * Hàm sử lí việc cập nhật lại giỏ hàng
         */
        async updateCart() {
            const me = this;
            me.resetCart();
            if (me.orders) {
                for (let i = 0; i < me.orders.length; i++) {
                    me.$commonFunc.addCart(me.$commonFunc.getUserName(), me.orders[i]);
                }
            }
            await me.getOrders();
        },
        /**
         * hàm sử lí xác nhận thanh toán
         */
        confirmPayment() {
            const me = this;
            if(me.totalMoney != 0){
                me.$router.push("/cart-pay");
                me.updateCart();
            }
        },

        clickMultiple(){
            const me = this;
            if(!me.selectMul){
                me.selectOrders(true);
            } 
            else{
                me.selectOrders(false);
            }
        },
        selectOrders(status){
            const me = this;
            if(me.orders && me.orders.length > 0){
                me.orders = me.orders.map((x) => {
                    return{
                        selected : status,
                        amount : x.amount,
                        product : x.product
                    }
                })
            }
        },
        deleteCart(){
            const me = this;
            me.orders = [...me.orders.filter(x => !x.selected)];
            me.updateCart();
        }
    }
}
</script>

<style scoped>
.h-text-select{
    font-size: 20px;
    display: flex;
    margin-bottom: -20px;
    margin-top: 20px;
    align-items: center;
}
.h-delete-orders{
    align-items: center;
    cursor: pointer;
    padding:10px;
    padding-right: 10px;
    border-radius:6px;
}
.h-delete-orders:hover{
    box-shadow: 1px 1px 1px 1px #e5e5e5,1px 1px 1px 1px #e5e5e5;;
}
.icon-delete-big{
    cursor: pointer;
}
thead, tbody, tfoot, tr, td, th{
    border-style: none !important;
}
tr{
    border-bottom: 1px solid #e5e5e5 !important;
}
tr td,tr th{
    border-left:1px solid #e5e5e5 !important ;
}
.jus-center{
    display: flex !important;
    justify-content: center !important;
}
.btn-buy-continue {
    cursor: pointer;
}

.btn-buy-continue:hover {
    background: #e5e5e5;
}

.btn-update-cart {
    cursor: pointer;
}

.btn-update-cart:hover {
    background: #e5e5e5;
}

.not-oder-cart {
    background: #e5e5e5;
    height: 250px;
    display: flex;
    justify-content: center;
    align-items: center;
}

.text-not-order {
    margin-bottom: 25px;
}

.btn-plus,
.btn-minus {
    cursor: pointer;
}

.btn-plus:hover,
.btn-minus:hover {}

.btn-confirm:hover {
    background: orange;
}
</style>
