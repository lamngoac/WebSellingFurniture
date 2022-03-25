export default{
    updateProducts : async function(state,res){
        state.products = [...res];
    }
}