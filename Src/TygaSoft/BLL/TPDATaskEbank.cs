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
        #region TPDATaskEbank Member
        
        public IList<TPDATaskEbankInfo> GetEtask(string pid, string pno, string adate, string uid)
        {
            return dal.GetEtask(pid, pno, adate, uid);
        }

        public IList<TPDATaskEbankInfo> GetEmpTlist(string pno, string mon, string uid)
        {
            return dal.GetEmpTlist(pno, mon, uid);
        }

        public int SaveETask(string oper, string pno, string bno, string rno, string adate, string stime, string etime, int kilm, int fee, string eva)
        {
            return dal.SaveETask(oper, pno, bno, rno, adate, stime, etime, kilm, fee, eva);
        }

        #endregion
    }
}
