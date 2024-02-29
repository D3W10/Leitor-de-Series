package com.d3w10.leitordeseries;

import android.os.Bundle;
import android.view.MenuItem;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.d3w10.leitordeseries.databinding.ActivitySerieBinding;
import com.d3w10.leitordeseries.request.Serie;
import com.google.android.material.appbar.CollapsingToolbarLayout;

public class SerieActivity extends AppCompatActivity {

    private ActivitySerieBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        binding = ActivitySerieBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        Serie current = ((Global) getApplication()).getData().getSeries().get(getIntent().getIntExtra("position", 0));

        Toolbar toolbar = binding.toolbar;
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        CollapsingToolbarLayout toolBarLayout = binding.toolbarLayout;
        toolBarLayout.setTitle(current.getName());

        RecyclerView serie_recycler = findViewById(R.id.serie_recycler);
        RecyclerAdapter adapter = new RecyclerAdapter(this, current.getEpisodes(), false, current.getName());
        serie_recycler.setAdapter(adapter);
        serie_recycler.setLayoutManager(new LinearLayoutManager(this));
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            onBackPressed();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}