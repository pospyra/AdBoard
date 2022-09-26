using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SelectedAd.DataAccess;
using SelectedAd.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.Registrar
{
    public static class AdBoardRegistrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDbContext<SelectedAdContext>((Action<IServiceProvider, DbContextOptionsBuilder>)((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<SelectedAdContext>>().Configure((DbContextOptionsBuilder<SelectedAdContext>) dbOptions)));
            services.AddSingleton<IDbContextOptionsConfigurator<SelectedAdContext>, SelectedAdContectConfiguration>();
            services.AddScoped<DbContext>((Func<IServiceProvider, DbContext>)(sp => (DbContext)sp.GetRequiredService<SelectedAdContext>()));
            return services;
        }
    }
}
