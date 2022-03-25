/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Repo;
import com.example.testRest.Models.ProductCategory;
import java.util.List;

import com.example.testRest.Models.Project;
import org.springframework.data.jpa.repository.Query;
/**
 *
 * @author BOSS
 */
public interface ProductCategoryRepo extends BaseRepo<ProductCategory>{
    @Query(value = "CALL `webnoithat_java`.proc_get_productCategorys_filter(?1,?2,?3);", nativeQuery = true)
    public List<ProductCategory> getPagging(int pageIndex, int pageSize, String fil);

    @Query(value = "CALL `webnoithat_java`.proc_get_productCategory_home;", nativeQuery = true)
    public List<ProductCategory> getHomes();
}
