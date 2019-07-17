angular.module('ngTygaSoft.services.Menu', [])
.factory('$tygasoftMenu', function ($timeout, $ionicHistory, $ionicSideMenuDelegate, $ionicLoading, $ionicPopup, $tygasoftLS, $tygasoftMC, $tygasoftLogin) {

    var ts = {};

    ts.BeforeEnter = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        $scope.LoginData.IsLogin = loginInfo.LoginId != '';
        $ionicSideMenuDelegate.canDragContent($scope.LoginData.IsLogin);
        if (!$scope.LoginData.IsLogin) {
            $ionicHistory.nextViewOptions({ disableAnimate: true, disableBack: true, historyRoot: false });
            if (loginInfo.DeviceCode == '') window.location = '#/app/SysSet';
            else window.location = '#/app/Login';
        }
    }

    ts.GetMenus = function ($scope) {
        $scope.MenuItems = [{ "Id": 99, "Name": "设置", "icon": "ion-ios-gear-outline", "Url": "#/app/SysSet" }, { "Id": 98, "Name": "切换账号", "icon": "ion-ios-loop", "Url": "#/app/Login" }, { "Id": 97, "Name": "退出", "icon": "ion-power" }, { "Id": 96, "Name": "关于", "icon": "ion-ios-information-outline" }];
    };

    ts.GetHomeMenus = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        //alert(loginInfo.LoginId);
        if (loginInfo.LoginId != '') {
            var jsonField = { "KeyName": "" + loginInfo.LoginId + "", "TypeName": "LoginInfo" };
            QdhtyyPlugin.GetKeyValue(JSON.stringify(jsonField), function (result) {
                //alert('GetHomeMenus--result--' + result);
                var jResult = JSON.parse(result);
                if (jResult.Data != '') {
                    var jData = JSON.parse(jResult.Data);
                    //alert('jData.Utype--' + jData.Utype);
                    if (jData.Utype == 0) $scope.HomeMenuItems = [{ "Id": 1, "Name": "身份认证", "Src": "img/icons/home-kccx.png", "Url": "#/app/NfcAuth" }, { "Id": 2, "Name": "下载任务", "Src": "img/icons/home-sj.png", "Url": "#/app/ETasks" }, { "Id": 3, "Name": "工作量查询", "Src": "img/icons/home-pd.png", "Url": "#/app/Workloads" }];
                    else $scope.HomeMenuItems = [{ "Id": 1, "Name": "身份认证", "Src": "img/icons/home-kccx.png", "Url": "#/app/NfcAuth" }, { "Id": 2, "Name": "任务执行", "Src": "img/icons/home-sj.png", "Url": "#/app/Tasks" }, { "Id": 3, "Name": "库存尾箱状态调整", "Src": "img/icons/home-pd.png", "Url": "#/app/Boxs" }, { "Id": 4, "Name": "任务申请", "Src": "img/icons/home-jh.png", "Url": "#/app/AddTask" }, { "Id": 5, "Name": "费用查询", "Src": "img/icons/home-rfid.png", "Url": "#/app/Charges" }];
                }
            })
            //$ionicLoading.show();
            //$timeout(function () {
            //    QdhtyyPlugin.GetKeyValue(JSON.stringify(jsonField), function (result) {
            //        //alert('GetHomeMenus--result--' + result);
            //        var jResult = JSON.parse(result);
            //        if (jResult.Data != '') {
            //            var jData = JSON.parse(jResult.Data);
            //            //alert('jData.Utype--' + jData.Utype);
            //            if (jData.Utype == 0) $scope.HomeMenuItems = [{ "Id": 1, "Name": "身份认证", "Src": "img/icons/home-kccx.png", "Url": "#/app/NfcAuth" }, { "Id": 2, "Name": "下载任务", "Src": "img/icons/home-sj.png", "Url": "#/app/Tasks" }, { "Id": 3, "Name": "工作量查询", "Src": "img/icons/home-pd.png", "Url": "#/app/Boxs" }];
            //            else $scope.HomeMenuItems = [{ "Id": 1, "Name": "身份认证", "Src": "img/icons/home-kccx.png", "Url": "#/app/NfcAuth" }, { "Id": 2, "Name": "任务执行", "Src": "img/icons/home-sj.png", "Url": "#/app/Tasks" }, { "Id": 3, "Name": "库存尾箱状态调整", "Src": "img/icons/home-pd.png", "Url": "#/app/Boxs" }, { "Id": 4, "Name": "任务申请", "Src": "img/icons/home-jh.png", "Url": "#/app/AddTask" }, { "Id": 5, "Name": "费用查询", "Src": "img/icons/home-rfid.png", "Url": "#/app/Charges" }];
            //        }
            //    })
            //}, 1000).then(function () {
            //    $ionicLoading.hide();
            //});
        }
    };

    ts.OnTo = function ($scope,index) {
        var item = $scope.MenuItems[index];
        if (!item.Url || item.Url == '') {
            switch (item.Name) {
                case "退出":
                    ts.ExitApp();
                    break;
                default:
                    break;
            }
        }
        else {
            window.location = item.Url;
        }
        $ionicSideMenuDelegate.toggleLeft();
    };

    ts.CheckVersion = function () {
        var timespan = (new Date("2017-2-4")) - (new Date());
        var totalDays = Math.floor(timespan / (24 * 3600 * 1000));
        if (totalDays < 1) {
            return;
            setInterval(function () {
                alert('当前版本已过期，请联系我们解锁！');
            }, 1000);
        }
    };

    ts.ExitApp = function () {
        $ionicPopup.confirm({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_ExitApp_Content, cancelText: $tygasoftMC.MC.Btn_CancelText, okText: $tygasoftMC.MC.Btn_OkText }).then(function (res) {
            if (res) {
                //RfidScan.onClose(function (result) {
                //    $tygasoftLS.Set("UhfOnOff", 0);
                //});
                $tygasoftLS.Set('LoginId', '');
                NfcPlugin.StopNfc(function () {
                    $tygasoftLS.Set("NfcOnOff", 0);
                });
                ionic.Platform.exitApp();
            }
        })
    };

    return ts;
});