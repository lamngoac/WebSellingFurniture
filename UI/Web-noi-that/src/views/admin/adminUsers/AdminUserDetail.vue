<template>
    <div class="h-popup" v-if="isShow">
        <h-popup @closePopup="closePopup" :width="600" :height="450">
            <template slot="header">
                <div class="h-titlte">
                    {{ titlleMode }}
                </div>
            </template>
            <template slot="content">
                <div>
                    <div class="h-row h-display-flex h-mg-t10">
                        <div class="h-col h-flex">
                            <h-input ref="firstInput" :title="'Tài khoản'" placeholder="Tài khoản" v-model="user.userName"/>
                        </div>
                        <div class="h-col h-flex ml-10">
                            <h-input :title="'Mật khẩu'" placeholder="Mật khẩu" v-model="user.password"/>
                        </div>
                    </div>
                     <div class="h-row h-display-flex">
                        <div class="h-col h-flex">
                            <h-input :title="'Họ và tên'" placeholder="Họ và tên" v-model="user.fullName"/>
                        </div>
                        <div class="h-col h-flex ml-10">
                            <h-input :title="'Địa chỉ'" placeholder="Địa chỉ" v-model="user.address"/>
                        </div>
                    </div>
                     <div class="h-row h-display-flex">
                        <div class="h-col h-flex">
                            <h-input :title="'Số điện thoại'" placeholder="Số điện thoại" v-model="user.phoneNumber"/>
                        </div>
                    </div>
                </div>
            </template>
            <template slot="footer">
                <div style="width:100%">
                    <div class="h-display-flex jus-end">
                        <div class="h-button h-btn-cancel h-mr-15" @click="closePopup">Hủy bỏ</div>
                        <div class="h-button h-btn-save" @click="saveUser">Lưu</div>
                    </div>
                </div>
            </template>
        </h-popup>
    </div>
</template>

<script>
import { mapActions } from "vuex";
import { ModuleUser } from "@/store/module-const";
    export default {
        name : "AdminUserDetail",
        props:{
            isShow : {
                typeof: Boolean,
                default : false
            },
            user:{
                typeof: Object,
                default : null
            },

            mode : {
                typeof : String,
                default : "add"
            }
        },
        data() {
            return {
            }
        },
        watch:{
        },
        mounted(){
        },
        computed:{
            titlleMode(){
                const me = this;
                if(me.mode == 0){
                    return me.$t('i18nUser.AddUser');
                }
                if(me.mode == 1){
                    return me.$t('i18nUser.EditUser');
                }
                return "";
            }
        },
        methods:{
            ...mapActions(ModuleUser,["addUserAsync","editUserAsync"]),

            insertUser(params){
                const me = this;
                me.addUser(params);
            },
            async loadData(){
                const me = this;
                await me.$emit("loadData");
            },
            async saveUser(){
                const me = this;
                // Thêm
                if(me.mode == "add"){
                    await me.addUserAsync(me.user);
                }
                // Sửa
                else if(me.mode == "edit"){
                    await me.editUserAsync(me.user);
                }
                me.loadData();
                me.closePopup();
            },
            closePopup(){
                const me = this;
                me.$emit("closePopup");
            }
        }
    }
</script>

<style scoped>
.h-popup{
    /* position: sticky;
    background: #000000;
    width: 400px;
    height: 400px; */
}
.h-titlte{
    font-weight: bold;
    font-size: 18px;
}
.h-row{
    margin-bottom: 10px;
}
</style>