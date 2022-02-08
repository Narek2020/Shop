$(document).ready(function () {
    
    let loader = $(".loader");



    if (userName != null) {
        $.ajax({
            url: "/Home/GetOrder",
            type: "POST",
            data: { userName: userName },
            success: function (data) {

                $(".orderCount").attr("data-notify", data.length);

                console.log(data.length);
            }
            
        })
    }
    
    $(document).on({
        ajaxStart: function () {
            loader.removeClass("d-none");
        },

        ajaxStop: function () {
            loader.addClass("d-none");
        }
    })
})


