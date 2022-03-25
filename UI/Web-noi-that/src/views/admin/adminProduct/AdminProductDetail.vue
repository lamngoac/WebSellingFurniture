<template>
<div class="h-popup" v-if="isShow">
    <h-popup @closePopup="closePopup" :width="600" :height="500">
        <template slot="header">
            <div class="h-titlte">
                {{ titlleMode }}
            </div>
        </template>
        <template slot="content">
            <div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                        <h-combobox
                            :class="''"
                            :styleCombo="{width:100+'%'}"
                            :title="'Danh mục sản phẩm'"
                            :classTitle="'h-mb-5 font-bold'"
                            :placeholder="'Danh mục sản phẩm'"
                            :data="categories"
                            :keyData="'productCategoryId'"
                            :display="'productCategoryName'"
                            :defaultValue="categories[0]"
                            :value="product.productCategoryId"
                            @changeCombobox="changCategory"
                        >
                        </h-combobox>
                    </div>
                </div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                        <h-input :title="'Tên sản phẩm'" placeholder="Tên sản phẩm" v-model="product.productName" />
                    </div>
                </div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                        <h-input :title="'Kích thước'" placeholder="Kích thước" v-model="product.productDimensions" />
                    </div>
                    <div class="h-col h-flex ml-10">
                        <h-input :title="'Nguyên liệu'" placeholder="Nguyên liệu" v-model="product.productMaterial " />
                    </div>
                </div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                        <h-input :title="'Nhà sản xuất'" placeholder="Nhà sản xuất" v-model="product.productManufacturer " />
                    </div>
                    <div class="h-col h-flex ml-10">
                        <!-- <h-input :title="'Màu sắc'" placeholder="Màu sắc" v-model="product.ProductColor" /> -->
                        <h-combobox
                            :class="''"
                            :styleCombo="{width:100+'%'}"
                            :title="'Màu sắc'"
                            :classTitle="'h-mb-5 font-bold'"
                            :placeholder="'Màu sắc'"
                            :data="colors"
                            :keyData="'key'"
                            :display="'name'"
                            :value="colors[0].key"
                            @changeCombobox="changColor"
                        >
                        </h-combobox>
                    </div>
                </div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                        <h-input :title="'Giá gốc'" placeholder="Giá gốc" v-model=" product.productOriginalPrice" />
                    </div>
                    <div class="h-col h-flex ml-10">
                        <h-input :title="'Giá sale'" placeholder="Giá sale" v-model="product.productSalePrice" />
                    </div>
                </div>
                <div class="h-row h-display-flex">
                    <div class="h-col h-flex">
                        <h-textarea :title="'Mô tả ngắn'" placeholder="Mô tả ngắn" v-model=" product.productDescriptionShort" />
                        </div>
          </div>
          <div class="h-row h-display-flex">
            <div class="h-col h-flex">
              <h-textarea :title="'Mô tả'"
               placeholder="Mô tả" 
                v-model="product.productDescription"
                />
            </div>
          </div>
          <div class="h-row h-display-flex">
            <div class="h-col h-flex">
              <h-input :title="'Đánh giá'"
               placeholder="Đánh giá"
                v-model="product.productEvaluate"
                 />
            </div>
          </div>
          <div class="h-row h-display-flex">
            <div class="h-col h-flex">
              <h-input-file :title="'Ảnh sản phẩm'" ref="inputFile" :name="product.productImage"/>
            </div>
          </div>
        </div>
      </template>
      <template slot="footer">
        <div style="width: 100%">
          <div class="h-display-flex jus-end">
            <div class="h-button h-btn-cancel h-mr-15" @click="closePopup">
              Hủy bỏ
            </div>
            <div class="h-button h-btn-save" @click="saveProduct">Lưu</div>
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
    ModuleProduct,
    ModuleProductCategory
} from "@/store/module-const";
export default {
    components: {
    },
    name: "AdminProductDetail",
    props: {
        isShow: {
            typeof: Boolean,
            default: false,
        },
        product: {
            typeof: Object,
            default: null,
        },

        mode: {
            typeof: String,
            default: "add",
        },
    },
    data() {
        return {
            categories : [],

            colors:[
                {name :"xanh",key:1},
                {name :"nâu",key:2},
                {name :"vàng",key:3},
                {name :"nâu sẫm",key:4}
            ]
        };
    },
    computed: {
        titlleMode() {
            const me = this;
            if (me.mode == 0) {
                return me.$t("i18nProduct.addProduct");
            }
            if (me.mode == 1) {
                return me.$t("i18nProduct.editProduct");
            }
            return "";
        },
    },
    created(){
        this.getDataCategories();
    },
    methods: {
        ...mapActions(ModuleProduct, [
            "addProductAsync",
            "editProductAsync",
        ]),
         ...mapActions(ModuleProductCategory, [
            "getProductCategories",
        ]),
        async getDataCategories(){
            const me = this;
            let res = await me.getProductCategories();
            if(res){
                me.categories = [...res];
                if(!me.product.productCategoryId){
                    me.product.productCategoryId = me.categories[0].productCategoryId;
                }
            }
        },
        async loadData() {
            const me = this;
            await me.$emit("loadData");
        },
        async saveProduct() {
            const me = this;
            if(me.$refs.inputFile.fileName){
                  me.product.productImage = "";
            }
            me.product.productImage = me.$commonFunc.convertImgSaveDB(me.$refs.inputFile.fileName);
            // Thêm
            if (me.mode == "add") {
                await me.addProductAsync(me.product);
            }
            // Sửa
            else if (me.mode == "edit") {
                await me.editProductAsync(me.product);
            }
            me.loadData();
            me.closePopup();
        },
        closePopup() {
            const me = this;
            me.$emit("closePopup");
        },

        changCategory(value){
            const me = this;
            me.product.productCategoryId = value;
        },
        changColor(value){
            const me = this;
            me.product.productColor = value;
        }
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
/* .h-dropdowm-combobox{
    z-index: 1600 !important;
} */
</style>
