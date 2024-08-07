function timerInactivo(dotnetHelper) {
    var timer;    
    clearTimeout(timer);
    timer = setInterval(refresToken, 270000);    
    function refresToken() {
        dotnetHelper.invokeMethodAsync("RefresToken");
    }
}