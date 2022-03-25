/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Controller;

import com.example.testRest.Models.Contact;
import com.example.testRest.Repo.ContactRepo;
import java.util.HashMap;
import java.util.Map;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
/**
 *
 * @author BOSS
 */
import java.util.UUID;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
@CrossOrigin("*")
@RequestMapping("api/v1/Contact")
public class ContactController extends BaseController<Contact>{
     @Autowired
    private ContactRepo contactRepo;
    
    @PutMapping(value = "")
    public String updateContact(@RequestBody Contact contact){
        Contact updatedContact = contactRepo.findById(contact.getContactId()).get();
        updatedContact.setContactName(contact.getContactName());
        updatedContact.setContactEmail(contact.getContactEmail());
        updatedContact.setContactPhone(contact.getContactPhone());
        updatedContact.setContactReminder(contact.getContactReminder());
        updatedContact.setCreatedDate(contact.getCreatedDate());
        updatedContact.setModifiedDate(contact.getModifiedDate());
        contactRepo.save(updatedContact);
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
            long count = contactRepo.count();
            response.put("data", contactRepo.getPagging(PageIndex, PageSize, Fil));
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
