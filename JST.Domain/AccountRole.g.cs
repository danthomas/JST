using System;

namespace JST.Domain
{
    public class AccountRole
    {
        public AccountRole(short accountRoleId, byte roleId, short accountId)
        {
            AccountRoleId = accountRoleId;
            RoleId = roleId;
            AccountId = accountId;
        }
    
        public short AccountRoleId { get; set; }
        public byte RoleId { get; set; }
        public short AccountId { get; set; }
    }
}