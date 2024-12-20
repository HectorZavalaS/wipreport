function getVirtDir() {
    var Path = location.host;
    var VirtualDirectory;
    if (Path.indexOf("localhost") >= 0 && Path.indexOf(":") >= 0) {
        VirtualDirectory = "";

    }
    else {
        var pathname = window.location.pathname;
        var VirtualDir = pathname.split('/');
        VirtualDirectory = VirtualDir[1];
        VirtualDirectory = '/' + VirtualDirectory;
    }
    return VirtualDirectory;
}

function getViewSMTIN() {
    //block();
    //loadHtml();
    $("#rptView").hide();
    $("#loader").show();
    $.ajax({
        method: "GET",
        url: getVirtDir() + "/WIP_RPT/",
        success: function (data) {

            $("#rptView").html(data);
            $("#loader").hide();
            $("#rptView").show();
            //unblock();
            return false;
        },
        error: function () { }
    });
}
function getViewSMTOut() {
    //block();
    //loadHtml();
    $("#rptView").hide();
    $("#loader").show();
    $.ajax({
        method: "GET",
        url: getVirtDir() + "/smtOut/",
        success: function (data) {

            $("#rptView").html(data);
            $("#loader").hide();
            $("#rptView").show();
            //unblock();
            return false;
        },
        error: function () { }
    });
}

function getViewSMTFin() {
    //block();
    //loadHtml();
    $("#rptView").hide();
    $("#loader").show();
    $.ajax({
        method: "GET",
        url: getVirtDir() + "/WIP_RPT_FIN/",
        success: function (data) {
            $("#rptView").html(data);
            $("#loader").hide();
            $("#rptView").show();
            //unblock();
            return false;
        },
        error: function () { }
    });
}
function getViewAssyFin() {
    //block();
    //loadHtml();
    $("#rptView").hide();
    $("#loader").show();
    $.ajax({
        method: "GET",
        url: getVirtDir() + "/assyRptFin/",
        success: function (data) {
            $("#rptView").html(data);
            $("#loader").hide();
            $("#rptView").show();
            //unblock();
            return false;
        },
        error: function () { }
    });
}

function getViewAging() {
    //block();
    //loadHtml();
    $("#rptView").hide();
    $("#loader").show();
    $.ajax({
        method: "GET",
        url: getVirtDir() + "/aging/",
        success: function (data) {

            $("#rptView").html(data);
            $("#loader").hide();
            $("#rptView").show();
            //unblock();
            return false;
        },
        error: function () { }
    });
} 

function getViewAssyIN() {
    //block();
    //loadHtml();
    $("#loader").show();
    $("#rptView").hide();
    $.ajax({
        method: "GET",
        url: getVirtDir() + "/WIP_RPTAssy/",
        success: function (data) {

            $("#rptView").html(data);
            $("#loader").hide();
            $("#rptView").show();
            //unblock();
            return false;
        },
        error: function () { }
    });
} 

function getSMTInReport() {
    //blockV2("");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getSMTINRpt.ashx",
        success: function (data) {
            //removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#btnDownload").html("<a href='" + getVirtDir() + "/Reports/SMT/" + r.html + "'>Descargar reporte</a>");
            }
            return false;
        },
        error: function () { }
    });
}

function getSMTOutReport() {
    //blockV2("");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getSMTOut.ashx",
        success: function (data) {
            //removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#btnDownload").html("<a href='" + getVirtDir() + "/Reports/SMT/" + r.html + "'>Descargar reporte</a>");
            }
            return false;
        },
        error: function () { }
    });
}

function getSMTFinReport() {
    //blockV2("");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getSMTFin.ashx",
        success: function (data) {
            //removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#btnDownload").html("<a href='" + getVirtDir() + "/Reports/FINANCE/SMT/" + r.html + "'>Descargar reporte</a>");
            }
            return false;
        },
        error: function () { }
    });
}

function getAssyFinReport() {
    //blockV2("");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getASSYFin.ashx",
        success: function (data) {
            //removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#btnDownload").html("<a href='" + getVirtDir() + "/Reports/FINANCE/ASSY/" + r.html + "'>Descargar reporte</a>");
            }
            return false;
        },
        error: function () { }
    });
}
function getAgingReport() {
    //blockV2("");
    $("#btnDownload").html("Creando archivo de reporte...");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getAgingSMT.ashx",
        success: function (data) {
            //removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#btnDownload").html("<a href='" + getVirtDir() + "/Reports/SMT/" + r.html + "'>Descargar reporte</a>");
            }
            return false;
        },
        error: function () { }
    });
}

function getAssyInReport() {
    //blockV2("");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getAssyInRpt.ashx",
        success: function (data) {
            //removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#btnDownload").html("<a href='" + getVirtDir() + "/Reports/ASSY/" + r.html + "'>Descargar reporte</a>");
            }
            return false;
        },
        error: function () { }
    });
}

$(document).ready(function () {
    $("#smtIn").click(function () {
        getViewSMTIN();
    });
    $("#smtOut").click(function () {
        getViewSMTOut();
    });
    $("#smtAging").click(function () {
        getViewAging();
    });
    $("#assyIn").click(function () {
        getViewAssyIN();
    });
    $("#smtFinance").click(function () {
        getViewSMTFin();
    });
    $("#assyFinance").click(function () {
        getViewAssyFin();
    });
});
