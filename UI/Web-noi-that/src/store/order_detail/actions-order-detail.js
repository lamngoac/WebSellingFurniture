import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'
export default{
    /**
     * Lấy danh sách chi tiết đơn hàng
     */
    getOrderDetails : async function(context,payload){
        let url = BASE_URL + '/OrderDetail';
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateOrderDetails");
        }
        return res;
    },
    /**
     * Lấy danh sách phân trang theo điều kiện lọc
     */
    getOrderDetailsPagging : async function(context,payload){
        let url = BASE_URL + '/OrderDetail/pagging';
        if(payload){
            url += '?PageIndex='+payload.PageIndex+'&PageSize='+payload.PageSize+'&Fil='+payload.Filter;
        }
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateUsers");
        }
        return res;
    },
    getOrderDetailById : async function(context,payload){
        let url = BASE_URL + '/OrderDetail/'+payload;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateOrderDetails");
        }
        return res;
    },
    
    addOrderDetailAsync : async function(context,payload){
        let url = BASE_URL + '/OrderDetail';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },
    editOrderDetailAsync : async function(context,payload){
        let url = BASE_URL + '/OrderDetail';
        let res = await BaseAPI.putAsync(url,payload);
        return res;
    },
    
    deleteOrderDetailAsync : async function(context, payload){
        let url = BASE_URL + '/OrderDetail/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    }
}
    