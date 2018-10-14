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
    public partial class TPDATaskBox
    {
        private static readonly ITPDATaskBox dal = DataAccess.CreateTPDATaskBox();

        #region TPDATaskBox Member

        public int Insert(TPDATaskBoxInfo model)
        {
            return dal.Insert(model);
        }

        public int Update(TPDATaskBoxInfo model)
        {
            return dal.Update(model);
        }

        public int Delete(string tBCID)
        {
            return dal.Delete(tBCID);
        }

        public bool DeleteBatch(IList<object> list)
        {
            return dal.DeleteBatch(list);
        }

        public TPDATaskBoxInfo GetModel(string tBCID)
        {
            return dal.GetModel(tBCID);
        }

        public IList<TPDATaskBoxInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, out totalRecords, sqlWhere, cmdParms);
        }

        public IList<TPDATaskBoxInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, sqlWhere, cmdParms);
        }

        public IList<TPDATaskBoxInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(sqlWhere, cmdParms);
        }

        public IList<TPDATaskBoxInfo> GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
