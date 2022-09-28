using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SelectedAd.DataAccess.Interface;

namespace SelectedAd.DataAccess
{
    public class SelectedAdContextConfiguration : IDbContextOptionsConfigurator<SelectedAdContext>
    {
        private const string PostgresConnectionStringName = "PostgresAdBoardDb";
        private const string MsSqlAdBoardDb = "MsSqlAdBoardDb";
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public SelectedAdContextConfiguration( ILoggerFactory loggerFactory,IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }


        public SelectedAdContextConfiguration(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Configure(DbContextOptionsBuilder<SelectedAdContext> options)
        {
            string connectionString;

            //var useMsSql = _configuration.Get<bool>("DataBaseOptions: UseMsSql").Value;
            var useMsSql = false;

            if (!useMsSql)
            {
                connectionString =_configuration.GetConnectionString(PostgresConnectionStringName);
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException(
                        $"Не найдена строка подключения с именем '(ConnectionStringName)'");
                }
                options.UseNpgsql(connectionString);

            }
            else
            {
                connectionString = _configuration.GetConnectionString(MsSqlAdBoardDb);
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException(
                        $"Не найдена строка подключения с именем '(ConnectionStringName)'");
                }
                options.UseSqlServer(connectionString);
            }
            options.UseLoggerFactory(_loggerFactory);
        }
    }  
}
