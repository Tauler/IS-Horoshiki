var defaultLang = 'ru';

var backendServerAddr = "/backend";
var backendTimeout = 5000;

function resizeFooter(){
    var contentHeight = $(window).height() - 123;
    $(".content-container").css("min-height", contentHeight + "px");
}

function getToken() {
    var accesstoken = sessionStorage.getItem('accessToken');
    var authHeaders = {};
    if (accesstoken) {
        authHeaders.Authorization = 'Bearer ' + accesstoken;
    }
    return authHeaders;
}

function httpErrors(url, status){

    console.log(status);
    switch(status){
        case 401:
            redirect403(url);
            break;
        case 403:
            redirect403(url);
            break;
        case 404:
            redirect404();
            break;
        case 0:
            break;
        case -1:
            break;
        default:
            redirectBackendError();
            break;
    }
}

function redirect403(url){
    redirect("/account/login?backUrl="+url);
}

function redirectBackendError(){
    redirect("/error.html");
}

function redirect404(){
    redirect("/error");
}

function redirectToMainSite(){
    redirect("/");
}

function redirect(url){
    url = url.replace(/&/g,"%26");
    window.location.href=url;
}

function numb2(numb){
    if (numb <= 9){
        return "0" + numb;
    }else{
        return numb;
    }
}

function timeFormatter(date){
    var viewHour = date.getHours();
    var viewMinutes = date.getMinutes();

    return numb2(viewHour)+":"+numb2(viewMinutes);
}

function dateFormatter(date){
    var dd = date.getDate();
    var mm = date.getMonth()+1;
    var yyyy = date.getFullYear();

    return numb2(dd)+"."+numb2(mm)+"."+yyyy;
}

function dateFormatterBackend(date){
    var dd = date.getDate();
    var mm = date.getMonth()+1;
    var yyyy = date.getFullYear();

    return  yyyy+"-"+numb2(mm)+"."+numb2(dd);
}

function displayMess(elem, disable){
    if ($("#" + elem).css("display") == "none") {
        $("#" + disable).attr("disabled", "true");
        $("#" + elem).show(200);
        setTimeout(function () {
            $("#" + disable).removeAttr("disabled");
            $("#" + elem).hide(200);
        }, 2000);
    }
}

function displayErrorMessage(text){
    if(typeof text === 'undefined'){
        text = '';
    }

    if(text.length>0){
        $('#serverErrorModalBody').html(text);
    }

    $('#serverErrorModal').modal();
}

function closeModal(id){
    $('#'+id).modal('hide');
}

