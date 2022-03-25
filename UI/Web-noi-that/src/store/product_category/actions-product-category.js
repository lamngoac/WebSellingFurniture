import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'
export default{
    /**
     * Lấy danh sách tất cả danh mục
     */
    getProductCategories : async function(context,payload){
        let url = BASE_URL + '/ProductCategory';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    /**
     * Lấy danh sách phân trang theo điều kiện lọc
     */
    getProductCategoriesPagging : async function(context,payload){
        
        let url = BASE_URL + '/ProductCategory/pagging';
        if(payload){
            url += '?PageIndex='+payload.PageIndex+'&PageSize='+payload.PageSize+'&Fil='+payload.Filter;
        }
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateUsers");
        }
        return res;
    },
    
    /**
     * Lấy danh sách du lieu ra home
     */
    getProductCategoriesHome : async function(context,payload){
        let url = BASE_URL + '/ProductCategory/data-home';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getProductCategoryById : async function(context,payload){
        let url = BASE_URL + '/ProductCategory/'+payload;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateProductCategorys");
        }
        return res;
    },
    
    addProductCategoryAsync : async function(context,payload){
        let url = BASE_URL + '/ProductCategory';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },
    editProductCategoryAsync : async function(context,payload){
        let url = BASE_URL + '/ProductCategory';
        let res = await BaseAPI.putAsync(url,payload);
        return res;
    },
    
    deleteProductCategoryAsync : async function(context, payload){
        let url = BASE_URL + '/ProductCategory/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    }
}
    