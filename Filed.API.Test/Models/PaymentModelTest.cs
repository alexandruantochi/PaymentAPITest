using Filed.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace File.API.Test.Models
{
    public class PaymentModelTest
    {
        [Fact]
        public void PaymentModelValidationPassesWithCorrectParams()
        {
            PaymentModel paymentModel = new PaymentModel()
            {
                CardHolder = "Alexandru Antochi",
                CreditCardNumber = "4111 1111 1111 1111",
                ExpirationDate = DateTime.Parse("2020/01/01"),
                Amount = 50,
                SecurityCode = ""
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(paymentModel, new ValidationContext(paymentModel), validationResults, true);

            Assert.True(actual);
        }

        [Fact]
        public void PaymentModelValidationFailsWithWrongDate()
        {
            PaymentModel paymentModel = new PaymentModel()
            {
                CardHolder = "Alexandru Antochi",
                CreditCardNumber = "4111 1111 1111 1111",
                ExpirationDate = DateTime.Parse("2008/01/01"),
                Amount = 50,
                SecurityCode = ""
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(paymentModel, new ValidationContext(paymentModel), validationResults, true);

            Assert.False(actual);
        }

    }
}
