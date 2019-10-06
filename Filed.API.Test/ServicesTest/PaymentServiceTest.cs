using Filed.API.Payments;
using Filed.API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace File.API.Test.ServicesTest
{
    public class PaymentServiceTest
    {
        [Fact]
        public void LowAmountReturnsCheapStrategy()
        {
            decimal lowAmount = decimal.One;
            var service = new PaymentService(null, null);
            Assert.IsType<CheapPayment>(service.GetStrategy(lowAmount));
        }

        [Fact]
        public void MediumAmountReturnsExpensiveStrategy()
        {
            decimal amount = new decimal(50);
            var service = new PaymentService(null, null);
            Assert.IsType<ExpensivePayment>(service.GetStrategy(amount));
        }

        [Fact]
        public void HighAmountReturnsPremiumStrategy()
        {
            decimal highAmount = new decimal(500.1);
            var service = new PaymentService(null, null);
            Assert.IsType<PremiumPayment>(service.GetStrategy(highAmount));
        }

    }
}
