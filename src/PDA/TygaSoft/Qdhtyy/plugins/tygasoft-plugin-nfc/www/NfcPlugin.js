var exec = require('cordova/exec');

exports.GetHelloWord = function (arg0, success, error) {
    exec(success, error, "NfcPlugin", "GetHelloWord", [arg0]);
};

exports.StartNfc = function(success, error) {
    exec(success, error, "NfcPlugin", "StartNfc", []);
};

exports.StopNfc = function(success, error) {
    exec(success, error, "NfcPlugin", "StopNfc", []);
};

exports.GetResult = function(success, error) {
    exec(success, error, "NfcPlugin", "GetResult", []);
};