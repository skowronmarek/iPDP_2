// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function daj_Zast() {
    var zast = document.querySelector("input[name='zastosowanie']:checked").value;
    document.getElementById("Kl_Zastosowania").value = zast;   // na stronie
};

// po zmianie Qw
function daj_Qw() {
    var Ls_m3h = 3600 / 1000;
    var Lmin_m3h = 60 / 1000;

    var Qw_UI = document.getElementById("Dis_Qw").value;
    var UI = document.querySelector("input[name='Unit']:checked").value;

    if (UI == "m3h") {
        var Qw_Mod = Qw_UI;
    }
    else if (UI == "L_s") {
        var Qw_Mod = Qw_UI * Ls_m3h;
    }
    else {
        Qw_Mod = Qw_UI * Lmin_m3h;
    };

    document.getElementById("Interfejs_Qw").value = Qw_UI;    // na stronie
    document.getElementById("Qw_model").value = Qw_Mod;       // na stronie
};

function zmien_QwUnit() {
    var m3h_Ls = 1000 / 3600;
    var m3h_Lm = 1000 / 60;

    var Qw_M = parseFloat(document.getElementById("Qw_model").value);
    var Qw_Unit = document.querySelector("input[name='Unit']:checked").value;

    if (Qw_Unit == "m3h") {
        var Qw_UI = Qw_M;
    }
    else if (Qw_Unit == "L_s") {
        var Qw_UI = Qw_M * m3h_Ls;
    }
    else {
        var Qw_UI = Qw_M * m3h_Lm;
    };

    Qw_UI = Math.round(Qw_UI * 10) / 10;
    document.getElementById("Dis_Qw").value = Qw_UI;
    document.getElementById("Interfejs_Qw").value = Qw_UI;
    document.getElementById("Interfejs_QwUnit").value = Qw_Unit;
};

function daj_dw() {
    var v = 1.2;
    var dw = 1;

    var Qw_M = parseFloat(document.getElementById("Qw_model").value);

    dw = Math.sqrt(4 * Qw_M / 3600 / 3.14 / v);

    dw = Math.round(dw * 1000);
    document.getElementById("Dis_d").value = dw;
    document.getElementById("Interfejs_d").value = dw;
};

function daj_Dh() {
    var dw = parseFloat(document.getElementById("Dis_d").value);
    var L = parseFloat(document.getElementById("Dis_L").value);
    var Qw_M = parseFloat(document.getElementById("Qw_model").value);
    var v = 4 * Qw_M / 3600 / 3.14 / (dw / 1000) ** 2;

    var Dh = 0.025 * L / dw * 1000 * v ** 2 / 2 / 9.81;
    Dh = Math.round(Dh * 100) / 100;

    document.getElementById("Dis_Dh").value = Dh;
    document.getElementById("Interfejs_Dh").value = Dh;
    document.getElementById("Interfejs_L").value = L;

};

function daj_Hw() {
    var Dh = parseFloat(document.getElementById("Dis_Dh").value);
    var Hg = parseFloat(document.getElementById("Dis_Hg").value);
    var Hw = Hg + Dh;
    Hw = Math.round(Hw * 10) / 10;

    document.getElementById("Hg_model").value = Hg;
    document.getElementById("Dis_Hw").value = Hw;
    document.getElementById("Hw_model").value = Hw;
};

function daj_Ph() {
    var Qw_M = parseFloat(document.getElementById("Qw_model").value);
    var Hw = parseFloat(document.getElementById("Hw_model").value);
    var Ph = Qw_M / 3600 * Hw * 1000 * 9.81;
    Ph = Math.round(Ph / 1000 * 100) / 100;
    document.getElementById("Dis_Ph").value = Ph;
    document.getElementById("Interfejs_Ph").value = Ph;
};

