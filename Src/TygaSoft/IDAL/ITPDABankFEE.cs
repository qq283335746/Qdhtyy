using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDABankFEE
    {
        #region ITPDABankFEE Member

        IList<TPDABankFEEInfo> GetFeeQ(string amon, string btype, string pno, string bno);

        #endregion
    }
}
