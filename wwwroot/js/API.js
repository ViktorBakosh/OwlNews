var url = "https://alerts.com.ua/api/states";
API();
setInterval(API, 10500);
function API() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", url);
    var text = new String;
    xhr.setRequestHeader("X-API-Key", "f16bd9a3ce36b4eed167325de19da4df5522fb11");
    let array = new Array();
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            // console.log(xhr.status);
            text = xhr.responseText;
            Read(xhr.responseText);
        }
    };
    xhr.send();

    function Read(text) {
        const Arr = JSON.parse(text);
        for (const element in Arr["states"]) {
            // console.log(Arr["states"][element]);
            color(Arr["states"][element]);
        }

    }

    function color(Jobj) {
        try {
            if (Jobj["alert"]) {
                document.getElementById(Jobj["id"]).style.fill = "rgba(230,25,25,1)";
                document.getElementById(Jobj["id"]).style.opacity = 0.5;
            }
            else {
                document.getElementById(Jobj["id"]).style.fill = "#83b4a4";
                // document.getElementById(Jobj["id"]).style.opacity=0.5;
            }
        } catch (error) { }
    }
}