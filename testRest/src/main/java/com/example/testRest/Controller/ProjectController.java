/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Controller;

import com.example.testRest.Models.Project;
import com.example.testRest.Repo.ProjectRepo;
import java.util.HashMap;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;


import java.util.List;
import java.util.Map;
import java.util.UUID;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
@CrossOrigin("*")
@RestController
@RequestMapping("api/v1/Project")
public class ProjectController extends BaseController<Project>{
    @Autowired
    private ProjectRepo projectRepo;
    
    @PutMapping(value = "")
    public String updateProject(@RequestBody Project project){
        Project updatedProject = projectRepo.findById(project.getProjectId()).get();
        updatedProject.setProjectTitle(project.getProjectTitle());
        updatedProject.setProjectContent(project.getProjectContent());
        updatedProject.setLinkImage(project.getLinkImage());
        updatedProject.setProjectHome(project.getProjectHome());
        updatedProject.setCreatedDate(project.getCreatedDate());
        updatedProject.setModifiedDate(project.getModifiedDate());
        projectRepo.save(updatedProject);
        return "update...";
    }
    @GetMapping(value = "/pagging")
    public ResponseEntity<Map<String, Object>> getPagging(@RequestParam int PageIndex, @RequestParam int PageSize, @RequestParam String Fil) {
        try {
            if(PageIndex == 0){
                PageIndex = 1;
            }
            if(PageSize == 1){
                PageSize = 10;
            }
            Map<String, Object> response = new HashMap<>();
            long count = projectRepo.count();
            response.put("data", projectRepo.getPagging(PageIndex, PageSize, Fil));
            response.put("pageIndex", PageIndex);
            response.put("pageSize", PageSize);
            response.put("totalRecord", count);
            if (count % PageSize != 0) {
                response.put("totalPages", (int) (count / PageSize) + 1);
            } else {
                response.put("totalPages", (int) (count / PageSize));
            }
            return new ResponseEntity<>(response, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
    
    @GetMapping(value = "/data-home")
    public List<Project> getHomes() {
        try {
            return projectRepo.getHomes();
        } catch (Exception e) {
            return null;
        }
    }
    @GetMapping(value = "/data-hot")
    public List<Project> getHots() {
        try {
            return projectRepo.getHots();
        } catch (Exception e) {
            return null;
        }
    }
}
