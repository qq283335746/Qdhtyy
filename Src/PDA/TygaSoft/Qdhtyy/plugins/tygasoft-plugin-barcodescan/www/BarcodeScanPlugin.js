var exec = require('cordova/exec');

exports.GetHelloWord = function (arg0, success, error) {
    exec(success, error, "BarcodeScanPlugin", "GetHelloWord", [arg0]);
};

exports.Init = function(success, error) {
    exec(success, error, "BarcodeScanPlugin", "Init", []);
};

exports.Close = function(success, error) {
    exec(success, error, "BarcodeScanPlugin", "Close", []);
};

exports.GetResult = function(success, error) {
    exec(success, error, "BarcodeScanPlugin", "GetResult", []);
};