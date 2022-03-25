export default{
    updateProjects : async function(state,res){
        state.projects = [...res];
    }
}