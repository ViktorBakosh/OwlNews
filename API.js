let url = "https://alerts.com.ua/api/states";
API();
setInterval(API, 10500);
function API() {
    let xhr = new XMLHttpRequest();
    xhr.open("GET", url);
    let text = new String;
    xhr.setRequestHeader("X-API-Key", "f16bd9a3ce36b4eed167325de19da4df5522fb11");

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
                document.getElementById(Jobj["id"]).style.fill = "rgb(152, 57, 65)";
                // document.getElementById(Jobj["id"]).style.opacity = 0.5;
                document.getElementById('0' + Jobj["id"]).style.visibility = "visible";
                document.getElementById('00' + Jobj["id"]).style.visibility = "visible";
            }
            else {
                document.getElementById(Jobj["id"]).style.fill = "rgba(131, 180, 163,1)";
                document.getElementById('00' + Jobj["id"]).style.visibility = "hidden";
                document.getElementById('0' + Jobj["id"]).style.visibility = "hidden";
                document.getElementById(Jobj["id"]).style.fill = "#83b4a4";
                // document.getElementById(Jobj["id"]+'0').style.visibility="hidden";
                // document.getElementById(Jobj["id"]).style.opacity=0.5;
            }
        } catch (error) { console.log(error); }
    }
}
