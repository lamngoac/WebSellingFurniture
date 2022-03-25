/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Controller;

import com.example.testRest.Models.User;
import com.example.testRest.Repo.UserRepo;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.UUID;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

/**
 *
 * @author BOSS
 */
@RestController
@RequestMapping("api/v1/User")
@CrossOrigin("*")
public class UserController extends BaseController<User> {

    @Autowired
    private UserRepo userRepo;

    @PutMapping(value = "")
    public String updateUsser(@RequestBody User user) {
        User updatedUser = userRepo.findById(user.getUserId()).get();
        updatedUser.setPassword(user.getPassword());
        updatedUser.setUserName(user.getUserName());
        updatedUser.setRole(user.getRole());
        updatedUser.setAddress(user.getAddress());
        updatedUser.setPhoneNumber(user.getPhoneNumber());
        updatedUser.setFullName(user.getFullName());
        updatedUser.setCreatedDate(user.getCreatedDate());
        updatedUser.setModifiedDate(LocalDateTime.now());

        userRepo.save(updatedUser);
        return "update...";
    }

    @GetMapping(value = "/username")
    public User uetUserByUserName(@RequestParam String UserName) {
        return userRepo.getUserByUserName(UserName);
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
            long count = userRepo.count();
            response.put("data", userRepo.getPagging(PageIndex, PageSize, Fil));
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
}
