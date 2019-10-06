
namespace Filed.API.Payments
{
    public interface IPaymentStrategy
    {
        bool ExecutePayment();
    }
}
