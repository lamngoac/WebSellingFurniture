<template>
<div class="container p-5 h-content-table-admin">
    <div class="row">
        <div class="col-md-offset-1">
            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Danh sách danh mục sản phẩm</h3>
                        </div>
                        <div style="width:300px;">
                            <h-input v-model="params.Filter" placeholder="Tìm kiếm" @keyup="filterData" />
                        </div>
                        <div class="col col-xs-6 text-right" style="justify-content: flex-end; display: flex">
                            <div type="button" class="btn btn-sm btn-add h-display-flex" @click="addProductCategory">
                                <div>Thêm mới</div>
                            </div>
                        </div>
                    </div>
                </div>
                <h-grid 
                    :columns="columns"
                    :data="productCategories"
                    :pageSize="params.PageSize"
                    :pageIndex="params.PageIndex"
                    :fieldId="'productCategoryId'"
                    @deleteData="deleteProductCategory"
                    @editData="editProductCategory"
                >
                </h-grid>
                <div class="h-pagination">
                    <h-pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'danh muc san pham'" />
                </div>
            </div>
        </div>
    </div>
    <AdminProductCategoryDetail :isShow="isShow" @closePopup="setStatePopup(false)" @showPopup="setStatePopup(true)" :productCategory="productCategory" :mode="mode" @loadData="getData" />
</div>
</template>

<script>
import {
    mapActions
} from "vuex";
import {
    ModuleProductCategory
} from "@/store/module-const";
import AdminProductCategoryDetail from "./AdminProductCategoryDetail.vue";
import {
    ProductCategory
} from "@/common/models/models";
import _ from 'lodash';
export default {
    components: {
        AdminProductCategoryDetail,
    },
    created() {
        const me = this;
        me.getData();
    },
    data() {
        return {
            productCategories: [],
            params: {
                PageIndex: 1,
                PageSize: 10,
                TotalRecord: 0,
                TotalPages: 0,
                Filter: "",
            },
            isShow: false,
            productCategory: ProductCategory(),

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
                    text :"Tên danh mục sản phẩm",
                    width : 200,
                    dataField :"productCategoryName"
                },
                {
                    text :"Mô tả",
                    width : 200,
                    dataField :"productCategoryDescription"
                },
                {
                    text :"Hình ảnh",
                    width : 200,
                    dataField :"productCategoryImage",
                    image : true
                },
                {
                    text : "Hiển thị ở trang chủ",
                    width : 200,
                    dataField :"productCategoryHome"
                }

            ]
        };
    },
    methods: {
        ...mapActions(ModuleProductCategory, [
            "getProductCategoriesPagging",
            "getProductCategoryById",
            "deleteProductCategoryAsync",
        ]),
        async getData() {
            const me = this;
            if (me.$refs.pagination) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getProductCategoriesPagging(me.params);
            if (res) {
                me.productCategories = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.productCategories = [];
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
        async addProductCategory() {
            const me = this;
            me.showPopup();
            me.mode = "add";
        },
        // bịp vl vcl

        async editProductCategory(id) {
            const me = this;
            // Lấy productCategory theo id

            me.productCategory = await me.getProductCategoryById(id);

            // Show popup
            me.showPopup();
            me.mode = "edit";
        },
        async deleteProductCategory(id) {
            const me = this;
            await me.deleteProductCategoryAsync(id);
            if (me.productCategories && me.productCategories.length == 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD - 1;
            } else if (me.productCategories && me.productCategories.length > 1) {
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getproductCategorysPagging(me.params);
            if (res) {
                me.productCategories = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.productCategories = [];
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
            me.productCategory = ProductCategory();
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
