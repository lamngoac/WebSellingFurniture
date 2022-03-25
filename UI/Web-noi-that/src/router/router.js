import Vue from 'vue'
import VueRouter from 'vue-router'

import PageUser from '@/pages/pageUser/PageUser.vue';
import Home from '@/views/home/Home.vue';
import News from '@/views/news/New.vue';
import NewDetail from '@/views/news/NewDetail.vue';
import Contact from '@/views/contact/Contact.vue';
import ProductDetail from '@/views/product/ProductDetail.vue';
import Recruitment from '@/views/recruitment/Recruitment.vue';
import RecruimentDetail from '@/views/recruitment/RecruitmentDetail.vue';
import Project from '@/views/project/Project.vue';
import ProjectDetail from '@/views/project/ProjectDetail.vue';
import Category from '@/views/category/Category.vue';
import Cart from '@/views/cart/Cart.vue';
import CartPay from '@/views/cart/CartPay.vue';
import About from '@/views/about/About.vue';
import Login from '@/views/login/Login.vue';
import Register from '@/views/register/Register.vue';
import ForgotPass from '@/views/ForgotPass/ForgotPass.vue';
import Admin from '@/views/admin/Admin.vue';
import AdminNews from '@/views/admin/adminNews/AdminNews.vue';
import AdminProject from '@/views/admin/adminProject/AdminProject.vue';
import AdminRecruitment from '@/views/admin/adminRecruitment/AdminRecruitment.vue';
import AdminProduct from '@/views/admin/adminProduct/AdminProduct.vue';
import AdminProductCategory from '@/views/admin/adminProductCategory/AdminProductCategory.vue';
import AdminOder from '@/views/admin/adminOrder/AdminOrder.vue';
import AdminOderDetail from '@/views/admin/adminOrderDetail/AdminOrderDetail.vue';
import AdminUsers from '@/views/admin/adminUsers/AdminUsers.vue';
import Pages404 from '@/views/404/404.vue';
import HistoryOrder from '@/views/historyOrder/HistoryOrder.vue'
Vue.use(VueRouter)

const routes = [
  {path: '/login',name:"login",component : Login, props:true},
   {path: '/forgotpass',component : ForgotPass},
   {path: '/register',component : Register,params :{userName : ""}, props:{
    userName : ""
  }},
   {path: '/admin',component : Admin, children :[
    {path: '/admin/:id?',component : AdminNews},
    {path: '/adminProject/:id?',component : AdminProject},
    {path: '/adminRecruitment/:id?',component : AdminRecruitment},
    {path: '/adminProduct/:id?',component : AdminProduct},
    {path: '/adminProductCategory/:id?',component : AdminProductCategory},
    {path: '/adminOder/:id?',component : AdminOder},
    {path: '/adminOderDetail/:id?',component : AdminOderDetail},
    {path: '/adminUsers/:id?',component : AdminUsers},
   ]},
   {  path: '/',
      component:  PageUser, children :[
        {path:'/',name:'home',component:Home,
          props: true,
          meta: { title: "Home"}
        },
        {path: '/news/:id?',component : News},
        {path: '/new-detail/:id?',component : NewDetail},
        {path: '/contact/:id?',component : Contact},
        {path: '/product-detail/:id?',component : ProductDetail},
        {path: '/recruiment/:id?',component : Recruitment},
        {path: '/recruiment-detail/:id?',component : RecruimentDetail},
        {path: '/project/:id?',component : Project},
        {path: '/project-detail/:id?',component : ProjectDetail},
        {path: '/category/:id?',component : Category},
        {path: '/cart/:id?',component : Cart},
        {path: '/cart-pay/:id?',component : CartPay},
        {path: '/about/:id?',component : About},
        {path: '/history-order/:id?',component : HistoryOrder},
        {path: '*',component : Pages404},
    ],
    props: true,
    meta: { title: "Data list" },
  },
]
const router = new VueRouter({
  routes,
  scrollBehavior () {
    return { x: 0, y: 0 }
  }
})
export default router