/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Models;

import java.time.LocalDateTime;
import java.util.List;

/**
 *
 * @author Dell
 */
public class OrderRespone {
     public OrderRespone(Order o, List<OrderDetail> odeDetails){
        this.order = o;
        this.orderDetails = odeDetails;
        this.createdDate = LocalDateTime.now();
    }

    public Order getOrder() {
        return order;
    }

    public void setOrder(Order order) {
        this.order = order;
    }

    public List<OrderDetail> getOrderDetails() {
        return orderDetails;
    }

    public void setOrderDetails(List<OrderDetail> orderDetails) {
        this.orderDetails = orderDetails;
    }
    private List<OrderDetail> orderDetails;
    private Order order;

    public LocalDateTime getCreatedDate() {
        return createdDate;
    }

    public void setCreatedDate(LocalDateTime createdDate) {
        this.createdDate = createdDate;
    }
    private  LocalDateTime createdDate;
}
