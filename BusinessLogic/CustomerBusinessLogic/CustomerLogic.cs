using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Persistence.DbContextScope;
using Repository.Interfaces;

namespace BusinessLogic.CustomerBusinessLogic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Customer> _customerRepository;


        public CustomerLogic(IDbContextScopeFactory dbContextScopeFactory, IRepository<Customer> customerRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _customerRepository = customerRepository;
        }


        public List<Customer> LitsCustomers(string search)
        {
            using (var ctx = _dbContextScopeFactory.CreateReadOnly())
            {
                return _customerRepository.GetAll().Where(x=> x.Identification.Contains(search) || x.Name.ToUpper().Contains(search.ToUpper()) || x.LastName.ToUpper().Contains(search)).ToList();
            }
        }
    }
}
