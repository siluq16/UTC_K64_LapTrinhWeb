namespace WebApplication29_08.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }

        public List<Product> GetProductsList()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/unnamed.jpg", Price = 10.0f },
                new Product() { Id = 2, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/unnamed.jpg", Price = 20.0f },
                new Product() { Id = 3, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/unnamed.jpg", Price = 30.0f }
            };
            return products;
        }

        public Product GetProductById(int id)
        {
            return GetProductsList().FirstOrDefault(p => p.Id == id);
        }
    }
}
