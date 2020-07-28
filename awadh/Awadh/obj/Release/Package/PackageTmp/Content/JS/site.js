
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

function copyToClipboard(str) {
    var $temp = $("<input>");
    $("body").append($temp);
    $temp.val(str).select();
    document.execCommand("copy");
    $temp.remove();
}

function pasteAtControl(ctrl, txtToAdd) {
    var caretPos = ctrl[0].selectionStart;
    var textAreaTxt = ctrl.val();
    ctrl.val(textAreaTxt.substring(0, caretPos) + txtToAdd + textAreaTxt.substring(caretPos));
    ctrl.focus();
}

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
(() => {
    $('.btnLoginWin').click(() => {
        $.post('/home/Login')
            .done(result => {
                mdlA.title = "login";
                mdlA.id = "winlogin";
                mdlA.content = result;
                mdlA.show(mdlA.size.default)
                $('button.close').click(() => mdlA.dispose());
            })
            .fail(xhr => {
                an.title = 'Oops';
                an.content = xhr.status == 0 ? 'Internet Connection was broken' : 'Server error';
                an.alert(an.type.failed);
            });
    });
    $('.btnPlaceOrder').click(() => {
        $.post('/home/_placeorder')
            .done(result => {
                mdlA.title = "Place Your Order";
                mdlA.id = "winOrder";
                mdlA.content = result;
                mdlA.show(mdlA.size.default)
                $('button.close').click(() => mdlA.dispose());
            })
            .fail(xhr => {
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
            });
    });

    if (!sessionStorage.getItem("IsAlert")) {
        $.post('/home/getNotice')
            .done(result => {
                if (result.ID > 0) {
                    mdlA.title = result.Title;
                    mdlA.id = "winOrder";
                    mdlA.content = result.Detail;
                    mdlA.modal(mdlA.size.default)
                }
            })
            .fail(xhr => {
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
            }).always(() => sessionStorage.setItem('IsAlert', 1));
    }
})();

