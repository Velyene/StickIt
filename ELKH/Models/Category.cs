using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELKH.Models
{
    public class Category
    {
        [Key]
        public int PkCategoryId { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; } = string.Empty;

        //Products list
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
