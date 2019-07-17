angular.module('ngTygaSoft.services.Workloads', [])
.factory('$tygasoftWorkloads', function ($timeout,$ionicLoading, $ionicPopup, $ionicModal, ionicDatePicker, ionicTimePicker, ngDialog, $tygasoftMC, $tygasoftCommon, $tygasoftLogin, $tygasoftLS) {

    var ts = {};

    ts.InitEvents = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        $scope.ModelData.StaffCode = loginInfo.LoginId;
        $scope.ModelData.YMonth = $tygasoftCommon.FMonth();

        $scope.toggleGroup = function (group) {
            if ($scope.isGroupShown(group)) {
                $scope.shownGroup = null;
            } else {
                $scope.shownGroup = group;
            }
        };
        $scope.isGroupShown = function (group) {
            return $scope.shownGroup === group;
        };
    };

    ts.GetWorkloads = function ($scope) {
        var sStaffCode = $scope.ModelData.StaffCode;
        var sYMonth = $scope.ModelData.YMonth;
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var jsonField = '{"DeviceId":"' + loginInfo.DeviceId + '","DeviceCode":"' + loginInfo.DeviceCode + '","Uid":"' + sStaffCode + '","YMonth":"' + sYMonth + '"}';

        $ionicLoading.show();
        setTimeout(function () {
            QdhtyyPlugin.GetEmpTlist(jsonField, function (result) {
                //alert('GetEmpTlist--result--' + result);
                $ionicLoading.hide();
                var jResult = JSON.parse(result);
                if (jResult.ResCode != 1000) {
                    $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                    return false;
                }
                $scope.Workloads = jResult.Data;
            });
        }, 1000);
    };

    ts.OnDpDate = function ($scope, n) {
        ionicDatePicker.openDatePicker({
            callback: function (val) {
                var sDate = new Date(val).Format("yyyy-MM");
                switch (n) {
                    case 6:
                        $scope.ModelData.YMonth = sDate;
                        break;
                    default:
                        break;
                }
            }
        });
    };

    return ts;
});