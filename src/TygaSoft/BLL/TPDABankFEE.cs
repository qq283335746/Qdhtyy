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
        #region TPDABankFEE Member

        public IList<TPDABankFEEInfo> GetFeeQ(string amon, string btype, string pno, string bno)
        {
            return dal.GetFeeQ(amon,btype, pno, bno);
        }

        #endregion
    }
}
