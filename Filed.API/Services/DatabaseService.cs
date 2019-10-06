using Filed.API.Context;
using Filed.API.Models;
using Filed.API.Util;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Filed.API.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DatabaseContext _context;

        public DatabaseService(DatabaseContext context)
        {
            _context = context;
        }

        public void UpdatePaymentStatus(int paymentId, PaymentState state)
        {
            var payment = _context.Payments.Where(x => x.PaymentId == paymentId).Include(x => x.PaymentDetails).FirstOrDefault();
            payment.PaymentDetails.State = state;
            _context.Add(payment);
            _context.SaveChanges();

        }
        public void SaveToDatabase(PaymentEntity payment)
        {
            _context.Add(payment);
            _context.SaveChanges();
        }
    }
}
