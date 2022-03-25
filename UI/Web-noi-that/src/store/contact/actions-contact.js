import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'
export default{
    getContacts : async function(context,payload){
        let url = BASE_URL + '/Contact';
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
    getContactsPagging : async function(context,payload){
        let url = BASE_URL + '/Contact/pagging';
        if(payload){
            url += '?PageIndex='+payload.PageIndex+'&PageSize='+payload.PageSize+'&Fil='+payload.Filter;
        }
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateUsers");
        }
        return res;
    },
    getContactById : async function(context,payload){
        let url = BASE_URL + '/Contact/'+payload;
        let res = await BaseAPI.getAsync(url,payload);
        if(res){
            // context.commit("updateNewss");
        }
        return res;
    },
    
    addContactAsync : async function(context,payload){
        let url = BASE_URL + '/Contact';
        let res = await BaseAPI.postAsync(url,payload);
        if(res){
            return res;
        }
        
    },
    editContactAsync : async function(context,payload){
        let url = BASE_URL + '/Contact';
        let res = await BaseAPI.putAsync(url,payload);
        return res;
    },
    
    deleteContactAsync : async function(context, payload){
        let url = BASE_URL + '/Contact/'+payload;
        let res = await BaseAPI.deleteAsync(url,payload);
        return res;
    }
}
    