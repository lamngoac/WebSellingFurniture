package com.example.testRest.Repo;

import com.example.testRest.Models.User;
import java.util.List;
import org.springframework.data.jpa.repository.Query;

public interface UserRepo extends BaseRepo<User>{
    @Query(value = "CALL `webnoithat_java`.proc_get_user_by_username(?1);", nativeQuery = true)
    public User getUserByUserName(String userName);
    
    @Query(value = "CALL `webnoithat_java`.proc_get_users_filter(?1,?2,?3);", nativeQuery = true)
    public List<User> getPagging(int pageIndex, int pageSize, String fil);
}
