package com.d3w10.leitordeseries.request;

import java.util.List;

public class Serie {
    private String name;
    private Banner banner;
    private List<Episode> episodes;

    public String getName() {
        return name;
    }

    public Banner getBanner() {
        return banner;
    }

    public List<Episode> getEpisodes() {
        return episodes;
    }
}