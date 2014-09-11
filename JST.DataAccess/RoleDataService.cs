using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface IRoleDataService
    {
        IEnumerable<Role> SelectForAccountId(short accountId);
    }

    public partial class RoleDataService
    {
        public IEnumerable<Role> SelectForAccountId(short accountId)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                return dataContext.ExecuteDataTable("Security.Role_SelectForAccountId", CommandType.StoredProcedure, new Parameter("AccountId", SqlDbType.SmallInt, accountId))
                    .Rows.Cast<DataRow>().Select(item => new Role(item.Field<byte>("RoleId"), item.Field<string>("Code"), item.Field<string>("Name")));
            }
        }
    }
}
