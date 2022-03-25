<template>
<div class="container p-5 h-content-table-admin">
    <div class="row">
        <div class="col-md-offset-1">
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Danh sách sản phẩm</h3>
                        </div>
                        <div style="width:300px;">
                          <h-input v-model="params.Filter" placeholder="Tìm kiếm" @keyup="filterData"/>
                        </div>
                        <div class="col col-xs-6 text-right" style="justify-content: flex-end; display: flex">
                            <div type="button" class="btn btn-sm btn-add h-display-flex" @click="addProduct">
                                <div>Thêm mới</div>
                            </div>
                        </div>
                    </div>
                </div>
                <h-grid 
                    :columns="columns"
                    :data="products"
                    :pageSize="params.PageSize"
                    :pageIndex="params.PageIndex"
                    :fieldId="'productId'"
                    @deleteData="deleteProduct"
                    @editData="editProduct"
                >
                </h-grid>
                <div class="h-pagination">
                    <h-pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'san pham'" />
                </div>
            </div>
        </div>
    </div>
    <AdminProductDetail :isShow="isShow" @closePopup="setStatePopup(false)" @showPopup="setStatePopup(true)" :product="product" :mode="mode" @loadData="getData" />
</div>
</template>

<script>
import {
    mapActions
} from "vuex";
import {
    ModuleProduct
} from "@/store/module-const";
import AdminProductDetail from "./AdminProductDetail.vue";
import {
    Product
} from "@/common/models/models";

import _ from 'lodash';
export default {
    components: {
        AdminProductDetail,
    },
    created() {
        const me = this;
        me.getData();
    },
    data() {
        return {
            products: [],
            params: {
                PageIndex: 1,
                PageSize: 10,
                TotalRecord: 0,
                TotalPages: 0,
                Filter: "",
                Sort: "",
                CategoryId: "",
                Price: 0
            },
            isShow: false,
            product: Product(),

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
                // {
                //     text :"Danh mục sản phẩm",
                //     dataField :"productName"
                // },
                {
                    text :"Tên sản phẩm",
                    dataField :"productName"
                },
                {
                    text :"Kích thước",
                    dataField :"productDimensions"
                },
                {
                    text : "Nguyên liệu",
                    dataField :"productMaterial"
                },
                {
                    text :"Nhà sản xuất",
                    dataField :"productManufacturer",
                },
                {
                    text :"Màu sắc",
                    dataField :"productColor",
                    format : this.$enum.Format.Color
                },
                {
                    text : "Giá gốc",
                    dataField :"productOriginalPrice",
                    format : this.$enum.Format.Money
                },
                {
                    text :"Giá sale",
                    dataField :"productSalePrice",
                    format : this.$enum.Format.Money
                },
                {
                    text : "Mô tả ngắn",
                    dataField :"productDescriptionShort"
                },
                {
                    text :"Mô tả",
                    dataField :"productDescription"
                },
                {
                    text : "Đánh giá",
                    dataField :"productEvaluate"
                },
                {
                    text : "Ảnh",
                    dataField :"productImage",
                    image:true,
                }



            ]
        };
    },
    methods: {
        ...mapActions(ModuleProduct, [
            "getProductsPagging",
            "getProductById",
            "deleteProductAsync",
        ]),
        async getData() {
            const me = this;
            if(me.$refs.pagination){
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getProductsPagging(me.params);
            if (res) {
                me.products = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.products = [];
                me.params = {
                    PageIndex: 1,
                    PageSize: 10,
                    TotalRecord: 0,
                    TotalPages: 0,
                    Sort: "",
                    CategoryId: "",
                    Price: 0,
                    Filter: me.params.Filter,
                };
            }
        },

        async addProduct() {
            const me = this;
            me.showPopup();
            me.mode = "add";
        },
        // bịp vl vcl

        async editProduct(id) {
            const me = this;
            // Lấy Product theo id
            me.product = await me.getProductById(id);

            // Show popup
            me.showPopup();
            me.mode = "edit";
        },
        async deleteProduct(id) {
            const me = this;
            await me.deleteProductAsync(id);
            if (me.products && me.products.length == 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD - 1;
            } else if (me.products && me.products.length > 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getProductsPagging(me.params);
            if (res) {
                me.products = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.products = [];
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
            me.product = Product();
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
