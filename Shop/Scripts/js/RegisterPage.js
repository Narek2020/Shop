$(document).ready(function () {

    $("button").click(function (event) {
        let pass = $("#exampleInputPassword").val();
        let passconf = $("#exampleInputPassword1").val();
        if (pass != passconf) {
            event.preventDefault();
            $("#confirmationMessage").text("Not the same");
        }
    })

    $("#checkPass").click(function () {
        let pass = $("#exampleInputPassword");
        let passConf = $("#exampleInputPassword1");

        if ($("#checkPass").is(':checked')) {
            pass.attr("type", "text");
            passConf.attr("type", "text");
        }
        else {
            pass.attr("type", "password");
            passConf.attr("type", "password");
        }

    })
});

