using System;

namespace Vrnz2.Challenge.ServiceContracts.Responses.Management.Clients
{
    public class PingController
    {
        public class Ping
        {
            public string ServiceDateTime { get; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:mm");
            public string ServiceName { get; } = AppDomain.CurrentDomain.FriendlyName;
        }
    }
}
