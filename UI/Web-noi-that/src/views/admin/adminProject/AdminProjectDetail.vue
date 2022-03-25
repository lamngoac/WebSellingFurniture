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
                        <h-input :title="'Tiêu đề dự án'" placeholder="Tiêu đề dự án" v-model="project.projectTitle" />
                    </div>
                </div>
                <div class="h-row h-display-flex">
                    <div class="h-col h-flex">
                        <h-textarea :title="'Nội dung dự án'" placeholder="Nội dung dự án" v-model="project.projectContent" />
                        </div>
          </div>
          <div class="h-row h-display-flex">
            <div class="h-col h-flex">
              <h-input-file :title="'Ảnh dự án'" ref="inputFile" :name="project.linkImage"/>
            </div>
          </div>
             <div class="h-row h-display-flex">
            <div class="h-col h-flex">
              <h-input :title="'Hiển thị ở trang chủ'"
               placeholder="Hiển thị ở trang chủ"
                v-model="project.projectHome"
                />
            </div>
            <div class="h-col h-flex ml-10">
              <h-input :title="'Dự án nổi bật'"
               placeholder="Dự án nổi bật"
                 v-model="project.projectHot"
                  />
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
            <div class="h-button h-btn-save" @click="saveProject">Lưu</div>
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
    ModuleProject
} from "@/store/module-const";
export default {
    components: {
    },
    name: "AdminProjectDetail",
    props: {
        isShow: {
            typeof: Boolean,
            default: false,
        },
        project: {
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

        };
    },
    computed: {
        titlleMode() {
            const me = this;
            if (me.mode == 0) {
                return me.$t("i18nProject.addProject");
            }
            if (me.mode == 1) {
                return me.$t("i18nProject.editProject");
            }
            return "";
        },
    },
    methods: {
        ...mapActions(ModuleProject, [
            "addProjectAsync",
            "editProjectAsync",
        ]),
        async loadData() {
            const me = this;
            await me.$emit("loadData");
        },
        async saveProject() {
            const me = this;
            if (me.$refs.inputFile.fileName) {
                me.project.linkImage = "";
            }
            me.project.linkImage = me.$commonFunc.convertImgSaveDB(me.$refs.inputFile.fileName);
            // Thêm
            if (me.mode == "add") {
                await me.addProjectAsync(me.project);
            }
            // Sửa
            else if (me.mode == "edit") {
                await me.editProjectAsync(me.project);
            }
            me.loadData();
            me.closePopup();
        },
        closePopup() {
            const me = this;
            me.$emit("closePopup");
        },
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
