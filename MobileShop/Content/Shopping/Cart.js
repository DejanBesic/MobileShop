function Buy() {
    $.ajax({
        url: "/Shopping/Buy",
        contentType: "application/json",
        method: "PUT",
        success: () => {
            alert("Once administrator accept your order, mobiles will be sent on your home address.")
            $("#cart tr").remove();
        },
        error: () => {
            alert("Failed to purchase mobile(s). Try refreshing page.");
        }
    });
}


function Remove(id) {
    $.ajax({
        url: "/Shopping/Remove/" + id,
        contentType: "application/json",
        method: "DELETE",
        success: () => {
            alert("Successfully removed mobile from cart.")
            $("#" + id).remove();
        },
        error: () => {
            alert("Failed to remove mobile from cart. Try refreshing page.");
        }
    });
}
