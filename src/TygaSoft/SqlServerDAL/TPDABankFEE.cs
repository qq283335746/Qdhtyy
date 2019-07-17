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
    public partial class TPDABankFEE
    {
        #region ITPDABankFEE Member

        public IList<TPDABankFEEInfo> GetFeeQ(string amon, string btype, string pno,string bno)
        {
            SqlParameter[] parms = {
                new SqlParameter("@PNO",pno),
                new SqlParameter("@AMON",amon),
                new SqlParameter("@Btype",btype)
            };

            var list = new List<TPDABankFEEInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString,CommandType.StoredProcedure, "SDP_GetFeeQ", parms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var model = new TPDABankFEEInfo();
                        model.TBdate = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.TBFName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.TBFee = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        model.TBnotes = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                 
                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
