using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public interface IAccountTypeDataService
    {
        AccountType SelectByAccountTypeId(byte accountTypeId);
    }

    public partial class AccountTypeDataService : IAccountTypeDataService
    {
        public virtual AccountType SelectByAccountTypeId(byte accountTypeId)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                DataRow dataRow = dataContext.ExecuteDataRow("Security.AccountType_SelectByAccountTypeId", CommandType.StoredProcedure, new Parameter("AccountTypeId", SqlDbType.TinyInt, accountTypeId));

                return dataRow == null ? null : new AccountType(dataRow.Field<byte>("AccountTypeId"), dataRow.Field<string>("Code"), dataRow.Field<string>("Name"));
            }
        }
    }
}
