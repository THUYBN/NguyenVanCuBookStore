$(document).ready(function () {
    $('#frm-login').validate({

        rules: {
            Email: {
                required: true,
            },
            Password: {
                required: true,
            }
        },
        messages: {
            Email: {
                required: "Mail is not empty",
            },
            Password: {
                required: "Password is not empty",
            }
        }

    });
});