angular.module('ngTygaSoft.services.TaskCargo', [])

.factory('$tygasoftTaskCargo', function ($ionicLoading, $ionicPopup, $ionicModal, ionicDatePicker, ngDialog, $tygasoftMC, $tygasoftCommon, $tygasoftLogin, $tygasoftTask) {

    var ts = {};

    ts.Bind = function ($scope) {
        var currDate = $tygasoftCommon.CurrentDate();
        $scope.BoxTypes = [{ "Id": 0, "Name": "不存放", "Odate": currDate }, { "Id": 1, "Name": "存放", "Odate": $tygasoftCommon.GetDate(currDate, "day", 1) }, { "Id": 2, "Name": "节假日存放", "Odate": $tygasoftCommon.GetDate(currDate, "day", 2) }, { "Id": 3, "Name": "上缴", "Odate": $tygasoftCommon.GetDate(currDate, "day", 3) }, { "Id": 4, "Name": "不定期存放", "Odate": $tygasoftCommon.GetDate(currDate, "day", 4) }];
    };

    ts.InitDlgTaskCargo = function ($scope) {
        $scope.CargoInfo = {};
        $ionicModal.fromTemplateUrl('templates/DlgTaskCargo.html', {
            scope: $scope
        }).then(function (modal) {
            $scope.DlgTaskCargoModal = modal;
        });
    };

    ts.InitDlgTaskCargoInfo = function ($scope) {
        $scope.CargoInfo = { "BoxType": "不存放" };
        $scope.CargoInfo.Odate = ts.GetOdate($scope,$scope.CargoInfo.BoxType);
        $ionicModal.fromTemplateUrl('templates/DlgTaskCargoInfo.html', {
            scope: $scope
        }).then(function (modal) {
            $scope.DlgTaskCargoInfoModal = modal;
        });
    };

    ts.GetOdate = function ($scope, name) {
        for (var i = 0; i < $scope.BoxTypes.length; i++) {
            if ($scope.BoxTypes[i].Name = name) {
                return $scope.BoxTypes[i].Odate;
            }
        }
    };

    ts.InitDlgBoxInfo = function ($scope) {
        $scope.BoxInfo = { "BoxTypeName": "请选择", "BoxPdate": "请选择" };
        $ionicModal.fromTemplateUrl('templates/DlgBoxInfo.html', {
            scope: $scope
        }).then(function (modal) {
            $scope.DlgBoxInfoModal = modal;
        });
    };

    ts.DlgBoxInfo = function ($scope) {
        $scope.DlgBoxInfoModal.show();
    };

    ts.CloseDlgBoxInfo = function ($scope) {
        $scope.DlgBoxInfoModal.hide();
    };

    ts.GetTaskCargoList = function ($scope) {
        var parentId = $scope.TaskInfo.TBRno + '|' + $scope.TaskInfo.TBType;
        var jsonField = '{"ParentId":"' + parentId + '","TypeName":"' + $scope.TaskInfo.TypeName + '"}';
        QdhtyyPlugin.GetBarcodeList(jsonField, function (result) {
            var jResult = JSON.parse(result);
            if (jResult.ResCode == 1000) {
                $scope.ScanData = [];
                var jData = JSON.parse(jResult.Data);
                if (jData.length > 0) {
                    for (var i = 0; i < jData.length; i++) {
                        var item = jData[i];
                        $scope.ScanData.push({ "Barcode": "" + item.Barcode + "", "Status": "" + $tygasoftCommon.GetSplitValue(item.ContentValue, "Status") + "" });
                    }
                }
            }
        });
    };

    ts.GetBoxList = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var jsonField = '{"Pno":"' + loginInfo.DeviceCode + '","Bno":"' + loginInfo.DeviceCode + '"}';
        QdhtyyPlugin.GetBoxList(jsonField, function (result) {
            //alert('GetBoxList--result--' + result);
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            $scope.Boxs = JSON.parse(jResult.Data);
        })
    };

    ts.OnBoxSelected = function ($scope, item) {
        $scope.BoxInfo = item;
        ts.DlgBoxInfo($scope);
    };

    ts.OnSelected = function ($scope, item) {
        $scope.CargoInfo = item;
        //$scope.ModelData.Barcode = item.Barcode;
        var parentId = $scope.TaskInfo.TBRno + '|' + $scope.TaskInfo.TBType;
        var jsonField = '{"Barcode":"' + item.Barcode + '","ParentId":"' + parentId + '"}';
        QdhtyyPlugin.GetBarcodeInfo(jsonField, function (result) {
            //alert('GetBarcodeInfo--result--' + result);
            var jResult = JSON.parse(result);
            if (jResult.ResCode == 1000) {
                var jData = JSON.parse(jResult.Data);
                $scope.CargoInfo.Id = jData.Id;
                $scope.CargoInfo.BoxType = $tygasoftCommon.GetSplitValue(jData.ContentValue, "Otype");
                $scope.CargoInfo.Odate = $tygasoftCommon.GetSplitValue(jData.ContentValue, "Odate");
                $scope.CargoInfo.BoxDcid = $tygasoftCommon.GetSplitValue(jData.ContentValue, "ToCID");
                $scope.CargoInfo.BoxDBno = $tygasoftCommon.GetSplitValue(jData.ContentValue, "ToBno");
            }
        });
        ts.OnDlgTaskCargoInfo($scope);
    };

    ts.DoScan = function ($scope, isAuto) {
        var sBarcode = $scope.ModelData.Barcode;
        if (!sBarcode || sBarcode == '') return false;
        try {
            var item = { Barcode: sBarcode, TaskId: $scope.TaskInfo.TBcid, Status: '待处理', TypeName: 'TaskCargo' };
            item.ContentValue = JSON.stringify(item);
            var len = $scope.ScanData.length;
            if (len == 0) $scope.ScanData.push(item);
            else {
                var isExist = false;
                for (var i = 0; i < len; i++) {
                    var oldItem = $scope.ScanData[i];
                    if (oldItem.Barcode == sBarcode) {
                        isExist = true;
                        break;
                    }
                }
                if (isExist) {
                    return false;
                }
                QdhtyyPlugin.InsertBarcode(JSON.stringify(item), function (result) {
                    $scope.ScanData.push(item);
                })
            }
        }
        finally {
            $scope.ModelData.Barcode = "";
        }
    };

    ts.SaveScan = function ($scope) {
        var len = $scope.ScanData.length;
        if (len > 0) {
            for (var i = 0; i < len; i++) {
                var item = $scope.ScanData[i];
                if (item.Status == '待处理') {

                    //$tygasoftLogin.GetLoginInfo().then(function (res) {
                    //    var postData = {};
                    //    postData.OrderCode = item.Barcode;
                    //    postData.CustomerCode = item.CustomerCode;
                    //    postData.OrderStep = item.OrderStep;
                    //    postData.LoginId = res.LoginId;
                    //    postData.DeviceId = res.DeviceId;
                    //    postData.Latlng = res.Latlng;
                    //    AfdPlugin.SaveOrderScan(JSON.stringify(postData), function (result) {
                    //        var jResult = JSON.parse(result);
                    //        if (jResult.ResCode == 1000) {
                    //            item.OrderProcessId = jResult.Data;
                    //            item.Status = '已处理';
                    //        }
                    //        else {
                    //            item.Status = '异常';
                    //        }
                    //        $scope.CanCommit = true;
                    //    })
                    //}, function (err) {
                    //    $scope.CanCommit = true;
                    //})
                    $scope.CanCommit = true;
                }
                else if (i == (len - 1)) $scope.CanCommit = true;
            }
        }
        else $scope.CanCommit = true;
    };

    ts.SaveBatchTaskCargo = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var jsonField = { Otype: $scope.CargoInfo.BoxType, Pno: loginInfo.DeviceCode, Oper: loginInfo.LoginId, TaskId: $scope.TaskInfo.TBcid, TypeName: 'BankTaskCargo' };
        QdhtyyPlugin.SaveBatchTaskCargo(JSON.stringify(jsonField), function (result) {
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Response_Ok, okText: $tygasoftMC.MC.Btn_OkText });
            ts.CloseDlgTaskCargo($scope);
        })
    };

    ts.SaveTaskCargoInfo = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var jsonField = { Otype: $scope.CargoInfo.BoxType, Pno: loginInfo.DeviceCode, Oper: loginInfo.LoginId, TaskId: $scope.TaskInfo.TBcid, TypeName: 'BankTaskCargo' };
        QdhtyyPlugin.SaveBatchTaskCargo(JSON.stringify(jsonField), function (result) {
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Response_Ok, okText: $tygasoftMC.MC.Btn_OkText });
            ts.CloseDlgTaskCargoInfo($scope);
        })
    };

    ts.BatchSave = function ($scope) {
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var parentId = $scope.TaskInfo.TBRno + '|' + $scope.TaskInfo.TBType;
        var jsonField = '{"ParentId":"' + parentId + '","TypeName":"' + $scope.TaskInfo.TypeName + '","Oper":"' + loginInfo.LoginId + '","Pno":"' + loginInfo.DeviceCode + '","Rno":"' + $scope.TaskInfo.TBRno + '","Bno":"' + $scope.TaskInfo.TBBNO + '"}';
        $ionicLoading.show();
        QdhtyyPlugin.SaveBatchTaskCargo(jsonField, function (result) {
            $ionicLoading.hide();
            //alert('SaveBatchTaskCargo--result--' + result);
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            $scope.TaskInfo.TBStime = $tygasoftCommon.FTime('');
            $tygasoftTask.SaveTaskInfo($scope);
            ts.GetTaskCargoList($scope);
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Response_Ok, okText: $tygasoftMC.MC.Btn_OkText });
        }, function (err) {
            $ionicLoading.hide();
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Http_Err, okText: $tygasoftMC.MC.Btn_OkText });
        })
    };

    ts.OnDlgTaskCargo = function ($scope) {
        $scope.DlgTaskCargoModal.show();
    };

    ts.CloseDlgTaskCargo = function ($scope) {
        $scope.DlgTaskCargoModal.hide();
    };

    ts.OnDlgTaskCargoInfo = function ($scope) {
        $scope.DlgTaskCargoInfoModal.show();
        //$scope.CargoInfo.Barcode = $scope.ModelData.Barcode;
        //$scope.ModelData.Barcode = "";
        //if ($scope.HasBarcode) $scope.HasBarcode = false;
    };

    ts.CloseDlgTaskCargoInfo = function ($scope) {
        $scope.DlgTaskCargoInfoModal.hide();
    };

    ts.OnDlgSelect = function ($scope, name) {
        var url = '';
        switch (name) {
            case "DlgBoxType":
                url = 'templates/DlgBoxType.html';
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
            case "BoxType":
                if ($scope.BoxInfo) {
                    $scope.BoxInfo.BoxType = item.Id;
                    $scope.BoxInfo.BoxTypeName = item.Name;
                }
                else $scope.CargoInfo.BoxType = item.Name;
                break;
            default:
                break;
        }

        ngDialog.closeAll();
    };

    ts.OnDpDate = function ($scope, n) {
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
                    case 3:
                        $scope.BoxInfo.BoxPdate = sDate;
                        break;
                    case 4:
                        $scope.CargoInfo.Odate = sDate;
                        break;
                    default:
                        break;
                }
            }
        });
    };

    ts.SaveBoxInfo = function ($scope) {
        //alert('saveBoxInfo--');
        var sBoxType = $scope.BoxInfo.BoxType;
        var sBoxPdate = $scope.BoxInfo.BoxPdate;
        var sBoxDcid = $scope.BoxInfo.BoxDcid;
        var sBoxDBno = $scope.BoxInfo.BoxDBno;
        var loginInfo = $tygasoftLogin.GetLoginInfo();
        var jsonField = '{"Pno":"' + loginInfo.DeviceCode + '","Bno":"' + $scope.BoxInfo.BoxBno + '","Oper":"' + loginInfo.LoginId + '","BoxNo":"' + $scope.BoxInfo.BoxNo + '","Btype":"' + sBoxType + '","Pdate":"' + sBoxPdate + '","ToCid":"' + sBoxDcid + '","ToBno":"' + sBoxDBno + '"}';
        //alert('SaveBoxInfo--jsonField--' + jsonField);
        QdhtyyPlugin.SaveBoxInfo(jsonField, function (result) {
            //alert('SaveBoxInfo--result--' + result);
            var jResult = JSON.parse(result);
            if (jResult.ResCode != 1000) {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Response_Ok, okText: $tygasoftMC.MC.Btn_OkText });
            ts.CloseDlgBoxInfo($scope);
        }, function (err) {
            $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_ExError, okText: $tygasoftMC.MC.Btn_OkText });
        })
    };

    return ts;
});