using MultiThreadSandbox.Repositories;
using MultiThreadSandbox.Repositories.Interfaces;
using SimpleInjector;
using SimpleInjector.Advanced;

namespace MultiThreadSandbox.Ioc
{
    public class SimpleInjectorIoc
    {
        private readonly Container _container;

        public SimpleInjectorIoc()
        {
            _container = new Container();
        }

        public SimpleInjectorIoc InitializerContainer()
        {
            _container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Singleton);
            _container.Verify();
            return this;
        }

        public Container GetContainer() => _container;
    }
}