package com.d3w10.leitordeseries.request;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface LeitorDeSeriesAPI {
    @GET("library")
    Call<Base> getSeries();

    @POST("library")
    Call<Status> updateSeen(@Body Update update);
}