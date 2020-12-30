using Data.Contracts;
using Data.EF;
using Data.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class ConfigServices
    {
        public static void AddDependencies(this IServiceCollection services) 
        {
            services.AddScoped<SgnWebContext>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IEquipamentoRepository, EquipamentoRepository>();
            services.AddTransient<ITipoEquipamentoRepository, TipoEquipamentoRepository>();
        }
    }
}
