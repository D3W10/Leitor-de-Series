package com.d3w10.leitordeseries.request;

import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class API {
    private static final Retrofit retrofit = new Retrofit.Builder()
            .baseUrl("https://leitor-de-series-api.vercel.app/api/")
            .addConverterFactory(GsonConverterFactory.create())
            .build();

    private static final LeitorDeSeriesAPI leitorDeSeriesAPI = retrofit.create(LeitorDeSeriesAPI.class);

    public static Call<Base> getSeries() {
        return leitorDeSeriesAPI.getSeries();
    }

    public static Call<Status> updateSeen(String name, String episode, Boolean seen) {
        return leitorDeSeriesAPI.updateSeen(new Update(name, episode, seen));
    }
}