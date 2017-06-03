using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Persistence.DbContextScope;
using Repository.Interfaces;

namespace BusinessLogic.ProductBusinessLogic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Product> _productRepository;

        public ProductLogic(IDbContextScopeFactory dbContextScopeFactory, IRepository<Product> productRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _productRepository = productRepository;
        }
        public List<Product> ListProducts(string search)
        {
            using (var ctx = _dbContextScopeFactory.CreateReadOnly())
            {
                return _productRepository.GetAll().Where(x=>x.Code.ToUpper().Contains(search.ToUpper()) || x.Name.ToUpper().Contains(search.ToUpper())).ToList();
            }
        }
    }
}
