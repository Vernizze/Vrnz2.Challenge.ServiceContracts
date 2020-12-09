using MediatR;
using System;
using System.Collections.Generic;
using Vrnz2.Challenge.ServiceContracts.UseCases.Models.Base;
using Vrnz2.Infra.CrossCutting.Extensions;
using T = Vrnz2.Infra.CrossCutting.Types;

namespace Vrnz2.Challenge.ServiceContracts.UseCases.Models
{
    public class GetCustomerPaymentsModel
    {
        public class Request
            : BaseRequestModel, IRequest<Response>
        {
            public Request() { }

            public Request(string cpf, string monthRefPaymentDate)
            {
                Cpf = cpf;
                PaymentDate = GetRefDueDate(monthRefPaymentDate);
            }

            public string Cpf { get; set; }
            public string PaymentDate { get; set; }

            public bool IsValid()
            {
                var cpfIsEmpty = string.IsNullOrEmpty(Cpf);
                var dueDateIsEmpty = string.IsNullOrEmpty(PaymentDate);

                var result = (!cpfIsEmpty || !dueDateIsEmpty);
                result = result && ((cpfIsEmpty || T.Cpf.IsValid(Cpf)) && (dueDateIsEmpty || PaymentDate.IsDate()));

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
            public string Cpf { get; set; }

            public string PaymentPeriod { get; set; }

            public decimal TotalValue { get; set; }
        }
    }
}
