import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'
export default{
    /**
     * Lấy danh sách tuyển dụng
     */
     getRecruitments : async function(context,payload){
        let url = BASE_URL + '/Recruitment';
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateRecruitments");
        }
        return res;
    },
    //tuyen dung lien quan
    getRecruitmentsHome : async function(context,payload){
        let url = BASE_URL + '/Recruitment/data-home';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
     //tuyen dung hot 
     getRecruitmentsHot : async function(context,payload){
        let url = BASE_URL + '/Recruitment/data-hot';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    /**
     * Lấy danh sách phân trang theo điều kiện lọc
     */
     getRecruitmentsPagging : async function(context,payload){
        
        let url = BASE_URL + '/Recruitment/pagging';
        if(payload){
            url += '?PageIndex='+payload.PageIndex+'&PageSize='+payload.PageSize+'&Fil='+payload.Filter;
        }
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateRecruitments");
        }
        return res;
    },
    getRecruitmentById : async function(context,payload){
        let url = BASE_URL + '/Recruitment/'+payload;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateRecruitments");
        }
        return res;
    },
    
    addRecruitmentAsync : async function(context,payload){
        let url = BASE_URL + '/Recruitment';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },
    editRecruitmentAsync : async function(context,payload){
        let url = BASE_URL + '/Recruitment';
        let res = await BaseAPI.putAsync(url,payload);
        return res;
    },
    
    deleteRecruitmentAsync : async function(context, payload){
        let url = BASE_URL + '/Recruitment/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    }

}
    