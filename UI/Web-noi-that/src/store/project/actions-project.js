import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'
export default{

    /**
     * Lấy danh các dự án
     */
    getProjects : async function(context,payload){
        let url = BASE_URL + '/Project';
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            context.commit("updateProjects");
        }
        return res;
    },
    /**
     * Lấy danh sách phân trang theo điều kiện lọc
     */
     getProjectsPagging : async function(context,payload){
        
        let url = BASE_URL + '/Project/pagging';
        if(payload){
            url += '?PageIndex='+payload.PageIndex+'&PageSize='+payload.PageSize+'&Fil='+payload.Filter;
        }
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateUsers");
        }
        return res;
    },
    //du an home
    getProjectsHome : async function(context,payload){
        let url = BASE_URL + '/Project/data-home';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
      //du an hot
      getProjectsHot : async function(context,payload){
        let url = BASE_URL + '/Project/data-hot';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getProjectById : async function(context,payload){
        let url = BASE_URL + '/Project/'+payload;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateProjects");
        }
        return res;
    },
    
    addProjectAsync : async function(context,payload){
        let url = BASE_URL + '/Project';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },
    editProjectAsync : async function(context,payload){
        let url = BASE_URL + '/Project';
        let res = await BaseAPI.putAsync(url,payload);
        return res;
    },
    
    deleteProjectAsync : async function(context, payload){
        let url = BASE_URL + '/Project/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    }
}
    