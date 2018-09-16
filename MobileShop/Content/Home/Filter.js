$(document).ready(function () {
    var maxOutput = document.getElementById("maxOutput");
    var maxSlider = document.getElementById("maxRange");
    maxOutput.value = maxSlider.value;

    var minOutput = document.getElementById("minOutput");
    var minSlider = document.getElementById("minRange");
    minOutput.value = minSlider.value;
});

function onMinValueSliderChange() {
    var minSlider = document.getElementById("minRange");
    var minOutput = document.getElementById("minOutput");

    minOutput.value = minSlider.value;
}

function onMaxValueSliderChange() {
    var maxSlider = document.getElementById("maxRange");
    var maxOutput = document.getElementById("maxOutput");

    maxOutput.value = maxSlider.value;
}

function onMinValueOutputChange() {
    var minSlider = document.getElementById("minRange");
    var minOutput = document.getElementById("minOutput");

    if (minOutput.value !== "") {
        minSlider.value = minOutput.value;
    }
}

function onMaxValueOutputChange() {
    var maxSlider = document.getElementById("maxRange");
    var maxOutput = document.getElementById("maxOutput");

    if (maxOutput.value !== "") {
        maxSlider.value = maxOutput.value;
    }
}


function Search() {
    var query = "?";

    var externs = [];
    $('.extern:checked').each(function () {
        externs.push($(this).attr("id"));
    })
    if (externs.length != 0) {
        query += "Externs=" + externs.join(",") + "&";
    }

    var interns = [];
    $('.intern:checked').each(function () {
        interns.push($(this).attr("id"));
    })
    if (interns.length != 0) {
        query += "Interns=" + interns.join(",") + "&";
    }

    var shops = [];
    $('.shop:checked').each(function () {
        shops.push($(this).attr("id"));
    })
    if (shops.length != 0) {
        query += "Shops=" + shops.join(",") + "&";
    }

    var touches = [];
    $('.touch:checked').each(function () {
        touches.push($(this).attr("id"));
    })
    if (touches.length != 0) {
        query += "Touches=" + touches.join(",") + "&";
    }

    var os= [];
    $('.os:checked').each(function () {
        os.push($(this).attr("id"));
    })
    if (os.length != 0) {
        query += "OS=" + os.join(",") + "&";
    }

    var ram = [];
    $('.ram:checked').each(function () {
        ram.push($(this).attr("id"));
    })
    if (ram.length != 0) {
        query += "Ram=" + ram.join(",") + "&";
    }

    var battery = [];
    $('.battery:checked').each(function () {
        battery.push($(this).attr("id"));
    })
    if (battery.length != 0) {
        query += "Battery=" + battery.join(",") + "&";
    }

    var fronts = [];
    $('.front:checked').each(function () {
        fronts.push($(this).attr("id"));
    })
    if (fronts.length != 0) {
        query += "Fronts=" + fronts.join(",") + "&";
    }

    var backs = [];
    $('.back:checked').each(function () {
        backs.push($(this).attr("id"));
    })
    if (backs.length != 0) {
        query += "Backs=" + backs.join(",") + "&";
    }
    var FMRadio = document.getElementById("fmradio").checked;
    var HDVoice = document.getElementById("hdvoice").checked;
    var Port35mm = document.getElementById("port35mm").checked;
    if (FMRadio === true) {
        query += "FMRadio=True&" ;
    }
    if (HDVoice === true) {
        query += "HDVoice=True&";
    }
    if (Port35mm === true) {
        query += "Port35mm=True&";
    }
    var minOutput = document.getElementById("minOutput").value;
    var maxOutput = document.getElementById("maxOutput").value;
    var search = document.getElementById("search").value;
    if (search !== "") {
        query += "Search=" + search + "&";
    }
    query += "Min=" + minOutput + "&";
    query += "Max=" + maxOutput;

    window.location.href = "/Home/Index" + query;
}