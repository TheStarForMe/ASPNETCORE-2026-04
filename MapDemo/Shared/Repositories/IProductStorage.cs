using MapDemo.Shared.Domain;

namespace MapDemo.Shared.Repositories {
    public interface IProductStorage {
        IReadOnlyList<Product> Get();
        Product? Get(int id);
        Product Add(Product product);
        Product? Update(int id, Product updatedProduct);
        void Delete(int id);
    }
}