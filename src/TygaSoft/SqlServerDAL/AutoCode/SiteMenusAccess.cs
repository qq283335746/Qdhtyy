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
    public partial class SiteMenusAccess : ISiteMenusAccess
    {
        #region ISiteMenusAccess Member

        public int Insert(SiteMenusAccessInfo model)
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"insert into SiteMenusAccess (AccessId,OperationAccess,AccessType)
			            values
						(@AccessId,@OperationAccess,@AccessType)
			            ");

            SqlParameter[] parms = {
                                       new SqlParameter("@AccessId",SqlDbType.UniqueIdentifier),
new SqlParameter("@OperationAccess",SqlDbType.NText,1073741823),
new SqlParameter("@AccessType",SqlDbType.NVarChar,50)
                                   };
            parms[0].Value = model.AccessId;
            parms[1].Value = model.OperationAccess;
            parms[2].Value = model.AccessType;

            return SqlHelper.ExecuteNonQuery(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Update(SiteMenusAccessInfo model)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"update SiteMenusAccess set OperationAccess = @OperationAccess,AccessType = @AccessType 
			            where AccessId = @AccessId
					    ");

            SqlParameter[] parms = {
                                     new SqlParameter("@AccessId",SqlDbType.UniqueIdentifier),
new SqlParameter("@OperationAccess",SqlDbType.NText,1073741823),
new SqlParameter("@AccessType",SqlDbType.NVarChar,50)
                                   };
            parms[0].Value = model.AccessId;
            parms[1].Value = model.OperationAccess;
            parms[2].Value = model.AccessType;

            return SqlHelper.ExecuteNonQuery(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public int Delete(Guid accessId)
        {
            StringBuilder sb = new StringBuilder(250);
            sb.Append("delete from SiteMenusAccess where AccessId = @AccessId ");
            SqlParameter[] parms = {
                                     new SqlParameter("@AccessId",SqlDbType.UniqueIdentifier)
                                   };
            parms[0].Value = accessId;

            return SqlHelper.ExecuteNonQuery(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString(), parms);
        }

        public bool DeleteBatch(IList<object> list)
        {
            StringBuilder sb = new StringBuilder(500);
            ParamsHelper parms = new ParamsHelper();
            int n = 0;
            foreach (string item in list)
            {
                n++;
                sb.Append(@"delete from SiteMenusAccess where AccessId = @AccessId" + n + " ;");
                SqlParameter parm = new SqlParameter("@AccessId" + n + "", SqlDbType.UniqueIdentifier);
                parm.Value = Guid.Parse(item);
                parms.Add(parm);
            }

            return SqlHelper.ExecuteNonQuery(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString(), parms != null ? parms.ToArray() : null) > 0;
        }

        public SiteMenusAccessInfo GetModel(Guid accessId)
        {
            SiteMenusAccessInfo model = null;

            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select top 1 AccessId,OperationAccess,AccessType 
			            from SiteMenusAccess
						where AccessId = @AccessId ");
            SqlParameter[] parms = {
                                     new SqlParameter("@AccessId",SqlDbType.UniqueIdentifier)
                                   };
            parms[0].Value = accessId;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString(), parms))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model = new SiteMenusAccessInfo();
                        model.AccessId = reader.GetGuid(0);
                        model.OperationAccess = reader.GetString(1);
                        model.AccessType = reader.GetString(2);
                    }
                }
            }

            return model;
        }

        public IList<SiteMenusAccessInfo> GetList(int pageIndex, int pageSize, out int totalRecords, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select count(*) from SiteMenusAccess ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            totalRecords = (int)SqlHelper.ExecuteScalar(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString(), cmdParms);

            if (totalRecords == 0) return new List<SiteMenusAccessInfo>();

            sb.Clear();
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by AccessType) as RowNumber,
			          AccessId,OperationAccess,AccessType
					  from SiteMenusAccess ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<SiteMenusAccessInfo> list = new List<SiteMenusAccessInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SiteMenusAccessInfo model = new SiteMenusAccessInfo();
                        model.AccessId = reader.GetGuid(1);
                        model.OperationAccess = reader.GetString(2);
                        model.AccessType = reader.GetString(3);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<SiteMenusAccessInfo> GetList(int pageIndex, int pageSize, string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            sb.Append(@"select * from(select row_number() over(order by AccessType) as RowNumber,
			           AccessId,OperationAccess,AccessType
					   from SiteMenusAccess ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.AppendFormat(@")as objTable where RowNumber between {0} and {1} ", startIndex, endIndex);

            IList<SiteMenusAccessInfo> list = new List<SiteMenusAccessInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SiteMenusAccessInfo model = new SiteMenusAccessInfo();
                        model.AccessId = reader.GetGuid(1);
                        model.OperationAccess = reader.GetString(2);
                        model.AccessType = reader.GetString(3);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<SiteMenusAccessInfo> GetList(string sqlWhere, params SqlParameter[] cmdParms)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append(@"select AccessId,OperationAccess,AccessType
                        from SiteMenusAccess ");
            if (!string.IsNullOrEmpty(sqlWhere)) sb.AppendFormat(" where 1=1 {0} ", sqlWhere);
            sb.Append("order by AccessType ");

            IList<SiteMenusAccessInfo> list = new List<SiteMenusAccessInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString(), cmdParms))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SiteMenusAccessInfo model = new SiteMenusAccessInfo();
                        model.AccessId = reader.GetGuid(0);
                        model.OperationAccess = reader.GetString(1);
                        model.AccessType = reader.GetString(2);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public IList<SiteMenusAccessInfo> GetList()
        {
            StringBuilder sb = new StringBuilder(300);
            sb.Append(@"select AccessId,OperationAccess,AccessType 
			            from SiteMenusAccess
					    order by AccessType ");

            IList<SiteMenusAccessInfo> list = new List<SiteMenusAccessInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.AspnetDbConnString, CommandType.Text, sb.ToString()))
            {
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SiteMenusAccessInfo model = new SiteMenusAccessInfo();
                        model.AccessId = reader.GetGuid(0);
                        model.OperationAccess = reader.GetString(1);
                        model.AccessType = reader.GetString(2);

                        list.Add(model);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
