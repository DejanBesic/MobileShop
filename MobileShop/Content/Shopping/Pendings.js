function Accept(id) {
    $.ajax({
        url: "/Shopping/Accept/" + id,
        contentType: "application/json",
        method: "PUT",
        success: () => {
            alert("Succesfully accepted shopping with id: " + id)
            $("#" + id).remove();
        },
        error: () => {
            alert("Failed to accept purchasing. Try refreshing page.");
        }
    });
}

function Decline(id) {
    $.ajax({
        url: "/Shopping/Decline/" + id,
        contentType: "application/json",
        method: "PUT",
        success: () => {
            alert("Succesfully declined shopping with id: " + id)
            $("#" + id).remove();
        },
        error: () => {
            alert("Failed to decline purchasing. Try refreshing page.");
        }
    });
}