<template>
<div>
    <section class="page_detail product-detail">
        <div class="container" v-if="product">
            <div class="row overflow-hidden">
                <div class="col-lg-7">
                    <div class="row mx-0">
                        <div class="col-lg-3 col-4 overflow-hidden wow fadeInLeft">
                            <div class="slide_product_thumb">
                                <div class="swiper-container">
                                    <div class="swiper-wrapper">
                                        <div class="swiper-slide">
                                            <img v-if="product.productImage" :src="require('@/assets/content/images/'+ product.productImage) " class="img-fluid">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-9 col-8 wow fadeInUp">
                            <div class="slide_product">
                                <div class="swiper-container">
                                    <div class="swiper-wrapper">
                                        <div class="swiper-slide">
                                            <img v-if="product.productImage" :src="require('@/assets/content/images/'+ product.productImage) " class="img-fluid">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 mt-lg-0 mt-3 wow fadeInRight">
                    <h1 class="title_page mb-lg-3 pb-2 mb-3">{{ product.productName}}</h1>
                    <div class="d-flex flex-wrap justifly-content-between infomation mb-lg-3 mb-2">
                        <div class="_rating position-relative d-flex">
                            <div class="_star position-absolute top-0 start-0">
                                <span v-for="index1 in product.productEvaluate" :key="index1"><i class="fa fa-star" aria-hidden="true"></i></span>
                            </div>
                            <div class="_star-blank">
                                <span v-for="index2 in 5" :key="index2"><i class="fa fa-star-o" aria-hidden="true"></i></span>
                            </div>
                            <span class="ratting_point ms-2">{{ product.productEvaluate }}</span>
                        </div>
                        <!-- <div class="count_comment ">Bình luận: <span class="number">15</span></div> -->
                    </div>
                    <div class="box_specs">
                        <div class="recond_properties">
                            <span class="key">Kích thước: </span>
                            <span class="value">{{ product.productDimensions }}</span>
                        </div>
                        <div class="recond_properties">
                            <span class="key">Chất liệu: </span>
                            <span class="value">{{ product.productMaterial }}</span>
                        </div>
                        <div class="recond_properties">
                            <span class="key">Nhà cung cấp: </span>
                            <span class="value">{{ product.productManufacturer }}</span>
                        </div>
                        <div class="description">
                            <div class="s-content">
                                <p>{{ product.ProductDescriptionShort }}</p>
                            </div>
                        </div>
                        <div class="box_price">
                            <span class="price_stock">{{ product.productOriginalPrice | formatMoney}} đ</span>
                            <span class="price_sale">{{ product.productSalePrice | formatMoney}}đ</span>
                        </div>
                        <div class="box_action d-flex flex-wrap align-items-center">
                            <div class="box_qty">
                                <span class="title me-2 pe-1">Số lượng</span>
                                <div class="quanty change_qty" id="input_div">
                                    <button @click="minusOrder" class="inputNumberMinus moins">
                                        <img src="../../assets/content/images/minus.svg" alt="Trừ" :disabled="numberOrder==1">
                                    </button>
                                    <input type="number" name="qty" :value="numberOrder" class="qty number text-center" id="number" min="1" max="100">
                                    <button @click="plusOrder" class="inputNumberPlus plus">
                                        <img src="../../assets/content/images/plus_.svg" alt="Cộng" :disabled="numberOrder==100">
                                    </button>
                                </div>
                            </div>
                            <div></div>
                            <div class="icon-cart h-ml-15" @click="addCart">
                                <img src="../../assets/content/icon/icon-add-cart.png"  class="h-icon-cart" alt="Thêm giỏ hàng">
                            </div>
                        </div>
                        <div title="Đặt hàng ngay" class="btn_all smooth d-block btn-order-now" @click="orderNow">Đặt hàng ngay</div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section_all section_details__content" v-if="product">
        <div class="container">
            <div class="row">
                <div class="col-lg-9 mb-lg-0 mb-3">
                    <div class="box__detail_content wow fadeInUp">
                        <a-tabs default-active-key="1" @change="callback">
                            <a-tab-pane key="1" tab="Mô tả">
                                {{ product.productDescription}}
                            </a-tab-pane>
                            <a-tab-pane key="2" tab="Đánh giá và bình luận" force-render>
                                <h2>Để lại đánh giá của bạn</h2>
                                <a-rate v-model="value" />
                                <comment :id="product.productId"></comment>
                            </a-tab-pane>
                        </a-tabs>
                    </div>
                </div>
                <div class="col-lg-3 mb-lg-0 mb-3 wow fadeInUp">
                    <div class="selling-prod h-top-selling">
                        <p class="selling-prod__title pb-lg-3 pb-2 wow fadeInUp">TOP SẢN PHẨM BÁN CHẠY</p>
                        <div class="row row-cols-lg-1 row-cols-2 pb-lg-3 pb-2 gy-3">
                            <div v-for="(product,index) in productsTopSelling" :key="index" class="col selling-prod__item wow flipInX" :data-wow-delay="`${index*0.1}`+'s'" data-wow-duration="1s">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="_img-link" title="">
                                            <img v-if="product.productImage" class="_img img-fluid" :src="require('@/assets/content/images/'+ product.productImage)">
                                        </div>
                                    </div>
                                    <div class="col-sm-8">
                                        <div class="_link d-block mb-sm-2 mb-1">{{ product.productName}}</div>
                                        <div class="_rating position-relative mb-sm-2 mb-1">
                                            <div class="_star position-absolute top-0 start-0">
                                                <span v-for="index in product.productEvaluate" :key="index"><i class="fa fa-star" aria-hidden="true"></i></span>
                                            </div>
                                            <div class="_star-blank">
                                                <span v-for="index2 in 5" :key="index2"><i class="fa fa-star-o" aria-hidden="true"></i></span>
                                            </div>
                                        </div>
                                        <div class="_price">
                                            <span class="_regular-price fw-bold">{{ product.productOriginalPrice }}đ</span>
                                            <span class="_sale-price text-decoration-line-through">{{ product.productSalePrice }}đ</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
} from 'vuex';
import {
    ModuleProduct
} from '@/store/module-const';
import Comment from '../comment/Comment.vue'
export default {
    components: {
        comment: Comment,

    },
    data() {
        return {
            id: "",
            product: null,
            numberOrder: 1,
            productsTopSelling: [],
            order: {},
            value: 2,
        }
    },
    async created() {
        const me = this;
        if (me.$route && me.$route.params && me.$route.params.id) {
            let res = await me.getProductById(me.$route.params.id);
            if (res) {
                me.product = {
                    ...res
                };
                me.order = {
                    product: me.product,
                    amount: me.numberOrder
                }
            }
        }
        // lấy 5 sản phẩm bán chạy nhất
        let products = await me.getProductsTopSelling(5);
        if (products) {
            me.productsTopSelling = [...products];
        }

    },
    methods: {
        ...mapActions(ModuleProduct, ['getProductById', 'getProductsTopSelling']),
        ...mapActions(["getCartByUser"]),
        callback(key) {
            console.log(key);
        },
        /**
         * Hàm sử lí cộng sản phẩm vào giỏ hàng
         */
        plusOrder() {
            const me = this;
            if (me.numberOrder < 100) {
                me.numberOrder += 1;
            }
            me.order = {
                product: me.product,
                amount: me.numberOrder
            }
        },
        /**
         * Hàm sử lí trừ sản phẩm vào giỏ hàng
         */
        minusOrder() {
            const me = this;
            if (me.numberOrder > 1) {
                me.numberOrder -= 1;
            }
            me.order = {
                product: me.product,
                amount: me.numberOrder
            }
        },

        /**
         * Hàm sử lí việc thêm giỏ hàng
         */
        async addCart() {
            const me = this;
            let userName = me.$commonFunc.getUserName()
            if (userName) {
                me.$commonFunc.addCart(userName, me.order);
                //load lại giỏ hàng
                await me.getCartByUser(userName);
            } else {
                me.$router.push("/login");
            }
        },

        /**
         * Hàm sử lí việc đặt hàng ngay
         */
        orderNow() {
            const me = this;
            if (me.$commonFunc.getUserName()){
                me.order.selected = true;
                me.$commonFunc.addCart(me.$commonFunc.getUserName(), me.order);
                me.$router.push("/cart-pay");
            }
                
        }

    }
}
</script>

<style scoped>
.product-detail {
    margin-top: 30px;
}

.icon-cart {
    cursor: pointer;
}

.btn-order-now {
    cursor: pointer;
}

.btn-order-now:hover {
    background: orange !important;
}

.h-top-selling {
    min-width: 300px;
    max-width: 300px;
}
.icon-hover:hover{
    background:orange;
}
.h-icon-cart:hover{
    box-shadow: 2px 2px 2px #e5e5e5;
    border-radius:4px;
}
</style>
