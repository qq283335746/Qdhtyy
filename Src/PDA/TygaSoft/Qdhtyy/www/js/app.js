
angular.module('starter', ['ionic', 'starter.controllers', 'ionic-datepicker', 'ionic-timepicker', 'ngCordova', 'ngDialog', 'ngTygaSoft'])
.run(function ($ionicPlatform, $ionicHistory, $rootScope, $state, $cordovaToast, $cordovaDevice, $tygasoftLS, $tygasoftMC, $tygasoftLogin, $tygasoftJPush) {
    $ionicPlatform.ready(function () {
        if (cordova.platformId === 'ios' && window.cordova && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
            cordova.plugins.Keyboard.disableScroll(true);

        }
        if (window.StatusBar) {
            StatusBar.styleDefault();
        }

        $ionicPlatform.registerBackButtonAction(function (e) {
            if ($ionicHistory.backView()) {
                $ionicHistory.goBack();
            }
            else {
                if ($rootScope.backButtonPressedOnceToExit) {
                    //ionic.Platform.exitApp();
                    $tygasoftLS.Set('LoginId', '');
                    NfcPlugin.StopNfc(function () {
                        $tygasoftLS.Set("NfcOnOff", 0);
                    });
                    ionic.Platform.exitApp();
                } else {
                    $rootScope.backButtonPressedOnceToExit = true;
                    $cordovaToast.showShortCenter($tygasoftMC.MC.M_ExitApp);
                    setTimeout(function () {
                        $rootScope.backButtonPressedOnceToExit = false;
                    }, 2000);
                }
            }
            e.preventDefault();
            return false;
        }, 101);

        $tygasoftJPush.init();

        //var jDevice = { "Platform": "" + $cordovaDevice.getPlatform() + "", "UUID": "" + $cordovaDevice.getUUID() + "", "Version": "" + $cordovaDevice.getVersion() + "", "Latlng": "" };
        $tygasoftLS.Set("DeviceId", $cordovaDevice.getUUID());

        $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams, options) {
            var loginInfo = $tygasoftLogin.GetLoginInfo();
            var hasLogin = loginInfo.LoginId != '';
            if (!hasLogin) {
                if (toState.name == 'app.Login' || toState.name == 'app.SysSet') {
                    $ionicHistory.nextViewOptions({ disableAnimate: true, disableBack: true, historyRoot: false });
                }
                else {
                    if (loginInfo.DeviceCode == '') $state.go('app.SysSet');
                    else $state.go('app.Login');
                    event.preventDefault();
                }
            }
        });

        NfcPlugin.StartNfc();
        $tygasoftLS.Set("NfcOnOff", 1);
        $tygasoftLS.Set("ServiceUrl", "http://120.26.198.137/qdhtyy");
    });
})

.config(function ($stateProvider, $urlRouterProvider, $ionicConfigProvider, ionicDatePickerProvider, ionicTimePickerProvider) {
    $ionicConfigProvider.navBar.alignTitle('center');
    $ionicConfigProvider.scrolling.jsScrolling(true);
    ionicDatePickerProvider.configDatePicker({
        inputDate: new Date(),
        setLabel: '确定',
        todayLabel: '今天',
        closeLabel: '关闭',
        mondayFirst: false,
        weeksList: ["日", "一", "二", "三", "四", "五", "六"],
        monthsList: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
        templateType: 'popup',
        showTodayButton: true,
        dateFormat: 'yyyy年MM月dd日',
        closeOnSelect: false,
        disableWeekdays: [6],
    });
    ionicTimePickerProvider.configTimePicker({
        inputTime: (((new Date()).getHours() * 60 * 60) + ((new Date()).getMinutes() * 60)),
        format: 24,
        step: 1,
        setLabel: '确定',
        closeLabel: '关闭'
    });
    $stateProvider

    .state('app', {
        url: '/app',
        abstract: true,
        templateUrl: 'templates/Menu.html',
        controller: 'MenuCtrl'
    })
    .state('app.Home', {
        url: '/Home',
        views: {
            'menuContent': {
                templateUrl: 'templates/Home.html',
                controller: 'AppCtrl'
            }
        }
    })
    .state('app.SysSet', {
        url: '/SysSet',
        views: {
            'menuContent': {
                templateUrl: 'templates/SysSet.html',
                controller: 'SysCtrl'
            }
        }
    })
    .state('app.JPushDetail', {
        url: '/JPushDetail/:item',
        views: {
            'menuContent': {
                templateUrl: 'templates/JPushDetail.html',
                controller: 'JPushDetailCtrl'
            }
        }
    })
    .state('app.Login', {
        url: '/Login',
        views: {
            'menuContent': {
                templateUrl: 'templates/Login.html',
                controller: 'LoginCtrl'
            }
        }
    })
    .state('app.NfcAuth', {
        url: '/NfcAuth',
        views: {
            'menuContent': {
                templateUrl: 'templates/NfcAuth.html',
                controller: 'NfcAuthCtrl'
            }
        }
    })
    .state('app.Tasks', {
        url: '/Tasks',
        views: {
            'menuContent': {
                templateUrl: 'templates/Tasks.html',
                controller: 'TasksCtrl'
            }
        }
    })
    .state('app.TaskCargo', {
        url: '/TaskCargo/:item',
        views: {
            'menuContent': {
                templateUrl: 'templates/TaskCargo.html',
                controller: 'TaskCargoCtrl'
            }
        }
    })
    .state('app.Barcode', {
        url: '/Barcode/:item',
        views: {
            'menuContent': {
                templateUrl: 'templates/Barcode.html',
                controller: 'BarcodeCtrl'
            }
        }
    })
    .state('app.Boxs', {
        url: '/Boxs',
        views: {
            'menuContent': {
                templateUrl: 'templates/Boxs.html',
                controller: 'BoxsCtrl'
            }
        }
    })
    .state('app.AddTask', {
        url: '/AddTask',
        views: {
            'menuContent': {
                templateUrl: 'templates/AddTask.html',
                controller: 'AddTaskCtrl'
            }
        }
    })
    .state('app.Charges', {
        url: '/Charges',
        views: {
            'menuContent': {
                templateUrl: 'templates/Charges.html',
                controller: 'ChargesCtrl'
            }
        }
    })
    .state('app.ETasks', {
        url: '/ETasks',
        views: {
            'menuContent': {
                templateUrl: 'templates/ListETask.html',
                controller: 'ETasksCtrl'
            }
        }
    })
    .state('app.Workloads', {
        url: '/Workloads',
        views: {
            'menuContent': {
                templateUrl: 'templates/ListWorkload.html',
                controller: 'WorkloadsCtrl'
            }
        }
    })

    $urlRouterProvider.otherwise('/app/Home');
});
