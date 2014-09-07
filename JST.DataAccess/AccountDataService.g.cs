using System;
using System.Collections.Generic;
using System.Data;
using DTS.AppFramework.Core;
using JST.Core;
using JST.Domain;

namespace JST.DataAccess
{
    public interface IAccountDataService
    {
        void Insert(Account account);

        void Update(Account account);

        void DeleteMany(params short[] ids);

        Account SelectByAccountId(short accountId);

        Account SelectByAccountName(string accountName);
    }

    public partial class AccountDataService : IAccountDataService
    {
        public virtual void Insert(Account account)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                account.AccountId = dataContext.ExecuteScalar<short>("Security.Account_Insert", CommandType.StoredProcedure, new Parameter("AccountId", SqlDbType.SmallInt, account.AccountId), new Parameter("AccountTypeId", SqlDbType.TinyInt, account.AccountTypeId), new Parameter("AccountName", SqlDbType.VarChar, account.AccountName), new Parameter("DisplayName", SqlDbType.VarChar, account.DisplayName), new Parameter("Password", SqlDbType.VarChar, account.Password));
            }
        }

        public virtual void Update(Account account)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                dataContext.ExecuteNonQuery("Security.Account_Update", CommandType.StoredProcedure, new Parameter("AccountId", SqlDbType.SmallInt, account.AccountId), new Parameter("AccountTypeId", SqlDbType.TinyInt, account.AccountTypeId), new Parameter("AccountName", SqlDbType.VarChar, account.AccountName), new Parameter("DisplayName", SqlDbType.VarChar, account.DisplayName), new Parameter("Password", SqlDbType.VarChar, account.Password));
            }
        }

        public virtual void DeleteMany(params short[] ids)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                dataContext.ExecuteNonQuery("Security.Account_DeleteMany", CommandType.StoredProcedure, new Parameter("Ids", SqlDbType.Binary, ids.ToByteArray()));
            }
        }

        public virtual Account SelectByAccountId(short accountId)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                DataRow dataRow = dataContext.ExecuteDataRow("Security.Account_SelectByAccountId", CommandType.StoredProcedure, new Parameter("AccountId", SqlDbType.SmallInt, accountId));

                return dataRow == null ? null : new Account(dataRow.Field<short>("AccountId"), dataRow.Field<byte>("AccountTypeId"), dataRow.Field<string>("AccountName"), dataRow.Field<string>("DisplayName"), dataRow.Field<string>("Password"));
            }
        }

        public virtual Account SelectByAccountName(string accountName)
        {
            using (JstDataContext dataContext = new JstDataContext())
            {
                DataRow dataRow = dataContext.ExecuteDataRow("Security.Account_SelectByAccountName", CommandType.StoredProcedure, new Parameter("AccountName", SqlDbType.VarChar, accountName));

                return dataRow == null ? null : new Account(dataRow.Field<short>("AccountId"), dataRow.Field<byte>("AccountTypeId"), dataRow.Field<string>("AccountName"), dataRow.Field<string>("DisplayName"), dataRow.Field<string>("Password"));
            }
        }
    }
}
