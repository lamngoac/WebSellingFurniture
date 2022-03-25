/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Models;

import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import java.util.List;

/**
 *
 * @author Dell
 */
public class PageResult<T> {
    
    private long totalRecord;
    private int totalPages;
    private List<T> data;
    private int pageIndex;
    private int pageSize;
    
    public PageResult(){
        
    }
    public PageResult(long totalRecord, int totalPages, List<T> data, int pageIndex, int pageSize) {
        this.totalRecord = totalRecord;
        this.totalPages = totalPages;
        this.data = data;
        this.pageIndex = pageIndex;
        this.pageSize = pageSize;
    }

    public long TotalRecord() {
        return totalRecord;
    }

    public void setTotalRecord(long totalRecord) {
        this.totalRecord = totalRecord;
    }

    public int TotalPages() {
        return totalPages;
    }

    public void setTotalPages(int totalPages) {
        this.totalPages = totalPages;
    }

    public int PageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public int PageSize() {
        return pageSize;
    }

    public void setPageSize(int pageSize) {
        this.pageSize = pageSize;
    }
    
    public void setData(List<T> data){
        this.data = data;
    }
    public List<T> Data(){
        return this.data;
    }
}
