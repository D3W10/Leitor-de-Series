const { app, BrowserWindow, dialog, globalShortcut, ipcMain } = require("electron");
const fs = require("fs");
const path = require("path");
const Store = require("electron-store");
var splash, win;

//#region INITIALIZATION

const appConfig = new Store({ defaults: {
    settings: {
        darkMode: false
    }
}});

//#endregion

//#region WINDOWS

function createWindow() {
    splash = new BrowserWindow({
        title: "Leitor de Séries",
        width: 450,
        height: 300,
        frame: false,
        resizable: false,
        fullscreen: false,
        fullscreenable: false,
        maximizable: false,
        show: false,
        icon: path.join(__dirname, "assets/logo.png"),
        webPreferences: {
            devTools: true,
            preload: path.join(__dirname, "src/splash.js"),
            nodeIntegration: true
        }
    });
    splash.loadFile("splash.html");
    splash.once("ready-to-show", () => splash.show());

    win = new BrowserWindow({
        title: "Leitor de Séries",
        width: 1000,
        height: 600,
        frame: false,
        resizable: false,
        fullscreen: false,
        fullscreenable: true,
        maximizable: false,
        show: false,
        icon: path.join(__dirname, "assets/logo.png"),
        webPreferences: {
            devTools: true,
            preload: path.join(__dirname, "src/home.js"),
            nodeIntegration: true
        }
    });
    win.loadFile("index.html");
}

//#endregion

//#region APP EVENTS

app.on("second-instance", () => {
    if (win.isMinimized())
        win.restore();
    win.focus();
});

app.whenReady().then(() => {
    createWindow();
    
    globalShortcut.register("CommandOrControl+Shift+I", () => {
        return false;
    });
    
    globalShortcut.register("CommandOrControl+F12", () => {
        if (BrowserWindow.getFocusedWindow())
            BrowserWindow.getFocusedWindow().webContents.openDevTools();
    });
});

app.on("window-all-closed", () => {
    if (process.platform !== "darwin")
        app.quit();
});

//#endregion

//#region RENDER EVENTS

ipcMain.on("WinClose", () => app.exit());

ipcMain.on("WinMinimize", () => BrowserWindow.getAllWindows()[0].minimize());

ipcMain.on("WinFullscreen", (_, fullscreen) => win.setFullScreen(fullscreen));

ipcMain.on("OpenMain", () => {
    splash.close();
    win.show();
});

ipcMain.on("GetPackageData", (event) => event.returnValue = getPackageData());

function getPackageData() { 
    return JSON.parse(fs.readFileSync(path.join(__dirname, "package.json"), "utf8"));
}

ipcMain.on("GetPaths", (event, name) => event.returnValue = app.getPath(name));

ipcMain.on("GetSetting", (event, name) => event.returnValue = appConfig.get(name));

ipcMain.on("SetSetting", (_, name, value) => appConfig.set(name, value));

ipcMain.on("ShowDialog", async (event, type, options) => {
    if (type == "OPEN")
        event.returnValue = await dialog.showOpenDialog(BrowserWindow.getAllWindows()[0], options);
    else if (type == "SAVE")
        event.returnValue = await dialog.showSaveDialog(BrowserWindow.getAllWindows()[0], options);
});

//#endregion