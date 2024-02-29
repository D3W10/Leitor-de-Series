package com.d3w10.leitordeseries.request;

import com.google.gson.annotations.SerializedName;

public class Banner {
    @SerializedName("__type")
    private String type;
    private String name;
    private String url;

    public String getType() {
        return type;
    }

    public String getName() {
        return name;
    }

    public String getUrl() {
        return url;
    }
}