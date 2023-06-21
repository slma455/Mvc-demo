using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Models
{
    public class ProductList
    {
        public static List<Product> products { get; set; }
        static ProductList()
        {
            products = new List<Product>();
            products.Add(new Product() { ID = 1, Name = "Laptop 1", Price = 3000, Description = "lorem" , Image = "1.jpg" });
            products.Add(new Product() { ID = 2, Name = "Laptop 2", Price = 3000, Description = "lorem", Image = "2.jpg" });
            products.Add(new Product() { ID = 3, Name = "Laptop 3", Price = 3000, Description= "lorem" , Image = "3.jpg" });
            products.Add(new Product() { ID = 4, Name = "Laptop 4", Price = 3000, Description ="lorem", Image = "4.jpg" });

        }
        public static List<Product> GetAll()
        {
            return products;
        }
        public static Product Find(int id)
        {
            return products.FirstOrDefault(p => p.ID == id);
        }
    }
}
