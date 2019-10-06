using Filed.API.Payments.MockInterfaces;

namespace Filed.API.Payments
{
    public class ExpensivePayment : IPaymentStrategy
    {
        private readonly IExpensivePaymentGateway expensivePayment = new IExpensivePaymentGateway();
        private readonly ICheapPaymentGateway cheapPayment = new ICheapPaymentGateway();
        private readonly decimal _amount;

        public ExpensivePayment(decimal amount)
        {
            _amount = amount;
        }
        public bool ExecutePayment()
        {
            if (expensivePayment.ExecutePayment())
            {
                return true;
            }
            return cheapPayment.ExecutePayment();
        }
    }
}
