
export default{
    updateRecruitments : async function(state,res){
        state.recruitments = [...res];
    }
}