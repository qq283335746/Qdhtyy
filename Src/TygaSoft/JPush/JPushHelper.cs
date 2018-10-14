using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using TygaSoft.SysException;
using cn.jpush.api;
using cn.jpush.api.push.mode;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;

namespace TygaSoft.JPush
{
    public class JPushHelper
    {
        static string[] appKeySecret = ConfigurationManager.AppSettings["JPushKey"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        string appKey = appKeySecret[0];
        string masterSecret = appKeySecret[1];

        public bool SendPush(JPushOptionInfo optionInfo)
        {
            PushPayload pushOption = null;
            switch (optionInfo.PushPayloadType)
            {
                case EnumPushPayloadType.All:
                    pushOption = PushToAll(optionInfo.Title, optionInfo.Content);
                    break;
                case EnumPushPayloadType.Alias:
                    pushOption = PushToAllAlias(optionInfo.Title, optionInfo.Content, optionInfo.Alias.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                    break;
                default:
                    break;
            }
            return SendPush(pushOption);
        }

        private bool SendPush(PushPayload pushOption)
        {
            try
            {
                JPushClient client = new JPushClient(appKey, masterSecret);
                var result = client.SendPush(pushOption);
                if (result.ResponseResult.responseCode != System.Net.HttpStatusCode.OK) throw new ArgumentException(result.ResponseResult.exceptionString);

                return result.ResponseResult.responseCode == System.Net.HttpStatusCode.OK;
            }
            catch (APIRequestException ex)
            {
                new CustomException(string.Format("JPushHelper--SendPush--APIRequestException--Message：{0}，ErrorMessage：{1}，ErrorCode：{2}，", ex.Message,ex.ErrorMessage,ex.ErrorCode));
            }
            catch (APIConnectionException ex)
            {
                new CustomException(string.Format("JPushHelper--SendPush--APIConnectionException--Message：{0}", ex.Message));
            }
            catch(Exception ex)
            {
                new CustomException("JPushHelper--SendPush--Exception--", ex);
            }

            return false;
        }

        public PushPayload PushToAll(string title,string content)
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.all();
            pushPayload.audience = Audience.all();
            pushPayload.notification = Notification.android(content, title);

            return pushPayload;
        }

        public static PushPayload PushToAllAlias(string title, string content,string[] alias)
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.android();
            pushPayload.audience = Audience.s_alias(alias);
            pushPayload.notification = Notification.android(content, title);

            return pushPayload;
        }
    }
}
