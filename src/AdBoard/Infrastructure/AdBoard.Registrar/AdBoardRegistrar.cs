using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<TContext>((Action<IServiceProvider, DnContextOptionsBuilder>)((sp, dbOprions) => sp.GetRequiredService<TContext>));
            services.AddSingleton<IDbContextOptionsConfigurator<TContext>, TConfigurator>();
            services.AddScoped<DbContext>((Func<IServiceProvider, DbContext>)(sp => (DbContext)sp.GetRequiredService<TContext>()));
            return services;
        }
    }
}
