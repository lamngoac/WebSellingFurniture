/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Controller;

import com.example.testRest.Models.ProductCategory;
import com.example.testRest.Models.Project;
import com.example.testRest.Repo.ProductCategoryRepo;
import java.util.HashMap;
import java.util.List;
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
@RestController
@RequestMapping("api/v1/ProductCategory")
public class ProductCategoryController extends BaseController<ProductCategory>{
    @Autowired
    private ProductCategoryRepo productCategoryRepo;

    @PutMapping(value = "")
    public String updateProductCategory(@RequestBody ProductCategory productCategory){
        ProductCategory updatedProductCategory = productCategoryRepo.findById(productCategory.getProductCategoryId()).get();
        updatedProductCategory.setProductCategoryName(productCategory.getProductCategoryName());
        updatedProductCategory.setProductCategoryDescription(productCategory.getProductCategoryDescription());
        updatedProductCategory.setProductCategoryImage(productCategory.getProductCategoryImage());
        updatedProductCategory.setProductCategoryHome(productCategory.getProductCategoryHome());
        updatedProductCategory.setCreatedDate(productCategory.getCreatedDate());
        updatedProductCategory.setModifiedDate(productCategory.getModifiedDate());
        productCategoryRepo.save(updatedProductCategory);
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
            long count = productCategoryRepo.count();
            response.put("data", productCategoryRepo.getPagging(PageIndex, PageSize, Fil));
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
    public List<ProductCategory> getHomes() {
        try {
            return productCategoryRepo.getHomes();
        } catch (Exception e) {
            return null;
        }
    }

}
