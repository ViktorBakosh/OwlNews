var url = "https://alerts.com.ua/api/states";

var xhr = new XMLHttpRequest();
xhr.open("GET", url);
var text = new String;
xhr.setRequestHeader("X-API-Key", "");
let array = new Array();  
xhr.onreadystatechange = function () {
   if (xhr.readyState === 4) {
      console.log(xhr.status);
      text=xhr.responseText;
      Read(xhr.responseText);
   }};
xhr.send();

function Read(text){
   const Arr = JSON.parse(text);
   for(const element in Arr["states"])
   {
      console.log(Arr["states"][element]);
      color(Arr["states"][element]);
   }

}

function color(Jobj){
   if(Jobj["alert"]){
    document.getElementById(Jobj["id"]).style.fill="rgba(230,25,25,1)";
    document.getElementById(Jobj["id"]).style.opacity=0.5;
   }
   else{
      document.getElementById(Jobj["id"]).style.fill="#83b4a4";
   }
}