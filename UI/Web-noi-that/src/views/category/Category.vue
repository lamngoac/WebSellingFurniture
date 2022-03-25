<template>
<div>
    <section class="section_banner img">
        <img src="../../assets/content/images/banner_cate.jpg" class="img-fluid" alt="">
    </section>
    <section class="page_category">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 category__filter">
                    <aside class="sidebar">
                        <div class="ls_category box_content wow fadeInUp">
                            <p class="title">Danh mục sản phẩm</p>
                            <div class="ls_ul">
                                <div class="ls_list">
                                    <label v-for="(category,index) in productCategories" :key="index" class="box_checkbox">
                                        <input v-model="categoriesCheck[index]" @click="clickCheck(index,category.productCategoryId)" style="width:20px;height:20px" type="checkbox" name="category">
                                        <span>{{ category.productCategoryName }}</span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="price_range box_content wow fadeInUp">
                            <p class="title">Khoảng giá</p>
                            <div class="ls_list">
                                <label v-for="(item,index) in prices" :key="index" class="box_checkbox">
                                    <input @click="getDataPriceCheck(index,item)" v-model="pricesCheck[index]" type="checkbox" name="" value="">
                                    <span class="name">Dưới {{ item }} triệu</span>
                                </label>
                            </div>
                        </div>
                    </aside>
                </div>
                <div class="col-lg-9">
                    <div class="category__filter-icon__wrapper d-flex d-lg-block justify-content-between align-items-center">
                        <p class="title_page mb-lg-4 mb-0 text-uppercase wow fadeInUp">Nội thất gỗ</p>
                    </div>
                    <form action="" method="POST" class="frm_filter wow fadeInUp d-lg-block d-none" accept-charset="utf-8">
                        <div class="row">
                            <div class="col-xl-6 mb-md-0 mb-3 h-display-flex">
                                <h-combobox
                                    :class="'h-display-flex'"
                                    :title="'Sắp xếp theo:'"
                                    :data="conditionSort"
                                    :keyData="'key'"
                                    :display="'name'"
                                    :value="statusPrice"
                                    @changeCombobox="changeSortPrice"
                                >
                                </h-combobox>
                            </div>
                            <div class="col-xl-6 d-flex flex-wrap justifly-content-between align-items-center h-input-search">
                                <Input placeholder="Tìm kiếm" @change="inputSearch" v-model="params.Filter" :icon="'icon-search icon-16'"/>
                            </div>
                        </div>
                    </form>
                    <div class="row row-cols-xxl-5 row-cols-md-5 row-cols-2 mt-lg-5 pt-lg-2 mt-3 gx-0" v-if="products">
                        <div class="col" v-for="(product,index) in products" :key="index" @click="selectProduct(product.productId)">
                            <div class="sale-prd__item h-100 wow fadeInUp">
                                <div class="_img-link d-block" title="" v-if="product.productImage">
                                     <img :src="require('@/assets/content/images/'+ product.productImage)" alt="" class="img-fluid">
                                </div>
                                <div class="_link d-block mb-sm-2 mb-1 mt-lg-4 mt-md-3 mt-2" title="">{{ product.productName }}</div>
                                <div class="sale-prd__content d-flex justify-content-between align-items-center">
                                    <div class="sale-prd__price-rating">
                                        <div class="_price mb-sm-2 mb-1">Giá gốc : <span class="text-money text-money-original">{{product.productOriginalPrice | formatMoney}}</span></div>
                                        <div class="_price mb-sm-2 mb-1">Giá sale : <span class="text-money text-money-sale">{{product.productSalePrice | formatMoney}}</span></div>
                                        <div class="_rating position-relative mb-2">
                                            <div class="_star position-absolute top-0 start-0">
                                                <span v-for="index1 in product.productEvaluate > 5 ? 5 : product.productEvaluate" :key="index1"><i class="fa fa-star" aria-hidden="true"></i></span>
                                            </div>
                                            <div class="_star-blank">
                                                <span v-for="index1 in 5" :key="index1"><i class="fa fa-star-o" aria-hidden="true"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div v-if="products.length == 0" class="text-not-data">
                        <div>Không có dữ liệu</div>
                    </div>
                    <div class="h-pagination">
                        <Pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'sản phẩm'" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
</template>

