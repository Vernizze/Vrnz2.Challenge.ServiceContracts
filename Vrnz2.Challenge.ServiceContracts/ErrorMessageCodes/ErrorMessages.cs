using System.Collections.Generic;

namespace Vrnz2.Challenge.ServiceContracts.ErrorMessageCodes
{
    public class ErrorMessages
    {
        public List<LocaleErrorMessages> LocaleMessages { get; set; }
    }

    public class LocaleErrorMessages
    {
        public string LocaleName { get; set; }

        public List<ErrorMessage> Messages { get; set; }
    }

    public class ErrorMessage 
    {
        public string Code { get; set; }

        public string Message { get; set; }
    }
}