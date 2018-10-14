using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDABOX
    {
        #region ITPDABOX Member

        int Insert(TPDABOXInfo model);

        int Update(TPDABOXInfo model);

        int Delete(string boxCID);

        bool DeleteBatch(IList<object> list);

        TPDABOXInfo GetModel(string boxCID);

        IList<TPDABOXInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDABOXInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDABOXInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDABOXInfo> GetList();

        #endregion
    }
}
