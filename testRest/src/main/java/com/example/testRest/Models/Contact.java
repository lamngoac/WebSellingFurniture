/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Models;

import java.util.Date;
import javax.persistence.*;
import java.util.UUID;
import org.hibernate.annotations.Type;
/**
 *
 * @author BOSS
 */
@Entity
public class Contact {
    @Id
    @GeneratedValue(generator="system-uuid")
    @Column(length = 36)
    @Type(type = "uuid-char")
    private UUID contactId;
    
    @Column
    private String contactName;
    
    @Column
    private String contactEmail;

    @Column
    private String contactPhone;

    @Column
    private String contactReminder;
    
    @Column
    private Date createdDate;
    @Column
    private Date modifiedDate;

    public UUID getContactId() {
        return contactId;
    }

    public void setContactId(UUID contactId) {
        this.contactId = contactId;
    }

    public String getContactName() {
        return contactName;
    }

    public void setContactName(String contactName) {
        this.contactName = contactName;
    }

    public String getContactEmail() {
        return contactEmail;
    }

    public void setContactEmail(String contactEmail) {
        this.contactEmail = contactEmail;
    }

    public String getContactPhone() {
        return contactPhone;
    }

    public void setContactPhone(String contactPhone) {
        this.contactPhone = contactPhone;
    }
    
    public String getContactReminder() {
        return contactReminder;
    }

    public void setContactReminder(String contactReminder) {
        this.contactReminder = contactReminder;
    }

    public Date getCreatedDate() {
        return createdDate;
    }

    public void setCreatedDate(Date createdDate) {
        this.createdDate = createdDate;
    }

    public Date getModifiedDate() {
        return modifiedDate;
    }

    public void setModifiedDate(Date modifiedDate) {
        this.modifiedDate = modifiedDate;
    }
}
