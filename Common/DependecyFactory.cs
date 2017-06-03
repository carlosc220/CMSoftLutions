using LightInject;

namespace Common
{
    public class DependecyFactory
    {
        public static T GetInstance<T>()
        {
            return new ServiceContainer().GetInstance<T>();
        }
    }
}
