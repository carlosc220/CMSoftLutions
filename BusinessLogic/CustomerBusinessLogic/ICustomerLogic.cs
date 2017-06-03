using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CustomerBusinessLogic
{
    public interface ICustomerLogic
    {
        List<Customer> LitsCustomers(string search);
    }
}
