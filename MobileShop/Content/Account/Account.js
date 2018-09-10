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