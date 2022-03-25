/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Repo;

import com.example.testRest.Models.Order;
import com.example.testRest.Models.OrderDetail;
import java.util.List;
import java.util.UUID;
import org.springframework.data.jpa.repository.Query;

/**
 *
 * @author BOSS
 */
public interface OrderRepo extends BaseRepo<Order>{
    @Query(value = "CALL `webnoithat_java`.proc_get_orders_filter(?1,?2,?3);", nativeQuery = true)
    public List<Order> getPagging(int pageIndex, int pageSize, String fil);
    
    @Query(value = "CALL `webnoithat_java`.proc_get_orders_by_user(?1);", nativeQuery = true)
    public List<Order> getOrderByUser(UUID userId);

    @Query(value = "CALL `webnoithat_java`.proc_get_orders_history_id(?1,?2,?3);", nativeQuery = true)
    public List<OrderDetail> getHistory(UUID id, int pageIndex, int pageSize);
    
    @Query(value = "CALL `webnoithat_java`.proc_delete_order(?1);", nativeQuery = true)
    public Object deleteOrder(UUID orderId);
}
