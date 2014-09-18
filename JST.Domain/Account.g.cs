using System;

namespace JST.Domain
{
    public class Account
    {
        public Account(short accountId, string accountName, string displayName, string email, string password, bool changePassword, bool isActive)
        {
            AccountId = accountId;
            AccountName = accountName;
            DisplayName = displayName;
            Email = email;
            Password = password;
            ChangePassword = changePassword;
            IsActive = isActive;
        }
    
        public short AccountId { get; set; }
        public string AccountName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ChangePassword { get; set; }
        public bool IsActive { get; set; }
    }
}