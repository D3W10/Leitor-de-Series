package com.d3w10.leitordeseries;

import android.app.Application;

import com.d3w10.leitordeseries.request.Base;

public class Global extends Application {
    private Base data;

    public Base getData() {
        return data;
    }

    public void setData(Base data) {
        this.data = data;
    }
}
