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
    public partial class TPDAUser
    {
        private static readonly ITPDAUser dal = DataAccess.CreateTPDAUser();

        #region TPDAUser Member

        public int Insert(TPDAUserInfo model)
        {
            return dal.Insert(model);
        }

        public int Update(TPDAUserInfo model)
        {
            return dal.Update(model);
        }

        public int Delete(string uID)
        {
            return dal.Delete(uID);
        }

        public bool DeleteBatch(IList<object> list)
        {
            return dal.DeleteBatch(list);
        }

        public TPDAUserInfo GetModel(string uID)
        {
            return dal.GetModel(uID);
        }

        public IList<TPDAUserInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, out totalRecords, sqlWhere, cmdParms);
        }

        public IList<TPDAUserInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, sqlWhere, cmdParms);
        }

        public IList<TPDAUserInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(sqlWhere, cmdParms);
        }

        public IList<TPDAUserInfo> GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
