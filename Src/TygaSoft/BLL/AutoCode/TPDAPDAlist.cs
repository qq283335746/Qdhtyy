using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.IDAL;
using TygaSoft.Model;
using TygaSoft.DALFactory;

namespace TygaSoft.BLL
{
    public partial class TPDAPDAlist
    {
        private static readonly ITPDAPDAlist dal = DataAccess.CreateTPDAPDAlist();

        #region TPDAPDAlist Member

        public int Insert(TPDAPDAlistInfo model)
        {
            return dal.Insert(model);
        }

        public int Update(TPDAPDAlistInfo model)
        {
            return dal.Update(model);
        }

        public int Delete(string pID)
        {
            return dal.Delete(pID);
        }

        public bool DeleteBatch(IList<object> list)
        {
            return dal.DeleteBatch(list);
        }

        public TPDAPDAlistInfo GetModel(string pID)
        {
            return dal.GetModel(pID);
        }

        public IList<TPDAPDAlistInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, out totalRecords, sqlWhere, cmdParms);
        }

        public IList<TPDAPDAlistInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, sqlWhere, cmdParms);
        }

        public IList<TPDAPDAlistInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(sqlWhere, cmdParms);
        }

        public IList<TPDAPDAlistInfo> GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
