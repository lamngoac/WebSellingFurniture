import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);
import state from './state';
import getters from './getters';
import mutations from './mutation';
import actions from './actions';

import user from './user/user-const.js';
import news from './news/news-const.js';
import order from './order/order-const.js';
import product from './product/product-const.js';
import project from './project/project-const.js';
import recruitment from './recuiment/recuiment-const.js';
import order_detail from './order_detail/order-detail-const.js';
import product_category from './product_category/product-category-const.js';
import translate from './translate/translate-const.js';
import contact from './contact/contact-const.js';
const store = new Vuex.Store({
    getters,
    state,
    actions,
    mutations,
    namespaced: true,
    modules:{
        user,
        news,
        order,
        product,
        project,
        recruitment,
        order_detail,
        product_category,
        translate,
        contact,
    }
});

export default store;