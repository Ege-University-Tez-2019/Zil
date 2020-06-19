 
$("#btnLogin").click(function () {

    var data = {
        "Email": $("#email").val(),
        "Password": $("#password").val()
    }

    if (data.Email.trim() !== "" && data.Password.trim() !== "") {
        beforeSend();
        Util.Ajax.Generic("/giris", data, "POST", "json", false, null, success, null, null);
    }
    else {
        var divError = $("#divError");
        var span = $("#spanhata");
        span.empty();
        span.append("Boş alan bırakılamaz");
        divError.show();
    }
});
function beforeSend() {
    $("#btnLogin").prop('disabled', true);
    $("#spanBtnLoginText").empty();
    $("#spanBtnLoginText").append("Oturum Açılıyor");
    $("#btnLogin").attr('class', 'btn btn-warning btn-block btn-c mt-4 mb-4');
}
function success(status) { 
    var userName = $("#txtUsername").val();
    var span = $("#spanhata");
    var divError = $("#divError");
    span.empty();
    if (status.operation == "Success") {
        window.location.href = '/anasayfa';
    }
    else if (response === 102) {
        window.location.href = '/verification';
    }
    else if (status.operation === 404) {
        span.append("Giriş bilgileri hatalı !");
        $("#btnLogin").prop('disabled', false);
        $("#spanBtnLoginText").empty();
        $("#spanBtnLoginText").append("Oturum Aç");
        $("#btnLogin").attr('class', 'btn btn-primary btn-block btn-c mt-4 mb-4');
        divError.show();
    }
    else if (status.operation == 429) {
        span.append(userName + "  adlı kullanıcının oturumu zaten açık !");
        $("#btnLogin").prop('disabled', false);
        $("#spanBtnLoginText").empty();
        $("#spanBtnLoginText").append("Oturum Aç");
        $("#btnLogin").attr('class', 'btn btn-primary btn-block btn-c mt-4 mb-4');
        divError.show();
        window.location.href = '/detail/dashboard';
    }
    else {
        span.append("Bilinmeyen bir hata oluştu !");
        $("#btnLogin").prop('disabled', false);
        $("#spanBtnLoginText").empty();
        $("#spanBtnLoginText").append("Oturum Aç");
        $("#btnLogin").attr('class', 'btn btn-primary btn-block btn-c mt-4 mb-4');
        divError.show();

        window.location.href = '/detail/dashboard';
    }
}

$('input').keypress(function (e) {
    if (e.which == 13) {
        $('#btnLogin').trigger("click");
        return false;
    }
});
$('body').keypress(function (e) {
    if (e.which == 13) {
        $('#btnLogin').trigger("click");
        return false;
    }
}); 