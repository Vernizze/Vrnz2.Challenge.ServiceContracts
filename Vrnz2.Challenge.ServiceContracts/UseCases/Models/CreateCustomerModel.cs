using FluentValidation;
using MediatR;
using System;
using Vrnz2.Challenge.ServiceContracts.ErrorMessageCodes;
using Vrnz2.Challenge.ServiceContracts.UseCases.Models.Base;
using Vrnz2.Infra.Crosscutting.Types;

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

        public class RequestValidator 
            : AbstractValidator<Request>
        {
            public RequestValidator() 
            {
                RuleFor(v => v.Name)
                    .NotEmpty()
                    .WithMessage(ErrorMessageCodesFactory.INVALID_CUSTOMER_NAME_ERROR);

                RuleFor(v => v.Cpf)
                    .Must(Cpf.IsValid)
                    .WithMessage(ErrorMessageCodesFactory.INVALID_ITR_ERROR);

                RuleFor(v => v.Cpf)
                    .NotEmpty()
                    .WithMessage(ErrorMessageCodesFactory.INVALID_CUSTOMER_RESIDENCE_STATE_ERROR);
            }
        }

        public class Response
            : BaseResponseModel<Response>
        {
            public Guid ClientUniqueId { get; set; }            
        }
    }
}
