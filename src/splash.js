const axios = require("axios").default;
const utils = require("./utils");

window.addEventListener("load", async () => {
    await utils.reloadIcons();
    
    if ((await utils.getSetting("settings")).darkMode)
        document.body.setAttribute("theme", "dark");

    try {
        await axios.get("https://1.1.1.1/", { timeout: 3000 });

        if (!navigator.onLine)
            throw new Error();
    }
    catch {
        document.getElementById("splashMessage").innerText = "Sem internet";
        document.getElementById("splashProgress").style.opacity = "0";
        return;
    }

    document.getElementById("splashMessage").innerText = "A concluir";
    document.getElementById("splashProgress").style.setProperty("--value", "100%");

    utils.openMain();
});