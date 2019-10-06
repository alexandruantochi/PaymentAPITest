
namespace Filed.API.Payments.MockInterfaces
{
    public class IExpensivePaymentGateway
    {
        public bool ExecutePayment() { return true; }
    }
}
