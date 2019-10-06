using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filed.API.Models
{
    public class PaymentModel : IValidatableObject
    {
        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        [Required(ErrorMessage = "Credit card number required.", ErrorMessageResourceName = nameof(CreditCardNumber))]
        public string CreditCardNumber { get; set; }
        [Required(ErrorMessage = "Card holder name required.", ErrorMessageResourceName = nameof(CardHolder))]
        public string CardHolder { get; set; }
        [Required(ErrorMessage = "Expiration date required.", ErrorMessageResourceName = nameof(ExpirationDate))]
        [DataType(DataType.Date, ErrorMessage = "Invalid expiration date format.", ErrorMessageResourceName = nameof(ExpirationDate))]
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        [Required(ErrorMessage = "Transfer amount required.", ErrorMessageResourceName = nameof(Amount))]
        public decimal Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // utsnow is later than expiration date
            if ((DateTime.Compare(DateTime.UtcNow, ExpirationDate.ToUniversalTime())) > 0)
            {
                yield return new ValidationResult("Expiry date is later than today.");
            }

            if (!string.IsNullOrEmpty(SecurityCode))
            {
                if (SecurityCode.Length != 3 || !int.TryParse(SecurityCode, out int result) || result < 0)
                {
                    yield return new ValidationResult("Invalid security code.");
                }
            }

            if (Amount <= decimal.Zero)
            {
                yield return new ValidationResult("Transfer amount can not be negative.");
            }
        }
    }
}
