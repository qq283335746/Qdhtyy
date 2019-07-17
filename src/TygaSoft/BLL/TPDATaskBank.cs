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
        #region TPDATaskBank Member

        public string GetAuthInfo(string pid, string pno, string eid, string adate)
        {
            return dal.GetAuthInfo(pid, pno, eid, adate);
        }

        public IList<TPDATaskBankInfo> GetList(string pid, string pno, string adate)
        {
            return dal.GetList(pid, pno, adate);
        }

        public IList<TPDATaskINQInfo> GetInQTask(string pid, string pno, string adate)
        {
            return dal.GetInQTask(pid, pno, adate);
        }

        public int SaveBatchTaskCargoInfo(string adate, string pno, string oper, string rno, string bno, string boxno, string tocid, string tobno, string otype, string odate, string pdate)
        {
            return dal.SaveBatchTaskCargoInfo(adate, pno, oper, rno, bno, boxno, tocid, tobno, otype, odate, pdate);
        }

        public int SaveTaskCargoInfo(string pno, string oper, string bno, string boxno, string tocid, string tobno, string btype, string pdate)
        {
            return dal.SaveTaskCargoInfo(pno, oper, bno, boxno, tocid, tobno, btype, pdate);
        }

        public int SaveTaskInfo(string cid, string adate, string rno, string bno, string stime, string etime, int kilm, int fee, string oper)
        {
            return dal.SaveTaskInfo(cid, adate, rno, bno, stime, etime, kilm, fee, oper);
        }

        public int SaveApplyTaskInfo(string adate, string pno, string bno, string oper, string ptime, string note)
        {
            return dal.SaveApplyTaskInfo(adate, pno, bno, oper, ptime, note);
        }

        #endregion
    }
}
