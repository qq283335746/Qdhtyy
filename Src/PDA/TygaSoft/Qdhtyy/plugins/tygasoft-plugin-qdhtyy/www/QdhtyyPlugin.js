var exec = require('cordova/exec');

exports.GetHelloWord = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetHelloWord", [arg0]);
};

exports.ValidateUser = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "ValidateUser", [arg0]);
};

exports.GetAuthInfo = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetAuthInfo", [arg0]);
};

exports.GetTaskList = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetTaskList", [arg0]);
};

exports.GetBoxList = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetBoxList", [arg0]);
};

exports.GetFeeQ = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetFeeQ", [arg0]);
};

exports.GetInQTask = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetInQTask", [arg0]);
};

exports.GetEtask = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetEtask", [arg0]);
};

exports.GetEmpTlist = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetEmpTlist", [arg0]);
};

exports.SaveTaskInfo = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "SaveTaskInfo", [arg0]);
};

exports.SaveBoxInfo = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "SaveBoxInfo", [arg0]);
};

exports.SaveBatchTaskCargo = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "SaveBatchTaskCargo", [arg0]);
};

exports.SaveTaskCargoInfo = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "SaveTaskCargoInfo", [arg0]);
};

exports.SaveApplyTaskInfo = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "SaveApplyTaskInfo", [arg0]);
};

exports.SaveETask = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "SaveETask", [arg0]);
};

exports.GetBarcodeList = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetBarcodeList", [arg0]);
};

exports.GetBarcodeInfo = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetBarcodeInfo", [arg0]);
};

exports.InsertBarcode = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "InsertBarcode", [arg0]);
};

exports.DeleteBarcode = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "DeleteBarcode", [arg0]);
};

exports.GetKeyValue = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "GetKeyValue", [arg0]);
};

exports.InsertKeyValue = function (arg0, success, error) {
    exec(success, error, "QdhtyyPlugin", "InsertKeyValue", [arg0]);
};
