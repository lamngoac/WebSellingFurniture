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
/**
 *
 * @author BOSS
 */
@Entity
public class ProductCategory {
    @Id
    @GeneratedValue(generator="system-uuid")
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID productCategoryId;
    
    @Column
    private String productCategoryName;
    
    @Column
    private String productCategoryDescription;

    @Column
    private String productCategoryImage;

    @Column
    private String productCategoryHome;
    
    @Column
    private LocalDateTime createdDate;
    @Column
    private LocalDateTime modifiedDate;

    public UUID getProductCategoryId() {
        return productCategoryId;
    }

    public void setProductCategoryId(UUID productCategoryId) {
        this.productCategoryId = productCategoryId;
    }

    public String getProductCategoryDescription() {
        return productCategoryDescription;
    }

    public void setProductCategoryDescription(String productCategoryDescription) {
        this.productCategoryDescription = productCategoryDescription;
    }

    public String getProductCategoryName() {
        return productCategoryName;
    }

    public void setProductCategoryName(String productCategoryName) {
        this.productCategoryName = productCategoryName;
    }

    public String getProductCategoryImage() {
        return productCategoryImage;
    }

    public void setProductCategoryImage(String productCategoryImage) {
        this.productCategoryImage = productCategoryImage;
    }
    
    public String getProductCategoryHome() {
        return productCategoryHome;
    }

    public void setProductCategoryHome(String productCategoryHome) {
        this.productCategoryHome = productCategoryHome;
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
}
