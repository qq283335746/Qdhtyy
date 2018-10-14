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
        #region TPDABOX Member

        public IList<TPDABOXInfo> GetBoxs(string pno, string bno)
        {
            return dal.GetBoxs(pno, bno);
        }

        public int SaveBoxInfo(string pno, string bno, string oper, string boxno, string btype, string pdate, string tocid, string tobno)
        {
            return dal.SaveBoxInfo(pno, bno, oper, boxno, btype, pdate, tocid, tobno);
        }

        #endregion
    }
}
