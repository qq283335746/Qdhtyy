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
    public partial class TPDAUser
    {
        #region TPDAUser Member

        public bool ValidateUser(string username, string password, string pid, string pno)
        {
            return dal.ValidateUser(username, password, pid, pno);
        }

        public TPDAUserInfo GetModel(string username, string password)
        {
            return dal.GetModel(username, password);
        }

        #endregion
    }
}
