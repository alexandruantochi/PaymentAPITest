using Filed.API.Payments.MockInterfaces;

namespace Filed.API.Payments
{
    public class CheapPayment : IPaymentStrategy
    {
        private readonly ICheapPaymentGateway paymentProcessor = new ICheapPaymentGateway();
        private readonly decimal _amount;

        public CheapPayment(decimal amount)
        {
            _amount = amount;
        }
        public bool ExecutePayment()
        {
            return paymentProcessor.ExecutePayment();
        }
    }
}
