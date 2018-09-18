function AddToCart(mobileId, shopId, price) {
    var obj = new Object();
    obj.MobileId = mobileId;
    obj.ShopId = shopId;
    obj.Price = price;

    $.ajax({
        url: "/Shopping/Add",
        contentType: "application/json",
        method: "POST",
        data: JSON.stringify(obj),
        success: () => {
            alert("Successfully added mobile to cart.")
        },
        error: (error) => {
            if (error.status === 401) {
                window.location.href = "/Auth/Login";
            } else {
                alert("Failed to add mobile to cart. Try refreshing page.");
            }
        }
    });
}

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

jQuery(document).ready(function ($) {
    //Handles the carousel thumbnails
    $('[id^=carousel-selector-]').click(function () {
        var id_selector = $(this).attr("id");
        try {
            var id = /-(\d+)$/.exec(id_selector)[1];
            console.log(id_selector, id);
            jQuery('#myCarousel').carousel(parseInt(id));
        } catch (e) {
            console.log('Regex failed!', e);
        }
    });
    // When the carousel slides, auto update the text
    $('#myCarousel').on('slid.bs.carousel', function (e) {
        var id = $('.item.active').data('slide-number');
        $('#carousel-text').html($('#slide-content-' + id).html());
    });
});

jssor_1_slider_init = function () {

    var jssor_1_options = {
        $AutoPlay: 1,
        $ArrowNavigatorOptions: {
            $Class: $JssorArrowNavigator$
        },
        $BulletNavigatorOptions: {
            $Class: $JssorBulletNavigator$
        }
    };

    var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

    /*#region responsive code begin*/

    var MAX_WIDTH = 400;

    function ScaleSlider() {
        var containerElement = jssor_1_slider.$Elmt.parentNode;
        var containerWidth = containerElement.clientWidth;

        if (containerWidth) {

            var expectedWidth = Math.min(MAX_WIDTH || containerWidth, containerWidth);

            jssor_1_slider.$ScaleWidth(expectedWidth);
        }
        else {
            window.setTimeout(ScaleSlider, 30);
        }
    }

    ScaleSlider();

    $Jssor$.$AddEvent(window, "load", ScaleSlider);
    $Jssor$.$AddEvent(window, "resize", ScaleSlider);
    $Jssor$.$AddEvent(window, "orientationchange", ScaleSlider);
    /*#endregion responsive code end*/
};