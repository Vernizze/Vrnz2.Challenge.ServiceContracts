using MediatR;
using System;

namespace Vrnz2.Challenge.ServiceContracts.UseCases.Models
{
    public class CreateClientModel
    {
        public class Request
            : IRequest<Response>
        {
            public string Name { get; set; }
            public string Cpf { get; set; }
            public string Estate { get; set; }
        }

        public class Response
        {
            public Guid ClientUniqueId { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }
        }
    }
}
