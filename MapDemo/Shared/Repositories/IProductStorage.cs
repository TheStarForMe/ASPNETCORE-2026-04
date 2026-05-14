using MapDemo.Shared.Domain;

namespace MapDemo.Shared.Repositories {
    public interface IProductStorage {
        Product Add(Product product);
        void Delete(int id);
        List<Product> Get();
        Product? Get(int id);
        Product? Update(int id, Product updatedProduct);
    }
}