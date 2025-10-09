using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVCDay08EFCF.Models
{
    [Table(name: "Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public bool isAcitve { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
