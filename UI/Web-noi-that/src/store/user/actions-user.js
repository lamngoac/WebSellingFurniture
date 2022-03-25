import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'

export default{
    getUsers : async function(context,payload){
        let url = BASE_URL + '/User';
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateUsers");
        }
        return res;
    },
    getUserById : async function(context,payload){
        let url = BASE_URL + '/User/'+payload;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateUsers");
        }
        return res;
    },
    getUserByUserName : async function(context,payload){
        let url = BASE_URL + '/User/username'+`?UserName=${payload}`;
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getUsersPagging : async function(context,payload){
        
        let url = BASE_URL + '/User/pagging';
        if(payload){
            url += '?PageIndex='+payload.PageIndex+'&PageSize='+payload.PageSize+'&Fil='+payload.Filter;
        }
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },

    addUserAsync : async function(context,payload){
        let url = BASE_URL + '/User';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },

    editUserAsync : async function(context,payload){
        let url = BASE_URL + '/User';
        let res = await BaseAPI.putAsync(url,payload);
        return res;
    },
    
    deleteUserAsync : async function(context, payload){
        let url = BASE_URL + '/User/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    }
}
    