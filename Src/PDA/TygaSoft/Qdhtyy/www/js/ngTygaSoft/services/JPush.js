angular.module('ngTygaSoft.services.JPush', [])

.factory('$tygasoftJPush', function ($state,$http, $ionicLoading, $ionicPopup, $ionicModal) {

    var ts = {};

    //启动极光推送
    var _init = function () {
        plugins.jPushPlugin.init();
        //document.addEventListener('jpush.setTagsWithAlias', setTagsWithAliasCallback, false);
        plugins.jPushPlugin.openNotificationInAndroidCallback = openNotificationInAndroidCallback;
        plugins.jPushPlugin.receiveNotificationInAndroidCallback = receiveNotificationInAndroidCallback;
        plugins.jPushPlugin.setDebugMode(true);
    }

    //设置tag和Alias触发事件处理
    var setTagsWithAliasCallback = function (event) {
        alert('result code:' + event.resultCode + ' tags:' + event.tags + ' alias:' + event.alias);
    }

    //打开推送消息事件处理
    var openNotificationInAndroidCallback = function (data) {
        if (typeof data == 'string') {
            data = JSON.parse(data);
        }
        var jparms = { Title: data.title, Content: data.alert };
        $state.go('app.JPushDetail', { item: JSON.stringify(jparms) });
    }

    //接收推送消息事件处理
    var receiveNotificationInAndroidCallback = function (data) {
        if (typeof data == 'string') {
            data = JSON.parse(data);
        }
        //alert('receiveNotificationInAndroidCallback--' + JSON.stringify(data));
    }

    //获取状态
    var _isPushStopped = function (fun) {
        plugins.jPushPlugin.isPushStopped(fun)
    }

    //停止极光推送
    var _stopPush = function () {
        plugins.jPushPlugin.stopPush();
    }

    //重启极光推送
    var _resumePush = function () {
        plugins.jPushPlugin.resumePush();
    }

    //设置标签和别名
    var _setTagsWithAlias = function (tags, alias) {
        plugins.jPushPlugin.setTagsWithAlias(tags, alias);
    }

    //设置标签
    var _setTags = function (tags) {
        plugins.jPushPlugin.setTags(tags);
    }

    //设置别名
    var _setAlias = function (alias) {
        plugins.jPushPlugin.setAlias(alias);
    }

    ts.init = _init;
    ts.isPushStopped = _isPushStopped;
    ts.stopPush = _stopPush;
    ts.resumePush = _resumePush;

    ts.setTagsWithAlias = _setTagsWithAlias;
    ts.setTags = _setTags;
    ts.setAlias = _setAlias;

    return ts;
});