import BaseAPI from '@/api/base/base-api';
import { BASE_URL } from '@/api/url'
export default{
    translateLanguage : async function(context,payload){
        let url = BASE_URL + `/Translate?language=${payload.language}&text=${payload.text}`;
        let res = await BaseAPI.getAsync(url,payload);
        return res;
    },
}