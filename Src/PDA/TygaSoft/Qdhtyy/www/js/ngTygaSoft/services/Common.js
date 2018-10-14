
angular.module('ngTygaSoft.services.Common', [])

.factory('$tygasoftCommon', function ($ionicPopup, $tygasoftLS, $tygasoftMC) {

    var ts = {};

    ts.AppKey = '011de50b-216d-49c4-8836-8ba2f4c9e490';

    ts.ServerUrl = function () {
        //return "http://localhost/ccecc";
        //return "http://www.tygaweb.com/ccecc";
        var serviceUrl = $tygasoftLS.Get("ServiceUrl", "");
        if (!serviceUrl || serviceUrl == '') {
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_ServiceUrlEmpty, okText: $tygasoftMC.MC.Btn_OkText }).then(function () {
                window.location = "#/app/SysSet";
            })
            return false;
        }
        if (serviceUrl.indexOf('/Services/PdaService.svc') > -1) serviceUrl = serviceUrl.replace('/Services/PdaService.svc', "");
        return serviceUrl;
    };

    ts.PageIndex = 1;
    ts.PageSize = 20;

    ts.GetSplitValue = function (s, k) {
        var arr = s.split('|');
        for (var i = 0; i < arr.length; i++) {
            var key = "" + k + "=";
            if (arr[i].indexOf(key) > -1) {
                return arr[i].replace(key, "");
            }
        }
        return "";
    };
    ts.IsMobilePhone = function (s) {
        var reg = /^0{0,1}(13[0-9]|15[0-9]|18[0-9])[0-9]{8}$/;

    };
    ts.CurrentDate = function () {
        var s = "";
        var date = new Date();
        s += date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        if (m < 10) s += "-" + "0" + m + "";
        else s += "-" + m;
        if (d < 10) s += "-" + "0" + d + "";
        else s += "-" + d;

        return s;
    };
    ts.GetDate = function (sDate, sType, n) {
        var s = "";
        var date = new Date(sDate);
        s += date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        if (sType == "month") {
            m = m + n;
            if (m < 10) s += "-" + "0" + m + "";
            else s += "-" + m;
            if (d < 10) s += "-" + "0" + d + "";
            else s += "-" + d;
        }
        else if (sType == "day") {
            if (m < 10) s += "-" + "0" + m + "";
            else s += "-" + m;
            d = d + n;
            if (d < 10) s += "-" + "0" + d + "";
            else s += "-" + d;
        }

        return s;
    };
    ts.FDate = function (value) {
        if (value == '') return new Date().Format("yyyy-MM-dd");
        return new Date(value.replace('T', ' ')).Format("yyyy-MM-dd");
    };
    ts.FDateTime = function (value) {
        if (value == '') return new Date().Format("yyyy-MM-dd hh:mm:ss");
        return new Date(value.replace('T', ' ')).Format("yyyy-MM-dd hh:mm:ss");
    };
    ts.FTime = function (value) {
        var s = '';
        if (value == '') {
            var date = new Date();
            var h = date.getHours();
            if (h < 10) s += '0' + h;
            else s += h;
            s += ':';
            var m = date.getMinutes();
            if (m < 10) s += '0' + m;
            else s += m;
        }
        else {
            var date = new Date(value * 1000);
            var h = date.getUTCHours();
            if (h < 10) s += '0' + h;
            else s += h;
            s += ':';
            var m = date.getUTCMinutes();
            if (m < 10) s += '0' + m;
            else s += m;
        }

        return s;
    };
    ts.FMonth = function () {
        var s = '';
        var date = new Date();
        s += date.getFullYear();
        var m = date.getMonth()+1;
        if (m < 10) s += "-0" + m;
        else s += "-" + m;
        return s;
    };
    ts.GetRndOrderCode = function (max) {
        return new Date().Format("yyyyMMddhhmmss") + Math.round(Math.random() * max);
    };

    ts.String = {
        IsNullOrWhiteSpace: function (s) {
            if (s) {
                if (s.replace(/^\s+|\s+$/g, "") != "") return false;
            }
            return true;
        },
        Trim: function (s) {
            return s.replace(/^\s+|\s+$/g, "");
        }
    };

    return ts;
});