"use strict";
var page = '/';
var btnLdr = {
    removeClass: '',
    addClass: '',
    Start: function (btn, btnText) {
        var dataLoadingClass = "<i class='fas fa-circle-notch fa-spin'></i> " + btnText;
        btn.attr('original-text', btn.html()).attr('disabled', 'disabled');
        btn.html(dataLoadingClass);
        btn.removeClass(this.removeClass).addClass(this.addClass);
    },
    Stop: function (btn) {
        btn.removeAttr('disabled');
        btn.html(btn.attr('original-text'));
        btn.removeClass(this.addClass).addClass(this.removeClass);
    }
};

function validateEmail(email) {
    var mailValid = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9])+\.)+([a-zA-z0-9]{2,4})+$/;
    return mailValid.test(email);
}

var modalAlert = {
    title: '',
    content: '',
    confirmContent: '<h5>Are you sure?</h5>',
    parent: $('body'),
    IsFooter: false,
    id: 'mymodal',
    size: { small: 'modal-sm', large: 'modal-lg', xlarge: 'modal-xl', xxlarge: 'modal-xxl', xxlargeM: 'modal-xxl-m', default: '' },
    bodyCls: '',
    isHeaderBorder: true,
    headerClass: 'h3',
    show: function (size, callBack) {
        var _html = `<div class="modal fade" id="${this.id}" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class= "modal-dialog modal-dialog-centered ${size}" role="document">
                <div class="modal-content">
                    <div class="${this.isHeaderBorder ? 'modal-header' : 'pl-3 pr-3 mt-2'}">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h3 class="${this.headerClass} modal-title">${this.title}</h3>
                    </div>
                    <div class="modal-body">${this.content}</div>
                </div>
            </div>
          </div>`
        this.parent.append(_html);
        $(`#${this.id}`).modal(this.options);
        $(`#${this.id}`).modal(this.options);
        $('button.close').unbind().click(() => {
            mdlA.dispose();
            if (callBack !== undefined) {
                callBack();
            }
        });
    },
    isHeaderBorder: true,
    headerClass: 'h5',
    callBack: '',
    modal: function (size, callBack) {
        var _html = `<div class="modal fade" id="${this.id}" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class= "modal-dialog modal-dialog-centered ${size}" role="document">
                <div class="modal-content">
                    <div class="${this.isHeaderBorder ? 'modal-header' : 'pl-3 pr-3 mt-2'} custome">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h3 class="${this.headerClass} modal-title">${this.title === "" ? 'Alert' : this.title}</h3> 
                    </div>
                    <div class="modal-body">${this.content}</div>
                </div>
            </div>
          </div>`
        this.parent.append(_html);
        $(`#${this.id}`).modal(this.options);
        $('button.close').unbind().click(() => {
            mdlA.dispose();
            if (callBack !== undefined) {
                callBack();
            }
        });
    },
    reset: function () {
        this.isHeaderBorder = true;
        this.title = "";
        this.headerClass = "h5";
        this.bodyCls = '';
    },
    options: { backdrop: 'static', keyboard: true, focus: true, show: true },
    dispose: function (f) {
        this.reset();
        var mdlId = this.id;
        $('#' + mdlId + ' .modal-content').animate({ opacity: 0 }, 500, function () {

            $('#' + mdlId + ',.modal-backdrop').remove();
            $('body').removeClass('modal-open').removeAttr('style');
            if (f !== undefined)
                f();
        });
    },
    confirm: function () {
        return `<div class="col-md-12" id="dvpopup">
                  <button type = "button" class="close" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                      ${this.confirmContent}
                  <div class="form-group"></div> <button class="btn btn-outline-success mr-2" id="btnOK">Yes</button>
                  <button class="btn btn-outline-danger" id="mdlCancel">No</button>
                </div>`;
    }
};




var getQueryString = function (field, url) {
    var href = url ? url : window.location.href;
    var reg = new RegExp('[?&]' + field + '=([^&#]*)', 'i');
    var string = reg.exec(href);
    return string ? string[1] : null;
};


