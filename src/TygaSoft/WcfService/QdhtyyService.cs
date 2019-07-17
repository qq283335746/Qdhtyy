using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TygaSoft.SysException;
using TygaSoft.SysHelper;
using TygaSoft.DBUtility;
using TygaSoft.Model;
using TygaSoft.WcfModel;
using TygaSoft.BLL;
using TygaSoft.WebHelper;
using TygaSoft.JPush;

namespace TygaSoft.WcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class QdhtyyService: IQdhtyy
    {
        #region 推送管理

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public ResResultModel SendPush(PushFmModel model)
        {
            try
            {
                JPushHelper jpush = new JPushHelper();
                JPushOptionInfo pushOptionInfo = null;
                if (!string.IsNullOrWhiteSpace(model.Alias)) pushOptionInfo = new JPushOptionInfo { Title = model.Title, Content = model.Content, Alias= model.Alias, PushPayloadType = EnumPushPayloadType.Alias };
                else pushOptionInfo = new JPushOptionInfo { Title = model.Title, Content = model.Content, PushPayloadType = EnumPushPayloadType.All };
                var isOk = jpush.SendPush(pushOptionInfo);
                if (!isOk) return ResResult.Response(false, MC.M_Save_Error, "");

                return ResResult.Response(true, "", "");
            }
            catch (Exception ex)
            {
                return ResResult.Response(false, ex.Message, "");
            }
        }

        #endregion

        #region 用户管理

        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public ResResultModel GetCbgUsers()
        {
            try
            {
                var cbgData = new List<KeyValueInfo>();

                var bll = new TPDAUser();
                int totalRecord = 0;

                var list = bll.GetList();
                totalRecord = list.Count;

                foreach(var item in list)
                {
                    cbgData.Add(new KeyValueInfo(item.UID, item.Uname));
                }

                return ResResult.Response(true, "", "{\"total\":" + totalRecord + ",\"rows\":" + JsonConvert.SerializeObject(cbgData) + "}");
            }
            catch (Exception ex)
            {
                return ResResult.Response(false, ex.Message, "");
            }
        }

        #endregion
    }
}
