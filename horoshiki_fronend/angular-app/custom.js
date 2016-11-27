var defaultLang = 'ru';

var backendServerAddr = "/backend";
var backendTimeout = 5000;

var mailRegexp = /^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$/;
var numberRegexp = /^[0-9]+$/;
var numberWithDotRegexp = /^[0-9.]+$/;

//Константы
var employeeStatus = {
    dismissed: '104688a6-9cd2-4fb9-ab03-9da1b5474be0',
    worked: 'b725328d-922a-4c21-9652-1108db0c8bd3',
    trainee: 'f64423dc-fb22-41f3-8faa-da9b38ea671d'
};

var enumPositions = {

    chiefOperatingOfficer: '449f1830-172a-4aec-bc29-6bb446cf8861',
    manager: '27c9376b-47b6-4eca-8920-e8a0e63f267c'
}

var enumTypePlan = {
    sushi: {id:1, name: 'Суши'},
    pizza: {id:2, name: 'Пицца'}
}

var enumYears = [2015,2016,2017,2018,2019,2020,2021,2022,2023,2024];
var enumMonth = [
        {id:0, name:'Январь'},
        {id:1, name:'Февраль'},
        {id:2, name:'Март'},
        {id:3, name:'Апрель'},
        {id:4, name:'Май'},
        {id:5, name:'Июнь'},
        {id:6, name:'Июль'},
        {id:7, name:'Август'},
        {id:8, name:'Сентябрь'},
        {id:9, name:'Октябрь'},
        {id:10, name:'Ноябрь'},
        {id:11, name:'Декабрь'}
];

var enumShiftCountRowsType = {
	morning: '292ef8fb-49dc-42b1-9e75-bee16d5454b4',
	evening: '4801812f-b7f1-4d64-ba8e-0e128ef3be20',
	night: '435a9e46-279a-4aab-b8a3-4412c9631bbb',
	powerup: '9849aef4-3413-4e3e-a427-4722cfa172f6'
}

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
			redirectBackendError();
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

    return  yyyy+"-"+numb2(mm)+"-"+numb2(dd);
}

function dateFormatterBackendToSafari(dateTime){

    var date = dateTime.split('T')[0].split("-");
    var dd = date[2];
    var mm = date[1];
    var yyyy = date[0];
    return  mm+'/'+dd+'/'+yyyy;
}

function displayMess(elem, disable){
    if ($("#" + elem).css("display") == "none") {
        $("#" + disable).attr("disabled", "true");
        $("#" + elem).show(200);
        setTimeout(function () {
            $("#" + disable).removeAttr("disabled");
            $("#" + elem).hide(200);
        }, 4000);
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

$("#numb").keyup(function(event){
    console.log(event);
    if(e.which!=8 && e.which!=0 && (e.which<48 || e.which>57)){
        return false;
    }
});
