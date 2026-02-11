
namespace ELKH.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string DeliveryStatus { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; } = 0;
    }
}
