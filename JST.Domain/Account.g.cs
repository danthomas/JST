using System;

namespace JST.Domain
{
    public class Account
    {
        public Account(short accountId, byte accountTypeId, string accountName, string displayName, string password)
        {
            AccountId = accountId;
            AccountTypeId = accountTypeId;
            AccountName = accountName;
            DisplayName = displayName;
            Password = password;
        }
    
        public short AccountId { get; set; }
        public byte AccountTypeId { get; set; }
        public string AccountName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}