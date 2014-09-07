using System;

namespace JST.Domain
{
    public class AccountType
    {
        public AccountType(byte accountTypeId, string code, string name)
        {
            AccountTypeId = accountTypeId;
            Code = code;
            Name = name;
        }
    
        public byte AccountTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}