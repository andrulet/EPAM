using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake.Repositories;
using DAL.Interface.Interfaces;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IRepository>().To<FakeRepository>();
            //kernel.Bind<IRepository>().To<AccountRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountGetId>().To<AccountGenerateId>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
