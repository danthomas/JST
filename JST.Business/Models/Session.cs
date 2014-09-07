using System;

namespace JST.Business.Models
{
    public class Session
    {
        public Session(Guid sessionId, string displayName, string accountTypeCode)
        {
            SessionId = sessionId;
            DisplayName = displayName;
            AccountTypeCode = accountTypeCode;
        }

        public Guid SessionId { get; set; }
        public string DisplayName { get; set; }
        public string AccountTypeCode { get; set; }
    }
}