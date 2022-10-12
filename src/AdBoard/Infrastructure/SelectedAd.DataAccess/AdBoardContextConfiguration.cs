using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SelectedAd.DataAccess.Interface;

namespace SelectedAd.DataAccess
{
    /// <summary>
    /// Конфигурация контекста БД
    /// </summary>
    public class AdBoardContextConfiguration : IDbContextOptionsConfigurator<AdBoardContext>
    {
        private const string PostgresConnectionStringName = "PostgresAdBoardDb";
        private const string MsSqlAdBoardDb = "MsSqlAdBoardDb";
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// Инициализирует экзмпляр <see cref="AdBoardContextConfiguration"/>
        /// </summary>
        /// <param name="loggerFactory">Фабрика средств логирования</param>
        /// <param name="configuration">Конфигурация</param>
        public AdBoardContextConfiguration( ILoggerFactory loggerFactory,IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        /// <inheritdoc />
        public void Configure(DbContextOptionsBuilder<AdBoardContext> options)
        {
            string connectionString;

            var useMsSql = _configuration.GetSection("DataBaseOptions:UseMsSql").Get<bool>(); 

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
