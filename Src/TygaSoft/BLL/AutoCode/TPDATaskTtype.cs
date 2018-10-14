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
    public partial class TPDATaskTtype
    {
        private static readonly ITPDATaskTtype dal = DataAccess.CreateTPDATaskTtype();

        #region TPDATaskTtype Member

        public int Insert(TPDATaskTtypeInfo model)
        {
            return dal.Insert(model);
        }

        public int Update(TPDATaskTtypeInfo model)
        {
            return dal.Update(model);
        }

        public int Delete(string tID)
        {
            return dal.Delete(tID);
        }

        public bool DeleteBatch(IList<object> list)
        {
            return dal.DeleteBatch(list);
        }

        public TPDATaskTtypeInfo GetModel(string tID)
        {
            return dal.GetModel(tID);
        }

        public IList<TPDATaskTtypeInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, out totalRecords, sqlWhere, cmdParms);
        }

        public IList<TPDATaskTtypeInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, sqlWhere, cmdParms);
        }

        public IList<TPDATaskTtypeInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(sqlWhere, cmdParms);
        }

        public IList<TPDATaskTtypeInfo> GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
