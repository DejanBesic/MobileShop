function Add(id) {
    $.ajax({
        url: "./Add/"+id,
        contentType: "application/json",
        method: "PUT",
        success: () => {
            $("#" + id).remove();
        },
        error: () => {
            alert("Failed to add admin. Try refreshing page.");
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
            alert("Failed to remove admin. Try refreshing page.");
        }
    });
}