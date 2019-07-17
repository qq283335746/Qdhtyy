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
    public partial class TPDATaskBank
    {
        private static readonly ITPDATaskBank dal = DataAccess.CreateTPDATaskBank();

        #region TPDATaskBank Member

        public int Insert(TPDATaskBankInfo model)
        {
            return dal.Insert(model);
        }

        public int Update(TPDATaskBankInfo model)
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

        public TPDATaskBankInfo GetModel(string tBcid)
        {
            return dal.GetModel(tBcid);
        }

        public IList<TPDATaskBankInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, out totalRecords, sqlWhere, cmdParms);
        }

        public IList<TPDATaskBankInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, sqlWhere, cmdParms);
        }

        public IList<TPDATaskBankInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(sqlWhere, cmdParms);
        }

        public IList<TPDATaskBankInfo> GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
