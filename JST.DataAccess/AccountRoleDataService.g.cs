using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface IAccountRoleDataService
    {
        AccountRole SelectByAccountId(short accountId);
    }

    public partial class AccountRoleDataService : IAccountRoleDataService
    {
        public virtual AccountRole SelectByAccountId(short accountId)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                DataRow dataRow = dataContext.ExecuteDataRow("Security.AccountRole_SelectByAccountId", CommandType.StoredProcedure, new Parameter("AccountId", SqlDbType.SmallInt, accountId));

                return dataRow == null ? null : new AccountRole(dataRow.Field<short>("AccountRoleId"), dataRow.Field<byte>("RoleId"), dataRow.Field<short>("AccountId"));
            }
        }
    }
}
