package com.example.testRest.Repo;

import com.example.testRest.Models.Recruitment;
import java.util.List;
import org.springframework.data.jpa.repository.Query;

public interface RecruitmentRepo extends BaseRepo<Recruitment>{
    @Query(value = "CALL `webnoithat_java`.proc_get_recruitment_home;", nativeQuery = true)
    public List<Recruitment> getHomes();
    
    @Query(value = "CALL `webnoithat_java`.proc_get_recruitment_hot;", nativeQuery = true)
    public List<Recruitment> getHots();
    
    @Query(value = "CALL `webnoithat_java`.proc_get_recruitments_filter(?1,?2,?3);", nativeQuery = true)
    public List<Recruitment> getPagging(int pageIndex, int pageSize, String fil);
}
