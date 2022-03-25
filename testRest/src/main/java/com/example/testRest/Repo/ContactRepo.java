/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Repo;

import com.example.testRest.Models.Contact;
import com.example.testRest.Models.News;
import java.util.List;
import org.springframework.data.jpa.repository.Query;


/**
 *
 * @author BOSS
 */

public interface ContactRepo extends BaseRepo<Contact>{
    @Query(value = "CALL `webnoithat_java`.proc_get_contacts_filter(?1,?2,?3);", nativeQuery = true)
    public List<Contact> getPagging(int pageIndex, int pageSize, String fil);
}
