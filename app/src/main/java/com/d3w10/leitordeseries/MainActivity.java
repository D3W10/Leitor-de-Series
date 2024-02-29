package com.d3w10.leitordeseries;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.ProgressBar;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.d3w10.leitordeseries.request.API;
import com.d3w10.leitordeseries.request.Base;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ProgressBar load_bar = findViewById(R.id.load_bar);
        RecyclerView content_recycler = findViewById(R.id.content_recycler);

        load_bar.setVisibility(View.VISIBLE);

        Context context = this;
        API.getSeries().enqueue(new Callback<Base>() {
            @Override
            public void onResponse(Call<Base> call, Response<Base> response) {
                ((Global) getApplication()).setData(response.body());

                RecyclerAdapter adapter = new RecyclerAdapter(context, response.body().getSeries(), true, null);
                content_recycler.setAdapter(adapter);
                content_recycler.setLayoutManager(new LinearLayoutManager(context));

                load_bar.setVisibility(View.INVISIBLE);
            }

            @Override
            public void onFailure(Call<Base> call, Throwable t) {}
        });
    }
}