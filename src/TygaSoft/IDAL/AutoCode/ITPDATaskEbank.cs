using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDATaskEbank
    {
        #region ITPDATaskEbank Member

        int Insert(TPDATaskEbankInfo model);

        int Update(TPDATaskEbankInfo model);

        int Delete(string tBcid);

        bool DeleteBatch(IList<object> list);

        TPDATaskEbankInfo GetModel(string tBcid);

        IList<TPDATaskEbankInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskEbankInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskEbankInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskEbankInfo> GetList();

        #endregion
    }
}
