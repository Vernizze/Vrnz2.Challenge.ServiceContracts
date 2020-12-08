using MediatR;
using System;
using Vrnz2.Challenge.ServiceContracts.UseCases.Models.Base;

namespace Vrnz2.Challenge.ServiceContracts.UseCases.Models
{
    public class CreateCustomerModel
    {
        public class Request
            : BaseRequestModel, IRequest<Response>
        {
            public string Name { get; set; }
            public string Cpf { get; set; }
            public string State { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }

            public string Message { get; set; }

            public Guid ClientUniqueId { get; set; }
        }
    }
}
