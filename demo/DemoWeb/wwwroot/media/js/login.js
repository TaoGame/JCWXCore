var Login = function () {
    
    return {
        //main function to initiate the module
        init: function () {
        	
           $('.login-form').validate({
	            errorElement: 'label', //default input error message container
	            errorClass: 'help-inline', // default input error message class
	            focusInvalid: false, // do not focus the last invalid input
	            rules: {
                    appid: {
                        required: true
	                },
                    appsecret: {
	                    required: true
	                }
	            },

	            messages: {
                    appid: {
	                    required: "AppID is required."
	                },
                    appsecret: {
	                    required: "AppSecret is required."
	                }
	            },

	            invalidHandler: function (event, validator) { //display error alert on form submit   
	                $('.alert-error', $('.login-form')).show();
	            },

	            highlight: function (element) { // hightlight error inputs
	                $(element)
	                    .closest('.control-group').addClass('error'); // set error class to the control group
	            },

                success: function (label) {
                    $(".btn").removeAttr('disabled');
	                label.closest('.control-group').removeClass('error');
	                label.remove();
	            },

                errorPlacement: function (error, element) {
                    $(".btn").removeAttr('disabled');
	                error.addClass('help-small no-left-padding').insertAfter(element.closest('.input-icon'));
	            },

                submitHandler: function (form) {
                    $(".btn").attr('disabled', '');
                    form.submit();
                    //$(form).submit();
	            }
	        });

        }

    };

}();