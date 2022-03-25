/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Controller;

import com.example.testRest.Models.SortCondition;
import com.example.testRest.Repo.BaseRepo;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestParam;

/**
 *
 * @author Dell
 */
//@RestController
//@CrossOrigin("*")
public class BaseController<T> {
    @Autowired
    private BaseRepo<T> baseRepo;

    @GetMapping(value = "")
    public List<T> GetAll() {
        return baseRepo.findAll();
    
    }
    @GetMapping(value = "/{id}")
    public T getById(@PathVariable UUID id) {
        return (T)baseRepo.findById(id);
    }
    @PostMapping(value = "")
    public ResponseEntity<T> save(@RequestBody T t) {
        return (ResponseEntity<T>) ResponseEntity.ok(baseRepo.save(t));
    }

    @DeleteMapping(value = "/{id}")
    public  ResponseEntity<T> delete(@PathVariable UUID id) {
        T entity = baseRepo.getById(id);
        baseRepo.delete(entity);
        return (ResponseEntity<T>) ResponseEntity.ok("delete");
    }
//    @GetMapping(value = "/pagging")
//    public ResponseEntity<Map<String, Object>> getPagging(@RequestParam int pageIndex, @RequestParam int pageSize){
//        try {
//            if(pageIndex == 0){
//                pageIndex = 1;
//            }
//            if(pageSize == 1){
//                pageSize = 10;
//            }
//            Pageable pageable = PageRequest.of(pageIndex, pageSize);
//            Page<T> page = baseRepo.findAll(pageable);
//            Map<String, Object> response = new HashMap<>();
//            response.put("data", page.getContent());
//            response.put("pageIndex", page.getNumber());
//            response.put("pageSize", page.getSize());
//            response.put("totalRecords", page.getTotalElements());
//            response.put("totalPages", page.getTotalPages());
//            return new ResponseEntity<>(response, HttpStatus.OK);
//        } catch (Exception e) {
//            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
//        }
//    }
    
    protected SortCondition GetSortCondition(String sort)
    {
        SortCondition sortCondition = new SortCondition();
        if(sort != null && sort.length() > 0)
        {   
            String [] splits = sort.split(" ");
            sortCondition.setSortStatus(
                !splits[0].equalsIgnoreCase("None") ? (splits[0].equalsIgnoreCase("Desc") ? 1 : 2) : 0
            );
            sortCondition.setFieldSort(splits[1]);
        }
        return sortCondition;
    }
}
