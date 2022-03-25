<template>
<div>
    <RevenueStatistic :isShow="isShow" @closePopup="setStatePopup(false)" @showPopup="setStatePopup(true)"/>
    <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark h-navbar-top">
        <form class="
          d-none d-md-inline-block
          form-inline
          ms-auto
          me-0 me-md-3
          my-2 my-md-0
        ">
        </form>
        <div class="h-display-flex text-statistic">
            <div @click="revenueStatistic"> 
                Thống kê doanh số
            </div>
            <ul class="h-display-flex h-user" v-if="userName">
                <li class="text-login">Xin chào!   <span style="font-weight:bold;margin-left:20px">{{ userName }}</span></li>
                <li class="text-logout"><div @click="logOut" title="">Đăng xuất</div></li>
            </ul>
        </div>
    </nav>
    <div id="layoutSidenav">
        <div id="layoutSidenav_nav">
            <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                <div class="sb-sidenav-menu">
                    <div class="nav" >
                        <div class="sb-sidenav-menu-heading" style="color:yellow">Danh sách các bảng</div>
                        <router-link to="/admin" class="nav-link" style="color:yellow">
                            <div class="sb-nav-link-icon"><i class="fa fa-table"></i></div>
                            Quản lý tin tức
                        </router-link>
                        <router-link to="/adminProject" class="nav-link" style="color:yellow">
                            <div class="sb-nav-link-icon"><i class="fa fa-table"></i></div>
                            Quản lý dự án
                        </router-link>
                        <router-link to="/adminRecruitment" class="nav-link" style="color:yellow">
                            <div class="sb-nav-link-icon"><i class="fa fa-table"></i></div>
                            Quản lý tuyển dụng
                        </router-link>
                        <router-link to="/adminProduct" class="nav-link" style="color:yellow">
                            <div class="sb-nav-link-icon"><i class="fa fa-table"></i></div>
                            Quản lý sản phẩm
                        </router-link>
                        <router-link to="/adminProductCategory" class="nav-link" style="color:yellow">
                            <div class="sb-nav-link-icon"><i class="fa fa-table"></i></div>
                            Quản lý danh mục sản phẩm
                        </router-link>
                        <router-link to="/adminOder" class="nav-link" style="color:yellow">
                            <div class="sb-nav-link-icon"><i class="fa fa-table"></i></div>
                            Quản lý đơn hàng
                        </router-link>
                        <router-link to="/adminOderDetail" class="nav-link" style="color:yellow">
                            <div class="sb-nav-link-icon"><i class="fa fa-table"></i></div>
                            Quản lý chi tiết đơn hàng
                        </router-link>
                         <router-link to="/adminUsers" class="nav-link" style="color:yellow">
                            <div class="sb-nav-link-icon"><i class="fa fa-table"></i></div>
                            Quản lý tài khoản
                        </router-link>
                    </div>
                </div>
            </nav>
        </div>
        <router-view></router-view>
    </div>
</div>
</template>

<script>
import {
    mapActions, 
} from 'vuex';
import {ModuleUser} from '@/store/module-const';
import RevenueStatistic from "./RevenueStatistic.vue";
export default {
    components:{
        RevenueStatistic
    },
    data(){
        return {
            userName : "",
            isShow : false,
        }
    },
    async created() {
        const me = this;
        let name = localStorage.getItem("userName");
        if(name){
            me.userName = name;
            let res = await me.getUserByUserName(me.userName);
            // Tài khoản không có quyền vào admin tự động out
            if(res && res.role != me.$enum.Role.Admin){
                me.logOut();
            }
        }
        // K đăng nhập k vào đc admin
        else{
            me.logOut();
        }
    },
    methods:{
         ...mapActions(ModuleUser, ["getUserByUserName"]),
        logOut(){
            const me = this;
            localStorage.removeItem("userName");
            me.$router.push("/login")
        },
        // Thực hiện show popup Thống kê
        revenueStatistic(){
            this.isShow = true;
        },
        // trạng thái của popup thống kê
        setStatePopup(isShow){
            this.isShow = isShow;
        }
    }

};
</script>

<style scoped>
#layoutSidenav_nav {
    max-height: calc(100vh - 56px);
    min-height: calc(100vh - 56px);
}
.h-user{
    color : #fff;
    padding-right:20px ;
}
.text-login{
    padding-right:10px;
    border-right: 1px solid #fff;
}
.text-logout{
    margin-left: 10px;
    cursor: pointer;
}
.text-logout:hover{
    color: orange;
}

.text-statistic{
    color: #fff;
    cursor: pointer;
}
.text-statistic:focus,.text-statistic:active{
    color: orange;
}
</style>
