const utils = require("./utils");
const { sleep } = require("./utils");
var openPanel = null, upSideDown = 0, upSideDownTimeOut = undefined;

window.addEventListener("load", () => {
    //#region INITIALIZATION

    (async function () {
        await utils.reloadIcons();

        if ((await utils.getSetting("settings")).darkMode) {
            document.body.setAttribute("theme", "dark");
            document.getElementById("settingsAppearance").value = "1";
        }

        for (const panel of document.querySelectorAll("#appTab > *")) {
            if (panel.id != document.getElementById("appTab").children[0].id) {
                panel.style.display = "none";
                panel.style.opacity = "0";
                openPanel = document.getElementById("appTab").children[0].id;
            }
        }

        for (const element of document.querySelectorAll("button[goto], a[goto]")) {
            element.addEventListener("click", async (event) => {
                let panelToSwitch = event.currentTarget.getAttribute("goto");

                if (openPanel != panelToSwitch && !event.currentTarget.hasAttribute("disabled") && !event.currentTarget.parentElement.hasAttribute("disabled")) {
                    for (const selectedTab of document.getElementsByClassName("selected"))
                        selectedTab.classList.remove("selected");
                    if (event.currentTarget.classList.contains("sidebarOption"))
                        event.currentTarget.classList.add("selected");

                    document.getElementById(openPanel).style.opacity = "0";
                    await sleep(200);
                    document.getElementById(openPanel).style.display = "none";

                    openPanel = panelToSwitch;

                    document.getElementById(panelToSwitch).style.display = "flex";
                    await sleep(200);
                    document.getElementById(panelToSwitch).removeAttribute("style");
                }
            });
        }

        document.getElementById("settingsVersion").innerText = utils.getPackageData().version;
    }());

    utils.reloadSeries();

    //#endregion

    //#region FRAME BAR

    document.getElementById("closeCircle").addEventListener("click", () => utils.closeWindow());

    document.getElementById("minimizeCircle").addEventListener("click", () => utils.minimizeWindow());

    //#endregion

    //#region SERIE PANEL

    document.getElementById("goToSerie").addEventListener("click", async () => {
        let sData = utils.getSerieDataByName(document.getElementById("goToSerie").innerText);
        
        document.querySelector("#serieHeader > h1").innerText = sData.name;
        document.querySelector("#serieHeader > img").src = sData.banner.url;
        
        document.getElementById("serieContent").replaceChildren();
        for (const episode of sData.episodes) {
            let episodeDiv = document.createElement("div"), episodeNumber = document.createElement("p"), episodeCheckmark = document.createElement("input");

            episodeNumber.innerText = episode.name;
            episodeCheckmark.type = "checkbox";
            episodeCheckmark.checked = episode.seen;
            episodeDiv.appendChild(episodeNumber);
            episodeDiv.appendChild(episodeCheckmark);
            episodeDiv.addEventListener("click", (event) => {
                if (event.target.tagName != "INPUT") {
                    document.querySelector("#playerPanel > h1").innerText = episode.name;
                    document.querySelector("#playerPanel > div > iframe").src = episode.link;
                    document.getElementById("goToPlayer").click();
                }
            });
            episodeCheckmark.addEventListener("click", async () => utils.setSeenEpisode(sData.name, episode.name, episodeCheckmark.checked));
            document.getElementById("serieContent").appendChild(episodeDiv);
        }
    });

    //#endregion

    //#region PLAYER PANEL

    document.querySelector("#playerFullscreen > div").addEventListener("click", () => utils.fullscreenWindow());

    //#endregion

    //#region SETTINGS PANEL

    document.getElementById("settingsAppearance").addEventListener("change", () => {
        if (Boolean(Number(document.getElementById("settingsAppearance").value)))
            document.body.setAttribute("theme", "dark");
        else
            document.body.setAttribute("theme", "light");
        utils.setSetting("settings.darkMode", Boolean(Number(document.getElementById("settingsAppearance").value)));
    });

    document.getElementById("settingsVersion").addEventListener("click", () => {
        upSideDown++;
        clearTimeout(upSideDownTimeOut);
        upSideDownTimeOut = setTimeout(() => upSideDown = 0, 400);
        if (upSideDown == 5) {
            upSideDown = 0;
            if (!document.body.hasAttribute("style"))
                document.body.style.transform = "rotateZ(180deg)";
            else
                document.body.removeAttribute("style");
        }
    });
    
    //#endregion
});