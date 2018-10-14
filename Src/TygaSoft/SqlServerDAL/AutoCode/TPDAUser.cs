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
    public partial class TPDAUser : ITPDAUser
    {
        #region ITPDAUser Member

        public int Insert(TPDAUserInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into TPDA_User (UID,Uname,UcNO,Upda,Upwd,Uoper,UopTime,Ustate,Utype)
			            values
						(@UID,@Uname,@UcNO,@Upda,@Upwd,@Uoper,@UopTime,@Ustate,@Utype)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@UID",SqlDbType.VarChar,10),
new SqlParameter("@Uname",SqlDbType.VarChar,20),
new SqlParameter("@UcNO",SqlDbType.VarChar,10),
new SqlParameter("@Upda",SqlDbType.VarChar,10),
new SqlParameter("@Upwd",SqlDbType.VarChar,50),
new SqlParameter("@Uoper",SqlDbType.VarChar,20),
new SqlParameter("@UopTime",SqlDbType.DateTime),
new SqlParameter("@Ustate",SqlDbType.Char,1),
new SqlParameter("@Utype",SqlDbType.Char,1)
                                   };
            parms[0].Value = model.UID;
            parms[1].Value = model.Uname;
            parms[2].Value = model.UcNO;
            parms[3].Value = model.Upda;
            parms[4].Value = model.Upwd;
            parms[5].Value = model.Uoper;
            parms[6].Value = model.UopTime;
            parms[7].Value = model.Ustate;
            parms[8].Value = model.Utype;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(TPDAUserInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update TPDA_User set Uname = @Uname,UcNO = @UcNO,Upda = @Upda,Upwd = @Upwd,Uoper = @Uoper,UopTime = @UopTime,Ustate = @Ustate,Utype = @Utype 
			            where UID = @UID
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@UID",SqlDbType.VarChar,10),
new SqlParameter("@Uname",SqlDbType.VarChar,20),
new SqlParameter("@UcNO",SqlDbType.VarChar,10),
new SqlParameter("@Upda",SqlDbType.VarChar,10),
new SqlParameter("@Upwd",SqlDbType.VarChar,50),
new SqlParameter("@Uoper",SqlDbType.VarChar,20),
new SqlParameter("@UopTime",SqlDbType.DateTime),
new SqlParameter("@Ustate",SqlDbType.Char,1),
new SqlParameter("@Utype",SqlDbType.Char,1)
                                   };
            parms[0].Value = model.UID;
            parms[1].Value = model.Uname;
            parms[2].Value = model.UcNO;
            parms[3].Value = model.Upda;
            parms[4].Value = model.Upwd;
            parms[5].Value = model.Uoper;
            parms[6].Value = model.UopTime;
            parms[7].Value = model.Ustate;
            parms[8].Value = model.Utype;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(string uID)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from TPDA_User where UID = @UID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@UID",SqlDbType.VarChar,10)
                                   };
            parms[0].Value = uID;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public bool DeleteBatch(IList<object> list)
        {
            StringBuilder sb = new StringBuilder(500);
            ParamsHelper parms = new ParamsHelper();
            int n = 0;
            foreach (string item in list)
            {
                n++;
                sb.Append(@"delete from TPDA_User where UID = @UID" + n + " ;");
                SqlParameter parm = new SqlParameter("@UID" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public TPDAUserInfo GetModel(string uID)
        {
            TPDAUserInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 UID,Uname,UcNO,Upda,Upwd,Uoper,UopTime,Ustate,Utype 
			            from TPDA_User
						where UID = @UID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@UID",SqlDbType.VarChar,10)
                                   };
            parms[0].Value = uID;

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
                        model.Upwd = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Uoper = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.UopTime = reader.IsDBNull(6) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(6);
                        model.Ustate = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.Utype = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                    }
                }
            }

            return model;
        }

        public IList<TPDAUserInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from TPDA_User ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<TPDAUserInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by UID) as RowNumber,
			          UID,Uname,UcNO,Upda,Upwd,Uoper,UopTime,Ustate,Utype
					  from TPDA_User ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDAUserInfo> list = new List<TPDAUserInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDAUserInfo model = new TPDAUserInfo();
                        model.UID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.Uname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.UcNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.Upda = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Upwd = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.Uoper = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.UopTime = reader.IsDBNull(7) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(7);
                        model.Ustate = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.Utype = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDAUserInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by UID) as RowNumber,
			           UID,Uname,UcNO,Upda,Upwd,Uoper,UopTime,Ustate,Utype
					   from TPDA_User ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDAUserInfo> list = new List<TPDAUserInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDAUserInfo model = new TPDAUserInfo();
                        model.UID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.Uname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.UcNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.Upda = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Upwd = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.Uoper = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.UopTime = reader.IsDBNull(7) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(7);
                        model.Ustate = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.Utype = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDAUserInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select UID,Uname,UcNO,Upda,Upwd,Uoper,UopTime,Ustate,Utype
                        from TPDA_User ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by UID ");

            IList<TPDAUserInfo> list = new List<TPDAUserInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDAUserInfo model = new TPDAUserInfo();
                        model.UID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.Uname = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.UcNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.Upda = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.Upwd = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Uoper = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.UopTime = reader.IsDBNull(6) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(6);
                        model.Ustate = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.Utype = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDAUserInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select UID,Uname,UcNO,Upda,Upwd,Uoper,UopTime,Ustate,Utype 
			            from TPDA_User
					    order by UID ");

            IList<TPDAUserInfo> list = new List<TPDAUserInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDAUserInfo model = new TPDAUserInfo();
                        model.UID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.Uname = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.UcNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.Upda = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.Upwd = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Uoper = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.UopTime = reader.IsDBNull(6) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(6);
                        model.Ustate = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.Utype = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
