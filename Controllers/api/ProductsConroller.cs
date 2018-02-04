using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using product.Data;

namespace product.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _products;
        
        public ProductsController(IProductsRepository products)
        {
            _products = products;
        }

        [HttpGet]
        public IEnumerable<ProductEntity> GetAll()
        {
            return _products.All();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _products.Delete(id);
        }

        [HttpPost]
        public ProductEntity Update([FromBody]ProductEntity product)
        {
            return _products.CreateOrUpdate(product);
        }
    }
}