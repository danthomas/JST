using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface IAccountDataService
    {
        IEnumerable<Account> SelectAll(JstDataContext dataContext);
    }

    public partial class AccountDataService : IAccountDataService
    {
        public virtual IEnumerable<Account> SelectAll(JstDataContext dataContext)
        {
           return dataContext.ExecuteDataTable("Security.Account_SelectAll", CommandType.StoredProcedure).Rows.Cast<DataRow>()
                .Select(item => new Account(item.Field<short>("AccountId"),
                    item.Field<string>("AccountName"),
                    item.Field<string>("DisplayName"), 
                    item.Field<string>("Email"), 
                    item.Field<string>("Password"), 
                    item.Field<bool>("ChangePassword"), 
                    item.Field<bool>("IsActive")));
        }
    }
}