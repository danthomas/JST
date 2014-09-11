using System;

namespace JST.Domain
{
    public class Session
    {
        public Session(Guid sessionId, short accountId, DateTime startDateTime, string client)
        {
            SessionId = sessionId;
            AccountId = accountId;
            StartDateTime = startDateTime;
            Client = client;
        }
    
        public Guid SessionId { get; set; }
        public short AccountId { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Client { get; set; }
    }
}