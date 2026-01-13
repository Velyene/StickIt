using System.ComponentModel.DataAnnotations;

namespace ELKH.Models
{
    public class OrderItem
    {
        [Key]
        public int PkOrderItemId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public decimal Price { get; set; } = 0;
        public int Quantity { get; set; } = 1;



        //Relationship with Order
        public int FkOrderId { get; set; }
        public Order Orders { get; set; } = new Order();
    }
}
