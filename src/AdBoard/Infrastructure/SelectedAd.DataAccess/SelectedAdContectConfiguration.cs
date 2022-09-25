using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SelectedAd.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.DataAccess
{
    public class SelectedAdContectConfiguration : IDbContextOptionsConfigurator<SelectedAdContext>
    {
        private const string PostgresConnectionStringName = "AdBoardDb";
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public SelectedAdContectConfiguration( ILoggerFactory loggerFactory,IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }


        public SelectedAdContectConfiguration(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Configure(DbContextOptionsBuilder<SelectedAdContext> options)
        {
            var connectionString = _configuration.GetConnectionString(ConnectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Не найдена строка подключения с именем '(ConnectionStringName)'");
            }

            options.UseNpgsql(connectionString)
                .UseLoggerFactory(_loggerFactory);
        }
    }
}
