import axios from 'axios';
/**
 * GET
 * @param {Url api} url 
 */
export const getAsync = async (url) =>
    await axios.get(url).then(res => {
        return Promise.resolve(res.data);
    }).catch(err => Promise.reject(err));
/**
 * DELETE
 * @param {*} url 
 */
 export const deleteAsync = async (url) =>{
    await axios.delete(url)
    .then(res => {
        if (res.status == 200) {
            return Promise.resolve(true);
        }
        return Promise.reject(false);
    })
    .catch(err => {
        console.log("Lỗi : " + err);
        return Promise.reject(false)
    });
}

/***
 * PUT
 */
export const putAsync = async (url,data)=>{
    await axios.put(url,data)
    .then(res => {
        if (res.status == 200 || res.status == 201) return Promise.resolve(true);
        return Promise.reject(false);
    })
    .catch(err => {
        console.log("Lỗi : " + err);
        return Promise.reject(false)
    });
}

/**
 * POST
 */
 export const postAsync = async (url,data)=>{
    await axios.post(url,data)
    .then(res => {
        if (res.status == 200 || res.status == 201) return Promise.resolve(true);
        return Promise.reject(false);
    })
    .catch(err => {
        console.log("Lỗi : " + err);
        return Promise.reject(false)
    });
}


export default {getAsync,putAsync,deleteAsync,postAsync}