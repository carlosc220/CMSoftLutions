#region Using
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
            //container.Register<IRepository<City>>((x) => new Repository<City>(ambientDbContextLocator));
            
            #endregion

            #region Logica de Aplicacion
            //container.Register<IThirdPartyLogic, ThirdPartyLogic>();
            
            #endregion
        }
    }
}
