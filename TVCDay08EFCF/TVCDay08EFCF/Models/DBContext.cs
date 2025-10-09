using Microsoft.EntityFrameworkCore;
using TVCDay08EFCF.Models;

namespace TVCDay08EFCF.Models
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TVCDay08EFCF.Models.Order> Order { get; set; } = default!;
        public DbSet<TVCDay08EFCF.Models.OrderDetail> OrderDetail { get; set; } = default!;
    }
}
