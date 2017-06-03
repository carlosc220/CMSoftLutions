using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Persistence.DbContextScope;
using Repository.Interfaces;
using Common;

namespace BusinessLogic.InvoiceBusinessLogic
{
    public class InvoiceLogic : IInvoiceLogic
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Invoice> _invoiceRepository;


        public InvoiceLogic(IDbContextScopeFactory dbContextScopeFactory, IRepository<Invoice> invoiceRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<ResponseModel> SaveInvoice(Invoice invoice)
        {
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    _invoiceRepository.Insert(invoice);
                    await ctx.SaveChangesAsync();
                    return new ResponseModel() { response=true,message="Guardado correctamente"};
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel() {response=  false,message= $"Error al Guardar, Error Interno: {(ex.InnerException != null ? ex.InnerException.ToString() : ex.Message)}" };
            }
        }
    }
}
