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
    public partial class TPDATaskBox : ITPDATaskBox
    {
        #region ITPDATaskBox Member

        public int Insert(TPDATaskBoxInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into TPDA_TaskBox (TB_CID,TB_Date,TB_RNO,TB_BNO,TB_Bname,TB_BoxNO,TB_BoxC0,TB_BoxC1,TB_InOut,TB_ToCID,TB_ToBno,TB_ToBname,TB_Otype,TB_Pdate,TB_State)
			            values
						(@TBCID,@TBDate,@TBRNO,@TBBNO,@TBBname,@TBBoxNO,@TBBoxC0,@TBBoxC1,@TBInOut,@TBToCID,@TBToBno,@TBToBname,@TBOtype,@TBPdate,@TBState)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@TBCID",SqlDbType.Char,2),
new SqlParameter("@TBDate",SqlDbType.Char,10),
new SqlParameter("@TBRNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBname",SqlDbType.VarChar,20),
new SqlParameter("@TBBoxNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBoxC0",SqlDbType.VarChar,10),
new SqlParameter("@TBBoxC1",SqlDbType.VarChar,10),
new SqlParameter("@TBInOut",SqlDbType.Char,1),
new SqlParameter("@TBToCID",SqlDbType.Char,2),
new SqlParameter("@TBToBno",SqlDbType.VarChar,10),
new SqlParameter("@TBToBname",SqlDbType.VarChar,20),
new SqlParameter("@TBOtype",SqlDbType.Char,1),
new SqlParameter("@TBPdate",SqlDbType.VarChar,10),
new SqlParameter("@TBState",SqlDbType.Char,1)
                                   };
            parms[0].Value = model.TBCID;
            parms[1].Value = model.TBDate;
            parms[2].Value = model.TBRNO;
            parms[3].Value = model.TBBNO;
            parms[4].Value = model.TBBname;
            parms[5].Value = model.TBBoxNO;
            parms[6].Value = model.TBBoxC0;
            parms[7].Value = model.TBBoxC1;
            parms[8].Value = model.TBInOut;
            parms[9].Value = model.TBToCID;
            parms[10].Value = model.TBToBno;
            parms[11].Value = model.TBToBname;
            parms[12].Value = model.TBOtype;
            parms[13].Value = model.TBPdate;
            parms[14].Value = model.TBState;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(TPDATaskBoxInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update TPDA_TaskBox set TB_Date = @TBDate,TB_RNO = @TBRNO,TB_BNO = @TBBNO,TB_Bname = @TBBname,TB_BoxNO = @TBBoxNO,TB_BoxC0 = @TBBoxC0,TB_BoxC1 = @TBBoxC1,TB_InOut = @TBInOut,TB_ToCID = @TBToCID,TB_ToBno = @TBToBno,TB_ToBname = @TBToBname,TB_Otype = @TBOtype,TB_Pdate = @TBPdate,TB_State = @TBState 
			            where TB_CID = @TBCID
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@TBCID",SqlDbType.Char,2),
new SqlParameter("@TBDate",SqlDbType.Char,10),
new SqlParameter("@TBRNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBname",SqlDbType.VarChar,20),
new SqlParameter("@TBBoxNO",SqlDbType.VarChar,10),
new SqlParameter("@TBBoxC0",SqlDbType.VarChar,10),
new SqlParameter("@TBBoxC1",SqlDbType.VarChar,10),
new SqlParameter("@TBInOut",SqlDbType.Char,1),
new SqlParameter("@TBToCID",SqlDbType.Char,2),
new SqlParameter("@TBToBno",SqlDbType.VarChar,10),
new SqlParameter("@TBToBname",SqlDbType.VarChar,20),
new SqlParameter("@TBOtype",SqlDbType.Char,1),
new SqlParameter("@TBPdate",SqlDbType.VarChar,10),
new SqlParameter("@TBState",SqlDbType.Char,1)
                                   };
            parms[0].Value = model.TBCID;
            parms[1].Value = model.TBDate;
            parms[2].Value = model.TBRNO;
            parms[3].Value = model.TBBNO;
            parms[4].Value = model.TBBname;
            parms[5].Value = model.TBBoxNO;
            parms[6].Value = model.TBBoxC0;
            parms[7].Value = model.TBBoxC1;
            parms[8].Value = model.TBInOut;
            parms[9].Value = model.TBToCID;
            parms[10].Value = model.TBToBno;
            parms[11].Value = model.TBToBname;
            parms[12].Value = model.TBOtype;
            parms[13].Value = model.TBPdate;
            parms[14].Value = model.TBState;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(string tBCID)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from TPDA_TaskBox where TB_CID = @TBCID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@TBCID",SqlDbType.Char,2)
                                   };
            parms[0].Value = tBCID;

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
                sb.Append(@"delete from TPDA_TaskBox where TBCID = @TBCID" + n + " ;");
                SqlParameter parm = new SqlParameter("@TBCID" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public TPDATaskBoxInfo GetModel(string tBCID)
        {
            TPDATaskBoxInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 TB_CID,TB_Date,TB_RNO,TB_BNO,TB_Bname,TB_BoxNO,TB_BoxC0,TB_BoxC1,TB_InOut,TB_ToCID,TB_ToBno,TB_ToBname,TB_Otype,TB_Pdate,TB_State 
			            from TPDA_TaskBox
						where TB_CID = @TBCID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@TBCID",SqlDbType.Char,2)
                                   };
            parms[0].Value = tBCID;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model = new TPDATaskBoxInfo();
                        model.TBCID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBDate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBRNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBBoxNO = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBBoxC0 = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBBoxC1 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBInOut = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBToCID = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TBToBno = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TBToBname = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBOtype = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBPdate = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBState = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                    }
                }
            }

            return model;
        }

        public IList<TPDATaskBoxInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from TPDA_TaskBox ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<TPDATaskBoxInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TB_CID) as RowNumber,
			          TB_CID,TB_Date,TB_RNO,TB_BNO,TB_Bname,TB_BoxNO,TB_BoxC0,TB_BoxC1,TB_InOut,TB_ToCID,TB_ToBno,TB_ToBname,TB_Otype,TB_Pdate,TB_State
					  from TPDA_TaskBox ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDATaskBoxInfo> list = new List<TPDATaskBoxInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskBoxInfo model = new TPDATaskBoxInfo();
                        model.TBCID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBDate = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBRNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBNO = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBBname = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBBoxNO = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBBoxC0 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBBoxC1 = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBInOut = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TBToCID = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TBToBno = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBToBname = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBOtype = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBPdate = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                        model.TBState = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskBoxInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TB_CID) as RowNumber,
			           TB_CID,TB_Date,TB_RNO,TB_BNO,TB_Bname,TB_BoxNO,TB_BoxC0,TB_BoxC1,TB_InOut,TB_ToCID,TB_ToBno,TB_ToBname,TB_Otype,TB_Pdate,TB_State
					   from TPDA_TaskBox ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDATaskBoxInfo> list = new List<TPDATaskBoxInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskBoxInfo model = new TPDATaskBoxInfo();
                        model.TBCID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBDate = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBRNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBNO = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBBname = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBBoxNO = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBBoxC0 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBBoxC1 = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBInOut = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TBToCID = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TBToBno = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBToBname = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBOtype = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBPdate = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                        model.TBState = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskBoxInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select TB_CID,TB_Date,TB_RNO,TB_BNO,TB_Bname,TB_BoxNO,TB_BoxC0,TB_BoxC1,TB_InOut,TB_ToCID,TB_ToBno,TB_ToBname,TB_Otype,TB_Pdate,TB_State
                        from TPDA_TaskBox ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by TB_CID ");

            IList<TPDATaskBoxInfo> list = new List<TPDATaskBoxInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskBoxInfo model = new TPDATaskBoxInfo();
                        model.TBCID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBDate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBRNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBBoxNO = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBBoxC0 = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBBoxC1 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBInOut = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBToCID = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TBToBno = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TBToBname = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBOtype = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBPdate = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBState = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskBoxInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select TB_CID,TB_Date,TB_RNO,TB_BNO,TB_Bname,TB_BoxNO,TB_BoxC0,TB_BoxC1,TB_InOut,TB_ToCID,TB_ToBno,TB_ToBname,TB_Otype,TB_Pdate,TB_State 
			            from TPDA_TaskBox
					    order by TB_CID ");

            IList<TPDATaskBoxInfo> list = new List<TPDATaskBoxInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskBoxInfo model = new TPDATaskBoxInfo();
                        model.TBCID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBDate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBRNO = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBBoxNO = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBBoxC0 = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.TBBoxC1 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBInOut = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBToCID = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.TBToBno = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TBToBname = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBOtype = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBPdate = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBState = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
