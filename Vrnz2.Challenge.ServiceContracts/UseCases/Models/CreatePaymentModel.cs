using MediatR;
using System;
using Vrnz2.Challenge.ServiceContracts.UseCases.Models.Base;
using Vrnz2.Infra.CrossCutting.Extensions;
using T = Vrnz2.Infra.CrossCutting.Types;

namespace Vrnz2.Challenge.ServiceContracts.UseCases.Models
{
    public class CreatePaymentModel
    {
        public class Request
            : BaseRequestModel, IRequest<Response>
        {
            public string Cpf { get; set; }

            public string DueDate { get; set; }
            
            public string Value { get; set; }

            public bool IsValid()
            {
                var result = false;

                result = T.Cpf.IsValid(Cpf);
                result = result && DueDate.IsDate();
                result = result && T.Money.IsValid(Value);

                return result;
            }
        }

        public class Response
        {
            public bool Success { get; set; }

            public string Message { get; set; }

            public Guid Tid { get; set; }
        }
    }
}