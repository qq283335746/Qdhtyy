using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDABOX
    {
        #region ITPDABOX Member

        IList<TPDABOXInfo> GetBoxs(string pno, string bno);

        int SaveBoxInfo(string pno, string bno, string oper, string boxno, string btype, string pdate, string tocid, string tobno);

        #endregion
    }
}
