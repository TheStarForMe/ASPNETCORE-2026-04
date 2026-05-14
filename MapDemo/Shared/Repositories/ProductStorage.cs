using MapDemo.Shared.Domain;

namespace MapDemo.Shared.Repositories {
    public class ProductStorage : IProductStorage {
        private object _lock = new object();
        
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

        public IReadOnlyList<Product> Get() {
            lock (_lock) {
                return _products.Select(Clone).ToList();
            }
        }

        public Product? Get(int id) {
            lock (_lock) {
                var product = _products.FirstOrDefault(p => p.Id == id);
                return product != null ? Clone(product) : null;
            }
        }

        public Product Add(Product product) {
            lock (_lock) {
                var productToAdd = Clone(product);

                productToAdd.Id = _products.Max(p => p.Id) + 1; // Auto-increment ID
                productToAdd.Notes += "Added to storage on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                _products.Add(productToAdd);

                return Clone(productToAdd);
            }
        }

        public Product? Update(int id, Product updatedProduct) {
            lock (_lock) {
                var existingProduct = _products.FirstOrDefault(p => p.Id == id);
                if (existingProduct == null) {
                    return null;
                }
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Stock = updatedProduct.Stock;
                existingProduct.Notes = updatedProduct.Notes;
                return Clone(existingProduct);
            }
        }

        public void Delete(int id) {
            lock (_lock) {
                var product = _products.FirstOrDefault(p => p.Id == id);
                if (product != null) {
                    _products.Remove(product);
                }
            }
        }

        private static Product Clone(Product product) {
            return new Product() {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Notes = product.Notes
            };
        }

    }
}
