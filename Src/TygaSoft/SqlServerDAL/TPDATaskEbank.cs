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

        public IList<TPDATaskEbankInfo> GetEtask(string pid, string pno, string adate, string uid)
        {
            SqlParameter[] parms = {
                new SqlParameter("@Adate",adate),
                new SqlParameter("@PID",pid),
                new SqlParameter("@PNO",pno),
                new SqlParameter("@Uid",uid)
            };

            var list = new List<TPDATaskEbankInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SDP_GetEtask", parms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var model = new TPDATaskEbankInfo();
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

        /// <summary>
        /// 工作量查询
        /// </summary>
        /// <param name="pno"></param>
        /// <param name="mon"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IList<TPDATaskEbankInfo> GetEmpTlist(string pno, string mon, string uid)
        {
            SqlParameter[] parms = {
                new SqlParameter("@MON",mon),
                new SqlParameter("@PNO",pno),
                new SqlParameter("@Uid",uid)
            };

            var list = new List<TPDATaskEbankInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SNP_GetEmpTlist", parms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var model = new TPDATaskEbankInfo();
                        model.TBdate = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBType = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBBname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.TBTlen = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                        model.TBFee = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public int SaveETask(string oper, string pno, string bno, string rno, string adate, string stime, string etime, int kilm, int fee, string eva)
        {
            SqlParameter[] parms = {
                new SqlParameter("@PNO",pno),
                new SqlParameter("@BNO",bno),
                new SqlParameter("@RNO",rno),
                new SqlParameter("@Stime",stime),
                new SqlParameter("@Etime",etime),
                new SqlParameter("@Kilm",kilm),
                new SqlParameter("@Fee",fee),
                new SqlParameter("@Eva",SqlDbType.Char,1),
                new SqlParameter("@Adate",adate),
                new SqlParameter("@Oper",oper)
            };
            parms[7].Value = char.Parse(eva);

            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SNP_SaveETask", parms);
        }

        #endregion
    }
}
