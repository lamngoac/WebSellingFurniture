/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Controller;

import com.example.testRest.Models.Product;
import com.example.testRest.Models.SortCondition;
import com.example.testRest.Repo.ProductRepo;
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
@RequestMapping("api/v1/Product")
public class ProductController extends BaseController<Product>{
    @Autowired
    private ProductRepo productRepo;

    @PutMapping(value = "")
    public String updateProduct(@RequestBody Product product){
        Product updatedProduct = productRepo.findById(product.getProductId()).get();
        updatedProduct.setProductName(product.getProductName());
        updatedProduct.setProductDimensions(product.getProductDimensions());
        updatedProduct.setProductMaterial(product.getProductMaterial());
        updatedProduct.setProductManufacturer(product.getProductManufacturer());
        updatedProduct.setProductColor(product.getProductColor());
        updatedProduct.setProductOriginalPrice(product.getProductOriginalPrice());
        updatedProduct.setProductSalePrice(product.getProductSalePrice());
        updatedProduct.setProductDescriptionShort(product.getProductDescriptionShort());
        updatedProduct.setProductDescription(product.getProductDescription());
        updatedProduct.setProductEvaluate(product.getProductEvaluate());
        updatedProduct.setProductCategoryId(product.getProductCategoryId());
        updatedProduct.setProductImage(product.getProductImage());
        updatedProduct.setCreatedDate(product.getCreatedDate());
        updatedProduct.setModifiedDate(product.getModifiedDate());
        productRepo.save(updatedProduct);
        return "update...";
    }
    @GetMapping(value = "/pagging-product")
    public ResponseEntity<Map<String, Object>> getPagging(@RequestParam int PageIndex, @RequestParam int PageSize, @RequestParam String Fil,
            @RequestParam String Sort, @RequestParam String CategoryId, @RequestParam int Price) {
        Map<String, Object> response = new HashMap<>();
        try {
            if(PageIndex == 0){
                PageIndex = 1;
            }
            if(PageSize == 0){
                PageSize = 10;
            }
            long count = productRepo.count();
            SortCondition sortCondition = GetSortCondition(Sort);
            response.put("data", productRepo.getPagging(PageIndex, PageSize, Fil,sortCondition.getSortStatus(),sortCondition.getFieldSort(),CategoryId,Price));
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
            response.put("error",e);
            return new ResponseEntity<>(response, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
    @GetMapping(value = "/top-selling")
    public List<Product> getTopSellings(@RequestParam int number) {
        return productRepo.getTopSellings(number);
    
    }
}
