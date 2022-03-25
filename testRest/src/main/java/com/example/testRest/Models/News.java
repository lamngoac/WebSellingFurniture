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
public class News {
    @Id
    @GeneratedValue(generator="system-uuid")
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID newsId;
    
    @Column
    private String newsTitle;
    
    @Column
    private String newsContent;

    @Column
    private String linkImage;

    @Column
    private int newsHot;
    
    @Column
    private int newsProduct;
    
    @Column
    private int newsSale;
    
    @Column
    private int newsEvent;
    
    @Column
    private int newsHome;
    
    @Column
    private LocalDateTime createdDate;
    @Column
    private LocalDateTime modifiedDate;

    public UUID getNewsId() {
        return newsId;
    }

    public void setNewsId(UUID newsId) {
        this.newsId = newsId;
    }

    public String getNewsTitle() {
        return newsTitle;
    }

    public void setNewsTitle(String newsTitle) {
        this.newsTitle = newsTitle;
    }

    public String getNewsContent() {
        return newsContent;
    }

    public void setNewsContent(String newsContent) {
        this.newsContent = newsContent;
    }

    public String getLinkImage() {
        return linkImage;
    }

    public void setLinkImage(String linkImage) {
        this.linkImage = linkImage;
    }
    /////
    public int getNewsHot() {
        return newsHot;
    }

    public void setNewsHot(int newsHot) {
        this.newsHot = newsHot;
    }
    /////
    public int getNewsProduct() {
        return newsProduct;
    }

    public void setNewsProduct(int newsProduct) {
        this.newsProduct = newsProduct;
    }
    /////
    public int getNewsSale() {
        return newsSale;
    }

    public void setNewsSale(int newsSale) {
        this.newsSale = newsSale;
    }
    /////
    public int getNewsEvent() {
        return newsEvent;
    }

    public void setNewsEvent(int newsEvent) {
        this.newsEvent = newsEvent;
    }
    /////
    public int getNewsHome() {
        return newsHome;
    }

    public void setNewsHome(int newsHome) {
        this.newsHome = newsHome;
    }
    /////
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
