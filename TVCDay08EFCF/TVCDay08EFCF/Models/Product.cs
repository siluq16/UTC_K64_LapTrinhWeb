using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace TVCDay08EFCF.Models
{
    [Table(name: "Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image {  get; set; }
        public int Quantity { get; set; }
        [Precision(18,2)]
        public decimal Price { get; set; } = decimal.Zero;
        public string Description { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
