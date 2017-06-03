using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ProductBusinessLogic
{
    public interface IProductLogic
    {
        List<Product> ListProducts(string search);
    }
}
