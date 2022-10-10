using AdBoard.AppServices.Ad.Repositories;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SelectedAd.DataAccess;
using SelectedAd.DataAccess.EntityConfiguration.Ad;
using SelectedAd.DataAccess.Interface;
using AdBoard.AppServices.Ad.Services;
using AdBoard.AppServices.Services;

namespace AdBoard.Registrar
{
    public static class AdBoardRegistrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeSevices, DateTimeSevices>();
            services.AddSingleton<IDbContextOptionsConfigurator<AdBoardContext>, AdBoardContextConfiguration>();

            services.AddDbContext<AdBoardContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
                ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<AdBoardContext>>()
                .Configure((DbContextOptionsBuilder<AdBoardContext>) dbOptions)));

            services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<AdBoardContext>()));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IAdService, AdService>();
            services.AddTransient<IAdRepository, AdRepository>();

            return services;
        }
    }
}