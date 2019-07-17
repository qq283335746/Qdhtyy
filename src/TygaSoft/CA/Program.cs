using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TygaSoft.JPush;

namespace TygaSoft.CA
{
    class Program
    {
        static void Main(string[] args)
        {
            //MobileClient client = new MobileClient();
            //var s = client.GetHelloWord();
            //var s = client.ValidateUser("admin", "ccecc123");

            //极光推送
            JPushHelper jpush = new JPushHelper();
            var pushOptionInfo = new JPushOptionInfo { Title="任务通知1",Content= "您好，任务通知1，请按时完成！",Alias= "01010101", PushPayloadType = EnumPushPayloadType.Alias };
            var isOk = jpush.SendPush(pushOptionInfo);
        }
    }
}
