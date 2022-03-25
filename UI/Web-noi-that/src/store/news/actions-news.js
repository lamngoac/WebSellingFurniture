import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'
export default{
    /**
     * Lấy danh sách tin tức
     */
    getNews : async function(context,payload){
        let url = BASE_URL + '/News';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    /**
     * Lấy danh sách phân trang theo điều kiện lọc
     */
    getNewssPagging : async function(context,payload){
        let url = BASE_URL + '/News/pagging';
        if(payload){
            url += '?PageIndex='+payload.PageIndex+'&PageSize='+payload.PageSize+'&Fil='+payload.Filter;
        }
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateUsers");
        }
        return res;
    },
    getNewsHome : async function(context,payload){
        let url = BASE_URL + '/News/data-home';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getNewsHot : async function(context,payload){
        let url = BASE_URL + '/News/data-hot';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getNewsProduct : async function(context,payload){
        let url = BASE_URL + '/News/data-product';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getNewsSale : async function(context,payload){
        let url = BASE_URL + '/News/data-sale';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getNewsEvent : async function(context,payload){
        let url = BASE_URL + '/News/data-event';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getNewsById : async function(context,payload){
        let url = BASE_URL + '/News/'+payload;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateNewss");
        }
        return res;
    },
    
    addNewsAsync : async function(context,payload){
        let url = BASE_URL + '/News';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },
    editNewsAsync : async function(context,payload){
        let url = BASE_URL + '/News';
        let res = await BaseAPI.putAsync(url,payload);
        return res;
    },
    
    deleteNewsAsync : async function(context, payload){
        let url = BASE_URL + '/News/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    }
}
    