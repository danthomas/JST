using System;

namespace JST.Domain
{
    public class Role
    {
        public Role(byte roleId, string code, string name)
        {
            RoleId = roleId;
            Code = code;
            Name = name;
        }
    
        public byte RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}