<script>
import Pagination from '../components/pagination/Pagination.vue'
import Input from '@/views/components/input/Input'
import {
    mapActions
} from 'vuex';
import {ModuleProductCategory,ModuleProduct} from '@/store/module-const';
export default {
    components:{
        Pagination,
        Input
    },
    async created(){
        const me = this;
        await me.getDataCategories();
        await me.getData();

        await me.setPriceCheck();
        if(me.$route && me.$route.params && me.$route.params.id && me.productCategories){
            let res = [...me.productCategories.filter(x => x.productCategoryId == me.$route.params.id)];
            if(res && res.length == 1){
                let index = me.productCategories.indexOf(res[0]);
                me.clickCheck(index,me.$route.params.id);
            }
        }
       
    },
    data(){
        return{
            styles: ["Hiện đại", "Cổ điển", "Luxury", "Chung cư", "Nhà phố"],
            materials: ["Gỗ thông", "Gỗ Sồi", "Gỗ công nghiệp", "Gỗ nhập khẩu", "Gỗ Lim"],
            productCategories : [],
           
            products : [],
            
            
            img : "project1",

            categoriesCheck : [],
            /**
             * Data ảo để lọc giá tiền product
             */
            prices : [6,11,16,21,26],
            pricesCheck : [],
            params :{
                PageIndex : 1,
                PageSize : 10,
                TotalRecord : 0,
                TotalPages : 0,
                Filter : "",  
                Sort : "Desc ProductSalePrice", 
                CategoryId : "",
                Price : 0 
            },

            conditionSort:[
                {
                    key : "Desc",
                    name : "Giá cao đến thấp"
                },
                {
                    key : "Asc",
                    name : "Giá thấp đến cao"
                }
            ],
            statusPrice : "Desc"
        }
        
    },
    methods:{
        ...mapActions(ModuleProductCategory,['getProductCategories']),
        ...mapActions(ModuleProduct,['getProductsPagging']),
        async getDataCategories(){
            const me = this;
            let res = await me.getProductCategories();
            if(res){
                me.productCategories = [...res];
            }
            for (let index = 0; index < me.productCategories.length; index++) {
                me.categoriesCheck.push(false);
            }
        },
        async getData(){
            const me = this;
            if(me.$refs.pagination){
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            me.getDataProduct();
        },  
        async getDataProduct(){
            const me = this;
            let res = await me.getProductsPagging(me.params);
            if(res){
                me.products = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if(!res){
                me.products = [];
                me.params = {
                    PageIndex : 1,
                    PageSize : 10,
                    TotalRecord : 0,
                    TotalPages : 0,
                    Filter : me.params.Filter,  
                    Sort : me.params.Sort, 
                    CategoryId : me.params.CategoryId,
                    Price : me.params.Price 
                }
            }
        },

        changeSortPrice(value){
            const me = this;
            me.statusPrice = value;
            me.params.Sort = `${value} ProductSalePrice`;
            me.getDataProduct(me.params);
        },
        handleBlur() {
        },
        handleFocus() {
        },
        filterOption(input, option){
            return (
                option.componentOptions.children[0].text.toLowerCase().indexOf(input.toLowerCase()) >= 0
            );
        },
        /**
         * Hàm sử lí tìm kiếm dữ liệu lọc
         */
        inputSearch(){
            const me = this;
            me.getDataProduct(me.params);
        },

        /**
         * Set data check box danh mục
         */
        setCategoriesCheck(){
            const me = this;
            for (let index = 0; index < me.productCategories.length; index++) {
                me.categoriesCheck = [];
                me.categoriesCheck.push(false);
            }
        },
        /**
         * Hàm sử lí sự kiện click checkbox danh mục
         */
        clickCheck(index,id){
            const me = this;
            me.params.PageIndex = 1;
            if(!me.categoriesCheck[index]){
                me.setCategoriesCheck();
                me.categoriesCheck[index] = true;
                me.params.CategoryId = id;
                if(me.$route && me.$route.params && me.$route.params.id != id){
                    me.$router.push(`/category/${id}`);
                }
                me.getDataProduct(me.params);
                return;
            }
            if(me.categoriesCheck[index]){
                me.setCategoriesCheck();
                me.params.CategoryId = "";
                me.$router.push(`/category`);
                me.getDataProduct(me.params);
            }

        },

        setPriceCheck(){
            const me = this;
            for (let index = 0; index < me.prices.length; index++) {
                me.pricesCheck = [];
                me.pricesCheck.push(false);
            }
        },
        /**
         * Hàm sử lí lọc dữ liệu về giá
         */
        getDataPriceCheck(index,price){
            const me = this;
            me.params.PageIndex = 1;
            if(!me.pricesCheck[index]){
                me.setPriceCheck();
                me.pricesCheck[index] = true;
                me.params.Price = price;
                me.getDataProduct(me.params);
                return;
            }
            if(me.pricesCheck[index]){
                me.setPriceCheck();
                me.params.Price = 0;
                me.getDataProduct(me.params);
            }

        },

        // chọn xem chi tiết sản phẩm
        selectProduct(id){
            const me = this;
            me.$router.push(`/product-detail/${id}`);
        }
    }
}
</script>

<style scoped>
@import '../../assets/content/scss/category-mobile.css';

.text-money{
    font-size: 12px;
}
.text-money-original{
     text-decoration: line-through !important;
}
.text-money-sale{
}
.text-not-data{
    height: 200px;
    line-height: 200px;
    width: 100%;
    background: #e5e5e5;
    text-align: center;
    font-weight: bold;
    font-size: 20px;
}
</style>
