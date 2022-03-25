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
public class Project {
    @Id
    @GeneratedValue(generator="system-uuid")
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID projectId;
    
    @Column
    private String projectTitle;
    
    @Column
    private String projectContent;

    @Column
    private String linkImage;

    @Column
    private int projectHome;
    @Column
    private int projectHot;

    @Column
    private LocalDateTime createdDate;
    @Column
    private LocalDateTime modifiedDate;

    public UUID getProjectId() {
        return projectId;
    }

    public void setProjectId(UUID projectId) {
        this.projectId = projectId;
    }

    public String getProjectTitle() {
        return projectTitle;
    }

    public void setProjectTitle(String projectTitle) {
        this.projectTitle = projectTitle;
    }

    public String getProjectContent() {
        return projectContent;
    }

    public void setProjectContent(String projectContent) {
        this.projectContent = projectContent;
    }

    public String getLinkImage() {
        return linkImage;
    }

    public void setLinkImage(String linkImage) {
        this.linkImage = linkImage;
    }

    public int getProjectHome() {
        return projectHome;
    }

    public void setProjectHome(int projectHome) {
        this.projectHome = projectHome;
    }

    public int getProjectHot() {
        return projectHot;
    }

    public void setProjectHot(int projectHot) {
        this.projectHot = projectHot;
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
