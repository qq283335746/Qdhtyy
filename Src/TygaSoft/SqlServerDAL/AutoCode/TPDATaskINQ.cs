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
    public partial class TPDATaskINQ : ITPDATaskINQ
    {
        #region ITPDATaskINQ Member

        public int Insert(TPDATaskINQInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into TPDA_TaskINQ (TK_date,TK_BNO,TK_Bname,TK_Pdate,TK_Note,TK_PNO,TK_oper,TK_opTime,TK_State,TK_Rno,TK_Coper,TK_CopTime)
			            values
						(@TKdate,@TKBNO,@TKBname,@TKPdate,@TKNote,@TKPNO,@TKoper,@TKopTime,@TKState,@TKRno,@TKCoper,@TKCopTime)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@TKdate",SqlDbType.Char,10),
new SqlParameter("@TKBNO",SqlDbType.VarChar,10),
new SqlParameter("@TKBname",SqlDbType.VarChar,30),
new SqlParameter("@TKPdate",SqlDbType.VarChar,10),
new SqlParameter("@TKNote",SqlDbType.VarChar,100),
new SqlParameter("@TKPNO",SqlDbType.VarChar,20),
new SqlParameter("@TKoper",SqlDbType.VarChar,10),
new SqlParameter("@TKopTime",SqlDbType.DateTime),
new SqlParameter("@TKState",SqlDbType.Char,1),
new SqlParameter("@TKRno",SqlDbType.VarChar,10),
new SqlParameter("@TKCoper",SqlDbType.VarChar,10),
new SqlParameter("@TKCopTime",SqlDbType.DateTime)
                                   };
            parms[0].Value = model.TKdate;
            parms[1].Value = model.TKBNO;
            parms[2].Value = model.TKBname;
            parms[3].Value = model.TKPdate;
            parms[4].Value = model.TKNote;
            parms[5].Value = model.TKPNO;
            parms[6].Value = model.TKoper;
            parms[7].Value = model.TKopTime;
            parms[8].Value = model.TKState;
            parms[9].Value = model.TKRno;
            parms[10].Value = model.TKCoper;
            parms[11].Value = model.TKCopTime;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(TPDATaskINQInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update TPDA_TaskINQ set TK_date = @TKdate,TK_BNO = @TKBNO,TK_Bname = @TKBname,TK_Pdate = @TKPdate,TK_Note = @TKNote,TK_PNO = @TKPNO,TK_oper = @TKoper,TK_opTime = @TKopTime,TK_State = @TKState,TK_Rno = @TKRno,TK_Coper = @TKCoper,TK_CopTime = @TKCopTime 
			            where TK_IID = @TKIID
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@TKIID",SqlDbType.Int),
new SqlParameter("@TKdate",SqlDbType.Char,10),
new SqlParameter("@TKBNO",SqlDbType.VarChar,10),
new SqlParameter("@TKBname",SqlDbType.VarChar,30),
new SqlParameter("@TKPdate",SqlDbType.VarChar,10),
new SqlParameter("@TKNote",SqlDbType.VarChar,100),
new SqlParameter("@TKPNO",SqlDbType.VarChar,20),
new SqlParameter("@TKoper",SqlDbType.VarChar,10),
new SqlParameter("@TKopTime",SqlDbType.DateTime),
new SqlParameter("@TKState",SqlDbType.Char,1),
new SqlParameter("@TKRno",SqlDbType.VarChar,10),
new SqlParameter("@TKCoper",SqlDbType.VarChar,10),
new SqlParameter("@TKCopTime",SqlDbType.DateTime)
                                   };
            parms[0].Value = model.TKIID;
            parms[1].Value = model.TKdate;
            parms[2].Value = model.TKBNO;
            parms[3].Value = model.TKBname;
            parms[4].Value = model.TKPdate;
            parms[5].Value = model.TKNote;
            parms[6].Value = model.TKPNO;
            parms[7].Value = model.TKoper;
            parms[8].Value = model.TKopTime;
            parms[9].Value = model.TKState;
            parms[10].Value = model.TKRno;
            parms[11].Value = model.TKCoper;
            parms[12].Value = model.TKCopTime;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(int tKIID)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from TPDA_TaskINQ where TK_IID = @TKIID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@TKIID",SqlDbType.Int)
                                   };
            parms[0].Value = tKIID;

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
                sb.Append(@"delete from TPDA_TaskINQ where TKIID = @TKIID" + n + " ;");
                SqlParameter parm = new SqlParameter("@TKIID" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public TPDATaskINQInfo GetModel(int tKIID)
        {
            TPDATaskINQInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 TK_IID,TK_date,TK_BNO,TK_Bname,TK_Pdate,TK_Note,TK_PNO,TK_oper,TK_opTime,TK_State,TK_Rno,TK_Coper,TK_CopTime 
			            from TPDA_TaskINQ
						where TK_IID = @TKIID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@TKIID",SqlDbType.Int)
                                   };
            parms[0].Value = tKIID;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model = new TPDATaskINQInfo();
                        model.TKIID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        model.TKdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TKBNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TKBname = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TKPdate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TKNote = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TKPNO = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TKoper = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TKopTime = reader.IsDBNull(8) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(8);
                        model.TKState = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TKRno = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TKCoper = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TKCopTime = reader.IsDBNull(12) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(12);
                    }
                }
            }

            return model;
        }

        public IList<TPDATaskINQInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from TPDA_TaskINQ ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<TPDATaskINQInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TK_IID) as RowNumber,
			          TK_IID,TK_date,TK_BNO,TK_Bname,TK_Pdate,TK_Note,TK_PNO,TK_oper,TK_opTime,TK_State,TK_Rno,TK_Coper,TK_CopTime
					  from TPDA_TaskINQ ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDATaskINQInfo> list = new List<TPDATaskINQInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskINQInfo model = new TPDATaskINQInfo();
                        model.TKIID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        model.TKdate = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TKBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TKBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TKPdate = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TKNote = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TKPNO = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TKoper = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TKopTime = reader.IsDBNull(9) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(9);
                        model.TKState = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TKRno = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TKCoper = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TKCopTime = reader.IsDBNull(13) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(13);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskINQInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TK_IID) as RowNumber,
			           TK_IID,TK_date,TK_BNO,TK_Bname,TK_Pdate,TK_Note,TK_PNO,TK_oper,TK_opTime,TK_State,TK_Rno,TK_Coper,TK_CopTime
					   from TPDA_TaskINQ ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDATaskINQInfo> list = new List<TPDATaskINQInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskINQInfo model = new TPDATaskINQInfo();
                        model.TKIID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        model.TKdate = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TKBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TKBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TKPdate = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TKNote = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TKPNO = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TKoper = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TKopTime = reader.IsDBNull(9) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(9);
                        model.TKState = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TKRno = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TKCoper = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TKCopTime = reader.IsDBNull(13) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(13);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskINQInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select TK_IID,TK_date,TK_BNO,TK_Bname,TK_Pdate,TK_Note,TK_PNO,TK_oper,TK_opTime,TK_State,TK_Rno,TK_Coper,TK_CopTime
                        from TPDA_TaskINQ ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by TK_IID ");

            IList<TPDATaskINQInfo> list = new List<TPDATaskINQInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskINQInfo model = new TPDATaskINQInfo();
                        model.TKIID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        model.TKdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TKBNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TKBname = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TKPdate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TKNote = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TKPNO = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TKoper = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TKopTime = reader.IsDBNull(8) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(8);
                        model.TKState = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TKRno = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TKCoper = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TKCopTime = reader.IsDBNull(12) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(12);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskINQInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select TK_IID,TK_date,TK_BNO,TK_Bname,TK_Pdate,TK_Note,TK_PNO,TK_oper,TK_opTime,TK_State,TK_Rno,TK_Coper,TK_CopTime 
			            from TPDA_TaskINQ
					    order by TK_IID ");

            IList<TPDATaskINQInfo> list = new List<TPDATaskINQInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskINQInfo model = new TPDATaskINQInfo();
                        model.TKIID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        model.TKdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TKBNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TKBname = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TKPdate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TKNote = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TKPNO = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TKoper = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TKopTime = reader.IsDBNull(8) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(8);
                        model.TKState = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TKRno = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TKCoper = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TKCopTime = reader.IsDBNull(12) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(12);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
