package com.example.testRest.Models;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.UUID;
import javax.persistence.*;
import org.hibernate.annotations.Type;

@Entity
public class User {

    @Id
    @GeneratedValue(generator = "system-uuid")
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID userId;
    @Column
    private String userName;
    @Column
    private String password;
    @Column
    private String fullName;
    @Column
    private String address;
    @Column
    private String phoneNumber;
    @Column
    private int role;
    @Column
    private LocalDateTime createdDate;
    @Column
    private LocalDateTime modifiedDate = null;
    
    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
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

    public int getRole() {
        return role;
    }

    public void setRole(int role) {
        this.role = role;
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

    public void setId(UUID userId) {
        this.userId = userId;
    }

    
}
