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
            alert("Successfully added.");
        },
        error: () => {
            alert("Failed to add mobile. Try refreshing page.");
        }
    });
}

function Remove(id) {
    $.ajax({
        url: "./Remove/" + id,
        contentType: "application/json",
        method: "DELETE",
        success: () => {
            $("#" + id).remove();
        },
        error: () => {
            alert("Failed to remove mobile. Try refreshing page.");
        }
    });
}