using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELKH.Models
{
    public class RegisteredUser
    {
        [Key]
        public int PkRegisteredUserId { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;


        //Relationship with Cart
        public ICollection<Cart> Cart { get; set; } = new List<Cart>();

        //Relationship with Order
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        //Relationship with Contact Detail
        public ICollection<ContactDetail> ContactDetails { get; set; } = new List<ContactDetail>();

        //Relationship With ProductRating
        public ICollection<ProductRating> ProductRatings { get; set; } = new List<ProductRating>();

        //Relationship with WishList
        public WishList WishLists { get; set; } = new WishList();
    }
}
