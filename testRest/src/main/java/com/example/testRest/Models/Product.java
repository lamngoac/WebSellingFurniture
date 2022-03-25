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
public class Product {
    @Id
    @GeneratedValue(generator="system-uuid")
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID productId;
    
    @Column
    private String productName;
    
    @Column
    private String productDimensions;

    @Column
    private String productMaterial;
    
    @Column
    private String productManufacturer;
    
    @Column
    private int productColor;
    
    @Column
    private double productOriginalPrice;
    
    @Column
    private double productSalePrice;
    
    @Column
    private String productDescriptionShort;
    
    @Column
    private String productDescription;
    
    @Column
    private double productEvaluate; 

    @Column
    private LocalDateTime createdDate = LocalDateTime.now();
    @Column
    private LocalDateTime modifiedDate = LocalDateTime.now(); 
    
    @GeneratedValue(generator="system-uuid")
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID productCategoryId;
    
    @Column
    private String productImage;

    public UUID getProductId() {
        return productId;
    }

    public void setProductId(UUID productId) {
        this.productId = productId;
    }

    public String getProductName() {
        return productName;
    }

    public void setProductName(String productName) {
        this.productName = productName;
    }

    public String getProductDimensions() {
        return productDimensions;
    }

    public void setProductDimensions(String productDimensions) {
        this.productDimensions = productDimensions;
    }

    public String getProductMaterial() {
        return productMaterial;
    }

    public void setProductMaterial(String productMaterial) {
        this.productMaterial = productMaterial;
    }
    
    public String getProductManufacturer() {
        return productMaterial;
    }

    public void setProductManufacturer(String productManufacturer) {
        this.productManufacturer = productManufacturer;
    }
    
    public int getProductColor() {
        return productColor;
    }

    public void setProductColor(int productColor) {
        this.productColor = productColor;
    }
    
    public double getProductOriginalPrice() {
        return productOriginalPrice;
    }

    public void setProductOriginalPrice(double productOriginalPrice) {
        this.productOriginalPrice = productOriginalPrice;
    }
    
    public double getProductSalePrice() {
        return productSalePrice;
    }

    public void setProductSalePrice(double productSalePrice) {
        this.productSalePrice = productSalePrice;
    }
    
    public String getProductDescriptionShort() {
        return productMaterial;
    }

    public void setProductDescriptionShort(String productDescriptionShort) {
        this.productDescriptionShort = productDescriptionShort;
    }
    
    public String getProductDescription() {
        return productMaterial;
    }

    public void setProductDescription(String productDescription) {
        this.productDescription = productDescription;
    }
    
    public double getProductEvaluate() {
        return productEvaluate;
    }

    public void setProductEvaluate(double productEvaluate) {
        this.productEvaluate = productEvaluate;
    }
    
    public UUID getProductCategoryId(){
        return productCategoryId;
    }
    
    public void setProductCategoryId(UUID productCategoryId){
        this.productCategoryId = productCategoryId;
    }
    
    public String getProductImage(){
        return productImage;
    }
    
    public void setProductImage(String productImage){
        this.productImage = productImage;
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
