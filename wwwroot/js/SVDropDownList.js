export function onClickDomDetect(dotNetHelper, id, element) {
    window.addEventListener("click", (e) => {
        if (e.target.getAttribute("id") != id &&e.target!=element) {
            dotNetHelper.invokeMethodAsync("ToggleFromJs", "click").then(x => console.log("se logró"));
        }
    });
    
}
