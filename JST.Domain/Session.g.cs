using System;

namespace JST.Domain
{
    public class Session
    {
        public Session(Guid sessionId, short accountId, DateTime startDateTime)
        {
            SessionId = sessionId;
            AccountId = accountId;
            StartDateTime = startDateTime;
        }
    
        public Guid SessionId { get; set; }
        public short AccountId { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}