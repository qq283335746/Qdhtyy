angular.module('ngTygaSoft.services.Login', [])

.factory('$tygasoftLogin', function ($q, $http, $ionicModal, $ionicHistory, $ionicLoading, $ionicPopup, $tygasoftMC, $tygasoftCommon, $tygasoftLS, $tygasoftJPush) {

    var ts = {};

    ts.Bind = function ($scope) {
        $scope.doLogin = function () {
            ts.DoLogin($scope);
        };
    };

    ts.IsLogin = function () {
        return parseInt($tygasoftLS.Get('IsLogin', 0)) == 1;
    };

    ts.GetLoginInfo = function () {
        var loginInfo = {};
        var deviceId = $tygasoftLS.Get('DeviceId', '');
        var deviceCode = $tygasoftLS.Get('DeviceCode', '');
        var loginId = $tygasoftLS.Get('LoginId', '');
        var customerId = $tygasoftLS.Get('CustomerId', '');
        loginInfo.DeviceId = deviceId;
        //loginInfo.DeviceCode = deviceCode;
        loginInfo.LoginId = loginId;
        //loginInfo.CustomerId = customerId;
        //loginInfo.DeviceId = 'ECDF768ACCBA';
        loginInfo.DeviceCode = 'P0001';
        loginInfo.CustomerId = '01001';
        return loginInfo;
    };

    ts.DoLogin = function ($scope) {
        var sUserName = $scope.LoginData.UserName;
        var sPassword = $scope.LoginData.Password;
        if ((!sUserName || sUserName == '') || (!sPassword || sPassword == '')) {
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Login_EmptyError, okText: $tygasoftMC.MC.Btn_OkText });
            return false;
        }
        var loginInfo = ts.GetLoginInfo();
        var sData = '{"DeviceId":"' + loginInfo.DeviceId + '","DeviceCode":"' + loginInfo.DeviceCode + '","UserName":"' + sUserName + '","Password":"' + sPassword + '"}';
        $ionicLoading.show();
        setTimeout(function () {
            QdhtyyPlugin.ValidateUser(sData, function (result) {
                $ionicLoading.hide();
                var jResult = JSON.parse(result);
                if (jResult.ResCode != 1000) {
                    $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                    return false;
                }
                var jsonField = { "KeyName": "" + sUserName + "", "TypeName": "LoginInfo", "ContentValue": JSON.stringify(jResult.Data) };
                QdhtyyPlugin.InsertKeyValue(jsonField, function (res) {
                    var jRes = JSON.parse(res);
                    if (jRes.ResCode != 1000) {
                        $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jRes.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                        return false;
                    }

                    //设置推送标签与别名
                    var sTags = jResult.Data.Utype == 0 ? "Customer" : "BankManager";
                    $tygasoftJPush.setTagsWithAlias([sTags], sUserName);

                    $tygasoftLS.Set('LoginId', sUserName);
                    ts.ToHome();
                })
            }, function (err) {
                $ionicLoading.hide();
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Http_Err, okText: $tygasoftMC.MC.Btn_OkText });
            })
        }, 1000);
    };

    ts.ToHome = function () {
        window.location = '#/app/Home';
    };

    ts.SetRootView = function () {
        $ionicHistory.nextViewOptions({
            disableAnimate: true,
            disableBack: true,
            historyRoot: true
        });
        window.location = '#/app/Home';
    };

    return ts;
});