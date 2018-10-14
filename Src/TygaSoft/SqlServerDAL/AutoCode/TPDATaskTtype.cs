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
    public partial class TPDATaskTtype : ITPDATaskTtype
    {
        #region ITPDATaskTtype Member

        public int Insert(TPDATaskTtypeInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into TPDA_TaskTtype (TID,Tname)
			            values
						(@TID,@Tname)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@TID",SqlDbType.Char,1),
new SqlParameter("@Tname",SqlDbType.VarChar,10)
                                   };
            parms[0].Value = model.TID;
            parms[1].Value = model.Tname;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(TPDATaskTtypeInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update TPDA_TaskTtype set Tname = @Tname 
			            where TID = @TID
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@TID",SqlDbType.Char,1),
new SqlParameter("@Tname",SqlDbType.VarChar,10)
                                   };
            parms[0].Value = model.TID;
            parms[1].Value = model.Tname;

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(string tID)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from TPDA_TaskTtype where TID = @TID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@TID",SqlDbType.Char,1)
                                   };
            parms[0].Value = tID;

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
                sb.Append(@"delete from TPDA_TaskTtype where TID = @TID" + n + " ;");
                SqlParameter parm = new SqlParameter("@TID" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public TPDATaskTtypeInfo GetModel(string tID)
        {
            TPDATaskTtypeInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 TID,Tname 
			            from TPDA_TaskTtype
						where TID = @TID ");
            SqlParameter[] parms = {
                                     new SqlParameter("@TID",SqlDbType.Char,1)
                                   };
            parms[0].Value = tID;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), parms))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model = new TPDATaskTtypeInfo();
                        model.TID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.Tname = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    }
                }
            }

            return model;
        }

        public IList<TPDATaskTtypeInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from TPDA_TaskTtype ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<TPDATaskTtypeInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TID) as RowNumber,
			          TID,Tname
					  from TPDA_TaskTtype ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDATaskTtypeInfo> list = new List<TPDATaskTtypeInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskTtypeInfo model = new TPDATaskTtypeInfo();
                        model.TID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.Tname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskTtypeInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by TID) as RowNumber,
			           TID,Tname
					   from TPDA_TaskTtype ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<TPDATaskTtypeInfo> list = new List<TPDATaskTtypeInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskTtypeInfo model = new TPDATaskTtypeInfo();
                        model.TID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        model.Tname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskTtypeInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select TID,Tname
                        from TPDA_TaskTtype ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by TID ");

            IList<TPDATaskTtypeInfo> list = new List<TPDATaskTtypeInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskTtypeInfo model = new TPDATaskTtypeInfo();
                        model.TID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.Tname = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<TPDATaskTtypeInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select TID,Tname 
			            from TPDA_TaskTtype
					    order by TID ");

            IList<TPDATaskTtypeInfo> list = new List<TPDATaskTtypeInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.QdhtyyDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TPDATaskTtypeInfo model = new TPDATaskTtypeInfo();
                        model.TID = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        model.Tname = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
