$("#btn_userSetting").click(function () {
    var data = {
        "UserName": $("#id_name").val(),
        "Job": $("#id_job").val(),
        "Telephone": $("#id_telephone").val(),
        "Email": $("#id_email").val(),
        "DateOfBirth": $("#id_dateofbirth").val(),
        "Gender": $("#id_gender").val(),
        "About": $("#id_about").val(),
        "School": $("#id_school").val(),
        "Country": $("#id_country").val(),
        "Address": $("#id_address").val(),
        "Site": $("#id_site").val(),
        "Twitter": $("#id_twitter").val(),
        "Linkedin": $("#id_linkedin").val(),
        "Youtube": $("#id_youtube").val(),
    };

    Util.Ajax.Generic("/update-setting", data, "POST", "json", false, null, success, null, null);


    function success(status) { 
        if (status.operation == "Success") {
            window.location.href = '/ayarlar';
        }
        
    }

});