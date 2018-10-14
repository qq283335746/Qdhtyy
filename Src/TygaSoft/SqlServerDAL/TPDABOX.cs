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
    public partial class TPDABOX
    {
        #region ITPDABOX Member
        
        public IList<TPDABOXInfo> GetBoxs(string pno,string bno)
        {
            SqlParameter[] parms = {
                new SqlParameter("@PNO",pno),
                new SqlParameter("@Bno",bno),
            };
            var list = new List<TPDABOXInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SNP_GetBOXList", parms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var model = new TPDABOXInfo();
                        model.BoxCID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.BoxNo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.BoxBno = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.BoxType = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.BoxPdate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.BoxState = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.BoxDcid = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.BoxDBno = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);

                        byte boxType = 0;
                        byte.TryParse(model.BoxType, out boxType);
                        model.BoxTypeName = Enum.GetName(typeof(EnumData.OType), boxType);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public int SaveBoxInfo(string pno, string bno, string oper, string boxno, string btype, string pdate, string tocid, string tobno)
        {
            SqlParameter[] parms = {
                new SqlParameter("@PNO",pno),
                new SqlParameter("@Bno",bno),
                new SqlParameter("@Oper",oper),
                new SqlParameter("@BoxNO",boxno),
                new SqlParameter("@Btype",btype),
                new SqlParameter("@Pdate",pdate),
                new SqlParameter("@ToCID",tocid),
                new SqlParameter("@ToBno",tobno)
            };
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.StoredProcedure, "SNP_ModiBox", parms);
        }

        #endregion
    }
}
