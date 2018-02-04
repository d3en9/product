
using System.Collections.Generic;

public interface IProductsRepository
{
    IEnumerable<ProductEntity> All();
    void Add(ProductEntity product);
    void Delete(int Id);
    ProductEntity CreateOrUpdate(ProductEntity product);
}