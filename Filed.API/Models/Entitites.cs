using Filed.API.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filed.API.Models
{
    [Table("Payments")]
    public class PaymentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("PaymentStateId")]
        public int PaymentStateId { get; set; }
        public PaymentStateEntitiy PaymentDetails { get; set; }
    }

    [Table("PaymentStates")]
    public class PaymentStateEntitiy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentStateId { get; set; }
        public DateTime PaymentDate { get; set; }
        [ForeignKey("PaymentId")]
        public int PaymentId { get; set; }
        public PaymentState State { get; set; }
    }
}
