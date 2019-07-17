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
    public partial class TPDABankFEE
    {
        private static readonly ITPDABankFEE dal = DataAccess.CreateTPDABankFEE();

        #region TPDABankFEE Member

        public int Insert(TPDABankFEEInfo model)
        {
            return dal.Insert(model);
        }

        public int Update(TPDABankFEEInfo model)
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

        public TPDABankFEEInfo GetModel(string tBcid)
        {
            return dal.GetModel(tBcid);
        }

        public IList<TPDABankFEEInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, out totalRecords, sqlWhere, cmdParms);
        }

        public IList<TPDABankFEEInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, sqlWhere, cmdParms);
        }

        public IList<TPDABankFEEInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(sqlWhere, cmdParms);
        }

        public IList<TPDABankFEEInfo> GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
