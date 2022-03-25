/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Models;

import java.time.LocalDateTime;
import java.util.Date;
import javax.persistence.*;
import java.util.UUID;
import org.hibernate.annotations.Type;

@Entity
@Table(name="order")
public class Order {
    @GeneratedValue(generator="system-uuid")
    @Id
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID orderId;
    @Column
    private String fullName;
    @Column
    private String address;
    @Column
    private String phoneNumber;
    @Column
    private int paymentMethods;
    @Column
    private String note;
    @Column
    private String userName;
    @Column
    private LocalDateTime createdDate = LocalDateTime.now();
    @Column
    private LocalDateTime modifiedDate =  LocalDateTime.now();
    
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID userId;
    
    @Column
    private int statusOrder;

    public int getStatusOrder() {
        return statusOrder;
    }

    public void setStatusOrder(int statusOrder) {
        this.statusOrder = statusOrder;
    }
    

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public int getPaymentMethods() {
        return paymentMethods;
    }

    public void setPaymentMethods(int paymentMethods) {
        this.paymentMethods = paymentMethods;
    }

    public String getNote() {
        return note;
    }

    public void setNote(String note) {
        this.note = note;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public UUID getOrderId() {
        return orderId;
    }

    public void setOrderId(UUID orderId) {
        this.orderId = orderId;
    }

    public LocalDateTime getCreatedDate() {
        return createdDate;
    }

    public void setCreatedDate(LocalDateTime createdDate) {
        this.createdDate = createdDate;
    }

    public LocalDateTime getModifiedDate() {
        return modifiedDate;
    }

    public void setModifiedDate(LocalDateTime modifiedDate) {
        this.modifiedDate = modifiedDate;
    }

    public UUID getUserId() {
        return userId;
    }

    public void setUserId(UUID userId) {
        this.userId = userId;
    }
}
