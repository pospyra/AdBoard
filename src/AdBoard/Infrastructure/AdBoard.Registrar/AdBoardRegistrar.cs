using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SelectedAd.DataAccess;
using SelectedAd.DataAccess.Interface;

namespace AdBoard.Registrar
{
    public static class AdBoardRegistrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDbContext<SelectedAdContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
                ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<SelectedAdContext>>()
                .Configure((DbContextOptionsBuilder<SelectedAdContext>) dbOptions)));
            services.AddSingleton<IDbContextOptionsConfigurator<SelectedAdContext>, SelectedAdContextConfiguration>();
            services.AddScoped(sp => (DbContext)sp.GetRequiredService<SelectedAdContext>());
           
            return services;
        }
    }
}