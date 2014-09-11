using System;

namespace JST.Business.Models
{
    public class Session
    {
        public Session(Guid sessionId, string displayName, string[] roleCodes)
        {
            SessionId = sessionId;
            DisplayName = displayName;
            RoleCodes = roleCodes;
        }

        public Guid SessionId { get; set; }
        public string DisplayName { get; set; }
        public string[] RoleCodes { get; set; }
    }
}