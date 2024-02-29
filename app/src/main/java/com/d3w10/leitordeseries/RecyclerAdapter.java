package com.d3w10.leitordeseries;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.d3w10.leitordeseries.request.API;
import com.d3w10.leitordeseries.request.Base;
import com.d3w10.leitordeseries.request.Episode;
import com.d3w10.leitordeseries.request.Serie;
import com.d3w10.leitordeseries.request.Status;

import java.util.List;
import java.util.Objects;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class RecyclerAdapter extends RecyclerView.Adapter<RecyclerAdapter.ViewHolder> {
    private final Context context;
    private final Object items;
    private final Boolean serie;
    private final String name;

    public RecyclerAdapter(Context context, Object items, Boolean serie, String name) {
        this.context = context;
        this.items = items;
        this.serie = serie;
        this.name = name;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(serie ? R.layout.recycler_serie : R.layout.recycler_item, parent, false);
        ViewHolder holder = new ViewHolder(view);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        if (serie) {
            holder.recycler_serie.setOnClickListener(v -> context.startActivity(new Intent(context, SerieActivity.class).putExtra("position", position)));
            new DownloadImageTask(holder.recycler_serie_image).execute(((List<Serie>) items).get(position).getBanner().getUrl());
            holder.recycler_serie_text.setText(((List<Serie>) items).get(position).getName());
        }
        else {
            holder.recycler_item.setOnClickListener(v -> context.startActivity(new Intent(context, WebActivity.class).putExtra("URL", ((List<Episode>) items).get(position).getLink())));
            holder.recycler_item_seen.setOnCheckedChangeListener((buttonView, isChecked) -> {
                API.updateSeen(name, ((List<Episode>) items).get(position).getName(), isChecked).enqueue(new Callback<Status>() {
                    @Override
                    public void onResponse(Call<Status> call, Response<Status> response) {
                        if (Objects.equals(response.body().getStatus(), "Successfully updated")) {
                            API.getSeries().enqueue(new Callback<Base>() {
                                @Override
                                public void onResponse(Call<Base> call, Response<Base> response) {
                                    ((Global) context.getApplicationContext()).setData(response.body());
                                }

                                @Override
                                public void onFailure(Call<Base> call, Throwable t) {}
                            });
                        }
                    }

                    @Override
                    public void onFailure(Call<Status> call, Throwable t) {}
                });
            });

            holder.recycler_item_text.setText(((List<Episode>) items).get(position).getName());
            holder.recycler_item_seen.setChecked(((List<Episode>) items).get(position).isSeen());
        }
    }

    @Override
    public int getItemCount() {
        return serie ? ((List<Serie>) items).size() : ((List<Episode>) items).size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        CardView recycler_serie;
        ImageView recycler_serie_image;
        TextView recycler_serie_text;

        CardView recycler_item;
        TextView recycler_item_text;
        CheckBox recycler_item_seen;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);

            if (serie) {
                recycler_serie = itemView.findViewById(R.id.recycler_serie);
                recycler_serie_image = itemView.findViewById(R.id.recycler_serie_image);
                recycler_serie_text = itemView.findViewById(R.id.recycler_serie_text);
            }
            else {
                recycler_item = itemView.findViewById(R.id.recycler_item);
                recycler_item_text = itemView.findViewById(R.id.recycler_item_text);
                recycler_item_seen = itemView.findViewById(R.id.recycler_item_seen);
            }
        }
    }
}