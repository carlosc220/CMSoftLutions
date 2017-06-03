using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.InvoiceBusinessLogic
{
    public interface IInvoiceLogic
    {
        Task<ResponseModel> SaveInvoice(Invoice invoice);
    }
}
