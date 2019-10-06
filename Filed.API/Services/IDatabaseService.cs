using Filed.API.Models;
using Filed.API.Util;

namespace Filed.API.Services
{
    public interface IDatabaseService
    {
        void SaveToDatabase(PaymentEntity payment);
        void UpdatePaymentStatus(int paymentId, PaymentState state);
    }
}
