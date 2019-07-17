using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDATaskEbank
    {
        #region ITPDATaskEbank Member

        IList<TPDATaskEbankInfo> GetEtask(string pid, string pno, string adate, string uid);

        IList<TPDATaskEbankInfo> GetEmpTlist(string pno, string mon, string uid);

        int SaveETask(string oper, string pno, string bno, string rno, string adate, string stime, string etime, int kilm, int fee, string eva);

        #endregion
    }
}
