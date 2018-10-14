var Customer = {
    Init: function () {
        this.InitEvent();
        this.InitData();
    },
    InitEvent: function () {

    },
    InitData: function () {
        this.Load(1, 10);
        var pager = $("#dg").datagrid('getPager');
        pager.pagination({
            onSelectPage: function (pageNumber, pageSize) {
                Customer.Load(pageNumber, pageSize);
            }
        });
    },
    SelectRow: null,
    Load: function (pageIndex, pageSize) {
        var keyword = $("#txtKeyword").textbox('getValue');
        var postData = '{"model":{"PageIndex": "' + pageIndex + '", "PageSize": "' + pageSize + '", "Keyword": "' + keyword + '"}}';
        var url = Common.AppName + '/Services/QdhtyyService.svc/GetCustomerList';
        Common.Ajax(url, postData, 'POST', '', true, true, function (result) {
            console.log('GetCustomerList--result--' + JSON.stringify(result));
            $("#dg").datagrid('loadData', JSON.parse(result.Data));
        });
    },
    OnSearch: function () {
        Customer.Load(1, 10);
    },
    Add: function () {
        Customer.SelectRow = null;
        if ($("body").find("#dlgAddCustomer").length == 0) {
            $("body").append("<div id=\"dlgAddCustomer\" style=\"padding:10px;\"></div>");
        }
        var s = '';
        var wh = Common.GetWh(780, 500);
        $("#dlgAddCustomer").dialog({
            title: '填写信息',
            width: wh[0],
            height: wh[1],
            closed: false,
            modal: true,
            iconCls: 'icon-add',
            buttons: [{
                id: 'btnSave', text: '保存', iconCls: 'icon-save', handler: function () {
                    AddCustomer.OnSave();
                }
            }, {
                id: 'btnCancelSave', text: '取消', iconCls: 'icon-cancel', handler: function () {
                    $('#dlgAddCustomer').dialog('close');
                }
            }],
            content: s
        })
        return false;
    },
    Edit: function () {
        var rows = $("#dg").datagrid('getSelections');
        if (!rows || rows.length != 1) {
            $.messager.alert('错误提示', "请选择一行且仅一行数据进行操作", 'error');
            return false;
        }
        Customer.SelectRow = rows[0];
        if ($("body").find("#dlgAddCustomer").length == 0) {
            $("body").append("<div id=\"dlgAddCustomer\" style=\"padding:10px;\"></div>");
        }
        var s = '';
        var wh = Common.GetWh(780, 500);
        $("#dlgAddCustomer").dialog({
            title: '编辑信息',
            width: wh[0],
            height: wh[1],
            closed: false,
            modal: true,
            iconCls: 'icon-add',
            buttons: [{
                id: 'btnSave', text: '保存', iconCls: 'icon-save', handler: function () {
                    AddCustomer.OnSave();
                }
            }, {
                id: 'btnCancelSave', text: '取消', iconCls: 'icon-cancel', handler: function () {
                    $('#dlgAddCustomer').dialog('close');
                }
            }],
            content: s
        })
        return false;
    },
    Del: function () {
        var rows = $("#dg").datagrid('getSelections');
        if (!rows || rows.length < 1) {
            $.messager.alert('错误提示', "请选择一行且仅一行数据进行操作", 'error');
            return false;
        }
        var itemAppend = "";
        for (var i = 0; i < rows.length; i++) {
            if (i > 0) itemAppend += ",";
            itemAppend += rows[i].Id;
        }
        $.messager.confirm('温馨提醒', '确定要删除吗？', function (r) {
            if (r) {
                var postData = { "ReqName": "DeleteCustomer", "ItemAppend": "" + itemAppend + "" };
                Common.AjaxPost("/ccecc/h/content.html", postData, function (result) {
                    jeasyuiFun.show("温馨提示", "保存成功！");
                    setTimeout(function () {
                        Customer.Load(1, 10);
                    }, 700);
                });
            }
        });
    },
    Save: function () {
        var isValid = $('#dlgFm').form('validate');
        if (!isValid) return false;
        var coded = $.trim($("#txtCoded").val());
        var named = $.trim($("#txtNamed").val());
        var shortName = $.trim($("#txtShortName").val());
        var contactMan = $.trim($("#txtContactMan").val());
        var contactPhone = $.trim($("#txtContactPhone").val());
        var telPhone = $.trim($("#txtTelPhone").val());
        var fax = $.trim($("#txtFax").val());
        var postCode = $.trim($("#txtPostCode").val());
        var address = $.trim($("#txtAddress").val());
        var cityName = $.trim($("#txtCityName").val());
        var tradeName = $.trim($("#txtTradeName").val());
        var cooperateTime = $.trim($("#txtCooperateTime").val());
        var payWay = $.trim($("#txtPayWay").val());
        var staffCode = $.trim($("#txtStaffCode").val());
        var remark = $.trim($("#txtRemark").val());
        var recordDate = $.trim($("#txtRecordDate").val());

        var postData = { "ReqName": "SaveCustomer", "Coded": "" + coded + "", "Named": "" + named + "", "ShortName": "" + shortName + "", "ContactMan": "" + contactMan + "", "ContactPhone": "" + contactPhone + "", "TelPhone": "" + telPhone + "", "Fax": "" + fax + "", "PostCode": "" + postCode + "", "Address": "" + address + "", "CityName": "" + cityName + "", "TradeName": "" + tradeName + "", "CooperateTime": "" + cooperateTime + "", "PayWay": "" + payWay + "", "StaffCode": "" + staffCode + "", "Remark": "" + remark + "", "RecordDate": "" + recordDate + "" };
        Common.AjaxPost("/ccecc/h/content.html", postData, function (result) {
            $("#dlgAddCustomer").dialog('close');
            jeasyuiFun.show("温馨提示", "保存成功！");
            setTimeout(function () {
                Customer.Load(1, 10);
            }, 700);
        })
    }
}