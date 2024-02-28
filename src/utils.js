const { ipcRenderer } = require("electron");
const axios = require("axios").default;
var libraryData;

//#region FUNCTIONS

function closeWindow() {
    ipcRenderer.send("WinClose");
}

function minimizeWindow() {
    ipcRenderer.send("WinMinimize");
}

function fullscreenWindow() {
    if (window.innerWidth != screen.width || window.innerHeight != screen.height) {
        document.getElementById("playerFullscreen").requestFullscreen();
        ipcRenderer.send("WinFullscreen", true);
    }
    else {
        reloadIcons();
        document.exitFullscreen();
        ipcRenderer.send("WinFullscreen", false);
    }
}

async function reloadIcons() {
    for (const icon of document.getElementsByTagName("icon")) {
        let iconXML = await fetch("./assets/icons/" + icon.getAttribute("name") + ".svg");
        icon.innerHTML = await iconXML.text();
    }
}

function openMain() {
    ipcRenderer.send("OpenMain");
}

async function reloadSeries() {
    document.getElementById("libraryLoading").style.display = "unset";

    let library = (await axios.get(getPackageData().api + "api/library")).data;
    libraryData = library.value;

    document.getElementById("libraryItems").replaceChildren();
    for (const serie of libraryData) {
        let card = document.createElement("div"), banner = document.createElement("img"), info = document.createElement("div"), name = document.createElement("h2");

        banner.src = serie.banner.url;
        name.innerText = serie.name;

        info.appendChild(name);
        card.appendChild(banner);
        card.appendChild(info);
        document.getElementById("libraryItems").appendChild(card);

        card.addEventListener("click", () => {
            document.getElementById("goToSerie").innerText = serie.name;
            document.getElementById("goToSerie").click();
        });
    }
    document.getElementById("libraryLoading").removeAttribute("style");
}

function getSerieDataByName(name) {
    return libraryData.find(element => element.name == name);
}

async function setSeenEpisode(name, episode, seen) {
    await axios.post(getPackageData().api + "api/library", {
        name: name,
        episode: episode,
        seen: seen
    });
    reloadSeries();
}

function getPackageData() {
    return ipcRenderer.sendSync("GetPackageData");
}

async function getPaths(name) {
    return await ipcRenderer.sendSync("GetPaths", name);
}

async function getSetting(name) {
    return await ipcRenderer.sendSync("GetSetting", name);
}

function setSetting(name, value) {
    return ipcRenderer.send("SetSetting", name, value);
}

async function showOpenDialog(title, filters, properties) {
    return await ipcRenderer.sendSync("ShowDialog", "OPEN", {
        title: title,
        filters: filters,
        properties: properties
    });
}

async function showSaveDialog(title, defaultPath, filters) {
    return await ipcRenderer.sendSync("ShowDialog", "SAVE", {
        title: title,
        defaultPath: defaultPath,
        filters: filters
    });
}

async function showPopUp(type, title, text, boxText) {
    document.querySelector("#" + type + " > h1").innerText = title;
    if (type == "alertPopup")
        document.querySelector("#" + type + " > p").innerText = text;
    if (type == "crashPopup") {
        document.querySelector("#" + type + " > p").innerText = text;
        document.querySelector("#" + type + " > div").innerText = boxText;
    }

    async function closePopUp(event) {
        if (event.currentTarget == event.target) {
            document.getElementById("popups").removeEventListener("click", closePopUp);
            if (type == "alertPopup")
                document.querySelector("#" + type + " > button").removeEventListener("click", closePopUp);
            else if (type == "crashPopup")
                document.querySelector("#" + type + " > button").removeEventListener("click", closePopUp);
            document.getElementById("popups").style.opacity = "0";
            document.getElementById(type).style.opacity = "0";
            document.getElementById(type).style.transform = "scale(0.5)";
            await sleep(200);
            document.getElementById(type).removeAttribute("style");
            document.getElementById("popups").removeAttribute("style");
        }
    }

    document.getElementById("popups").style.display = "flex";
    await sleep(50);
    document.getElementById("popups").style.opacity = "1";
    document.getElementById(type).style.display = "block";
    await sleep(50);
    document.getElementById(type).style.opacity = "1";
    document.getElementById(type).style.transform = "scale(1)";
    document.getElementById("popups").addEventListener("click", closePopUp);
    if (type == "alertPopup")
        document.querySelector("#" + type + " > button").addEventListener("click", closePopUp);
    else if (type == "crashPopup")
        document.querySelector("#" + type + " > button").addEventListener("click", closePopUp);
}

function sleep(milliseconds) {
    return new Promise(resolve => setTimeout(resolve, milliseconds));
}

//#endregion

exports.closeWindow = closeWindow;
exports.minimizeWindow = minimizeWindow;
exports.fullscreenWindow = fullscreenWindow;
exports.reloadIcons = reloadIcons;
exports.openMain = openMain;
exports.reloadSeries = reloadSeries;
exports.getSerieDataByName = getSerieDataByName;
exports.setSeenEpisode = setSeenEpisode;
exports.getPackageData = getPackageData;
exports.getPaths = getPaths;
exports.getSetting = getSetting;
exports.setSetting = setSetting;
exports.showOpenDialog = showOpenDialog;
exports.showSaveDialog = showSaveDialog;
exports.showPopUp = showPopUp;
exports.sleep = sleep;