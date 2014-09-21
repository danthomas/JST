using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface IRoleDataService
    {
        Role SelectByCode(JstDataContext dataContext, string code);
    }

    public partial class RoleDataService : IRoleDataService
    {
        public virtual Role SelectByCode(JstDataContext dataContext, string code)
        {
            DataRow dataRow = dataContext.ExecuteDataRow("Security.Role_SelectByCode", CommandType.StoredProcedure, new Parameter("Code", SqlDbType.VarChar, code));

            return dataRow == null ? null : new Role(dataRow.Field<byte>("RoleId"), dataRow.Field<string>("Code"), dataRow.Field<string>("Name"));
        }
    }
}