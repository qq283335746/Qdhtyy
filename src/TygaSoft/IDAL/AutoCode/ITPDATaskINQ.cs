using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDATaskINQ
    {
        #region ITPDATaskINQ Member

        int Insert(TPDATaskINQInfo model);

        int Update(TPDATaskINQInfo model);

        int Delete(int tKIID);

        bool DeleteBatch(IList<object> list);

        TPDATaskINQInfo GetModel(int tKIID);

        IList<TPDATaskINQInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskINQInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskINQInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskINQInfo> GetList();

        #endregion
    }
}
