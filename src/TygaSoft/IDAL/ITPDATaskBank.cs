using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDATaskBank
    {
        #region ITPDATaskBank Member

        string GetAuthInfo(string pid, string pno, string eid, string adate);

        IList<TPDATaskBankInfo> GetList(string pid, string pno, string adate);

        IList<TPDATaskINQInfo> GetInQTask(string pid, string pno, string adate);

        int SaveBatchTaskCargoInfo(string adate, string pno, string oper, string rno, string bno, string boxno, string tocid, string tobno, string otype, string odate, string pdate);

        int SaveTaskCargoInfo(string pno, string oper, string bno, string boxno, string tocid, string tobno, string btype, string pdate);

        int SaveTaskInfo(string cid, string adate, string rno, string bno, string stime, string etime, int kilm, int fee, string oper);

        int SaveApplyTaskInfo(string adate, string pno, string bno, string oper, string ptime, string note);

        #endregion
    }
}
