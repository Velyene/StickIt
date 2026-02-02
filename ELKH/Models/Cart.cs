using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELKH.Models
{
    public class Cart
    {
        [Key]
        public int PkCartId { get; set; }

        //Relationship with RegisteredUser table
        public int FkRegisteredUserId { get; set; }
        public RegisteredUser RegisteredUser { get; set; } = new RegisteredUser();

        //Relationship with Product
        public int FkProductID { get; set; }
        public Product Product { get; set; } =  new Product();
    }
}
