angular.module('starter.controllers', [])

.controller('AppCtrl', function ($scope, $tygasoftMenu) {
    $scope.$on('$ionicView.beforeEnter', function (e) {
        $tygasoftMenu.GetHomeMenus($scope);
        //$tygasoftMenu.CheckVersion();
    });
})
.controller('MenuCtrl', function ($scope, $tygasoftMenu) {
    $scope.LoginData = {};
    $scope.$on('$ionicView.beforeEnter', function (e) {
        $tygasoftMenu.BeforeEnter($scope);
    });
    $tygasoftMenu.GetMenus($scope);
    $scope.onTo = function (index) {
        $tygasoftMenu.OnTo($scope, index);
    };
})
.controller('DefaultCtrl', function ($scope) {
    $scope.$on('$ionicView.enter', function (e) {
    });
})
.controller('SysCtrl', function ($scope, $tygasoftLS, $tygasoftSys) {
    $scope.ModelData = { "ServerIP": "", "ServerPort": "80", "DeviceCode": "" + $tygasoftLS.Get("DeviceCode", "") + "", "ServiceUrl": "" + $tygasoftLS.Get("ServiceUrl", "") + "", "UhfOnOff": "checked" };
    $tygasoftSys.Bind($scope);
})
.controller('JPushDetailCtrl', function ($scope, $stateParams) {
    $scope.JNotice = JSON.parse($stateParams.item);
})
.controller('LoginCtrl', function ($scope, $ionicHistory, $tygasoftLogin) {
    $ionicHistory.clearHistory();
    $ionicHistory.clearCache();
    $scope.LoginData = { UserName: '01010101', Password: '111111' };
    $tygasoftLogin.Bind($scope);
})
.controller('NfcAuthCtrl', function ($scope, $rootScope, $interval, $ionicPopup, $tygasoftMC, $tygasoftTask) {
    $scope.ModelData = { NfcDescr: '未认证！请将卡置于下方...' };
    if (!$rootScope.NfcCode) {
        $rootScope.NfcCode = '';
        $rootScope.PictureUrl = 'img/BlankPic.png';
    }
    else {
        $scope.ModelData.NfcDescr = '已认证！';
    }
    $scope.ItvNfc = null;
    $scope.CanReadNfc = true;

    $scope.onOk = function () {
        if (!$scope.ModelData.NfcCode || $scope.ModelData.NfcCode == '') {
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_Auth, okText: $tygasoftMC.MC.Btn_OkText });
            return false;
        }
        $rootScope.NfcCode = $scope.ModelData.NfcCode;
        var dlgShow = $ionicPopup.show({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_AuthOk });
        setTimeout(function () {
            dlgShow.close();
            window.location = "#/app/Home";
        }, 1000);
    };

    $scope.onResetAuth = function () {
        $ionicPopup.confirm({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Confirm_Msg, cancelText: $tygasoftMC.MC.Btn_CancelText, okText: $tygasoftMC.MC.Btn_OkText }).then(function (res) {
            if (res) {
                $rootScope.NfcCode = '';
                $rootScope.PictureUrl = 'img/BlankPic.png';
                $scope.ModelData.NfcDescr = '请将卡置于下方...';
            }
        })
    };

    $scope.$on('$ionicView.enter', function (e) {
        $scope.ItvNfc = $interval(function () {
            if (!$scope.CanReadNfc) return;
            if ($rootScope.NfcCode && $rootScope.NfcCode != "") {
                return;
            }
            $scope.CanReadNfc = false;
            NfcPlugin.GetResult(function (result) {
                if (result != '') {
                    $scope.ModelData.NfcCode = result;
                    $tygasoftTask.GetAuthInfo($scope);
                }
                
                $scope.CanReadNfc = true;
            });
        }, 1000);
    });
    $scope.$on('$ionicView.leave', function (e) {
        $interval.cancel($scope.ItvNfc);
    });
})
.controller('TasksCtrl', function ($scope, $tygasoftTask) {
    $scope.TaskInfo = { "TBStime": "请选择", "TBEtime": "请选择" };

    $tygasoftTask.DlgTask($scope);
    $tygasoftTask.GetTaskList($scope);

    $scope.onDpTime = function (n) {
        $tygasoftTask.OnDpTime($scope, n);
    };
    $scope.onDoTask = function (item) {
        $tygasoftTask.DoTask($scope, item);
    };
    $scope.saveTaskInfo = function () {
        $tygasoftTask.SaveTaskInfo($scope);
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
})
.controller('TaskCargoCtrl', function ($scope, $interval, $tygasoftTaskCargo) {
    $scope.TaskInfo = JSON.parse($stateParams.item);
    $scope.ModelData = { "Barcode": "" };
    $scope.BoxTypes = [{ "Id": "0", "Name": "不存放" }, { "Id": "1", "Text": "存放" }, { "Id": "2", "Text": "节假日存放" }, { "Id": "3", "Text": "上缴" }, { "Id": "4", "Text": "不定期存放" }];
    $scope.ScanData = [];
    $scope.ItvCommit = null;
    $scope.CanCommit = true;

    $scope.$on('$ionicView.enter', function (e) {
        $scope.ItvCommit = $interval(function () {
            if (!$scope.CanCommit) return;
            $scope.CanCommit = false;
            if ($scope.ScanData.length > 0) {
                $tygasoftTaskCargo.SaveScan($scope);
            }
            else $scope.CanCommit = true;
        }, 1000);
    });
    $scope.$on('$ionicView.leave', function (e) {
        $interval.cancel($scope.ItvCommit);
    });

    $tygasoftTaskCargo.InitDlgTaskCargo($scope);
    $tygasoftTaskCargo.InitDlgTaskCargoInfo($scope);
    $scope.onDlgTaskCargo = function () {
        $tygasoftTaskCargo.OnDlgTaskCargo($scope);
    };
    $scope.onDlgTaskCargoInfo = function () {
        $tygasoftTaskCargo.OnDlgTaskCargoInfo($scope);
    };
    $scope.onDlg = function (name) {
        $tygasoftTaskCargo.OnDlg($scope, name);
    };
    $scope.onDlgSeleteItem = function (name, item) {
        $tygasoftTaskCargo.OnDlgSeleteItem($scope, name, item);
    };
    $scope.saveBatchTaskCargo = function () {
        $tygasoftTaskCargo.SaveBatchTaskCargo($scope);
    };
    $scope.saveTaskCargoInfo = function () {
        $tygasoftTaskCargo.SaveTaskCargoInfo($scope);
    };

    $scope.onSure = function () {
        $tygasoftTaskCargo.DoScan($scope, false);
    };
    $scope.onBarcodeChanged = function () {
        if ($scope.btnTabIndex == 1) return false;
        $tygasoftTaskCargo.DoScan($scope, true);
    };
    $scope.btnTabIndex = 0;
    $scope.onTabSelected = function (index) {
        $scope.btnTabIndex = index;
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
})
.controller('BarcodeCtrl', function ($scope, $timeout, $stateParams, $tygasoftCommon, $tygasoftBarcode, $tygasoftTaskCargo) {
    $scope.ModelData = { Barcode: "", Isfocus:true };
    $scope.TaskInfo = JSON.parse($stateParams.item);
    $scope.TaskInfo.Title = $scope.TaskInfo.TBRno + '（晚接任务）';
    $scope.TaskInfo.TypeName = 'TaskCargo';
    $scope.ScanData = [];
    $tygasoftTaskCargo.Bind($scope);
    $tygasoftTaskCargo.InitDlgTaskCargoInfo($scope);
    //$tygasoftBarcode.StartQueue($scope);
    $tygasoftBarcode.GetBarcodeList($scope);
    
    $scope.$on('$ionicView.enter', function (e) {
        //$tygasoftBarcode.InitFocus($scope);
    });
    $scope.$on('$ionicView.leave', function (e) {
        $tygasoftBarcode.StopFocus($scope);
        //$tygasoftBarcode.Reset($scope);
    });

    $scope.onSelectedTaskCargo = function (item) {
        $scope.ModelData.Isfocus = false;
        //$scope.ModelData.Barcode = item.Barcode;
        $tygasoftTaskCargo.OnSelected($scope,item);
    };
    $scope.onDlgSelect = function (name) {
        $tygasoftTaskCargo.OnDlgSelect($scope, name);
    };
    $scope.onDpDate = function (n) {
        $tygasoftTaskCargo.OnDpDate($scope, n);
    };
    $scope.onDeletedBarcode = function (item) {
        $tygasoftBarcode.OnDeletedBarcode($scope, item);
    };
    $scope.onDlgSeleteItem = function (name, item) {
        $tygasoftTaskCargo.OnDlgSeleteItem($scope, name, item);
    };
    $scope.saveTaskCargoInfo = function () {
        $scope.ModelData.Barcode = $scope.CargoInfo.Barcode;
        $tygasoftBarcode.DoScan($scope, true);
        //$tygasoftTaskCargo.SaveTaskCargoInfo($scope);
    };
    $scope.closeDlgTaskCargoInfo = function () {
        $tygasoftTaskCargo.CloseDlgTaskCargoInfo($scope);
    };
    $scope.onSave = function () {
        $tygasoftTaskCargo.BatchSave($scope);
    };
    $scope.onSure = function () {
        $scope.ModelData.Isfocus = false;
        $tygasoftTaskCargo.OnDlgTaskCargoInfo($scope);
        //$tygasoftBarcode.DoScan($scope, false);
    };
    $scope.onBarcodeChanged = function () {
        if ($scope.btnTabIndex == 1) return false;
        if ($scope.ModelData.Barcode == '') return false;
        $scope.ModelData.Isfocus = false;
        $scope.CargoInfo.Barcode = $scope.ModelData.Barcode;
        $tygasoftBarcode.DoScan($scope, true);
        $scope.ModelData.Isfocus = true;
    };
    $scope.btnTabIndex = 0;
    $scope.onTabSelected = function (index) {
        $scope.btnTabIndex = index;
        $scope.ModelData.Isfocus = true;
    };

    $scope.onFocus = function () {
        $scope.ModelData.Isfocus = true;
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
})
.controller('BoxsCtrl', function ($scope, $tygasoftTaskCargo) {
    
    $scope.$on('$ionicView.enter', function (e) {
    });

    $tygasoftTaskCargo.GetBoxList($scope);

    $tygasoftTaskCargo.InitDlgBoxInfo($scope);

    $tygasoftTaskCargo.Bind($scope);

    $scope.onBoxSelected = function (item) {
        $tygasoftTaskCargo.OnBoxSelected($scope, item);
    };

    $scope.closeDlgBoxInfo = function () {
        $tygasoftTaskCargo.CloseDlgBoxInfo($scope);
    };

    $scope.onDlgSelect = function (name) {
        $tygasoftTaskCargo.OnDlgSelect($scope, name);
    };

    $scope.onDpDate = function (n) {
        $tygasoftTaskCargo.OnDpDate($scope, n);
    };

    $scope.onDlgSeleteItem = function (name, item) {
        $tygasoftTaskCargo.OnDlgSeleteItem($scope, name, item);
    };

    $scope.saveBoxInfo = function () {
        $tygasoftTaskCargo.SaveBoxInfo($scope);
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
})
.controller('AddTaskCtrl', function ($scope, $tygasoftTask) {
    $scope.TaskInfo = { "TBPtime": "请选择","TBnotes":"" };
    $scope.$on('$ionicView.enter', function (e) {
    });

    $tygasoftTask.GetInQTask($scope);

    $scope.onDpDate = function (n) {
        $tygasoftTask.OnDpDate($scope, n);
    };
    $scope.saveApplyTaskInfo = function () {
        $tygasoftTask.SaveApplyTaskInfo($scope)
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
})
.controller('ChargesCtrl', function ($scope, $tygasoftCommon, $tygasoftTask) {
    $scope.ModelData = { YMonth: $tygasoftCommon.FMonth(), TaskType: '请选择' };

    $tygasoftTask.Bind($scope);
    $scope.$on('$ionicView.enter', function (e) {
    });

    $scope.onDpDate = function (n) {
        $tygasoftTask.OnDpDate($scope, n);
    };

    $scope.onDlgSelect = function (name) {
        $tygasoftTask.OnDlgSelect($scope, name);
    };

    $scope.onDlgSeleteItem = function (name, item) {
        $tygasoftTask.OnDlgSeleteItem($scope, name, item);
    };

    $scope.onSearch = function () {
        $tygasoftTask.GetFeeQ($scope);
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
})
.controller('ETasksCtrl', function ($scope, $tygasoftETasks) {
    $tygasoftETasks.InitEvents($scope);
    $tygasoftETasks.GetETasks($scope);
})
.controller('WorkloadsCtrl', function ($scope, $tygasoftWorkloads) {
    $scope.ModelData = { StaffCode: "", YMonth:"请选择"};

    $tygasoftWorkloads.InitEvents($scope);

    $scope.onSearch = function () {
        $tygasoftWorkloads.GetWorkloads($scope);
    };

    $scope.onDpDate = function (n) {
        $tygasoftWorkloads.OnDpDate($scope, n);
    };
})
.controller('RfidCtrl', function ($scope, $interval, $http, $tygasoftRfid, $tygasoftCommon) {
    var itvRfid = null;
    $scope.CanReadRfid = true;

    $scope.$on('$ionicView.beforeEnter', function (e) {
        $tygasoftRfid.Reset();
    });
    $scope.$on('$ionicView.enter', function (e) {
        $tygasoftRfid.SetResult();
        var rfidItems = [];
        itvRfid = $interval(function () {
            if (!$scope.CanReadRfid) return;
            $scope.CanReadRfid = false;
            var rfids = $tygasoftRfid.GetRfidItems();
            for (var i = 0; i < rfids.length; i++) {
                rfidItems.push(rfids[i]);
                $scope.Items = rfidItems;
                $scope.DoRfid(rfids[i].Name);
            }
            $scope.CanReadRfid = true;
        }, 1000);
    });
    $scope.$on('$ionicView.leave', function (e) {
        //clearInterval(itvRfid);
        $interval.cancel(itvRfid);
        $tygasoftRfid.Reset();
    });

    $scope.DoRfid = function (rfid) {
        var postData = '{"model":{"TID":"' + rfid + '","EPC":"' + rfid + '"}}';
        var sUrl = "" + $tygasoftCommon.ServerUrl() + "/Services/PdaService.svc/SaveRFIDQueue";
        $http.defaults.headers.post['Content-Type'] = 'application/json; charset=utf-8';
        $http({
            method: 'POST',
            url: sUrl,
            data: postData
        }).then(function (res) {
            var result = res.data;
        }, function (err) {
        });
    };
});
