/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Controller;

import com.example.testRest.Models.News;
import com.example.testRest.Repo.NewsRepo;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.util.UUID;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

@CrossOrigin("*")
@RestController
@RequestMapping("api/v1/News")
public class NewsController extends BaseController<News>{
    @Autowired
    private NewsRepo newsRepo;

    @PutMapping(value = "")
    public String updateProject(@RequestBody News news){
        News updatedNews = newsRepo.findById(news.getNewsId()).get();
        updatedNews.setNewsTitle(news.getNewsTitle());
        updatedNews.setNewsContent(news.getNewsContent());
        updatedNews.setLinkImage(news.getLinkImage());
        updatedNews.setNewsHot(news.getNewsHot());
        updatedNews.setNewsProduct(news.getNewsProduct());
        updatedNews.setNewsSale(news.getNewsSale());
        updatedNews.setNewsEvent(news.getNewsEvent());
        updatedNews.setNewsHome(news.getNewsHome());
        updatedNews.setCreatedDate(news.getCreatedDate());
        updatedNews.setModifiedDate(news.getModifiedDate());
        newsRepo.save(updatedNews);
        return "update...";
    }
    
    @GetMapping(value = "/pagging")
    public ResponseEntity<Map<String, Object>> getPagging(@RequestParam int PageIndex, @RequestParam int PageSize, @RequestParam String Fil) {
        try {
            if(PageIndex == 0){
                PageIndex = 1;
            }
            if(PageSize == 1){
                PageSize = 10;
            }
            Map<String, Object> response = new HashMap<>();
            long count = newsRepo.count();
            response.put("data", newsRepo.getPagging(PageIndex, PageSize, Fil));
            response.put("pageIndex", PageIndex);
            response.put("pageSize", PageSize);
            response.put("totalRecord", count);
            if (count % PageSize != 0) {
                response.put("totalPages", (int) (count / PageSize) + 1);
            } else {
                response.put("totalPages", (int) (count / PageSize));
            }
            return new ResponseEntity<>(response, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
    
    @GetMapping(value = "/data-home")
    public List<News> getHomes() {
        try {
            return newsRepo.getHomes();
        } catch (Exception e) {
            return null;
        }
    }
    @GetMapping(value = "/data-hot")
    public List<News> getHots() {
        try {
            return newsRepo.getHots();
        } catch (Exception e) {
            return null;
        }
    }
    
    @GetMapping(value = "/data-sale")
    public List<News> getSales() {
        try {
            return newsRepo.getSales();
        } catch (Exception e) {
            return null;
        }
    }
    @GetMapping(value = "/data-event")
    public List<News> getEvents() {
        try {
            return newsRepo.getEvents();
        } catch (Exception e) {
            return null;
        }
    }
    
    @GetMapping(value = "/data-product")
    public List<News> getProducts() {
        try {
            return newsRepo.getProducts();
        } catch (Exception e) {
            return null;
        }
    }
}
