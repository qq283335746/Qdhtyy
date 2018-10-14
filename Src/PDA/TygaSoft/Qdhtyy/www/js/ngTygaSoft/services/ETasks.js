angular.module('ngTygaSoft.services.ETasks', [])
.factory('$tygasoftETasks', function ($rootScope, $ionicLoading, $ionicPopup, $ionicModal, ionicDatePicker, ionicTimePicker, ngDialog, $tygasoftMC, $tygasoftCommon, $tygasoftLogin, $tygasoftLS) {

    var ts = {};

    ts.InitEvents = function ($scope) {

        ts.InitDlgETask($scope);

        $scope.onDoETask = function (item) {
            if (!$rootScope.AuthTime || $rootScope.AuthTime == '') {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_Auth, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            $scope.ETaskInfo = item;
            $scope.ETaskInfo.TBStime = $rootScope.AuthTime;
            if (!$scope.ETaskInfo.TBEtime || $scope.ETaskInfo.TBEtime == '') $scope.ETaskInfo.TBEtime = $tygasoftCommon.FTime('');
            if (!$scope.ETaskInfo.TBEva || $scope.ETaskInfo.TBEva == "") {
                $scope.ETaskInfo.EvaId = "0";
                $scope.ETaskInfo.Eva = '请选择';
            }
            else {
                $scope.ETaskInfo.EvaId = $scope.ETaskInfo.TBEva;
                $scope.ETaskInfo.Eva = '*';
            }
            
            ts.OpenDlgTask($scope);
        };

        $scope.saveETaskInfo = function () {
            ts.SaveETask($scope);
        };

        $scope.onDlgSelect = function (name) {
            ts.OnDlgSelect($scope, name);
        };

        $scope.onDlgSeleteItem = function (name, item) {
            ts.OnDlgSeleteItem($scope, name, item);
        };

        $scope.onDpTime = function (n) {
            ts.OnDpTime($scope, n);
        };

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

    ts.GetETasks = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var jsonField = '{"DeviceId":"' + loginInfo.DeviceId + '","DeviceCode":"' + loginInfo.DeviceCode + '","Uid":"' + loginInfo.LoginId + '"}';
        QdhtyyPlugin.GetEtask(jsonField, function (result) {
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            $scope.ETasks = jResult.Data;
        })
    };

    ts.SaveETask = function ($scope) {
        var sStartTime = $scope.ETaskInfo.TBStime;
        var sEndTime = $scope.ETaskInfo.TBEtime;
        var sKilm = $scope.ETaskInfo.TBKilm;
        var sFee = $scope.ETaskInfo.TBFee;
        var sEva = $scope.ETaskInfo.EvaId;
        var isRight = true;
        if (sStartTime == '') isRight = false;
        else if (sEndTime == "") {
            isRight = false;
        }
        else if (!sKilm || sKilm == "") {
            isRight = false;
        }
        else if (!sFee || sFee == "") {
            isRight = false;
        }
        if (!isRight) {
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_Required_Error, okText: $tygasoftMC.MC.Btn_OkText });
            return false;
        }
        var sBno = $scope.ETaskInfo.TBBNO;
        var sRno = $scope.ETaskInfo.TBRno;
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var jsonField = '{"Oper":"' + loginInfo.LoginId + '","Pno":"' + loginInfo.DeviceCode + '","Bno":"' + sBno + '","Rno":"' + sRno + '","Adate":"","Stime":"' + sStartTime + '","Etime":"' + sEndTime + '","Kilm":"' + sKilm + '","Fee":"' + sFee + '","Eva":"' + sEva + '"}';
        $ionicLoading.show();
        setTimeout(function () {
            QdhtyyPlugin.SaveETask(jsonField, function (result) {
                $ionicLoading.hide();
                var jResult = JSON.parse(result);
                if (jResult.ResCode != 1000) {
                    $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                    return false;
                }
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Response_Ok, okText: $tygasoftMC.MC.Btn_OkText });
                ts.CloseDlgETask($scope);
            }, function (err) {
                $ionicLoading.hide();
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Http_Err, okText: $tygasoftMC.MC.Btn_OkText });
            })
        }, 1000);
    };

    ts.InitDlgETask = function ($scope) {
        $scope.ETaskInfo = {};
        $ionicModal.fromTemplateUrl('templates/AddETask.html', {
            scope: $scope
        }).then(function (modal) {
            $scope.DlgETaskModal = modal;
        });
    };

    ts.OpenDlgTask = function ($scope) {
        $scope.DlgETaskModal.show();
    };

    ts.CloseDlgETask = function ($scope) {
        $scope.DlgETaskModal.hide();
    };

    ts.OnDlgSelect = function ($scope, name) {
        var url = '';
        switch (name) {
            case "Eva":
                $scope.Evaluates = [{ Key: 0, Value: '好' }, { Key: 1, Value: '中' }, { Key: 2, Value: '差' }];
                url = 'templates/DlgEvaluate.html';
                break;
            default:
                break;
        }
        ngDialog.open({
            scope: $scope,
            template: url,
            className: 'ngdialog-theme-default',
            width: '100%',
            showClose: false
        });
    };

    ts.OnDlgSeleteItem = function ($scope, name, item) {
        switch (name) {
            case "Eva":
                $scope.ETaskInfo.Eva = "*";
                $scope.ETaskInfo.EvaId = item.Key;
                break;
            default:
                break;
        }
        ngDialog.closeAll();
    };

    ts.OnDpTime = function ($scope, n) {
        ionicTimePicker.openTimePicker({
            callback: function (val) {
                var selectedTime = $tygasoftCommon.FTime(val);
                switch (n) {
                    case 2:
                        $scope.ETaskInfo.TBEtime = selectedTime;
                        break;
                    default:
                        break;
                }
            }
        });
    };

    return ts;
});