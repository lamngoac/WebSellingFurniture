<template>
<div>
    <section class="section recru container">
        <div class="section__title text-center text-uppercase wow fadeInUp">Việc làm tốt nhất</div>
        <div class="row gx-md-3 gy-md-3 gy-2 recru__list">
            <div v-for="(recruitment,index) in recruitments" :key="index" class="col-12 col-md-6">
                <div class="recru__item wow fadeInUp" data-wow-delay="<?php echo $i*0.3; ?>s" data-wow-duration="1s" @click="viewRecruitment(recruitment.recruitmentId)">
                    <div class="row">
                        <div class="col-xxl-4 col-xl-5">
                            <a class="_img-link d-block mb-xl-0 mb-sm-2 mb-1" >
                                <img :src="require('@/assets/content/images/'+ recruitment.linkImage)" alt="" class="img-fluid">
                            </a>
                        </div>
                        <div class="col-xxl-8 col-xl-7">
                            <div class="recru__item__time mb-1">
                                <img src="../../assets/content/images/clock.svg" alt="" class="_img _icon img-fluid">
                                <span class="_time">{{recruitment.createdDate | moment("DD/MM/YYYY")}}</span>
                            </div>
                            <a class="recru__item__title d-block mb-2">{{ recruitment.recruitmentTitle }}</a>
                            <a class="recure__item__short mb-lg-3 mb-2">
                                {{ recruitment.recruitmentContent }}
                            </a>
                            <div class="recru__item__more d-inline-block" >Xem thêm</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="h-pagination">
            <Pagination ref="pagination" @getData="getData" :totalRecord="params.TotalRecord" :pageSize="params.PageSize" :totalPages="params.TotalPages" :pageIndex="params.PageIndex" :filter="params.Filter" :textTotal="'dự án'" />
        </div>
    </section>
</div>
</template>

<script>
import Pagination from "@/views/components/pagination/Pagination";
import {
    mapActions
} from 'vuex';
import {ModuleRecruitment} from '@/store/module-const';
export default {
     components:{
        Pagination
    },
    data(){
        return{
            recruitments : [],
             params: {
                PageIndex: 1,
                PageSize: 4,
                TotalRecord: 0,
                TotalPages: 0,
                Filter: "",
            },
        }
    },
    created(){
        const me = this;
        me.getData();
    },
    computed:{
    },
    methods:{
         ...mapActions(ModuleRecruitment,['getRecruitmentsPagging']),
        async getData(){
            const me = this;
            if(me.$refs.pagination){
                me.params.PageIndex = me.$refs.pagination.pageIndexD;
            }
            let res = await me.getRecruitmentsPagging(me.params);
            if (res) {
                me.recruitments = [...res.data];
                me.params.PageIndex = res.pageIndex;
                me.params.PageSize = res.pageSize;
                me.params.TotalRecord = res.totalRecord;
                me.params.TotalPages = res.totalPages;
            }
            if (!res) {
                me.recruitments = [];
                me.params = {
                    PageIndex: 1,
                    PageSize: 10,
                    TotalRecord: 0,
                    TotalPages: 0,
                    Filter: me.params.Filter,
                };
            }
        },
         viewRecruitment(id){
            const me = this;
            me.$router.push(`/recruiment-detail/${id}`);
        },
    }
}
</script>

<style scoped>
.recru .recru__list .recru__item .recure__item__short{
     overflow: hidden;
    text-overflow: ellipsis;
    line-height: 20px;
    -webkit-line-clamp: 3;
    display: -webkit-box;
    -webkit-box-orient: vertical;
}
</style>
