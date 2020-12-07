using System;
using System.Collections.Generic;

namespace Vrnz2.Challenge.ServiceContracts.UseCases.Models.Base
{
    public abstract class BaseResponseModel<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public List<Exception> Exceptions { get; set; }

        public List<string> ValidationFaults { get; set; }

        public T Content { get; set; }
    }
}
