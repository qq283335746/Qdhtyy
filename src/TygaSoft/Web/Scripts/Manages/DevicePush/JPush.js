var JPush = {
    Init:function(){
        
    },
    OnToUsersSelected:function(t){
        var $this = $(t);
        if ($this.val() == 1) {
            $('#cbgUsersBox').show();
            JPush.CbgUsers("cbgUsers", true, null);
        }
        else $('#cbgUsersBox').hide();
    },
    SendPush: function () {
        var isValid = $('#form1').form('validate');
        if (!isValid) return false;
        var sTitle = $.trim($('#txtTitle').val());
        var sContent = $.trim($('#txtContent').val());
        var toUserType = $('[name$=ToUsers]:checked').val();
        var sToUser = toUserType == 1 ? $('#cbgUsers').combogrid('getValues') : "";
        $.messager.confirm('提示', '确定要将消息推送出去吗？', function (r) {
            if (r) {
                var postData = '{"model":{"Title": "' + sTitle + '","Content": "' + sContent + '","Alias": "' + sToUser + '"}}';
                var url = Common.AppName + "/Services/QdhtyyService.svc/SendPush";
                Common.Ajax(url, postData, "POST", "", true, true, function (result) {
                    jeasyuiFun.show("提示", "发送成功！");
                });
            }
        });
    },
    CbgUsers: function (cbgId, isLoad, values) {
        var cbg = $('#' + cbgId + '');
        if (!isLoad) {
            cbg.combogrid({
                readonly: true
            });
            if (values) cbg.combogrid('setValue', values);
        }
        else {
            var url = Common.AppName + "/Services/QdhtyyService.svc/GetCbgUsers";
            Common.Ajax(url, {}, 'GET', '', true, true, function (result) {
                cbg.combogrid({
                    panelWidth: 300,
                    fitColumns: true,
                    columns: [[
                        { field: '', checkbox:true },
                        { field: 'Key', title: '账号', width: 200 }
                    ]],
                    data: JSON.parse(result.Data),
                    onLoadSuccess: function (data) {
                        if (values) cbg.combogrid('setValue', values);
                    }
                });
            });
        }
    }
}