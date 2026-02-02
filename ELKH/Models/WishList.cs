using System.ComponentModel.DataAnnotations;

namespace ELKH.Models
{
    public class WishList
    {
        [Key]
        public int PkWishListId { get; set; }

        //Relationship with user
        public int FkUserId { get; set; }
        public RegisteredUser RegisteredUser { get; set; } = new RegisteredUser();

        //Relationship with Product
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
