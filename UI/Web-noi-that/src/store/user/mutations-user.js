export default{
    updateUsers : async function(state,res){
        state.users = [...res];
    }
}