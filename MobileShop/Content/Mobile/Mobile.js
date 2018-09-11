function Add(id) {
    var amount = $("#amount_" + id).val();
    var price = $("#price_" + id).val();
    var obj = new Object();
    obj.Price = price;
    obj.Amount = amount;
    obj.MobileId = id;

    $.ajax({
        url: "./Add",
        contentType: "application/json",
        method: "POST",
        data: JSON.stringify(obj),
        success: () => {
            $("#" + id).remove();
        },
        error: () => {
            alert("Failed to add mobile. Try refreshing page.");
        }
    });
}

function Edit(id, name) {

    var obj = new Object();
    obj.Amount = $("#amount_" + id).val();
    obj.Price = $("#price_" + id).val();
    obj.Id = id;
    obj.Name = name;

    $.ajax({
        url: "./Edit",
        contentType: "application/json",
        method: "PUT",
        data: JSON.stringify(obj),
        success: () => {
            alert("Successfully edited.")
        },
        error: () => {
            alert("Failed to edit mobile. Try refreshing page.");
        }
    });
}