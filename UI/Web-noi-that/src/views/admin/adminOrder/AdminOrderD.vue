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
                        <h-input :title="'Tài Khoản'" placeholder="Tài khoản" v-model=" order.userName" />
                    </div>
                </div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                        <h-input :title="'Số điện thoại'" placeholder="Số điện thoại" v-model="order.phoneNumber" />
                    </div>
                </div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                        <h-input :title="'Địa chỉ'" placeholder="Địa chỉ" v-model="order.address" />
                    </div>
                </div>
                <div class="h-row h-display-flex h-mg-t10">
                    <div class="h-col h-flex">
                      <h-combobox
                            :styleCombo="{width:100+'%'}"
                            :title="'Trạng thái đơn hàng'"
                            :classTitle="'h-mb-5 font-bold'"
                            :placeholder="'Trạng thái đơn hàng'"
                            :data="orderStatus"
                            :keyData="'id'"
                            :display="'name'"
                            :value="order.statusOrder"
                            @changeCombobox="changeOrderStatus"
                        >
                        </h-combobox>
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
                    <div class="h-button h-btn-save" @click="saveOrder">Lưu</div>
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
    ModuleOrder
} from "@/store/module-const";

export default {
    components: {},
    name: "Order",
    props: {
        isShow: {
            typeof: Boolean,
            default: false,
        },
        order: {
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
          orderStatus:[
                {name :"Chờ xác nhận",id:5},
                {name :"Chờ lấy hàng",id:1},
                {name :"Đang giao hàng",id:2},
                {name :"Giao hàng thất bại",id:3},
                {name :"Giao hàng thành công",id:4}
            ]
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
    },
    methods: {
        ...mapActions(ModuleOrder, [
            "addOrderAsync",
            "editOrderAsync",
        ]),

        insertOrder(params) {
            const me = this;

            me.addOrder(params);
        },
        async loadData() {
            const me = this;
            await me.$emit("loadData");
        },
        async saveOrder() {
            const me = this;
            // Thêm
            if (me.mode == "add") {
                await me.addOrderAsync(me.order);
            }
            // Sửa
            else if (me.mode == "edit") {
                await me.editOrderAsync(me.order);
            }
            me.loadData();
            me.closePopup();
        },

        clickSaveOrder() {
            const me = this;
            me.saveOrder(() => {
                me.$emit("loadData");
                // me.closePopup();
            });
        },
        closePopup() {
            const me = this;
            me.$emit("closePopup");
        },

        changeOrderStatus(value){
           const me = this;
            me.order.statusOrder = value;
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
</style>
