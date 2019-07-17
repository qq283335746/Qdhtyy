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
    public partial class TPDABOX : ITPDABOX
    {
        #region ITPDABOX Member

        public int Insert(TPDABOXInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into TPDA_BOX (BoxCID,BoxNo,BoxBno,BoxType,BoxPdate,BoxScid,BoxSbno,BoxCstate,BoxDcid,BoxDBno,BoxOper,BoxOpTime,BoxState)
			            values
						(@BoxCID,@BoxNo,@BoxBno,@BoxType,@BoxPdate,@BoxScid,@BoxSbno,@BoxCstate,@BoxDcid,@BoxDBno,@BoxOper,@BoxOpTime,@BoxState)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@BoxCID",SqlDbType.Char,2),
new SqlParameter("@BoxNo",SqlDbType.VarChar,10),
new SqlParameter("@BoxBno",SqlDbType.VarChar,10),
new SqlParameter("@BoxType",SqlDbType.VarChar,1),
new SqlParameter("@BoxPdate",SqlDbType.VarChar,10),
new SqlParameter("@BoxScid",SqlDbType.Char,2),
new SqlParameter("@BoxSbno",SqlDbType.VarChar,10),
new SqlParameter("@BoxCstate",SqlDbType.Char,1),
new SqlParameter("@BoxDcid",SqlDbType.Char,2),
new SqlParameter("@BoxDBno",SqlDbType.VarChar,10),
new SqlParameter("@BoxOper",SqlDbType.VarChar,20),
new SqlParameter("@BoxOpTime",SqlDbType.DateTime),
new SqlParameter("@BoxState",SqlDbType.Char,1)
                                   };
            parms[0].Value = model.BoxCID;
            parms[1].Value = model.BoxNo;
            parms[2].Value = model.BoxBno;
            parms[3].Value = model.BoxType;
            parms[4].Value = model.BoxPdate;
            parms[5].Value = model.BoxScid;
            parms[6].Value = model.BoxSbno;
            parms[7].Value = model.BoxCstate;
            parms[8].Value = model.BoxDcid;
            parms[9].Value = model.BoxDBno;
            parms[10].Value = model.BoxOper;
            parms[11].Value = model.BoxOpTime;
            parms[12].Value = model.BoxState;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(TPDABOXInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update TPDA_BOX set BoxNo = @BoxNo,BoxBno = @BoxBno,BoxType = @BoxType,BoxPdate = @BoxPdate,BoxScid = @BoxScid,BoxSbno = @BoxSbno,BoxCstate = @BoxCstate,BoxDcid = @BoxDcid,BoxDBno = @BoxDBno,BoxOper = @BoxOper,BoxOpTime = @BoxOpTime,BoxState = @BoxState 
			            where BoxCID = @BoxCID
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@BoxCID",SqlDbType.Char,2),
new SqlParameter("@BoxNo",SqlDbType.VarChar,10),
new SqlParameter("@BoxBno",SqlDbType.VarChar,10),
new SqlParameter("@BoxType",SqlDbType.VarChar,1),
new SqlParameter("@BoxPdate",SqlDbType.VarChar,10),
new SqlParameter("@BoxScid",SqlDbType.Char,2),
new SqlParameter("@BoxSbno",SqlDbType.VarChar,10),
new SqlParameter("@BoxCstate",SqlDbType.Char,1),
new SqlParameter("@BoxDcid",SqlDbType.Char,2),
new SqlParameter("@BoxDBno",SqlDbType.VarChar,10),
new SqlParameter("@BoxOper",SqlDbType.VarChar,20),
new SqlParameter("@BoxOpTime",SqlDbType.DateTime),
new SqlParameter("@BoxState",SqlDbType.Char,1)
                                   };
            parms[0].Value = model.BoxCID;
            parms[1].Value = model.BoxNo;
            parms[2].Value = model.BoxBno;
            parms[3].Value = model.BoxType;
            parms[4].Value = model.BoxPdate;
            parms[5].Value = model.BoxScid;
            parms[6].Value = model.BoxSbno;
            parms[7].Value = model.BoxCstate;
            parms[8].Value = model.BoxDcid;
            parms[9].Value = model.BoxDBno;
            parms[10].Value = model.BoxOper;
            parms[11].Value = model.BoxOpTime;
            parms[12].Value = model.BoxState;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(string boxCID)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from TPDA_BOX where BoxCID = @BoxCID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@BoxCID",SqlDbType.Char,2)
                                   };
            parms[0].Value = boxCID;

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
                sb.Append(@"delete from TPDA_BOX where BoxCID = @BoxCID" + n + " ;");
                SqlParameter parm = new SqlParameter("@BoxCID" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public TPDABOXInfo GetModel(string boxCID)
        {
            TPDABOXInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 BoxCID,BoxNo,BoxBno,BoxType,BoxPdate,BoxScid,BoxSbno,BoxCstate,BoxDcid,BoxDBno,BoxOper,BoxOpTime,BoxState 
			            from TPDA_BOX
						where BoxCID = @BoxCID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@BoxCID",SqlDbType.Char,2)
                                   };
            parms[0].Value = boxCID;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model = new TPDABOXInfo();
                        model.BoxCID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.BoxNo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.BoxBno = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.BoxType = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.BoxPdate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.BoxScid = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.BoxSbno = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.BoxCstate = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.BoxDcid = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.BoxDBno = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.BoxOper = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.BoxOpTime = reader.IsDBNull(11) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(11);
                        model.BoxState = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                    }
                }
            }

            return model;
        }

        public IList<TPDABOXInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from TPDA_BOX ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<TPDABOXInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by BoxCID) as RowNumber,
			          BoxCID,BoxNo,BoxBno,BoxType,BoxPdate,BoxScid,BoxSbno,BoxCstate,BoxDcid,BoxDBno,BoxOper,BoxOpTime,BoxState
					  from TPDA_BOX ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDABOXInfo> list = new List<TPDABOXInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDABOXInfo model = new TPDABOXInfo();
                        model.BoxCID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.BoxNo = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.BoxBno = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.BoxType = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.BoxPdate = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.BoxScid = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.BoxSbno = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.BoxCstate = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.BoxDcid = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.BoxDBno = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.BoxOper = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.BoxOpTime = reader.IsDBNull(12) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(12);
                        model.BoxState = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDABOXInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by BoxCID) as RowNumber,
			           BoxCID,BoxNo,BoxBno,BoxType,BoxPdate,BoxScid,BoxSbno,BoxCstate,BoxDcid,BoxDBno,BoxOper,BoxOpTime,BoxState
					   from TPDA_BOX ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDABOXInfo> list = new List<TPDABOXInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDABOXInfo model = new TPDABOXInfo();
                        model.BoxCID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.BoxNo = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.BoxBno = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.BoxType = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.BoxPdate = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.BoxScid = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.BoxSbno = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.BoxCstate = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.BoxDcid = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.BoxDBno = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.BoxOper = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        model.BoxOpTime = reader.IsDBNull(12) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(12);
                        model.BoxState = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDABOXInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select BoxCID,BoxNo,BoxBno,BoxType,BoxPdate,BoxScid,BoxSbno,BoxCstate,BoxDcid,BoxDBno,BoxOper,BoxOpTime,BoxState
                        from TPDA_BOX ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by BoxCID ");

            IList<TPDABOXInfo> list = new List<TPDABOXInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDABOXInfo model = new TPDABOXInfo();
                        model.BoxCID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.BoxNo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.BoxBno = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.BoxType = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.BoxPdate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.BoxScid = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.BoxSbno = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.BoxCstate = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.BoxDcid = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.BoxDBno = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.BoxOper = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.BoxOpTime = reader.IsDBNull(11) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(11);
                        model.BoxState = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDABOXInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select BoxCID,BoxNo,BoxBno,BoxType,BoxPdate,BoxScid,BoxSbno,BoxCstate,BoxDcid,BoxDBno,BoxOper,BoxOpTime,BoxState 
			            from TPDA_BOX
					    order by BoxCID ");

            IList<TPDABOXInfo> list = new List<TPDABOXInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDABOXInfo model = new TPDABOXInfo();
                        model.BoxCID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.BoxNo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.BoxBno = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        model.BoxType = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        model.BoxPdate = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        model.BoxScid = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        model.BoxSbno = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        model.BoxCstate = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        model.BoxDcid = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        model.BoxDBno = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        model.BoxOper = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        model.BoxOpTime = reader.IsDBNull(11) ? DateTime.Parse("1754-01-01") : reader.GetDateTime(11);
                        model.BoxState = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
