package com.example.testRest.Controller;

import com.example.testRest.Models.Recruitment;
import com.example.testRest.Repo.RecruitmentRepo;
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
@RequestMapping("api/v1/Recruitment")
public class RecruitmentControllers extends BaseController<Recruitment>{

    @Autowired
    private RecruitmentRepo recruitmentRepo;

    @PutMapping(value = "")
    public String updateRecruitment(@RequestBody Recruitment recruitment){
        Recruitment updatedRecruitment = recruitmentRepo.findById(recruitment.getRecruitmentId()).get();
        updatedRecruitment.setRecruitmentTitle(recruitment.getRecruitmentTitle());
        updatedRecruitment.setRecruitmentContent(recruitment.getRecruitmentContent());
        updatedRecruitment.setLinkImage(recruitment.getLinkImage());
        updatedRecruitment.setModifiedDate(recruitment.getModifiedDate());
        recruitmentRepo.save(updatedRecruitment);
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
            long count = recruitmentRepo.count();
            response.put("data", recruitmentRepo.getPagging(PageIndex, PageSize, Fil));
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
    public List<Recruitment> getHomes() {
        try {
            return recruitmentRepo.getHomes();
        } catch (Exception e) {
            return null;
        }
    }
    @GetMapping(value = "/data-hot")
    public List<Recruitment> getHots() {
        try {
            return recruitmentRepo.getHots();
        } catch (Exception e) {
            return null;
        }
    }
}
