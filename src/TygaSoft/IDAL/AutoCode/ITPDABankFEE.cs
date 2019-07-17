using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDABankFEE
    {
        #region ITPDABankFEE Member

        int Insert(TPDABankFEEInfo model);

        int Update(TPDABankFEEInfo model);

        int Delete(string tBcid);

        bool DeleteBatch(IList<object> list);

        TPDABankFEEInfo GetModel(string tBcid);

        IList<TPDABankFEEInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDABankFEEInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDABankFEEInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDABankFEEInfo> GetList();

        #endregion
    }
}
