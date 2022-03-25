/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Models;

import java.util.List;

/**
 *
 * @author Dell
 */
public class OrderRequest {

    public OrderRequest(Order o, List<OrderDetail> odeDetails){
        this.order = o;
        this.orderDetail = odeDetails;
    }
    public List<OrderDetail> getOrderDetail() {
        return orderDetail;
    }

    public void setOrderDetail(List<OrderDetail> orderDetail) {
        this.orderDetail = orderDetail;
    }

    public Order getOrder() {
        return order;
    }

    public void setOrder(Order order) {
        this.order = order;
    }
    private List<OrderDetail> orderDetail;
    private Order order;
}
