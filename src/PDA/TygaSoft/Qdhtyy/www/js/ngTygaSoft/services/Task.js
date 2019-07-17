angular.module('ngTygaSoft.services.Task', [])
.factory('$tygasoftTask', function ($rootScope, $ionicLoading, $ionicPopup, $ionicModal, ionicDatePicker, ionicTimePicker, ngDialog, $tygasoftMC, $tygasoftCommon, $tygasoftLogin, $tygasoftLS) {

    var ts = {};

    ts.Bind = function ($scope) {
        $scope.TaskTypes = [{ "Key": "A", "Value": "早送" }, { "Key": "B", "Value": "晚接" }, { "Key": "C", "Value": "包车" }, { "Key": "E", "Value": "约时" }, { "Key": "F", "Value": "定时" }];
    };

    ts.InitDlgTask = function ($scope) {
        $scope.DlgTaskInfo = {};
        $ionicModal.fromTemplateUrl('templates/DlgTask.html', {
            scope: $scope
        }).then(function (modal) {
            $scope.DlgTaskModal = modal;
        });
    };

    ts.OpenDlgTask = function ($scope) {
        $scope.DlgTaskModal.show();
    };

    ts.CloseDlgTask = function ($scope) {
        $scope.DlgTaskModal.hide();
    };

    ts.GetAuthInfo = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var sData = '{"DeviceId":"' + loginInfo.DeviceId + '","DeviceCode":"' + loginInfo.DeviceCode + '","NfcCode":"' + $scope.ModelData.NfcCode + '"}';
        QdhtyyPlugin.GetAuthInfo(sData, function (result) {
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            var jData = JSON.parse(jResult.Data);
            $rootScope.PictureUrl = jData.PictureUrl;
            $rootScope.AuthTime = $tygasoftCommon.FTime('');
            $scope.ModelData.NfcDescr = '请点击确认按钮通过认证！'
            $tygasoftLS.Set('CustomerId', jData.CustomerId);
        })
    };

    ts.GetTaskList = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var sData = '{"DeviceId":"' + loginInfo.DeviceId + '","DeviceCode":"' + loginInfo.DeviceCode + '"}';
        QdhtyyPlugin.GetTaskList(sData, function (result) {
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            var jData = JSON.parse(jResult.Data);
            $scope.Tasks = jData;
        })
    };

    ts.GetFeeQ = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var sYMonth = $scope.ModelData.YMonth.replace('请选择', '');
        var sTaskType = $scope.ModelData.TaskTypeId ? $scope.ModelData.TaskTypeId : '';
        var jsonField = '{"Amon":"' + sYMonth + '","Btype":"' + sTaskType + '","Pno":"' + loginInfo.DeviceCode + '","Bno":"' + loginInfo.DeviceCode + '"}';
        $ionicLoading.show();
        QdhtyyPlugin.GetFeeQ(jsonField, function (result) {
            $ionicLoading.hide();
            //alert('GetFeeQ--result--' + result);
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            var jData = JSON.parse(jResult.Data);
            $scope.Charges = jData;
        }, function (err) {
            $ionicLoading.hide();
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_LoadingError, okText: $tygasoftMC.MC.Btn_OkText });
        });
    };

    ts.GetInQTask = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var jsonField = '{"Pid":"' + loginInfo.DeviceId + '","Pno":"' + loginInfo.DeviceCode + '"}';
        $ionicLoading.show();
        QdhtyyPlugin.GetInQTask(jsonField, function (result) {
            $ionicLoading.hide();
            //alert('GetInQTask--result--' + result);
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            var jData = JSON.parse(jResult.Data);
            $scope.InQTasks = jData;
        }, function (err) {
            $ionicLoading.hide();
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_LoadingError, okText: $tygasoftMC.MC.Btn_OkText });
        });
    };

    ts.DoTask = function ($scope, item) {
        $scope.TaskInfo = item;
        if (!$scope.TaskInfo.TBStime || $scope.TaskInfo.TBStime == '') $scope.TaskInfo.TBStime = '请选择';
        if (!$scope.TaskInfo.TBEtime || $scope.TaskInfo.TBEtime == '') $scope.TaskInfo.TBEtime = '请选择';
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        //alert('loginInfo.CustomerId--' + loginInfo.CustomerId);
        if ($scope.TaskInfo.TBEmp != loginInfo.CustomerId) {
            var errMsg = '';
            if (!loginInfo.CustomerId || loginInfo.CustomerId == '') {
                errMsg = $tygasoftMC.MC.M_Auth;
            }
            else {
                errMsg = $tygasoftMC.MC.M_AuthInvalidError;
            }
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: errMsg, okText: $tygasoftMC.MC.Btn_OkText });
            return false;
        }
        
        var sTaskType = $scope.TaskInfo.TBType;
        if (sTaskType == 'B') {
            //晚接任务
            window.location = '#/app/Barcode/' + JSON.stringify($scope.TaskInfo) + '';
        }
        else {
            ts.OpenDlgTask($scope);
        }
    };

    ts.SaveTaskInfo = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var sData = '{"CId":"' + $scope.TaskInfo.TBcid + '","Adate":"' + $scope.TaskInfo.TBdate + '","RNO":"' + $scope.TaskInfo.TBRno + '","BNO":"' + $scope.TaskInfo.TBBNO + '","Stime":"' + $scope.TaskInfo.TBStime + '","Etime":"' + $scope.TaskInfo.TBEtime + '","Kilm":"' + $scope.TaskInfo.TBKilM + '","Fee":"' + $scope.TaskInfo.TBFee + '","Oper":"' + loginInfo.LoginId + '"}';
        QdhtyyPlugin.SaveTaskInfo(sData, function (result) {
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            ts.CloseDlgTask($scope);
            //window.location = '#/app/Tasks/' + JSON.stringify($scope.TaskInfo) + '';
        })
    };

    ts.SaveApplyTaskInfo = function ($scope) {
        var sPtime = $scope.TaskInfo.TBPtime.replace("请选择","");
        var sDescr = $scope.TaskInfo.TBnotes;
        if (sPtime == '' || sDescr == '') {
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_Required_Error, okText: $tygasoftMC.MC.Btn_OkText });
            return false;
        }
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var jsonField = '{"Adate":"","Pno":"' + loginInfo.DeviceCode + '","Bno":"' + loginInfo.DeviceCode + '","Oper":"' + loginInfo.LoginId + '","Ptime":"' + sPtime + '","Note":"' + sDescr + '"}';
        QdhtyyPlugin.SaveApplyTaskInfo(jsonField, function (result) {
            //alert('SaveApplyTaskInfo--result--' + result);
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            ts.GetInQTask($scope);
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Response_Ok, okText: $tygasoftMC.MC.Btn_OkText });
        }, function (err) {
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_LoadingError, okText: $tygasoftMC.MC.Btn_OkText });
        })
    };

    ts.DlgTask = function ($scope) {
        $scope.DlgTaskModel = {};
        $ionicModal.fromTemplateUrl('templates/DlgTask.html', {
            scope: $scope
        }).then(function (modal) {
            $scope.DlgTaskModal = modal;
        });
    };

    ts.OnDlgSelect = function ($scope, name) {
        var url = '';
        switch (name) {
            case "TaskType":
                url = 'templates/DlgTaskType.html';
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
            case "TaskType":
                $scope.ModelData.TaskType = item.Value;
                $scope.ModelData.TaskTypeId = item.Key;
                break;
            default:
                break;
        }

        ngDialog.closeAll();
    };

    ts.OnDpDate = function ($scope,n) {
        ionicDatePicker.openDatePicker({
            callback: function (val) {
                var sDate = new Date(val).Format("yyyy-MM-dd");
                switch (n) {
                    case 1:
                        $scope.ModelData.StartDate = sDate;
                        break;
                    case 2:
                        $scope.ModelData.EndDate = sDate;
                        break;
                    case 4:
                        $scope.TaskInfo.TBPtime = sDate;
                        break;
                    case 5:
                        $scope.ModelData.YMonth = new Date(val).Format("yyyy-MM");
                        break;
                    default:
                        break;
                }
            }
        });
    };

    ts.OnDpTime = function ($scope, n) {
        ionicTimePicker.openTimePicker({
            callback: function (val) {
                var selectedTime = $tygasoftCommon.FTime(val);
                switch (n) {
                    case 1:
                        $scope.TaskInfo.TBStime = selectedTime;
                        break;
                    case 2:
                        $scope.TaskInfo.TBEtime = selectedTime;
                        break;
                    default:
                        break;
                }
            }
        });
    };

    return ts;
});