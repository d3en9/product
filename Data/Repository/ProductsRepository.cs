using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using product.Data;

public class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<ProductEntity> All()
    {
        return _dbContext.Products;
    }
    public void Add(ProductEntity product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    public void Delete(int Id)
    {
        _dbContext.Products.Remove(_dbContext.Products.Find(Id));
        _dbContext.SaveChanges();
    }

    public ProductEntity CreateOrUpdate(ProductEntity product)
    {
        if (product.Id == 0)
        {
            _dbContext.Products.Add(product);
        }
        else
        {
            var entity = _dbContext.Products.Find(product.Id);
            entity.Name = product.Name;
            _dbContext.Entry(entity).State = EntityState.Modified;            
        }
        _dbContext.SaveChanges();
        return _dbContext.Products.Find(product.Id);

    }
}