using Filed.API.Payments.MockInterfaces;
using System;
using System.Threading.Tasks;

namespace Filed.API.Payments
{
    public class PremiumPayment : IPaymentStrategy
    {
        IExpensivePaymentGateway expensivePayment = new IExpensivePaymentGateway();
        private readonly TimeSpan delay = TimeSpan.FromSeconds(5);
        private const int retries = 3;
        private readonly decimal _amount;

        public PremiumPayment(decimal amount)
        {
            _amount = amount;
        }

        public bool ExecutePayment()
        {
            for (int i = 0; i < retries; i++)
            {
                if (expensivePayment.ExecutePayment())
                {
                    return true;
                }
                else
                {
                    Task.Delay(delay * i);
                }
            }
            return false;
        }
    }
}
