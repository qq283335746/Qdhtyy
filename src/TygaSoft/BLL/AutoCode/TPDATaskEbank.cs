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
    public partial class TPDATaskEbank
    {
        private static readonly ITPDATaskEbank dal = DataAccess.CreateTPDATaskEbank();

        #region TPDATaskEbank Member

        public int Insert(TPDATaskEbankInfo model)
        {
            return dal.Insert(model);
        }

        public int Update(TPDATaskEbankInfo model)
        {
            return dal.Update(model);
        }

        public int Delete(string tBcid)
        {
            return dal.Delete(tBcid);
        }

        public bool DeleteBatch(IList<object> list)
        {
            return dal.DeleteBatch(list);
        }

        public TPDATaskEbankInfo GetModel(string tBcid)
        {
            return dal.GetModel(tBcid);
        }

        public IList<TPDATaskEbankInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, out totalRecords, sqlWhere, cmdParms);
        }

        public IList<TPDATaskEbankInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, sqlWhere, cmdParms);
        }

        public IList<TPDATaskEbankInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(sqlWhere, cmdParms);
        }

        public IList<TPDATaskEbankInfo> GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
