export default{
    updateProductCategorys : async function(state,res){
        state.productCategories = [...res];
    }
}