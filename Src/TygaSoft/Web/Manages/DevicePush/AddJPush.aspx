<%@ Page Title="消息推送" Language="C#" MasterPageFile="~/Masters/Manages.Master" AutoEventWireup="true" CodeBehind="AddJPush.aspx.cs" Inherits="TygaSoft.Web.Manages.DevicePush.AddJPush" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="row mt10">
        <span class="rl w100">标题：</span>
        <div class="fl">
            <input type="text" id="txtTitle" class="easyui-validatebox txt w452" data-options="required:true" />
        </div>
    </div>
    <div class="row mt10">
        <span class="rl w100">推送用户：</span>
        <div class="fl">
            <label><input type="radio" checked="checked" name="ToUsers" value="0" onclick="JPush.OnToUsersSelected(this)" />全部</label>
            <label class="ml10"><input type="radio" name="ToUsers" value="1" onclick="JPush.OnToUsersSelected(this)" />选择</label>
        </div>
        <div id="cbgUsersBox" class="fl ml10" style="display:none;">
            <input id="cbgUsers" data-options="mode:'remote',idField:'Key',textField:'Key',editable:true,multiple:true" style="width:342px;" />
        </div>
    </div>
    <div class="row mt10">
        <span class="rl w100">消息内容：</span>
        <div class="fl">
            <textarea rows="3" cols="80" id="txtContent" class="easyui-validatebox" data-options="required:true"></textarea>
        </div>
    </div>
    <div class="row mt10">
        <div class="fl" style="padding-left:100px;">
            <a class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="JPush.SendPush()">发送</a>
        </div>
    </div>
    <script type="text/javascript" src="/qdhtyy/Scripts/Manages/DevicePush/JPush.js"></script>

</asp:Content>
