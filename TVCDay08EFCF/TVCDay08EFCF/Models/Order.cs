using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVCDay08EFCF.Models
{
    [Table(name: "Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Adress { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
