angular.module('ngTygaSoft.services.Barcode', [])
.directive('isfocus', function ($interval,$timeout, $parse) {
    return{
        link: function (scope, element, attrs) {
            scope.ItvFocus = $interval(function () {
                var model = $parse(attrs.isfocus);
                scope.$watch(model, function (value) {
                    if (scope.ModelData.Barcode == '') {
                        if (!value) element[0].blur();
                        else element[0].focus();
                    }
                    //if (value) {
                    //    if (scope.ModelData.Barcode == '') {
                    //        element[0].focus();
                    //    }
                    //    //$timeout(function() {
                    //    //    element[0].focus();
                    //    //});
                    //}
                    //else{
                    //    $timeout(function() {
                    //        element[0].blur();
                    //    });
                    //}
                });
            }, 1000);
        }
    }
})
.factory('$tygasoftBarcode', function ($interval, $ionicPopup, $ionicModal, $tygasoftMC, $tygasoftCommon, $tygasoftLogin, $tygasoftTaskCargo) {

    var ts = {};

    //ts.ItvFocus = null;
    ts.InitFocus = function ($scope) {
        //ts.ItvFocus = $interval(function () {
        //    if ($scope.ModelData.Barcode == '') $scope.ModelData.Isfocus = true;
        //    else $scope.ModelData.Isfocus = false;
        //}, 1000);
    };
    ts.StopFocus = function ($scope) {
        $scope.ModelData.Barcode == '';
        $interval.cancel($scope.ItvFocus);
    };

    ts.DoScan = function ($scope, isAuto) {
        try {
            var sBarcode = $scope.CargoInfo.Barcode;
            if (!sBarcode || sBarcode == '') {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_EmptyError, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            var sId = $scope.CargoInfo.Id;
            var sOtype = $scope.CargoInfo.BoxType;
            var sOdate = $scope.CargoInfo.Odate;
            var sToCID = $scope.CargoInfo.BoxDcid;
            var sToBno = $scope.CargoInfo.BoxDBno;
            if (!sOtype || sOtype.replace("请选择", "") == "") sOtype = "不存放";
            if (!sOdate || sOdate == "") sOdate = $tygasoftCommon.CurrentDate();
            if (!sToCID) sToCID = "";
            if (!sToBno) sToBno = "";
            var sParentId = $scope.TaskInfo.TBRno + '|' + $scope.TaskInfo.TBType;
            var sStatus = "待处理";
            if (sId && sId != '') sStatus = "待提交";
            else sId = "";
            var item = {Id:sId, Barcode: sBarcode, ParentId: sParentId, Status: sStatus, TypeName: $scope.TaskInfo.TypeName };
            item.ContentValue = "Status=" + sStatus + "|Otype=" + sOtype + "|Odate=" + sOdate + "|ToCID=" + sToCID + "|ToBno=" + sToBno + "";
            QdhtyyPlugin.InsertBarcode(JSON.stringify(item), function (result) {
                //alert('InsertBarcode--result--' + result);
                var jResult = JSON.parse(result);
                if (jResult.ResCode != 1000) {
                    var dlgShow = $ionicPopup.show({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg });
                    setTimeout(function () {
                        dlgShow.close();
                    }, 1000);
                    return false;
                }
                ts.GetBarcodeList($scope);
            })
        }
        finally {
            $scope.CargoInfo.Id = "";
            $scope.CargoInfo.BoxType = "不存放";
            $scope.CargoInfo.BoxDcid = "";
            $scope.ModelData.Barcode = "";
            $scope.CargoInfo.BoxDBno = "";
            //$scope.HasBarcode = false;
            $scope.ModelData.Isfocus = true;
            $tygasoftTaskCargo.CloseDlgTaskCargoInfo($scope);
        }
    };

    ts.GetBarcodeList = function ($scope) {
        var parentId = $scope.TaskInfo.TBRno + '|' + $scope.TaskInfo.TBType;
        var jsonField = '{"ParentId":"' + parentId + '","TypeName":"' + $scope.TaskInfo.TypeName + '"}';
        //QdhtyyPlugin.DeleteBarcode(jsonField, function (result) {
        //    alert('result--'+result);
        //});
        QdhtyyPlugin.GetBarcodeList(jsonField, function (result) {
            //alert('GetBarcodeList--result--' + result);
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

    ts.OnDeletedBarcode = function ($scope, item) {
        $ionicPopup.confirm({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.Confirm_Msg_Delete, cancelText: $tygasoftMC.MC.Btn_CancelText, okText: $tygasoftMC.MC.Btn_OkText }).then(function (res) {
            if (res) {
                var parentId = $scope.TaskInfo.TBRno + '|' + $scope.TaskInfo.TBType;
                var jsonField = '{"Barcode":"' + item.Barcode + '","ParentId":"' + parentId + '","TypeName":"' + $scope.TaskInfo.TypeName + '"}';
                QdhtyyPlugin.DeleteBarcode(jsonField, function (result) {
                    //alert('OnDeletedBarcode--result--' + result);
                    var jResult = JSON.parse(result);
                    if (jResult.ResCode != 1000) {
                        $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: jResult.Msg, okText: $tygasoftMC.MC.Btn_OkText });
                        return false;
                    }
                    ts.GetBarcodeList($scope);
                })
            }
        })
    };

    //ts.StartQueue = function ($scope) {
    //    $scope.HasBarcode = false;
    //    $scope.ItvQueue = $interval(function () {
    //        //alert('$scope.btnTabIndex--' + $scope.btnTabIndex);
    //        if ($scope.btnTabIndex != 1) {
    //            //alert('$scope.ModelData.Barcode--' + $scope.ModelData.Barcode);
    //            if (!$scope.HasBarcode) {
    //                $scope.HasBarcode = true;
    //                //TaynooScanPlugin.GetResult(function (result) {
    //                //    //alert('result--' + result);
    //                //    if (result != '') {
    //                //        $scope.ModelData.Barcode = result;
    //                //        $scope.CargoInfo.Barcode = result;
    //                //        ts.DoScan($scope, true);
    //                //        //$tygasoftTaskCargo.OnDlgTaskCargoInfo($scope);
    //                //    }
    //                //    else $scope.HasBarcode = false;
    //                //});
    //            }
    //        }
    //    }, 500);
    //};

    ts.Reset = function ($scope) {
        $interval.cancel($scope.ItvQueue);
        $scope.ItvQueue = null;
        $scope.ModelData.Barcode = '';
    };

    return ts;
});