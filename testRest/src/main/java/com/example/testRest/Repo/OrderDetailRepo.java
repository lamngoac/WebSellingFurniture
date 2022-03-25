/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Repo;

import com.example.testRest.Models.OrderDetail;
import java.util.List;
import org.springframework.data.jpa.repository.Query;

/**
 *
 * @author BOSS
 */
public interface OrderDetailRepo extends BaseRepo<OrderDetail>{
    @Query(value = "CALL `webnoithat_java`.proc_get_orderDetails_filter(?1,?2,?3);", nativeQuery = true)
    public List<OrderDetail> getPagging(int pageIndex, int pageSize, String fil);
}
