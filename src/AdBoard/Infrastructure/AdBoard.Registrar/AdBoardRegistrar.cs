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
            services.AddDbContext<AdBoardContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
                ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<AdBoardContext>>()
                .Configure((DbContextOptionsBuilder<AdBoardContext>) dbOptions)));
            services.AddSingleton<IDbContextOptionsConfigurator<AdBoardContext>, SelectedAdContextConfiguration>();
            services.AddScoped(sp => (DbContext)sp.GetRequiredService<AdBoardContext>());
           
            return services;
        }
    }
}