var preloader = {
    load: () => $('body').append('<div class="loading"><i class="fa fa-refresh fa-spin mr-1"></i> Loading&#8230;</div>'),
    remove: () => $('.loading').remove()
};

var mdlA = modalAlert;

(function ($) {
    $.FormValidation = $.FormValidation || {};
    $.FormValidation.IsFormValid = function (IsModelPopUp = false) {
        let IsValid = false;
        if (!IsModelPopUp) {
            $('[required="required"]').each(function () {
                let _tag = $(this).prop('tagName'), _ele = $(this);
                if (_ele.parent('div').html().indexOf('text-invalid') > -1) {
                    _ele.removeClass('invalid');
                    _ele.parent('div').find('span.text-invalid').remove();
                }
                if ((_tag === 'SELECT' || _tag === 'INPUT') && (_ele.val() === undefined || _ele.val() === '') || (_tag === 'SELECT' && _ele.val() === "0")) {
                    _ele.addClass('invalid').after(' <span class="text-danger text-monospace text-invalid"><small>(This is mendetory field)</span></small>').focus();
                    IsValid = false;
                    return false;
                }
                else {
                    IsValid = true;
                }
            })
        }
        else {
            $('.modal [required="required"]').each(function () {
                let _tag = $(this).prop('tagName'), _ele = $(this);
                if (_ele.parent('div').html().indexOf('text-invalid') > -1) {
                    _ele.removeClass('invalid');
                    _ele.parent('div').find('span.text-invalid').remove();
                }
                if ((_tag === 'SELECT' || _tag === 'INPUT') && (_ele.val() === undefined || _ele.val() === '') || (_tag === 'SELECT' && _ele.val() === "0")) {
                    _ele.addClass('invalid').after(' <span class="text-danger text-monospace text-invalid"><small>(This is mendetory field)</span></small>').focus();
                    IsValid = false;
                    return false;
                }
                else {
                    IsValid = true;
                }
            })
        }
        return IsValid;
    };
})($);




var loginWin = () => {
    $.post('/home/login').done(result => {
        mdlA.id = "loginWindow";
        mdlA.title = "Login";
        mdlA.content = result;
        mdlA.modal(mdlA.size.default);
        $('#btnLogin').click(() => {
            if ($.FormValidation.IsFormValid()) {
                let params = {
                    RegId: $('#UserId').val(),
                    PSD: $('#Password').val()
                };
                $.post('/home/_Login', params).done(response => {
                    Q.alert({
                        response: response,
                    });
                    if (response.StatusCode === 1)
                        window.location.href = response.CommonString;
                }).fail(xhr => Q.alert({ xhr: xhr }));
            }
        })
    });
}



var RegistrationWin = () => {
    $.post('/home/Registration').done(result => {
        mdlA.id = "loginWindow";
        mdlA.title = "Registration";
        mdlA.content = result;
        mdlA.modal(mdlA.size.default);
        $('input[name="PassportImage"]').change(e => {
            let size = parseFloat($(e.currentTarget)[0].files[0].size / 1024).toFixed(2);
            if (size > 1000) {
                $(e.currentTarget).parents('.form-group').find('label').append('<small class="text-danger">Please select image less than or equal to 1 mb</small>')
                $(e.currentTarget).val('');
            }
        });

        $('#btnRegistration').click(() => {
            btnLdr.Start($('#btnRegistration'), 'Requesting......');
            if ($.FormValidation.IsFormValid()) {
                let Email = $('input[name="Email"]').val();
                if (!validateEmail(Email)) {
                    $('input[name="Email"]').before('<small class="mendetory">Please Fill Valid Email Id</small>').focus();
                    btnLdr.Stop($('#btnRegistration'));
                    return false;
                }
                var data = new FormData();
                var files = $('input[name="PassportImage"]').get(0).files;
                if (files.length > 0) {
                    data.append("file", files[0]);
                }
                data.append("Name", $('input[name="Name"]').val());
                data.append("Father_Name", $('input[name="FatherName"]').val());
                data.append("Mother_Name", $('input[name="MotherName"]').val());
                data.append("Phone", $('input[name="ContactNo"]').val());
                data.append("Email", $('input[name="Email"]').val());
                data.append("Class", $('select[name="Class"]').val());
                data.append("Password", $('input[name="Password"]').val());
                data.append("DOB", $('input[name="Dob"]').val());
                data.append("Role", $('select[name="Role"]').val());
                $.ajax({
                    url: '/home/_Registration',
                    type: "POST",
                    processData: false,
                    contentType: false,
                    data: data,
                    success: function (response) {
                        btnLdr.Stop($('#btnRegistration'));
                        Q.alert({ response: response });
                        mdlA.dispose();
                    },
                    error: function (xhr) {
                        btnLdr.Stop($('#btnRegistration'));
                        Q.alert({ xhr: xhr })
                    }
                });
            }
            else {
                btnLdr.Stop($('#btnRegistration'));
            }
        })
    }).fail(xhr => Q.alert({ xhr: xhr }));
}

