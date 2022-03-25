/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Repo;

import com.example.testRest.Models.News;
import java.util.List;
import org.springframework.data.jpa.repository.Query;

/**
 *
 * @author BOSS
 */
public interface NewsRepo extends BaseRepo<News>{
    
    @Query(value = "CALL `webnoithat_java`.proc_get_news_event;", nativeQuery = true)
    public List<News> getEvents();
    
    @Query(value = "CALL `webnoithat_java`.proc_get_news_sale;", nativeQuery = true)
    public List<News> getSales();
    
    @Query(value = "CALL `webnoithat_java`.proc_get_news_home;", nativeQuery = true)
    public List<News> getHomes();
    
    @Query(value = "CALL `webnoithat_java`.proc_get_news_hot;", nativeQuery = true)
    public List<News> getHots();
    
    @Query(value = "CALL `webnoithat_java`.proc_get_news_product;", nativeQuery = true)
    public List<News> getProducts();
    
    @Query(value = "CALL `webnoithat_java`.proc_get_newss_filter(?1,?2,?3);", nativeQuery = true)
    public List<News> getPagging(int pageIndex, int pageSize, String fil);
}
