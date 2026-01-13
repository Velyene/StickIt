using System.ComponentModel.DataAnnotations;

namespace ELKH.Models
{
    public class Transaction
    {
        [Key]
        public int PkTransactionId { get; set; }
        [Display(Name = "Transaction Status")]
        public string TransactionStatus { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Amount { get; set; } = 0;
        [Display(Name ="Transaction Time")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        //Relationship with Order
        public Order Order { get; set; } = new Order();

    }
}
