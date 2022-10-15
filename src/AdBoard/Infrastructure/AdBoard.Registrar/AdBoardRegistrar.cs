using AdBoard.AppServices.Ad.Repositories;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SelectedAd.DataAccess;
using SelectedAd.DataAccess.EntityConfiguration.Ad;
using SelectedAd.DataAccess.Interface;
using AdBoard.AppServices.Ad.Services;
using AdBoard.AppServices.Services;
using AdBoard.AppServices.SelectedAd.Repositories;
using SelectedAd.DataAccess.EntityConfiguration.SelectedAd;
using AdBoard.AppServices.SelectedAd.Services;
using AdBoard.AppServices.User.IRepository;
using AdBoard.AppServices.User.Services;
using SelectedAd.DataAccess.EntityConfiguration.User;

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

            // Регистрация объявления
            services.AddTransient<IAdService, AdService>();
            services.AddTransient<IAdRepository, AdRepository>();

            //Регистрация Избранных
            services.AddTransient<ISelectedAdService, SelectedAdService>();
            services.AddTransient<ISelectedAdRepository, SelectedAdRepository>();

            // Регистрация Пользователя
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
} 