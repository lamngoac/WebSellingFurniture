<template>
  <div class="container p-5 h-content-table-admin">
    <div class="row">
        <div class="col-md-offset-1">
            <div class="panel panel-default panel-table">
                <div class="panel-heading h-row-header">
                    <div class="row">
                        <div class="col col-xs-6">
                            <h3 class="panel-title">Danh sách dự án</h3>
                        </div>
                        <div style="width:300px;">
                          <h-input v-model="params.Filter" placeholder="Tìm kiếm" @keyup="filterData"/>
                        </div>
                        <div class="col col-xs-6 text-right" style="justify-content: flex-end; display: flex">
                            <div type="button" class="btn btn-sm btn-add h-display-flex" @click="addProject">
                                <div>Thêm mới</div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- <div class="panel-body">
                    <table class="h-table">
                        <thead class="h-th-table">
                            <tr>
                                <th class="fix h-text-center width-100px">
                                    <em class="fa fa-cog"></em>
                                </th>
                                <th class="hidden-xs min-w-200px">Mã số</th>
                                <th class="min-w-200px">Tiêu đề dự án</th>
                                <th class="min-w-200px">Nội dung dự án</th>
                                <th class="min-w-200px">Link ảnh</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(project, index) in projects" :key="index">
                                <td align="center" class="btn_click">
                                    <a class="btn btn-default" @click="editProject(project.projectId)"><em class="fa fa-pencil"></em></a>
                                    <a class="btn btn-danger" @click="deleteProject(project.projectId)"><em class="fa fa-trash"></em></a>
                                </td>
                                <td class="hidden-xs">
                                    {{ params.PageSize * (params.PageIndex - 1) + index + 1 }}
                                </td>
                                <td>{{ project.projectTitle }}</td>
                                <td>{{ project.projectContent }}</td>
                                <td class="min-w-200px">
                                    <div class="img-prds__img ">
                                        <div title="" class="d-block" v-if="project.linkImage">
                                            <img :src="require('@/assets/content/images/'+ project.linkImage )" alt="" class="img-fluid" />
                                        </div>
                                        <div>
                                            {{project.linkImage }}
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div> -->
                 <h-grid 
                    :columns="columns"
                    :data="projects"
                    :pageSize="params.PageSize"
                    :pageIndex="params.PageIndex"
                    :fieldId="'projectId'"
                    @deleteData="deleteProject"
                    @editData="editProject"
                >
                </h-grid>
                <div class="h-pagination">
                    <h-pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'du an'" />
                </div>
            </div>
        </div>
    </div>
    <AdminProjectDetail
      :isShow="isShow"
      @closePopup="setStatePopup(false)"
      @showPopup="setStatePopup(true)"
      :project="project"
      :mode="mode"
      @loadData="getData"
    />
  </div>
</template>

<script>
import { mapActions } from "vuex";
import { ModuleProject } from "@/store/module-const";
import AdminProjectDetail from "./AdminProjectDetail.vue";
import { Project } from "@/common/models/models";
import _ from "lodash";
export default {
  components: {
    AdminProjectDetail,
  },
  created() {
    const me = this;
    me.getData();
  },
  data() {
    return {
      projects: [],
      params: {
        PageIndex: 1,
        PageSize: 10,
        TotalRecord: 0,
        TotalPages: 0,
        Filter: "",
      },
      isShow: false,
      project: Project(),

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
                    text :"Tiêu đề dự án",
                    width : 200,
                    dataField :"projectTitle"
                },
                {
                    text :"Nội dung dự án",
                    width : 200,
                    dataField :"projectContent"
                },
                {
                    text : "Ảnh",
                    width : 200,
                    dataField :"linkImage",
                    image:true
                }

            ]
        };
    },
    methods: {
        ...mapActions(ModuleProject, [
            "getProjectsPagging",
            "getProjectById",
            "deleteProjectAsync",
        ]),
        async getData() {
            const me = this;
            if(me.$refs.pagination){
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getProjectsPagging(me.params);
            if(me.$refs.pagination){
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            if (res) {
                me.projects = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.projects = [];
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
    async addProject() {
      const me = this;
      me.showPopup();
      me.mode = "add";
    },

    async editProject(id) {
      const me = this;
      // Lấy project theo id

      me.project = await me.getProjectById(id);

      // Show popup
      me.showPopup();
      me.mode = "edit";
    },
    async deleteProject(id) {
      const me = this;
      await me.deleteProjectAsync(id);
      if (me.projects && me.projects.length == 1) {
        me.params.PageIndex = me.$refs.pagination.pageIndexD - 1;
      } else if (me.projects && me.projects.length > 1) {
        me.params.PageIndex = me.$refs.pagination.pageIndexD;
      }
      let res = await me.getProjectsPagging(me.params);
      if (res) {
        me.projects = [...res.data];
        me.params.PageIndex = res.pageIndex;
        me.params.PageSize = res.pageSize;
        me.params.TotalRecord = res.totalRecord;
        me.params.TotalPages = res.totalPages;
      }
      if (!res) {
        me.projects = [];
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
      me.project = Project();
    },

    /**
     * Hàm sử lí việc lọc data tìm kiếm
     */
    filterData: _.debounce(function () {
      const me = this;
      me.getData();
    }, 500),
  },
};
</script>

<style scoped>
@import "../../../assets/content/css/common/tableAdmin.css";
</style>
