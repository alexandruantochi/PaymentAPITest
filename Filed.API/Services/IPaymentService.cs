using Filed.API.Models;

namespace Filed.API.Services
{
    public interface IPaymentService
    {
        void PerformPayment(PaymentModel payment);
    }
}
