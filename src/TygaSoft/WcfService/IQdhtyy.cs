using System;
using System.ServiceModel;
using TygaSoft.WcfModel;

namespace TygaSoft.WcfService
{
    [ServiceContract(Namespace = "http://TygaSoft.Services.QdhtyyService")]
    public interface IQdhtyy
    {
        #region 推送管理

        [OperationContract(Name = "SendPush")]
        ResResultModel SendPush(PushFmModel model);

        #endregion

        #region 用户管理

        [OperationContract(Name = "GetCbgUsers")]
        ResResultModel GetCbgUsers();

        #endregion
    }
}
