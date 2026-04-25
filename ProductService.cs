using DotNetCourseraFinal.Models;

namespace DotNetCourseraFinal.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 800 },
            new Product { Id = 2, Name = "Phone", Price = 500 }
        };

        public List<Product> GetAll() => products;

        public Product GetById(int id) => products.FirstOrDefault(p => p.Id == id);

        public Product Add(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
            return product;
        }

        public Product Update(int id, Product updated)
        {
            var product = GetById(id);
            if (product == null) return null;

            product.Name = updated.Name;
            product.Price = updated.Price;
            return product;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;

            products.Remove(product);
            return true;
        }
    }
}
