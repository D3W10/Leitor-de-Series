package com.d3w10.leitordeseries.request;

public class Update {
    private String name;
    private String episode;
    private Boolean seen;

    public Update(String name, String episode, Boolean seen) {
        this.name = name;
        this.episode = episode;
        this.seen = seen;
    }

    public String getName() {
        return name;
    }

    public String getEpisode() {
        return episode;
    }

    public Boolean getSeen() {
        return seen;
    }
}
