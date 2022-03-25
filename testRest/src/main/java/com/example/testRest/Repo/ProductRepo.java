/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Repo;

import com.example.testRest.Models.Product;
import java.util.List;
import org.springframework.data.jpa.repository.Query;
/**
 *
 * @author BOSS
 */
public interface ProductRepo extends BaseRepo<Product>{
    @Query(value = "CALL `webnoithat_java`.proc_get_products_filter(?1,?2,?3,?4,?5,?6,?7);", nativeQuery = true)
    public List<Product> getPagging(int pageIndex, int pageSize, String fil,int sortStatus, String fieldSort,String categoryId, int price);
    
    
    @Query(value = "CALL `webnoithat_java`.proc_get_products_top_selling(?1);", nativeQuery = true)
    public List<Product> getTopSellings(int number);
    
}
