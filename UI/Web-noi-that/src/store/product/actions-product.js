import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'
export default{

    /**
     * Lấy danh sách sản phẩm
     */
    getProducts : async function(context,payload){
        let url = BASE_URL + '/Product';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },

    /**
     * Lấy danh sách sản phẩm
     */
     getProductsTopSelling : async function(context,payload){
        if(!payload){
            payload = 5;
        }
        let url = BASE_URL + `/Product/top-selling/?number=${payload}`;
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    /**
     * Lấy danh sách phân trang theo điều kiện lọc
     */
    getProductsPagging : async function(context,payload){
        
        let url = BASE_URL + '/Product/pagging-product';
        if(payload){
            url += `?PageIndex=${payload.PageIndex}&PageSize=${payload.PageSize}&Fil=${payload.Filter}&Sort=${payload.Sort}&CategoryId=${payload.CategoryId}&Price=${payload.Price}`;
        }
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getProductById : async function(context,payload){
        let url = BASE_URL + '/Product/'+payload;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateProducts");
        }
        return res;
    },
    
    addProductAsync : async function(context,payload){
        let url = BASE_URL + '/Product';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },
    editProductAsync : async function(context,payload){
        let url = BASE_URL + '/Product';
        let res = await BaseAPI.putAsync(url,payload);
        return res;
    },
    
    deleteProductAsync : async function(context, payload){
        let url = BASE_URL + '/Product/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    }
}
    