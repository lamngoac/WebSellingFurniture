/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.testRest.Models;

/**
 *
 * @author Dell
 */
public class SortCondition {

    public int getSortStatus() {
        return sortStatus;
    }

    public void setSortStatus(int sortStatus) {
        this.sortStatus = sortStatus;
    }

    public String getFieldSort() {
        return fieldSort;
    }

    /// <summary>
    /// Trạng thái sắp xếp
    public void setFieldSort(String fieldSort) {
        this.fieldSort = fieldSort;
    }
    /// </summary>
    private int sortStatus = 0;
    /// <summary>
    /// Field Sắp xếp
    /// </summary>
    private String fieldSort;
}
