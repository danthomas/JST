using System;

namespace JST.Domain
{
    public class Account
    {
        public Account(short accountId, string accountName, string displayName, string password)
        {
            AccountId = accountId;
            AccountName = accountName;
            DisplayName = displayName;
            Password = password;
        }
    
        public short AccountId { get; set; }
        public string AccountName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }
}