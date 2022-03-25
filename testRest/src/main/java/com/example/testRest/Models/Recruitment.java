package com.example.testRest.Models;
import java.time.LocalDateTime;
import java.util.Date;
import javax.persistence.*;
import java.util.UUID;
import org.hibernate.annotations.Type;

@Entity
public class Recruitment {
    @Id
    @GeneratedValue(generator="system-uuid")
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID recruitmentId;
    @Column
    private String recruitmentTitle;
    @Column
    private String recruitmentContent;

    @Column
    private String linkImage;
    @Column
    private int recruitmentHome;

    public int getRecruitmentHome() {
        return recruitmentHome;
    }

    public void setRecruitmentHome(int recruitmentHome) {
        this.recruitmentHome = recruitmentHome;
    }

    public int getRecruitmentHot() {
        return recruitmentHot;
    }

    public void setRecruitmentHot(int recruitmentHot) {
        this.recruitmentHot = recruitmentHot;
    }

    @Column
    private int recruitmentHot;
    @Column
    private LocalDateTime createdDate;
    @Column
    private LocalDateTime modifiedDate;

    public UUID getRecruitmentId() {
        return recruitmentId;
    }

    public void setRecruitmentId(UUID recruitmentId) {
        this.recruitmentId = recruitmentId;
    }

    public String getRecruitmentTitle() {
        return recruitmentTitle;
    }

    public void setRecruitmentTitle(String recruitmentTitle) {
        this.recruitmentTitle = recruitmentTitle;
    }

    public String getRecruitmentContent() {
        return recruitmentContent;
    }

    public void setRecruitmentContent(String recruitmentContent) {
        this.recruitmentContent = recruitmentContent;
    }

    public String getLinkImage() {
        return linkImage;
    }

    public void setLinkImage(String linkImage) {
        this.linkImage = linkImage;
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
