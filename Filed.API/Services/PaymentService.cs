using System;
using AutoMapper;
using Filed.API.Models;
using Filed.API.Payments;
using Filed.API.Util;

namespace Filed.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IDatabaseService _databaseService;

        public PaymentService(IMapper mapper, IDatabaseService databaseService)
        {
            _mapper = mapper;
            _databaseService = databaseService;
        }
        public void PerformPayment(PaymentModel payment)
        {
            var paymentStrategy = GetStrategy(payment.Amount);
            var paymentEntity = _mapper.Map<PaymentEntity>(payment);

            PaymentStateEntitiy paymentState = new PaymentStateEntitiy()
            {
                PaymentDate = DateTime.UtcNow,
                State = PaymentState.PENDING
            };

            paymentEntity.PaymentDetails = paymentState;
            _databaseService.SaveToDatabase(paymentEntity);

            if (paymentStrategy.ExecutePayment())
            {
                paymentState.State = PaymentState.PROCESSED;
            }
            else
            {
                paymentState.State = PaymentState.FAILED;
            }

            _databaseService.UpdatePaymentStatus(paymentEntity.PaymentId, paymentState.State);
        }

        public IPaymentStrategy GetStrategy(decimal amount)
        {
            if (amount <= 20)
            {
                return new CheapPayment(amount);
            }
            if (amount > 20 && amount <= 500)
            {
                return new ExpensivePayment(amount);
            }
            return new PremiumPayment(amount);
        }
    }
}
