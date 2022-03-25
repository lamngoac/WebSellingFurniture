export default{
    updateNews : async function(state,res){
        state.news = [...res];
    }
}