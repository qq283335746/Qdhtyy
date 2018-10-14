using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDAUser
    {
        #region ITPDAUser Member

        int Insert(TPDAUserInfo model);

        int Update(TPDAUserInfo model);

        int Delete(string uID);

        bool DeleteBatch(IList<object> list);

        TPDAUserInfo GetModel(string uID);

        IList<TPDAUserInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDAUserInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDAUserInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDAUserInfo> GetList();

        #endregion
    }
}
