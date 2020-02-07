using CadSage.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CadSage.Services.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}