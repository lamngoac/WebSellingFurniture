/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Repo;

import com.example.testRest.Models.Project;
import com.example.testRest.Models.Recruitment;
import java.util.List;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
/**
 *
 * @author BOSS
 */

public interface ProjectRepo extends BaseRepo<Project>{
    
    @Query(value = "CALL `webnoithat_java`.proc_get_project_home;", nativeQuery = true)
    public List<Project> getHomes();
    
    @Query(value = "CALL `webnoithat_java`.proc_get_project_hot;", nativeQuery = true)
    public List<Project> getHots();
    
    @Query(value = "CALL `webnoithat_java`.proc_get_projects_filter(?1,?2,?3);", nativeQuery = true)
    public List<Project> getPagging(int pageIndex, int pageSize, String fil);
}
