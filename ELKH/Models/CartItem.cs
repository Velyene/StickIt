using System.ComponentModel.DataAnnotations;

namespace ELKH.Models
{
    public class CartItem
    {
        [Key]
        public int PkCartItemId { get; set; }
        //Set default quantity to one
        public int Quantities { get; set; } = 1;

        //Relationship with Cart
        public int FkCartId { get; set; }
        public Cart Cart { get; set; } = new Cart();

        //Relationship with Product
        public int FkProductId { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
