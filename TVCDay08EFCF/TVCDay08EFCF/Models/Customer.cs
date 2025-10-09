using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVCDay08EFCF.Models
{
    [Table(name: "Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Column(name: "FullName", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
