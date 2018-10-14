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
    public partial class TPDAPDAlist : ITPDAPDAlist
    {
        #region ITPDAPDAlist Member

        public int Insert(TPDAPDAlistInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into TPDA_PDAlist (PID,PNO,PCNO,PCID,Pstate,Poper,PopTime)
			            values
						(@PID,@PNO,@PCNO,@PCID,@Pstate,@Poper,@PopTime)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@PID",SqlDbType.VarChar,30),
new SqlParameter("@PNO",SqlDbType.VarChar,10),
new SqlParameter("@PCNO",SqlDbType.VarChar,10),
new SqlParameter("@PCID",SqlDbType.Char,2),
new SqlParameter("@Pstate",SqlDbType.Char,1),
new SqlParameter("@Poper",SqlDbType.VarChar,20),
new SqlParameter("@PopTime",SqlDbType.DateTime)
                                   };
            parms[0].Value = model.PID;
            parms[1].Value = model.PNO;
            parms[2].Value = model.PCNO;
            parms[3].Value = model.PCID;
            parms[4].Value = model.Pstate;
            parms[5].Value = model.Poper;
            parms[6].Value = model.PopTime;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(TPDAPDAlistInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update TPDA_PDAlist set PNO = @PNO,PCNO = @PCNO,PCID = @PCID,Pstate = @Pstate,Poper = @Poper,PopTime = @PopTime 
			            where PID = @PID
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@PID",SqlDbType.VarChar,30),
new SqlParameter("@PNO",SqlDbType.VarChar,10),
new SqlParameter("@PCNO",SqlDbType.VarChar,10),
new SqlParameter("@PCID",SqlDbType.Char,2),
new SqlParameter("@Pstate",SqlDbType.Char,1),
new SqlParameter("@Poper",SqlDbType.VarChar,20),
new SqlParameter("@PopTime",SqlDbType.DateTime)
                                   };
            parms[0].Value = model.PID;
            parms[1].Value = model.PNO;
            parms[2].Value = model.PCNO;
            parms[3].Value = model.PCID;
            parms[4].Value = model.Pstate;
            parms[5].Value = model.Poper;
            parms[6].Value = model.PopTime;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(string pID)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from TPDA_PDAlist where PID = @PID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@PID",SqlDbType.VarChar,30)
                                   };
            parms[0].Value = pID;

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
                sb.Append(@"delete from TPDA_PDAlist where PID = @PID" + n + " ;");
                SqlParameter parm = new SqlParameter("@PID" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public TPDAPDAlistInfo GetModel(string pID)
        {
            TPDAPDAlistInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 PNO,PID,PCNO,PCID,Pstate,Poper,PopTime 
			            from TPDA_PDAlist
						where PID = @PID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@PID",SqlDbType.VarChar,30)
                                   };
            parms[0].Value = pID;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model = new TPDAPDAlistInfo();
                        model.PNO = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.PID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.PCNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.PCID = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.Pstate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Poper = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.PopTime = reader.IsDBNull(6) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(6);
                    }
                }
            }

            return model;
        }

        public IList<TPDAPDAlistInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from TPDA_PDAlist ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<TPDAPDAlistInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by PID) as RowNumber,
			          PNO,PID,PCNO,PCID,Pstate,Poper,PopTime
					  from TPDA_PDAlist ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDAPDAlistInfo> list = new List<TPDAPDAlistInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDAPDAlistInfo model = new TPDAPDAlistInfo();
                        model.PNO = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.PID = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.PCNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.PCID = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Pstate = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.Poper = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.PopTime = reader.IsDBNull(7) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(7);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDAPDAlistInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by PID) as RowNumber,
			           PNO,PID,PCNO,PCID,Pstate,Poper,PopTime
					   from TPDA_PDAlist ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDAPDAlistInfo> list = new List<TPDAPDAlistInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDAPDAlistInfo model = new TPDAPDAlistInfo();
                        model.PNO = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.PID = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.PCNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.PCID = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Pstate = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.Poper = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.PopTime = reader.IsDBNull(7) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(7);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDAPDAlistInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select PNO,PID,PCNO,PCID,Pstate,Poper,PopTime
                        from TPDA_PDAlist ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by PID ");

            IList<TPDAPDAlistInfo> list = new List<TPDAPDAlistInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDAPDAlistInfo model = new TPDAPDAlistInfo();
                        model.PNO = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.PID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.PCNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.PCID = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.Pstate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Poper = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.PopTime = reader.IsDBNull(6) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(6);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDAPDAlistInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select PNO,PID,PCNO,PCID,Pstate,Poper,PopTime 
			            from TPDA_PDAlist
					    order by PID ");

            IList<TPDAPDAlistInfo> list = new List<TPDAPDAlistInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDAPDAlistInfo model = new TPDAPDAlistInfo();
                        model.PNO = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.PID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.PCNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.PCID = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.Pstate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.Poper = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.PopTime = reader.IsDBNull(6) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(6);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
