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
    public partial class TPDABankFEE : ITPDABankFEE
    {
        #region ITPDABankFEE Member

        public int Insert(TPDABankFEEInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into TPDA_BankFEE (TB_cid,TB_date,TB_BNO,TB_Bname,TB_FName,TB_notes,TB_oper,TB_opTime,TB_Fee)
			            values
						(@TBcid,@TBdate,@TBBNO,@TBBname,@TBFName,@TBnotes,@TBoper,@TBopTime,@TBFee)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@TBcid",SqlDbType.Char,2),
new SqlParameter("@TBdate",SqlDbType.Char,10),
new SqlParameter("@TBBNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBname",SqlDbType.VarChar,30),
new SqlParameter("@TBFName",SqlDbType.VarChar,30),
new SqlParameter("@TBnotes",SqlDbType.VarChar,255),
new SqlParameter("@TBoper",SqlDbType.VarChar,10),
new SqlParameter("@TBopTime",SqlDbType.DateTime),
new SqlParameter("@TBFee",SqlDbType.Int)
                                   };
            parms[0].Value = model.TBcid;
            parms[1].Value = model.TBdate;
            parms[2].Value = model.TBBNO;
            parms[3].Value = model.TBBname;
            parms[4].Value = model.TBFName;
            parms[5].Value = model.TBnotes;
            parms[6].Value = model.TBoper;
            parms[7].Value = model.TBopTime;
            parms[8].Value = model.TBFee;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(TPDABankFEEInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update TPDA_BankFEE set TB_date = @TBdate,TB_BNO = @TBBNO,TB_Bname = @TBBname,TB_FName = @TBFName,TB_notes = @TBnotes,TB_oper = @TBoper,TB_opTime = @TBopTime,TB_Fee = @TBFee 
			            where TB_cid = @TBcid
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@TBcid",SqlDbType.Char,2),
new SqlParameter("@TBdate",SqlDbType.Char,10),
new SqlParameter("@TBBNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBname",SqlDbType.VarChar,30),
new SqlParameter("@TBFName",SqlDbType.VarChar,30),
new SqlParameter("@TBnotes",SqlDbType.VarChar,255),
new SqlParameter("@TBoper",SqlDbType.VarChar,10),
new SqlParameter("@TBopTime",SqlDbType.DateTime),
new SqlParameter("@TBFee",SqlDbType.Int)
                                   };
            parms[0].Value = model.TBcid;
            parms[1].Value = model.TBdate;
            parms[2].Value = model.TBBNO;
            parms[3].Value = model.TBBname;
            parms[4].Value = model.TBFName;
            parms[5].Value = model.TBnotes;
            parms[6].Value = model.TBoper;
            parms[7].Value = model.TBopTime;
            parms[8].Value = model.TBFee;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(string tBcid)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from TPDA_BankFEE where TB_cid = @TBcid ");
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
                sb.Append(@"delete from TPDA_BankFEE where TBcid = @TBcid" + n + " ;");
                SqlParameter parm = new SqlParameter("@TBcid" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public TPDABankFEEInfo GetModel(string tBcid)
        {
            TPDABankFEEInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 TB_cid,TB_date,TB_BNO,TB_Bname,TB_FName,TB_notes,TB_oper,TB_opTime,TB_Fee 
			            from TPDA_BankFEE
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
                        model = new TPDABankFEEInfo();
                        model.TBcid = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBBNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBname = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBFName = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBnotes = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBoper = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBopTime = reader.IsDBNull(7) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(7);
                        model.TBFee = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                    }
                }
            }

            return model;
        }

        public IList<TPDABankFEEInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from TPDA_BankFEE ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<TPDABankFEEInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TB_cid) as RowNumber,
			          TB_cid,TB_date,TB_BNO,TB_Bname,TB_FName,TB_notes,TB_oper,TB_opTime,TB_Fee
					  from TPDA_BankFEE ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDABankFEEInfo> list = new List<TPDABankFEEInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDABankFEEInfo model = new TPDABankFEEInfo();
                        model.TBcid = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBdate = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBFName = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBnotes = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBoper = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBopTime = reader.IsDBNull(8) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(8);
                        model.TBFee = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDABankFEEInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TB_cid) as RowNumber,
			           TB_cid,TB_date,TB_BNO,TB_Bname,TB_FName,TB_notes,TB_oper,TB_opTime,TB_Fee
					   from TPDA_BankFEE ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDABankFEEInfo> list = new List<TPDABankFEEInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDABankFEEInfo model = new TPDABankFEEInfo();
                        model.TBcid = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBdate = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBFName = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBnotes = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBoper = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBopTime = reader.IsDBNull(8) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(8);
                        model.TBFee = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDABankFEEInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select TB_cid,TB_date,TB_BNO,TB_Bname,TB_FName,TB_notes,TB_oper,TB_opTime,TB_Fee
                        from TPDA_BankFEE ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by TB_cid ");

            IList<TPDABankFEEInfo> list = new List<TPDABankFEEInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDABankFEEInfo model = new TPDABankFEEInfo();
                        model.TBcid = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBBNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBname = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBFName = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBnotes = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBoper = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBopTime = reader.IsDBNull(7) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(7);
                        model.TBFee = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDABankFEEInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select TB_cid,TB_date,TB_BNO,TB_Bname,TB_FName,TB_notes,TB_oper,TB_opTime,TB_Fee 
			            from TPDA_BankFEE
					    order by TB_cid ");

            IList<TPDABankFEEInfo> list = new List<TPDABankFEEInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDABankFEEInfo model = new TPDABankFEEInfo();
                        model.TBcid = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBBNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBname = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBFName = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBnotes = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBoper = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBopTime = reader.IsDBNull(7) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(7);
                        model.TBFee = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
