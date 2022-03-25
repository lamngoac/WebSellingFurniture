/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Repo;
import java.util.UUID;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.NoRepositoryBean;

/**
 *
 * @author Dell
 * @param <T>
 */
@NoRepositoryBean
public interface BaseRepo<T> extends JpaRepository<T,UUID>{
}
