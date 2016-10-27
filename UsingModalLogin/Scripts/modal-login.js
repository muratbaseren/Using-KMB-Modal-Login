/* #####################################################################
   #
   #   Project       : Modal Login with jQuery Effects
   #   Author        : Rodrigo Amarante (rodrigockamarante)
   #   Orginal Ver.  : 1.0
   #   Created       : 07/29/2015
   #   Last Change   : 08/04/2015
   #
   #   Updated		 : 27.10.2016
   #   Author 		 : K. Murat Baseren (www.muratbaseren.com.tr)
   #   Current Ver.  : 2.6
   #
   ##################################################################### */

$(function () {

    var $formLogin = $('#login-form');
    var $formLost = $('#lost-form');
    var $divForms = $('#div-forms');
    var $modalAnimateTime = 300;
    var $msgAnimateTime = 150;
    var $msgShowTime = 2000;

    $('#login-modal').on('show.bs.modal', function (event) {

        var button = $(event.relatedTarget) // Button or link that triggered the modal
        var mode = button.data('openmode') // Extract info from data-* attributes

        if (mode == "undefined" || mode == null)
            return;

        if (mode == "login") {
            // mode value is "login" then; and last panel is "lost" then, show to "login" with animate.

            if ($formLost.css("display") != "none") {
                setTimeout(function () {
                    modalAnimate($formLost, $formLogin);
                }, 500);
            }

        }
        else if (mode == "lost") {
            // mode value is "lost" then; and last panel is "login" then, show to "lost" with animate.

            if ($formLogin.css("display") != "none") {
                setTimeout(function () {
                    modalAnimate($formLogin, $formLost);
                }, 500);
            }
        }
        else {
            // mode has not value then; and last panel is "lost" then, show to "login" with animate.
            
            if ($formLost.css("display") != "none") {
                setTimeout(function () {
                    modalAnimate($formLost, $formLogin);
                }, 500);
            }
        }
    })

    $("#login-modal form").submit(function () {
        switch (this.id) {
            case "login-form":
                var $lg_username = $('#login_username').val();
                var $lg_password = $('#login_password').val();
                var $lg_rememberme = false;

                if ($('#login_rememberme').val() == "on") {
                    $lg_rememberme = true;
                }

                $("#login_submit_btn").attr("disabled", "disabled");

                $.ajax({
                    method: "post",
                    url: "/ModalLogin/SignIn",
                    data: { login_username: $lg_username, login_password: $lg_password, login_rememberme: $lg_rememberme }
                }).done(function (res) {
                    if (res.HasError) {
                        msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "error", "glyphicon-remove", res.Result);

                        $('#login_username').val("");
                        $('#login_password').val("");

                        $("#login_submit_btn").removeAttr("disabled");
                    }
                    else {
                        msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "success", "glyphicon-ok", res.Result);

                        setTimeout(function () {
                            location.reload();
                        }, 1500);
                    }
                });

                return false;
                break;
            case "lost-form":
                var $ls_email = $('#lost_email').val();

                $.ajax({
                    method: "post",
                    url: "/ModalLogin/LostPassword",
                    data: { lost_email: $ls_email }
                }).done(function (res) {
                    if (res.HasError) {
                        msgChange($('#div-lost-msg'), $('#icon-lost-msg'), $('#text-lost-msg'), "error", "glyphicon-remove", res.Result);

                        $('#lost_email').val("");
                    }
                    else {
                        msgChange($('#div-lost-msg'), $('#icon-lost-msg'), $('#text-lost-msg'), "success", "glyphicon-ok", res.Result);
                    }
                });

                return false;
                break;
            default:
                return false;
        }

        return false;
    });

    
    $('#login_lost_btn').click(function () { modalAnimate($formLogin, $formLost); });
    $('#lost_login_btn').click(function () { modalAnimate($formLost, $formLogin); });

    function modalAnimate($oldForm, $newForm) {
        var $oldH = $oldForm.height();
        var $newH = $newForm.height();
        $divForms.css("height", $oldH);
        $oldForm.fadeToggle($modalAnimateTime, function () {
            $divForms.animate({ height: $newH }, $modalAnimateTime, function () {
                $newForm.fadeToggle($modalAnimateTime);
            });
        });
    }

    function msgFade($msgId, $msgText) {
        $msgId.fadeOut($msgAnimateTime, function () {
            $(this).text($msgText).fadeIn($msgAnimateTime);
        });
    }

    function msgChange($divTag, $iconTag, $textTag, $divClass, $iconClass, $msgText) {
        var $msgOld = $divTag.text();
        msgFade($textTag, $msgText);
        $divTag.addClass($divClass);
        $iconTag.removeClass("glyphicon-chevron-right");
        $iconTag.addClass($iconClass + " " + $divClass);
        setTimeout(function () {
            msgFade($textTag, $msgOld);
            $divTag.removeClass($divClass);
            $iconTag.addClass("glyphicon-chevron-right");
            $iconTag.removeClass($iconClass + " " + $divClass);
        }, $msgShowTime);
    }
});