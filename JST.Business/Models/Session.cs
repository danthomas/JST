using System;
using System.Collections.Generic;

namespace JST.Business.Models
{
    public class Session
    {
        public Session(Guid sessionId, string displayName, string[] roleCodes, List<Route> routes)
        {
            SessionId = sessionId;
            DisplayName = displayName;
            RoleCodes = roleCodes;
            Routes = routes;
        }

        public Guid SessionId { get; set; }
        public string DisplayName { get; set; }
        public string[] RoleCodes { get; set; }
        public List<Route> Routes { get; set; }
    }
}