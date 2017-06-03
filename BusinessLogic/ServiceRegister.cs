#region Using
using BusinessLogic.CustomerBusinessLogic;
using BusinessLogic.InvoiceBusinessLogic;
using BusinessLogic.ProductBusinessLogic;
using LightInject;
using Model;
using Persistence.DbContextScope;
using Repository;
using Repository.Interfaces;
#endregion

namespace BusinessLogic
{
    public class ServiceRegister : ICompositionRoot
    {               
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            #region Repositorios
            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IRepository<Customer>>((x) => new Repository<Customer>(ambientDbContextLocator));
            container.Register<IRepository<Product>>((x) => new Repository<Product>(ambientDbContextLocator));
            container.Register<IRepository<Invoice>>((x) => new Repository<Invoice>(ambientDbContextLocator));
            container.Register<IRepository<InvoiceDetail>>((x) => new Repository<InvoiceDetail>(ambientDbContextLocator));
            #endregion

            #region Logica de Aplicacion
            container.Register<IProductLogic, ProductLogic>();
            container.Register<IInvoiceLogic, InvoiceLogic>();
            container.Register<ICustomerLogic, CustomerLogic>();
            #endregion
        }
    }
}
