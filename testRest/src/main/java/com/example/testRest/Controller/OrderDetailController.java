/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Controller;

import com.example.testRest.Models.OrderDetail;
import com.example.testRest.Repo.OrderDetailRepo;
import java.util.HashMap;
import java.util.Map;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.UUID;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

@CrossOrigin("*")
@RestController
@RequestMapping("api/v1/OrderDetail")
public class OrderDetailController extends BaseController<OrderDetail>{
    @Autowired
    private OrderDetailRepo orderdetailRepo;

    @PutMapping(value = "")
    public String updateOrderDetail(@RequestBody OrderDetail orderdetail){
        OrderDetail updatedOrderDetail = orderdetailRepo.findById(orderdetail.getOrderDetailId()).get();
        updatedOrderDetail.setProductId(orderdetail.getProductId());  
        updatedOrderDetail.setAmount(orderdetail.getAmount());
        orderdetailRepo.save(updatedOrderDetail);
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
            long count = orderdetailRepo.count();
            response.put("data", orderdetailRepo.getPagging(PageIndex, PageSize, Fil));
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
