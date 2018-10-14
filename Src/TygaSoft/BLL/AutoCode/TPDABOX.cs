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
    public partial class TPDABOX
    {
        private static readonly ITPDABOX dal = DataAccess.CreateTPDABOX();

        #region TPDABOX Member

        public int Insert(TPDABOXInfo model)
        {
            return dal.Insert(model);
        }

        public int Update(TPDABOXInfo model)
        {
            return dal.Update(model);
        }

        public int Delete(string boxCID)
        {
            return dal.Delete(boxCID);
        }

        public bool DeleteBatch(IList<object> list)
        {
            return dal.DeleteBatch(list);
        }

        public TPDABOXInfo GetModel(string boxCID)
        {
            return dal.GetModel(boxCID);
        }

        public IList<TPDABOXInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, out totalRecords, sqlWhere, cmdParms);
        }

        public IList<TPDABOXInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(pageIndex, pageSize, sqlWhere, cmdParms);
        }

        public IList<TPDABOXInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            return dal.GetList(sqlWhere, cmdParms);
        }

        public IList<TPDABOXInfo> GetList()
        {
            return dal.GetList();
        }

        #endregion
    }
}
