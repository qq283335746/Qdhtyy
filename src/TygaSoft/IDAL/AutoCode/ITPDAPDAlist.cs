using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDAPDAlist
    {
        #region ITPDAPDAlist Member

        int Insert(TPDAPDAlistInfo model);

        int Update(TPDAPDAlistInfo model);

        int Delete(string pID);

        bool DeleteBatch(IList<object> list);

        TPDAPDAlistInfo GetModel(string pID);

        IList<TPDAPDAlistInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDAPDAlistInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDAPDAlistInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms);

        IList<TPDAPDAlistInfo> GetList();

        #endregion
    }
}
