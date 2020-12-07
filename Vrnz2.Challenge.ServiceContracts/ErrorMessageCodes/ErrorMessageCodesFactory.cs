using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Vrnz2.Challenge.ServiceContracts.ErrorMessageCodes
{
    public class ErrorMessageCodesFactory
    {
        #region Cosntants 

        public const string UNEXPECTED_ERROR = "ERROR_00000";
        public const string INVALID_CUSTOMER_NAME_ERROR = "CREATE_CUSTOMER_00001";
        public const string INVALID_ITR_ERROR = "CREATE_CUSTOMER_00002";
        public const string INVALID_CUSTOMER_RESIDENCE_STATE_ERROR = "CREATE_CUSTOMER_00003";

        #endregion

        #region Variables

        private static ErrorMessageCodesFactory _instance;

        #endregion

        #region Constructors

        private ErrorMessageCodesFactory() { Init(); }

        #endregion

        #region Attributes

        public static ErrorMessageCodesFactory Instance 
        {
            get 
            {
                _instance = _instance ?? new ErrorMessageCodesFactory();

                return _instance;
            }
        }

        public string LocaleName { get; private set; }

        public List<ErrorMessage> ErrorMessages { get; private set; }

        #endregion

        #region Methods

        private void Init() 
        {
            var culture = Thread.CurrentThread.CurrentCulture;

            var errorMessages = JsonConvert.DeserializeObject<ErrorMessages>(File.ReadAllText("error_messages.json"));

            var currentErrorMessage = errorMessages.LocaleMessages.First(e => e.LocaleName.Equals(culture.Name));

            LocaleName = currentErrorMessage.LocaleName;
            ErrorMessages = currentErrorMessage.Messages;
        }

        public string GetMessage(string errorCode)
        {
            if (ErrorMessages.Any(e => e.Code.Equals(errorCode)))
                return ErrorMessages.FirstOrDefault(e => e.Code.Equals(errorCode)).Message;
            else
                return string.Empty;
        }

        #endregion
    }
}