var ChangePassWin = () => {
    preloader.load();
    $.post('/common/ChangePassword')
        .done(result => {
            mdlA.id = "changePassWindow";
            mdlA.title = "Change Password";
            mdlA.content = result;
            mdlA.modal(mdlA.size.default);
            $('#btnChangePass').click(() => {
                preloader.load();
                if ($.FormValidation.IsFormValid()) {
                    let params = {
                        currentPass: $('#currentPass').val(),
                        newPass: $('#newPass').val(),
                        rePass: $('#rePass').val()
                    };
                    if (params.newPass !== params.rePass) {
                        $('#rePass').after('<label class="text-danger text-monospace">* Password not matched.Please Reenter password</label>');
                        return false
                    }
                    $.post('/Common/ChangeUserPassword', params).done(response => {
                        Q.alert({ response: response });
                        if (response.StatusCode === 1) {
                            mdlA.dispose();
                        }
                    }).fail(xhr => Q.alert({ xhr: xhr })).always(() => preloader.remove());
                }
            })
        }).always(() => preloader.remove());
}

var Q;
(function (Q) {
    Q.result = {};
    Q.isValidDate = /^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/;
    Q.ResponseStatus = { SUCCESS: 1, FAILED: 2, ACCEPT: 3, REJECT: 4, INCOMPLETE: 5, UNAUTHORISED: 6, UNDERSCREENING: 7, SERVICEDOWN: 8 };
    Q.reset = () => {
        $('input').val('');
        $('select').each(function (i) {
            $('select')[i].selectedIndex = 0;
        });
        $('textarea').val('');
        $('input[type="radio"]').prop('checked', false);
        $('input[type="checkbox"]').prop('checked', false);
    }
    function alert(Options = {}) {
        if (Options.response !== undefined && Options.response.StatusCode !== undefined) {
            Swal.fire({
                title: Options.response.StatusCode === 1 ? 'success' : 'error',
                titleText: Options.response.StatusCode === 1 ? 'Success!' : "Error",
                text: Options.response.Status,
                icon: Options.response.StatusCode === 1 ? 'success' : 'error',
                confirmButtonText: '',
                showConfirmButton: false,
                toast: true,
                position: 'top-right',
                timer: 3000,
                timerProgressBar: true
            });
        }

        if (Options.xhr !== undefined && Options.xhr.status !== undefined) {
            Swal.fire({
                title: 'error',
                titleText: "Oops",
                text: Options.xhr.status === 0 ? 'Internet was broken' : Options.xhr.status === 404 ? 'Requested path not found' : 'Server error',
                icon: 'error',
                confirmButtonText: '',
                showConfirmButton: false,
                toast: true,
                position: 'top-right',
                timer: 3000,
                timerProgressBar: true
            });
        }
    }
    Q.uploadedMaterial = async subjectId => {
        await $.post('/common/GetuploadedMaterial', { SubjectID: subjectId })
            .done(result => {
                Q.result = result
            })
    };
    Q.alert = alert;
})(Q || (Q = {}));

