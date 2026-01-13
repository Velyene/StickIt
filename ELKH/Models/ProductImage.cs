using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELKH.Models
{
    public class ProductImage
    {
        [Key]
        public int PkProductImageId { get; set; }
        [DisplayName("Product Image Link")]
        public string? ProductImageURL { get; set; } = string.Empty;

        //Relationship with Product
        public int FkProductId { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
