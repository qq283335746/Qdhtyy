using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDATaskBank
    {
        #region ITPDATaskBank Member

        int Insert(TPDATaskBankInfo model);

        int Update(TPDATaskBankInfo model);

        int Delete(string tBcid);

        bool DeleteBatch(IList<object> list);

        TPDATaskBankInfo GetModel(string tBcid);

        IList<TPDATaskBankInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskBankInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskBankInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskBankInfo> GetList();

        #endregion
    }
}
