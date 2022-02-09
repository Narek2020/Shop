$(document).ready(function () {
    let form = $("#InsertOrderForm");

    $("#Add").click(function () {
        let count = $("#count").val();
        $("#inputCount").val(count);

        $.ajax({
            url: "/Info/Index",
            type: "POST",
            data: form.serialize(),
            success: function (data) {
                let one = $(".orderCount").attr("data-notify");
                let result = parseInt(one) + 1;
                $(".orderCount").attr("data-notify", result);
                window.location.reload();   
            }
        })

       
    })


})