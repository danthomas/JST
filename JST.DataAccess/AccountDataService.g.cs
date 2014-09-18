using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public partial interface IAccountDataService
    {
        void Insert(JstDataContext dataContext, Domain.Account account);

        void Update(JstDataContext dataContext, Domain.Account account);

        void DeleteMany(JstDataContext dataContext, params short[] ids);

        Account SelectByAccountId(JstDataContext dataContext, short accountId);

        Account SelectByAccountName(JstDataContext dataContext, string accountName);
    }

    public partial class AccountDataService : IAccountDataService
    {
        public virtual void Insert(JstDataContext dataContext, Domain.Account account)
        {
            account.AccountId = dataContext.ExecuteScalar<short>("Security.Account_Insert", CommandType.StoredProcedure, new Parameter("AccountName", SqlDbType.VarChar, account.AccountName), new Parameter("DisplayName", SqlDbType.VarChar, account.DisplayName), new Parameter("Email", SqlDbType.VarChar, account.Email), new Parameter("Password", SqlDbType.VarChar, account.Password), new Parameter("ChangePassword", SqlDbType.Bit, account.ChangePassword), new Parameter("IsActive", SqlDbType.Bit, account.IsActive));
        }

        public virtual void Update(JstDataContext dataContext, Domain.Account account)
        {
            dataContext.ExecuteNonQuery("Security.Account_Update", CommandType.StoredProcedure, new Parameter("AccountId", SqlDbType.SmallInt, account.AccountId), new Parameter("AccountName", SqlDbType.VarChar, account.AccountName), new Parameter("DisplayName", SqlDbType.VarChar, account.DisplayName), new Parameter("Email", SqlDbType.VarChar, account.Email), new Parameter("Password", SqlDbType.VarChar, account.Password), new Parameter("ChangePassword", SqlDbType.Bit, account.ChangePassword), new Parameter("IsActive", SqlDbType.Bit, account.IsActive));            
        }

        public virtual void DeleteMany(JstDataContext dataContext, params short[] ids)
        {
            dataContext.ExecuteNonQuery("Security.Account_DeleteMany", CommandType.StoredProcedure, new Parameter("Ids", SqlDbType.Binary, ids.ToByteArray()));            
        }

        public virtual Account SelectByAccountId(JstDataContext dataContext, short accountId)
        {
            DataRow dataRow = dataContext.ExecuteDataRow("Security.Account_SelectByAccountId", CommandType.StoredProcedure, new Parameter("AccountId", SqlDbType.SmallInt, accountId));

            return dataRow == null ? null : new Account(dataRow.Field<short>("AccountId"), dataRow.Field<string>("AccountName"), dataRow.Field<string>("DisplayName"), dataRow.Field<string>("Email"), dataRow.Field<string>("Password"), dataRow.Field<bool>("ChangePassword"), dataRow.Field<bool>("IsActive"));
        }

        public virtual Account SelectByAccountName(JstDataContext dataContext, string accountName)
        {
            DataRow dataRow = dataContext.ExecuteDataRow("Security.Account_SelectByAccountName", CommandType.StoredProcedure, new Parameter("AccountName", SqlDbType.VarChar, accountName));

            return dataRow == null ? null : new Account(dataRow.Field<short>("AccountId"), dataRow.Field<string>("AccountName"), dataRow.Field<string>("DisplayName"), dataRow.Field<string>("Email"), dataRow.Field<string>("Password"), dataRow.Field<bool>("ChangePassword"), dataRow.Field<bool>("IsActive"));
        }
    }
}