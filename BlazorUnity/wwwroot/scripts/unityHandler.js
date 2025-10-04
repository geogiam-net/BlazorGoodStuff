// we need a destructor, remove script

var loadUnity = () => {
    var redButton = document.querySelector("#unity-red");
    var blueButton = document.querySelector("#unity-blue");

    var canvas = document.querySelector("#unity-canvas");
    var buildUrl = "Build";
    var loaderUrl = buildUrl + "/build2.loader.js";
    var config = {
        arguments: [],
        dataUrl: buildUrl + "/build2.data.json",
        frameworkUrl: buildUrl + "/build2.framework.js",
        codeUrl: buildUrl + "/build2.wasm",
        streamingAssetsUrl: "StreamingAssets",
        companyName: "DefaultCompany",
        productName: "UnityProject2",
        productVersion: "0.1.0",
        showBanner: () => { },
    };

    var script = document.createElement("script");
    script.src = loaderUrl;

    script.onload = () => {
        createUnityInstance(canvas, config, (progress) => {
            // document.querySelector("#unity-progress-bar-full").style.width = 100 * progress + "%";
        }).then((unityInstance) => {
            /*
            document.querySelector("#unity-loading-bar").style.display = "none";
            document.querySelector("#unity-fullscreen-button").onclick = () => {
                unityInstance.SetFullscreen(1);
            };
            */

            redButton.addEventListener('click', function () {
                unityInstance.SendMessage('JavascriptHook', 'TintRed');
                console.log('clicked red');
            });

            blueButton.addEventListener('click', function () {
                unityInstance.SendMessage('JavascriptHook', 'TintBlue');
                console.log('clicked blue');
            });

        }).catch((message) => {
            alert(message);
        });
    };

    document.body.appendChild(script);
};

export { loadUnity };