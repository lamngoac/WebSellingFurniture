<template>
<div>
    <div class="panel-body">
        <table class="h-table">
            <thead class="h-th-table">
                <tr>
                    <th v-for="(col,index) in columns" :key="index" :class="col.center ? col.center : ''" :style="col.width  ? {'min-width':col.width+'px'} : ''">
                        <div class="h-display-flex table-th" :class="col.center ? 'jus-center' : ''">
                            {{ col.text }}
                            <em v-if="col.icon" class="fa fa-cog"></em>
                        </div>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, index) in data" :key="index">
                    <td v-for="(col,index1) in columns" :key="index1" :class="col.center ? `${col.center}` : ''">
                        <div v-if="col.icon" class="h-display-flex jus-center">
                            <div class="btn btn-default" @click="editData(item[`${fieldId}`])"><em class="fa fa-pencil"></em></div>
                            <div class="btn btn-danger" v-if="!col.notDelete" @click="deleteData(item[`${fieldId}`])"><em class="fa fa-trash"></em></div>
                        </div>
                        <div v-else-if="col.serial">
                            {{ pageSize * (pageIndex - 1) + index + 1 }}
                        </div>
                        <div v-if="col.image">
                            <div title="" class="d-block" v-if="item[`${col.dataField}`]">
                                <img height="200px" width="200px" :src="require('@/assets/content/images/'+item[`${col.dataField}`])" alt="" class="img-fluid" />
                                <div class="text-center">
                                    {{ item[`${col.dataField}`] }}
                                </div>
                            </div>
                        </div>
                        <div v-else>
                            <div v-if="col.format">
                                {{ $commonFunc.formatData(col.format,item[`${col.dataField}`])}}
                            </div>
                            <div v-else> {{ item[`${col.dataField}`] }}</div>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
</template>
<script>
export default {
    props: {
        columns: [],
        data: [],
        /**
         * Có phân trang hay không
         */
        pagination: {
            default: false,
            typeof: Boolean
        },
        pageIndex: {
            typeof: Number,
            default: 1
        },
        pageSize: {
            typeof: Number,
            default: 10
        },
        fieldId: {
            typeof: String,
            default: ""
        }
    },
    data() {
        return {}
    },
    methods: {
        getData() {

        },
        deleteData(id) {
            const me = this;
            me.$emit("deleteData", id);
        },
        editData(id) {
            const me = this;
            me.$emit("editData", id);
        }

    }
}
</script>

<style scoped>
@import "../../../assets/content/css/common/tableAdmin.css";
.table-th{
    position: relative;
}
.icon-sorts{
    position: absolute;
    right: 10px;
}
.icon-up{
    position: absolute !important;
    top: 0px !important;
}
.icon-down{
    position: absolute !important;
    top: 8px !important;
}
</style>
