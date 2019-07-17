using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.IDAL;
using TygaSoft.Model;
using TygaSoft.DBUtility;
using TygaSoft.SysHelper;

namespace TygaSoft.SqlServerDAL
{
    public partial class TPDAUser
    {
        #region ITPDAUser Member

        public bool ValidateUser(string username, string password, string pid, string pno)
        {
            SqlParameter[] parms = {
                new SqlParameter("@ReturnValue", SqlDbType.Int),
                new SqlParameter("@PID",pid),
                new SqlParameter("@PNO",pno),
                new SqlParameter("@UID",username),
                new SqlParameter("@Pwd",EncryptHelper.GetMd5Hash(password))
            };
            parms[0].Direction = ParameterDirection.ReturnValue;

            //var obj = SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, "SDP_Login", parms);
            //if (obj != null && (int)obj > 0) return true;
            //object aaa = parms[4].Value;

            SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString,CommandType.StoredProcedure, "SDP_Login", parms);
            int returnValue = (int)parms[0].Value;

            return returnValue == 0;
        }

        public TPDAUserInfo GetModel(string username, string password)
        {
            TPDAUserInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 UID,Uname,UcNO,Upda,Upwd,Uoper,UopTime,Ustate,Utype 
			            from TPDA_User
						where UID = @UID and Upwd = @Upwd ");
            SqlParameter[] parms = {
                                     new SqlParameter("@UID",username),
                                     new SqlParameter("@Upwd",EncryptHelper.GetMd5Hash(password))
                                   };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model = new TPDAUserInfo();
                        model.UID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.Uname = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.UcNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.Upda = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        //model.Upwd = string.Empty;
                        //model.Uoper = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.UopTime = reader.IsDBNull(6) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(6);
                        model.Ustate = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.Utype = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                    }
                }
            }

            return model;
        }

        #endregion
    }
}
