using MediatR;
using System;

namespace Vrnz2.Challenge.ServiceContracts.Notifications
{
    public class CustomerNotification
    {
        public class Created
            : INotification
        {
            public DateTime CreationDate { get; set; }
            public string Cpf { get; set; }
            public string Name { get; set; }
        }        
    }
}
