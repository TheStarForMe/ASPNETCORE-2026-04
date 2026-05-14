using MapDemo.Shared.Domain;

namespace MapDemo.Shared.Repositories {
    public class ProductStorage : IProductStorage {
        private List<Product> _products = new List<Product>() {
            new Product() {
                Id = 1,
                Name = "Laptop",
                Description = "A high-performance laptop.",
                Price = 999.99m,
                Stock = 10,
                Notes = "Comes with a 1-year warranty."
            },
            new Product() {
                Id = 2,
                Name = "Smartphone",
                Description = "A latest model smartphone.",
                Price = 699.99m,
                Stock = 20,
                Notes = "Includes a free case."
            }
        };

        public List<Product> Get() {
            return _products;
        }

        public Product? Get(int id) {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Add(Product product) {
            product.Id = _products.Max(p => p.Id) + 1; // Auto-increment ID
            product.Notes += "Added to storage on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _products.Add(product);
            return product;
        }

        public Product? Update(int id, Product updatedProduct) {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null) {
                return null;
            }
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Stock = updatedProduct.Stock;
            existingProduct.Notes = updatedProduct.Notes;
            return existingProduct;
        }

        public void Delete(int id) {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null) {
                _products.Remove(product);
            }
        }
    }
}
