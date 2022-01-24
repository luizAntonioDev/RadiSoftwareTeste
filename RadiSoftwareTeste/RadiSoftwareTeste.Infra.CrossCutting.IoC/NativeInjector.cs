using Microsoft.Extensions.DependencyInjection;
using RadiSoftwareTeste.Infra.CrossCutting.IoC.Modules;

namespace RadiSoftwareTeste.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void Register(IServiceCollection service)
        {
            ServiceModules.Register(service);
            DatabaseRepositoryModule.Register(service);

            service.BuildServiceProvider();
        }
    }
}
