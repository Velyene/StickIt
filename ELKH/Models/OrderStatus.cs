using System.ComponentModel.DataAnnotations;

namespace ELKH.Models
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;

        //Order Relationshiop
        public int FkOrderId { get; set; }
        public Order Order { get; set; } = new Order();
    }
}
