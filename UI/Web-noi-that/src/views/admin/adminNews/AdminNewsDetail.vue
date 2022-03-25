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
                        <h-input :title="'Tiêu đề tin tức'" placeholder="Tiêu đề tin tức" v-model="news.newsTitle" />
                    </div>
                </div>
                <div class="h-row h-display-flex">
                    <div class="h-col h-flex">
                        <h-textarea :title="'Nội dung tin tức'" placeholder="Nội dung tin tức" v-model="news.newsContent" />
                        </div>
          </div>
          <div class="h-row h-display-flex">
            <div class="h-col h-flex">
              <h-input-file :title="'Ảnh tin tức'" ref="inputFile" :name="news.linkImage"/>
            </div>
          </div>
          <div class="h-row h-display-flex">
            <div class="h-col h-flex">
              <h-input :title="'Tin hot'"
               placeholder="Tin hot"
                 v-model="news.newsHot"
                  />
            </div>
            <div class="h-col h-flex ml-10">
              <h-input :title="'Tin sản phẩm'"
               placeholder="Tin sản phẩm"
                  v-model="news.newsProduct"
                />
            </div>
          </div>
          <div class="h-row h-display-flex">
            <div class="h-col h-flex">
              <h-input :title="'Tin khuyến mại'"
               placeholder="Tin khuyến mại"
                v-model="news.newsSale"
                />
            </div>
            <div class="h-col h-flex ml-10">
              <h-input :title="'Tin sự kiện'"
               placeholder="Tin sự kiện"
                 v-model="news.newsEvent"
                  />
            </div>
          </div>
          <div class="h-row h-display-flex">
            <div class="h-col">
              <h-input :title="'Tin trang chủ'"
               placeholder="Tin trang chủ"
                 v-model="news.newsHome"
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
            <div class="h-button h-btn-save" @click="saveNews">Lưu</div>
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
    ModuleNews
} from "@/store/module-const";
export default {
    components: {
    },
    name: "AdminNewsDetail",
    props: {
        isShow: {
            typeof: Boolean,
            default: false,
        },
        news: {
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
                return me.$t("i18nNews.addNews");
            }
            if (me.mode == 1) {
                return me.$t("i18nNews.editNews");
            }
            return "";
        },
    },
    methods: {
        ...mapActions(ModuleNews, [
            "addNewsAsync",
            "editNewsAsync",
        ]),

        insertNews(params) {
            const me = this;

            me.addNews(params);
        },
        async loadData() {
            const me = this;
            await me.$emit("loadData");
        },
        async saveNews() {
            const me = this;
            if(me.$refs.inputFile.fileName){
                  me.news.linkImage = "";
            }
            me.news.linkImage = this.$commonFunc.convertImgSaveDB(me.$refs.inputFile.fileName);
            // Thêm
            if (me.mode == "add") {
                await me.addNewsAsync(me.news);
            }
            // Sửa
            else if (me.mode == "edit") {
                await me.editNewsAsync(me.news);
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
