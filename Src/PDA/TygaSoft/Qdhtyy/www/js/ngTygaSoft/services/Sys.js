angular.module('ngTygaSoft.services.Sys', [])

.factory('$tygasoftSys', function ($http, $ionicLoading, $ionicPopup, $ionicModal, ionicDatePicker, $tygasoftLS, $tygasoftMC, $tygasoftCommon) {

    var ts = {};

    ts.Bind = function ($scope) {
        $scope.ModelData.NfcOnOff = parseInt($tygasoftLS.Get("NfcOnOff", "0")) == 1;
        $scope.ModelData.UhfOnOff = parseInt($tygasoftLS.Get("UhfOnOff", "0")) == 1;
        $scope.onNfcChange = function () {
            if ($scope.ModelData.NfcOnOff) ts.NfcOn();
            else ts.NfcOff();
        }
        $scope.onUhfChange = function () {
            $scope.ModelData.UhfOnOff ? ts.UhfOn() : ts.UhfOff();
        }
        $scope.onSave = function () {
            if (!$scope.ModelData.ServiceUrl || $scope.ModelData.ServiceUrl == '') {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_EmptyError, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            if (!$scope.ModelData.DeviceCode || $scope.ModelData.DeviceCode == '') {
                $ionicPopup.alert({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_EmptyError, okText: $tygasoftMC.MC.Btn_OkText });
                return false;
            }
            $ionicPopup.confirm({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_SaveConfirm, cancelText: $tygasoftMC.MC.Btn_CancelText, okText: $tygasoftMC.MC.Btn_OkText }).then(function (r) {
                if (r) {
                    $tygasoftLS.Set("DeviceCode", $scope.ModelData.DeviceCode);
                    $tygasoftLS.Set("ServiceUrl", $scope.ModelData.ServiceUrl);
                    var dlgShow = $ionicPopup.show({ title: $tygasoftMC.MC.Alert_Title, template: $tygasoftMC.MC.M_Waiting });
                    setTimeout(function () {
                        dlgShow.close();
                        window.location = '#/app/Home';
                    }, 1000);
                }
            })
        }
    };

    ts.NfcOn = function () {
        NfcPlugin.StartNfc(function (result) {
            $tygasoftLS.Set("NfcOnOff", 1);
        }, function (err) {
            $tygasoftLS.Set("NfcOnOff", 0);
        })
    };

    ts.NfcOff = function () {
        NfcPlugin.StopNfc(function () {
            $tygasoftLS.Set("NfcOnOff", 0);
        })
    };

    ts.UhfOn = function () {
        //RfidScan.onPause(0);
        //RfidScan.onScan();
        $tygasoftLS.Set("UhfOnOff", 1);
    };

    ts.UhfOff = function () {
        //RfidScan.onPause(1);
        $tygasoftLS.Set("UhfOnOff", 0);
    };

    return ts;
});