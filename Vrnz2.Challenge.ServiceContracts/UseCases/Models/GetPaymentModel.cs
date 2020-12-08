using MediatR;
using System;
using System.Collections.Generic;
using Vrnz2.Challenge.ServiceContracts.UseCases.Models.Base;
using Vrnz2.Infra.CrossCutting.Extensions;
using T = Vrnz2.Infra.CrossCutting.Types;

namespace Vrnz2.Challenge.ServiceContracts.UseCases.Models
{
    public class GetPaymentModel
    {
        public class Request
            : BaseRequestModel, IRequest<Response>
        {
            public Request() { }

            public Request(string cpf, string monthRefDueDate)
            {
                Cpf = cpf;
                DueDate = GetRefDueDate(monthRefDueDate);
            }

            public string Cpf { get; set; }
            public string DueDate { get; set; }

            public bool IsValid()
            {
                var cpfIsEmpty = string.IsNullOrEmpty(Cpf);
                var dueDateIsEmpty = string.IsNullOrEmpty(DueDate);

                var result = (!cpfIsEmpty || !dueDateIsEmpty);
                result = result && ((cpfIsEmpty || T.Cpf.IsValid(Cpf)) && (dueDateIsEmpty || DueDate.IsDate()));

                return result;
            }

            private string GetRefDueDate(string monthRefDueDate)
            {
                var result = string.Empty;

                if (!string.IsNullOrEmpty(monthRefDueDate)) 
                {
                    var splitedDate = monthRefDueDate.Split('-');

                    if (splitedDate.Length > 0 && DateTime.TryParse($"{splitedDate[0]}-{splitedDate[1]}-01 00:00:00", out DateTime parsedDate))
                        result = parsedDate.ToString("yyyy-MM-dd HH:mm:00");
                }               

                return result;
            }
        }

        public class Response
        {
            public List<ResponsePayments> Payments { get; set; }
        }

        public class ResponsePayments 
        {
            public Guid Tid { get; set; }

            public string Cpf { get; set; }

            public DateTime DueDate { get; set; }

            public decimal Value { get; set; }
        }
    }
}
