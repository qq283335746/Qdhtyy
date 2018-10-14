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
    public partial class TPDATaskEbank : ITPDATaskEbank
    {
        #region ITPDATaskEbank Member

        public int Insert(TPDATaskEbankInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into TPDA_TaskEbank (TB_cid,TB_date,TB_Rno,TB_BNO,TB_Bname,TB_Ptime,TB_boxNum,TB_Notes,TB_oper,TB_opTime,TB_State,TB_Type,TB_Stime,TB_Etime,TB_Tlen,TB_KilM,TB_Fee,TB_Emp,TB_CNO,TB_Eva)
			            values
						(@TBcid,@TBdate,@TBRno,@TBBNO,@TBBname,@TBPtime,@TBboxNum,@TBNotes,@TBoper,@TBopTime,@TBState,@TBType,@TBStime,@TBEtime,@TBTlen,@TBKilM,@TBFee,@TBEmp,@TBCNO,@TBEva)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@TBcid",SqlDbType.Char,2),
new SqlParameter("@TBdate",SqlDbType.Char,10),
new SqlParameter("@TBRno",SqlDbType.VarChar,10),
new SqlParameter("@TBBNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBname",SqlDbType.VarChar,30),
new SqlParameter("@TBPtime",SqlDbType.VarChar,5),
new SqlParameter("@TBboxNum",SqlDbType.Int),
new SqlParameter("@TBNotes",SqlDbType.VarChar,20),
new SqlParameter("@TBoper",SqlDbType.VarChar,10),
new SqlParameter("@TBopTime",SqlDbType.DateTime),
new SqlParameter("@TBState",SqlDbType.Char,1),
new SqlParameter("@TBType",SqlDbType.Char,1),
new SqlParameter("@TBStime",SqlDbType.VarChar,10),
new SqlParameter("@TBEtime",SqlDbType.VarChar,10),
new SqlParameter("@TBTlen",SqlDbType.Decimal),
new SqlParameter("@TBKilM",SqlDbType.Int),
new SqlParameter("@TBFee",SqlDbType.Int),
new SqlParameter("@TBEmp",SqlDbType.VarChar,20),
new SqlParameter("@TBCNO",SqlDbType.VarChar,20),
new SqlParameter("@TBEva",SqlDbType.Char,1)
                                   };
            parms[0].Value = model.TBcid;
            parms[1].Value = model.TBdate;
            parms[2].Value = model.TBRno;
            parms[3].Value = model.TBBNO;
            parms[4].Value = model.TBBname;
            parms[5].Value = model.TBPtime;
            parms[6].Value = model.TBboxNum;
            parms[7].Value = model.TBNotes;
            parms[8].Value = model.TBoper;
            parms[9].Value = model.TBopTime;
            parms[10].Value = model.TBState;
            parms[11].Value = model.TBType;
            parms[12].Value = model.TBStime;
            parms[13].Value = model.TBEtime;
            parms[14].Value = model.TBTlen;
            parms[15].Value = model.TBKilM;
            parms[16].Value = model.TBFee;
            parms[17].Value = model.TBEmp;
            parms[18].Value = model.TBCNO;
            parms[19].Value = model.TBEva;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(TPDATaskEbankInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update TPDA_TaskEbank set TB_date = @TBdate,TB_Rno = @TBRno,TB_BNO = @TBBNO,TB_Bname = @TBBname,TB_Ptime = @TBPtime,TB_boxNum = @TBboxNum,TB_Notes = @TBNotes,TB_oper = @TBoper,TB_opTime = @TBopTime,TB_State = @TBState,TB_Type = @TBType,TB_Stime = @TBStime,TB_Etime = @TBEtime,TB_Tlen = @TBTlen,TB_KilM = @TBKilM,TB_Fee = @TBFee,TB_Emp = @TBEmp,TB_CNO = @TBCNO,TB_Eva = @TBEva 
			            where TB_cid = @TBcid
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@TBcid",SqlDbType.Char,2),
new SqlParameter("@TBdate",SqlDbType.Char,10),
new SqlParameter("@TBRno",SqlDbType.VarChar,10),
new SqlParameter("@TBBNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBname",SqlDbType.VarChar,30),
new SqlParameter("@TBPtime",SqlDbType.VarChar,5),
new SqlParameter("@TBboxNum",SqlDbType.Int),
new SqlParameter("@TBNotes",SqlDbType.VarChar,20),
new SqlParameter("@TBoper",SqlDbType.VarChar,10),
new SqlParameter("@TBopTime",SqlDbType.DateTime),
new SqlParameter("@TBState",SqlDbType.Char,1),
new SqlParameter("@TBType",SqlDbType.Char,1),
new SqlParameter("@TBStime",SqlDbType.VarChar,10),
new SqlParameter("@TBEtime",SqlDbType.VarChar,10),
new SqlParameter("@TBTlen",SqlDbType.Decimal),
new SqlParameter("@TBKilM",SqlDbType.Int),
new SqlParameter("@TBFee",SqlDbType.Int),
new SqlParameter("@TBEmp",SqlDbType.VarChar,20),
new SqlParameter("@TBCNO",SqlDbType.VarChar,20),
new SqlParameter("@TBEva",SqlDbType.Char,1)
                                   };
            parms[0].Value = model.TBcid;
            parms[1].Value = model.TBdate;
            parms[2].Value = model.TBRno;
            parms[3].Value = model.TBBNO;
            parms[4].Value = model.TBBname;
            parms[5].Value = model.TBPtime;
            parms[6].Value = model.TBboxNum;
            parms[7].Value = model.TBNotes;
            parms[8].Value = model.TBoper;
            parms[9].Value = model.TBopTime;
            parms[10].Value = model.TBState;
            parms[11].Value = model.TBType;
            parms[12].Value = model.TBStime;
            parms[13].Value = model.TBEtime;
            parms[14].Value = model.TBTlen;
            parms[15].Value = model.TBKilM;
            parms[16].Value = model.TBFee;
            parms[17].Value = model.TBEmp;
            parms[18].Value = model.TBCNO;
            parms[19].Value = model.TBEva;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(string tBcid)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from TPDA_TaskEbank where TB_cid = @TBcid ");
            SqlParameter[] parms = {
                                     new SqlParameter("@TBcid",SqlDbType.Char,2)
                                   };
            parms[0].Value = tBcid;

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
                sb.Append(@"delete from TPDA_TaskEbank where TBcid = @TBcid" + n + " ;");
                SqlParameter parm = new SqlParameter("@TBcid" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public TPDATaskEbankInfo GetModel(string tBcid)
        {
            TPDATaskEbankInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 TB_cid,TB_date,TB_Rno,TB_BNO,TB_Bname,TB_Ptime,TB_boxNum,TB_Notes,TB_oper,TB_opTime,TB_State,TB_Type,TB_Stime,TB_Etime,TB_Tlen,TB_KilM,TB_Fee,TB_Emp,TB_CNO,TB_Eva 
			            from TPDA_TaskEbank
						where TB_cid = @TBcid ");
            SqlParameter[] parms = {
                                     new SqlParameter("@TBcid",SqlDbType.Char,2)
                                   };
            parms[0].Value = tBcid;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model = new TPDATaskEbankInfo();
                        model.TBcid = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBRno = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBPtime = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBboxNum = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        model.TBNotes = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBoper = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBopTime = reader.IsDBNull(9) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(9);
                        model.TBState = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TBType = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBStime = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBEtime = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBTlen = reader.IsDBNull(14) ? 0 : reader.GetDecimal(14);
                        model.TBKilM = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                        model.TBFee = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
                        model.TBEmp = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                        model.TBCNO = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                        model.TBEva = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                    }
                }
            }

            return model;
        }

        public IList<TPDATaskEbankInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from TPDA_TaskEbank ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<TPDATaskEbankInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TB_cid) as RowNumber,
			          TB_cid,TB_date,TB_Rno,TB_BNO,TB_Bname,TB_Ptime,TB_boxNum,TB_Notes,TB_oper,TB_opTime,TB_State,TB_Type,TB_Stime,TB_Etime,TB_Tlen,TB_KilM,TB_Fee,TB_Emp,TB_CNO,TB_Eva
					  from TPDA_TaskEbank ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDATaskEbankInfo> list = new List<TPDATaskEbankInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskEbankInfo model = new TPDATaskEbankInfo();
                        model.TBcid = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBdate = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBRno = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBNO = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBBname = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBPtime = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBboxNum = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                        model.TBNotes = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBoper = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TBopTime = reader.IsDBNull(10) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(10);
                        model.TBState = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBType = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBStime = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBEtime = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                        model.TBTlen = reader.IsDBNull(15) ? 0 : reader.GetDecimal(15);
                        model.TBKilM = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
                        model.TBFee = reader.IsDBNull(17) ? 0 : reader.GetInt32(17);
                        model.TBEmp = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                        model.TBCNO = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                        model.TBEva = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskEbankInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TB_cid) as RowNumber,
			           TB_cid,TB_date,TB_Rno,TB_BNO,TB_Bname,TB_Ptime,TB_boxNum,TB_Notes,TB_oper,TB_opTime,TB_State,TB_Type,TB_Stime,TB_Etime,TB_Tlen,TB_KilM,TB_Fee,TB_Emp,TB_CNO,TB_Eva
					   from TPDA_TaskEbank ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDATaskEbankInfo> list = new List<TPDATaskEbankInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskEbankInfo model = new TPDATaskEbankInfo();
                        model.TBcid = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBdate = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBRno = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBNO = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBBname = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBPtime = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBboxNum = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                        model.TBNotes = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBoper = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TBopTime = reader.IsDBNull(10) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(10);
                        model.TBState = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBType = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBStime = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBEtime = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                        model.TBTlen = reader.IsDBNull(15) ? 0 : reader.GetDecimal(15);
                        model.TBKilM = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
                        model.TBFee = reader.IsDBNull(17) ? 0 : reader.GetInt32(17);
                        model.TBEmp = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                        model.TBCNO = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                        model.TBEva = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskEbankInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select TB_cid,TB_date,TB_Rno,TB_BNO,TB_Bname,TB_Ptime,TB_boxNum,TB_Notes,TB_oper,TB_opTime,TB_State,TB_Type,TB_Stime,TB_Etime,TB_Tlen,TB_KilM,TB_Fee,TB_Emp,TB_CNO,TB_Eva
                        from TPDA_TaskEbank ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by TB_cid ");

            IList<TPDATaskEbankInfo> list = new List<TPDATaskEbankInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskEbankInfo model = new TPDATaskEbankInfo();
                        model.TBcid = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBRno = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBPtime = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBboxNum = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        model.TBNotes = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBoper = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBopTime = reader.IsDBNull(9) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(9);
                        model.TBState = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TBType = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBStime = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBEtime = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBTlen = reader.IsDBNull(14) ? 0 : reader.GetDecimal(14);
                        model.TBKilM = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                        model.TBFee = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
                        model.TBEmp = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                        model.TBCNO = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                        model.TBEva = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskEbankInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select TB_cid,TB_date,TB_Rno,TB_BNO,TB_Bname,TB_Ptime,TB_boxNum,TB_Notes,TB_oper,TB_opTime,TB_State,TB_Type,TB_Stime,TB_Etime,TB_Tlen,TB_KilM,TB_Fee,TB_Emp,TB_CNO,TB_Eva 
			            from TPDA_TaskEbank
					    order by TB_cid ");

            IList<TPDATaskEbankInfo> list = new List<TPDATaskEbankInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskEbankInfo model = new TPDATaskEbankInfo();
                        model.TBcid = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBRno = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBPtime = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBboxNum = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        model.TBNotes = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBoper = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBopTime = reader.IsDBNull(9) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(9);
                        model.TBState = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TBType = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBStime = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBEtime = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBTlen = reader.IsDBNull(14) ? 0 : reader.GetDecimal(14);
                        model.TBKilM = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                        model.TBFee = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
                        model.TBEmp = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                        model.TBCNO = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                        model.TBEva = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
