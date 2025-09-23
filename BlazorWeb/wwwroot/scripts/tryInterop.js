var blazorInstance = null;

var showMessage = (message) => {
    var elem = document.getElementById('jsResult');
    elem.innerText = message;
};

var btClick = () => {
    blazorInstance.invokeMethodAsync('InvokeCSharp');
};

var putBlazorInstance = (instance) => {
    blazorInstance = instance;
};

export { showMessage, btClick, putBlazorInstance };