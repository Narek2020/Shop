$(document).ready(function () {
    console.log(userName);
    
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
    
    

    console.log("end!");

})