using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using TygaSoft.IDAL;
using TygaSoft.Model;
using TygaSoft.DBUtility;

namespace TygaSoft.SqlServerDAL
{
    public partial class TPDATaskBank
    {
        #region ITPDATaskBank Member

        public string GetAuthInfo(string pid, string pno, string eid, string adate)
        {
            SqlParameter[] parms = {
                new SqlParameter("@JpgIP", SqlDbType.VarChar,100),
                new SqlParameter("@Emp", SqlDbType.VarChar,10),
                new SqlParameter("@Adate",adate),
                new SqlParameter("@PID",pid),
                new SqlParameter("@PNO",pno),
                new SqlParameter("@EID",eid)
            };
            parms[0].Direction = ParameterDirection.Output;
            parms[1].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SDP_GetEmpJPG", parms);
            var dic = new Dictionary<string, string>();
            dic.Add("PictureUrl", (string)parms[0].Value);
            dic.Add("CustomerId", (string)parms[1].Value);
            return JsonConvert.SerializeObject(dic);
        }

        public IList<TPDATaskBankInfo> GetList(string pid, string pno, string adate)
        {
            SqlParameter[] parms = {
                new SqlParameter("@Adate",adate),
                new SqlParameter("@PID",pid),
                new SqlParameter("@PNO",pno)
            };

            var list = new List<TPDATaskBankInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SDP_GetTask", parms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var model = new TPDATaskBankInfo();
                        model.TBcid = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBdate = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBRno = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBBNO = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.TBBname = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.TBPtime = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.TBboxNum = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        model.TBnotes = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.TBoper = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.TBopTime = reader.IsDBNull(9) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(9);
                        model.TBState = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.TBType = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.TBStime = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        model.TBEtime = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                        model.TBTlen = reader.IsDBNull(14) ? 0 : reader.GetDecimal(14);
                        model.TBKilM = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                        model.TBFee = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
                        model.TBWxs = reader.IsDBNull(17) ? 0 : reader.GetInt32(17);
                        model.TBEmp = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                        model.TBCNO = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);

                        //if (model.TBState == "1") model.TBState = "已完成";

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskINQInfo> GetInQTask(string pid, string pno, string adate)
        {
            SqlParameter[] parms = {
                new SqlParameter("@PID",pid),
                new SqlParameter("@PNO",pno),
                new SqlParameter("@Adate",adate)
            };

            var list = new List<TPDATaskINQInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString,CommandType.StoredProcedure, "SDP_GetInQTask", parms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var model = new TPDATaskINQInfo();
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

                        model.TKStateName = model.TKState == "1" ? "已安排":"未安排";

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public int SaveTaskInfo(string cid, string adate, string rno, string bno, string stime, string etime, int kilm, int fee, string oper)
        {
            SqlParameter[] parms = {
                new SqlParameter("@CID",cid),
                new SqlParameter("@Adate",adate),
                new SqlParameter("@RNO",rno),
                new SqlParameter("@BNO",bno),
                new SqlParameter("@Stime",stime),
                new SqlParameter("@Etime",etime),
                new SqlParameter("@Kilm",kilm),
                new SqlParameter("@Fee",fee),
                new SqlParameter("@Oper",oper)
            };

            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SNP_SaveTask", parms);
        }

        public int SaveTaskCargoInfo(string pno, string oper, string bno, string boxno, string tocid, string tobno, string btype, string pdate)
        {
            SqlParameter[] parms = {
                new SqlParameter("@PNO",pno),
                new SqlParameter("@Oper",oper),
                new SqlParameter("@Bno",bno),
                new SqlParameter("@BoxNO",boxno),
                new SqlParameter("@ToCID",tocid),
                new SqlParameter("@ToBno",tobno),
                new SqlParameter("@Btype",btype),
                new SqlParameter("@Pdate",pdate)
            };

            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SNP_ModiBox", parms);
        }

        public int SaveBatchTaskCargoInfo(string adate, string pno, string oper, string rno, string bno, string boxno, string tocid, string tobno, string otype, string odate, string pdate)
        {
            SqlParameter[] parms = {
                new SqlParameter("@Adate",adate),
                new SqlParameter("@PNO",pno),
                new SqlParameter("@Oper",oper),
                new SqlParameter("@RNO",rno),
                new SqlParameter("@Bno",bno),
                new SqlParameter("@BoxNO",boxno),
                new SqlParameter("@ToCID",tocid),
                new SqlParameter("@ToBno",tobno),
                new SqlParameter("@Otype",otype),
                new SqlParameter("@ODate",odate),
                new SqlParameter("@Pdate",pdate)
            };

            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SNP_UppBox", parms);
        }

        public int SaveApplyTaskInfo(string adate, string pno, string bno, string oper, string ptime, string note)
        {
            SqlParameter[] parms = {
                new SqlParameter("@Adate",adate),
                new SqlParameter("@PNO",pno),
                new SqlParameter("@BNO",bno),
                new SqlParameter("@Oper",oper),
                new SqlParameter("@Ptime",ptime),
                new SqlParameter("@Note",note)
            };

            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SNP_REQTSK", parms);
        }

        #endregion
    }
}
