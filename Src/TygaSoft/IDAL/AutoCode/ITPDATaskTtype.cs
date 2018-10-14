using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDATaskTtype
    {
        #region ITPDATaskTtype Member

        int Insert(TPDATaskTtypeInfo model);

        int Update(TPDATaskTtypeInfo model);

        int Delete(string tID);

        bool DeleteBatch(IList<object> list);

        TPDATaskTtypeInfo GetModel(string tID);

        IList<TPDATaskTtypeInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskTtypeInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskTtypeInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDATaskTtypeInfo> GetList();

        #endregion
    }
}
