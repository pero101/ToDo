$(function () {
    $("#btnRegister").click(function () {
        if ($("#passwordRegister").val() != $("#passwordConfirmRegister").val())
        {
            alert("Password and the confirmed password do not match!")
            return;
        }

        var value = $("#usernameRegister").val();
        var tempurl = '/api/register?username=' + $("#usernameRegister").val() + "&password=" + $("#passwordRegister").val() + "&email=" + $("#emailRegister").val();
        $.ajax({
            type: 'GET',
            url: tempurl,
        }).done(function (data) {
            alert(data);
        });
    });
});

