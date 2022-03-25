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
                            <h-input :title="'Tiều đề tuyển dụng'" placeholder="Tiều đề tuyển dụng" v-model="recruitment.recruitmentTitle" />
                        </div>
                    </div>
                     <div class="h-row h-display-flex">
                        <div class="h-col h-flex">
                            <h-textarea :title="'Nội dung tuyển dụng'" placeholder="Nội dung tuyển dụng"  v-model="recruitment.recruitmentContent"/>
                        </div>
                    </div>
                     <div class="h-row h-display-flex">
                        <div class="h-col h-flex">
                            <h-input-file :title="'Ảnh tuyển dụng'" :name="recruitment.linkImage" ref="h-inputFile"/>
                        </div>
                    </div>
                </div>
            </template>
            <template slot="footer">
                <div style="width:100%">
                    <div class="h-display-flex jus-end">
                        <div class="h-button h-btn-cancel h-mr-15" @click="closePopup">Hủy bỏ</div>
                        <div class="h-button h-btn-save" @click="saveRecruitment">Lưu</div>
                    </div>
                </div>
            </template>
        </h-popup>
    </div>
</template>

<script>
import { mapActions } from "vuex";
import { ModuleRecruitment } from "@/store/module-const";
    export default {
        components:{
        },
        name : "AdminRecruitmentDetail",
        props:{
            isShow : {
                typeof: Boolean,
                default : false
            },
            recruitment:{
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
                srcImg : null
            }
        },
        computed:{
            titlleMode(){
                const me = this;
                if(me.mode == 0){
                    return me.$t('i18nRecruitment.addRecruitment');
                }
                if(me.mode == 1){
                    return me.$t('i18nRecruitment.editRecruitment');
                }
                return "";
            },
        },
        methods:{
             ...mapActions(ModuleRecruitment,["addRecruitmentAsync","editRecruitmentAsync"]),
            async loadData(){
                const me = this;
                await me.$emit("loadData");
            },
            async saveRecruitment(){
                const me = this;
                if(me.$refs.inputFile.fileName){
                     me.recruitment.linkImage = "";
                }
                me.recruitment.linkImage = me.$commonFunc.convertImgSaveDB(me.$refs.inputFile.fileName);
                // Thêm
                if(me.mode == "add"){
                    await me.addRecruitmentAsync(me.recruitment);
                }
                // Sửa
                else if(me.mode == "edit"){
                    await me.editRecruitmentAsync(me.recruitment);
                }
                me.loadData();
                me.closePopup();
            },
            closePopup(){
                const me = this;
                me.$emit("closePopup");
            },
        }
    }
</script>

<style scoped>
.h-popup {
}
.h-titlte {
  font-weight: bold;
  font-size: 18px;
}
.h-row {
  margin-bottom: 10px;
}
</style>