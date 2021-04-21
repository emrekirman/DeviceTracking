const { app, BrowserWindow } = require('electron')
// const url = require("url");
const path = require("path");
var exec = require('child_process').execFile, child;


// const shell = require('shelljs');
// shell.exec("START api/UncleProductTracking.API.exe");

var run = function () {
    // child = exec(__dirname + "\\api\\start.bat", function (err, stdout, stderr) {
    child = exec(__dirname + "\\api\\UncleProductTracking.API.exe", function (err, stdout, stderr) {
        console.log(__dirname);
        if (err) {
            console.log(err);
        }
        console.log(stdout);
    })

    // console.log(child);
}

let mainWindow
run();


function createWindow() {
    mainWindow = new BrowserWindow({
        width: 1024,
        height: 768,
        webPreferences: {
            nodeIntegration: true
        }
    })

    // run();


    mainWindow.removeMenu();
    mainWindow.loadFile(__dirname + '/dist/productTracking/index.html');
    console.log(__dirname);

    //   mainWindow.loadURL(
    //     url.format({
    //       pathname: path.join(__dirname, `/dist/index.html`),
    //       protocol: "file:",
    //       slashes: true
    //     })
    //   );
    // Open the DevTools.
    // mainWindow.webContents.openDevTools();

    mainWindow.on('closed', function () {
        mainWindow = null
    })
}

app.on('ready', createWindow);

app.on('window-all-closed', function () {
    if (process.platform !== 'darwin') app.quit()
})

app.on('activate', function () {
    if (mainWindow === null) createWindow()
})
