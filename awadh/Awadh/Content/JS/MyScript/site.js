"use strict";
var page = '/';
var ResponseStatus = { SUCCESS: 1, FAILED: 2, ACCEPT: 3, REJECT: 4, INCOMPLETE: 5, UNAUTHORISED: 6, UNDERSCREENING: 7, SERVICEDOWN: 8 };
var btnLdr = {
    removeClass: '',
    addClass: '',
    Start: function (btn, btnText) {
        var dataLoadingClass = "<i class='fas fa-circle-notch fa-spin'></i> " + btnText;
        btn.attr('original-text', btn.html());
        btn.html(dataLoadingClass);
        btn.removeClass(this.removeClass).addClass(this.addClass);
    },
    Stop: function (btn) {
        btn.html(btn.attr('original-text'));
        btn.removeClass(this.addClass).addClass(this.removeClass);
    }
};

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
    load: () => $('body').append('<div class="loading">Loading&#8230;</div>'),
    remove: () => $('.loading').remove()
};

var mdlA = modalAlert;
var loginWin = () => {
    $.post('/home/login').done(result => {
        mdlA.id = "loginWindow";
        mdlA.title = "Login";
        mdlA.content = result;
        mdlA.modal(mdlA.size.default);
        $('#btnLogin').click(() => {
            let params = {
                RegId: $('#UserId').val(),
                PSD: $('#Password').val()
            };
            $.post('/home/_Login', params).done(response => {
                console.log(response)
                let ln = response.length;
                if (ln == 0) {
                    alert("Please Check Your UserId/Password OR Your Account Has been Deactivated .");
                }
                else {
                    let Role = response[0].Role;
                    if (Role === "Student") {
                        window.location.href = '/Student/Index';
                    }
                    if (Role == 'Admin') {
                        window.location.href = '/Teacher/Index';
                    }
                    if (Role == 'Teacher') {
                        window.location.href = '/Teacher/Index';
                    }
                }
            });
        })
    });
}

var RegistrationWin = () => {
    $.post('/home/Registration').done(result => {
        mdlA.id = "loginWindow";
        mdlA.title = "Registration";
        mdlA.content = result;
        mdlA.modal(mdlA.size.default);
        $('#btnRegistration').click(() => {
            let params = {
                Name: $('input[name="Name"]').val(),
                Father_Name: $('input[name="FatherName"]').val(),
                Mother_Name: $('input[name="MotherName"]').val(),
                Phone: $('input[name="Phone"]').val(),
                Email: $('input[name="Email"]').val(),
                Class: $('select[name="Class"]').val(),
                Password: $('input[name="Password"]').val(),
                Address: $('input[name="Address"]').val(),
                DOB: $('input[name="Dob"]').val(),
                LastSchool: $('input[name="LastSchool"]').val(),
                Role: $('select[name="Role"]').val()
            };
            $.post('/home/_Registration', params)
                .done(response => {
                    if (response > 0) {
                        var data = new FormData();
                        var files = $('input[name="PassportImage"]').get(0).files;
                        if (files.length > 0) {
                            data.append("file", files[0]);
                        }
                        data.append("newname", response);
                        $.ajax({
                            url: '/home/Upload',
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,
                            success: function (response) {
                                Swal.fire({
                                    title: 'success',
                                    titleText: 'Success!',
                                    text: 'Your request is saved successfully.We will response soon',
                                    icon: 'success',
                                    confirmButtonText: '',
                                    showConfirmButton: false,
                                    toast: true,
                                    position: 'top-right',
                                    timer: 3000,
                                    timerProgressBar: true
                                });
                                mdlA.dispose();
                            },
                            error: function (xhr) {
                                Swal.fire({
                                    title: 'error',
                                    titleText: 'Error!',
                                    text: xhr.status === 0 ? 'Internet Connection was broken' : xhr.status === 404 ? 'Requested action not found' : 'internal Server Error',
                                    icon: 'error',
                                    confirmButtonText: '',
                                    showConfirmButton: false,
                                    toast: true,
                                    position: 'top-right',
                                    timer: 3000,
                                    timerProgressBar: true
                                });
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            title: 'error',
                            titleText: 'Error!',
                            text: 'Technical Issue',
                            icon: 'error',
                            confirmButtonText: '',
                            showConfirmButton: false,
                            toast: true,
                            position: 'top-right',
                            timer: 3000,
                            timerProgressBar: true
                        });
                    }
                });
        })
    });
}