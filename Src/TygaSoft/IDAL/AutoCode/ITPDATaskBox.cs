using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDATaskBox
    {
        #region ITPDATaskBox Member

        int Insert(TPDATaskBoxInfo model);

        int Update(TPDATaskBoxInfo model);

        int Delete(string tBCID);

        bool DeleteBatch(IList<object> list);

        TPDATaskBoxInfo GetModel(string tBCID);

        IList<TPDATaskBoxInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskBoxInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskBoxInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskBoxInfo> GetList();

        #endregion
    }
}
