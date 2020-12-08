namespace Vrnz2.Challenge.ServiceContracts.Notifications
{
    public class PaymentNotification
    {
        public class Created
        {
            public string Cpf { get; set; }
            public decimal Value { get; set; }
        }
    }
}
