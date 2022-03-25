/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Controller;

import com.example.testRest.Models.*;
import com.example.testRest.Repo.OrderDetailRepo;
import com.example.testRest.Repo.OrderRepo;
import static java.util.Comparator.comparing;
import java.util.HashMap;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;


import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

@CrossOrigin("*")
@RestController
@RequestMapping("api/v1/Order")
public class OrderController extends BaseController<Order>{
    @Autowired
    private OrderRepo orderRepo;
    @Autowired
    private OrderDetailRepo orderDetailRepo;
    
    @GetMapping(value = "/{id}")
    @Override
    public Order getById(@PathVariable UUID id) {
        try {
            Order o = orderRepo.findById(id).get();
            return o;
        } catch (Exception e) {
            return null;
        }
    }
    @PutMapping(value = "")
    public String updateOrder(@RequestBody Order order){
        Order updatedOrder = orderRepo.findById(order.getOrderId()).get();
        updatedOrder.setUserId(order.getUserId());  
        updatedOrder.setCreatedDate(order.getCreatedDate());
        updatedOrder.setModifiedDate(order.getModifiedDate());
        updatedOrder.setFullName(order.getFullName());
        updatedOrder.setUserName(order.getUserName());
        updatedOrder.setStatusOrder(order.getStatusOrder());
        updatedOrder.setAddress(order.getAddress());
        updatedOrder.setPhoneNumber(order.getPhoneNumber());
        orderRepo.save(updatedOrder);
        return "update...";
    }

    @GetMapping(value = "/pagging")
    public ResponseEntity<Map<String, Object>> getPagging(@RequestParam int PageIndex, @RequestParam int PageSize, @RequestParam String Fil) {
        Map<String, Object> response = new HashMap<>();
        try {
            if(PageIndex == 0){
                PageIndex = 1;
            }
            if(PageSize == 1){
                PageSize = 10;
            }
            long count = orderRepo.count();
            response.put("data", orderRepo.getPagging(PageIndex, PageSize, Fil));
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
    
    @PostMapping(value = "/order-payment")
    public String save(@RequestBody OrderRequest orderRequest){
        Order order = orderRequest.getOrder();
        orderRepo.save(order);
        for (int i = 0; i < orderRequest.getOrderDetail().size(); i++) {
            orderRequest.getOrderDetail().get(i).setOrderId(order.getOrderId());
        }
        orderDetailRepo.saveAll(orderRequest.getOrderDetail());
        return "saved";
    }
    
    @GetMapping(value = "/order-history/{userId}")
    public ResponseEntity<Map<String, Object>> getHistoryOrderByUserId(@PathVariable UUID userId,@RequestParam int PageIndex, @RequestParam int PageSize) {
        try {
            if(PageIndex == 0){
                PageIndex = 1;
            }
            if(PageSize == 1){
                PageSize = 10;
            }
            Map<String, Object> response = new HashMap<>();
            List<Order> orders = orderRepo.findAll();
              long count = orderRepo.count();
                response.put("pageIndex", PageIndex);
                response.put("pageSize", PageSize);
                response.put("totalRecord", count);
                if (count % PageSize != 0) {
                    response.put("totalPages", (int) (count / PageSize) + 1);
                } else {
                    response.put("totalPages", (int) (count / PageSize));
                }
            if(orders != null && orders.size() > 0){
                List<Order> ord =  orders.stream().filter(o -> o.getUserId().equals(userId)).collect(Collectors.toList());
                // lịch sử
                List<OrderRespone> histories = ord.stream().
                    map(o -> 
                        new OrderRespone(o, getListOrderDetailById(o.getOrderId()))
                    )   
                    .collect(Collectors.toList());
                histories = histories.stream().skip((PageIndex-1)*PageSize).limit(PageSize).sorted(comparing(OrderRespone::getCreatedDate).reversed()).collect(Collectors.toList());
                response.put("data", histories);
            }
            else{
                response.put("data",null);
            }
            return new ResponseEntity<>(response, HttpStatus.OK);
        } catch (Exception e) {
            Map<String, Object> response = new HashMap<>();
            response.put("error", e);
            return new ResponseEntity<>(response, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
    @DeleteMapping(value = "/{id}")
    @Override
    public  ResponseEntity<Order> delete(@PathVariable UUID id) {
        try {
            Order o = orderRepo.getById(id);
            List<OrderDetail> od = orderDetailRepo.findAll().stream().filter(ode -> ode.getOrderId().equals(id)).collect(Collectors.toList());
            orderDetailRepo.deleteAll(od);
            orderRepo.delete(o);
            return new ResponseEntity<>(o, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(new Order(), HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
    
    private List<OrderDetail> getListOrderDetailById(UUID id){
        List<OrderDetail> o = orderDetailRepo.findAll().stream().filter(x->x.getOrderId().equals(id)).collect(Collectors.toList());
        if(o != null && o.size() > 0){
            return o;
        }
        return null;
    }
}
