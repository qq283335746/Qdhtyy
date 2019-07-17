using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TygaSoft.IDAL;
using TygaSoft.Model;
using TygaSoft.DALFactory;

namespace TygaSoft.BLL
{
    public partial class FeatureUser
    {
        #region FeatureUser Member

        public FeatureUserInfo GetModel(Guid userId, string typeName)
        {
            return dal.GetModel(userId, typeName);
        }

        #endregion
    }
}
