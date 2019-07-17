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
    public partial class TPDATaskINQ
    {
        private static readonly ITPDATaskINQ dal = DataAccess.CreateTPDATaskINQ();

        #region TPDATaskINQ Member

        public int Insert(TPDATaskINQInfo model)
        {
            return dal.Insert(model);
        }

        public int Update(TPDATaskINQInfo model)
        {
            return dal.Update(model);
        }

        public int Delete(int tKIID)
        {
            return dal.Delete(tKIID);
        }

        public bool DeleteBatch(IList<object> list)
        {
            return dal.DeleteBatch(list);
        }

        public TPDATaskINQInfo GetModel(int tKIID)
        {
            return dal.GetModel(tKIID);
        }

        public IList<TPDATaskINQInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, out totalRecords, sqlWhere, cmdParms);
        }

        public IList<TPDATaskINQInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, sqlWhere, cmdParms);
        }

        public IList<TPDATaskINQInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(sqlWhere, cmdParms);
        }

        public IList<TPDATaskINQInfo> GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
