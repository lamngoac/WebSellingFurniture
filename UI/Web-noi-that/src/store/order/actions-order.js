import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'
export default{
    /**
     * Lấy danh tất cả đơn hàng
     */
    getOrders : async function(context,payload){
        let url = BASE_URL + '/Order';
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateOrders");
        }
        return res;
    },
    /**
     * Lấy danh sách phân trang theo điều kiện lọc
     */
    getOrdersPagging : async function(context,payload){
        let url = BASE_URL + '/Order/pagging';
        if(payload){
            url += '?PageIndex='+payload.PageIndex+'&PageSize='+payload.PageSize+'&Fil='+payload.Filter;
        }
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateUsers");
        }
        return res;
    },
    getOrderById : async function(context,payload){
        let url = BASE_URL + '/Order/'+payload;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateOrders");
        }
        return res;
    },
    
    addOrderAsync : async function(context,payload){
        let url = BASE_URL + '/Order';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },
    editOrderAsync : async function(context,payload){
        let url = BASE_URL + '/Order';
        let res = await BaseAPI.putAsync(url,payload);
        return res;
    },
    
    deleteOrderAsync : async function(context, payload){
        let url = BASE_URL + '/Order/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    },

    cancelOrderAsync: async function(context, payload){
        let url = BASE_URL + '/Order/cancelOrder/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    },
    addOrderPayment : async function(context,payload){
        let url = BASE_URL + '/Order/order-payment';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },

    getHistoriesOrder : async function(context,payload){
        let url = BASE_URL + `/Order/order-history/${payload.UserId}?PageIndex=${payload.PageIndex}&PageSize=${payload.PageSize}`;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateUsers");
        }
        return res;
    },
}
    