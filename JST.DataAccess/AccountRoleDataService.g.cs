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
        void Insert(JstDataContext dataContext, Domain.AccountRole accountRole);

        AccountRole SelectByAccountId(JstDataContext dataContext, short accountId);
    }

    public partial class AccountRoleDataService : IAccountRoleDataService
    {
        public virtual void Insert(JstDataContext dataContext, Domain.AccountRole accountRole)
        {
            accountRole.AccountRoleId = dataContext.ExecuteScalar<short>("Security.AccountRole_Insert", CommandType.StoredProcedure, new Parameter("RoleId", SqlDbType.TinyInt, accountRole.RoleId), new Parameter("AccountId", SqlDbType.SmallInt, accountRole.AccountId));
        }

        public virtual AccountRole SelectByAccountId(JstDataContext dataContext, short accountId)
        {
            DataRow dataRow = dataContext.ExecuteDataRow("Security.AccountRole_SelectByAccountId", CommandType.StoredProcedure, new Parameter("AccountId", SqlDbType.SmallInt, accountId));

            return dataRow == null ? null : new AccountRole(dataRow.Field<short>("AccountRoleId"), dataRow.Field<byte>("RoleId"), dataRow.Field<short>("AccountId"));
        }
    }
}