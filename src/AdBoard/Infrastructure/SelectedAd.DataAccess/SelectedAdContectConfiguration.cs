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
        private const string PostgresConnectionStringName = "PostgresAdBoardDb";
        private const string MsSqlAdBoardDb = "MsSqlAdBoardDb";
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
            var connectionString = _configuration.GetConnectionString(PostgresConnectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Не найдена строка подключения с именем '(ConnectionStringName)'");
            }

            //var useMsSql = _configuration.GetSection("DataBaseOptions: UseMsSql").Value;

            options.UseNpgsql(connectionString)
                .UseLoggerFactory(_loggerFactory);
        }
    }
}
