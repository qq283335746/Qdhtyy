using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.Model;

namespace TygaSoft.IDAL
{
    public partial interface ITPDAUser
    {
        #region ITPDAUser Member

        bool ValidateUser(string username, string password, string pid, string pno);

        TPDAUserInfo GetModel(string username, string password);

        #endregion
    }
}
