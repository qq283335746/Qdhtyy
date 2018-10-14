using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.IDAL;
using TygaSoft.Model;
using TygaSoft.DBUtility;

namespace TygaSoft.SqlServerDAL
{
    public partial class Applications
    {
        #region IApplications Member

        public object GetAspnetAppId(string appName)
        {
            string cmdText = @"select ApplicationId from aspnet_Applications where LoweredApplicationName = @AppName ";
            SqlParameter parm = new SqlParameter("@AppName", SqlDbType.NVarChar, 256);
            parm.Value = appName.ToLower();

            return SqlHelper.ExecuteScalar(SqlHelper.AspnetDbConnString, CommandType.Text, cmdText, parm);
        }

        //public object GetApplicationId(string appName)
        //{
        //    string cmdText = @"select Id from Applications where LOWER(@AppName) = LowerName ";
        //    SqlParameter parm = new SqlParameter("@AppName", SqlDbType.NVarChar, 256);
        //    parm.Value = appName.ToLower();

        //    return SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, CommandType.Text, cmdText, parm);
        //}

        #endregion
    }
}
