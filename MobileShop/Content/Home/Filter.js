
$(document).ready(function () {
    var maxOutput = document.getElementById("maxOutput");
    var maxSlider = document.getElementById("maxRange");
    maxOutput.value = maxSlider.value;
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


