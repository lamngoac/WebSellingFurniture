export default{
    updateProductCategorys : async function(state,res){
        state.orderDetails = [...res];
    }
}