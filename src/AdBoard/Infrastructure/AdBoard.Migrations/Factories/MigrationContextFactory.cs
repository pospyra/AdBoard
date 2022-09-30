using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace AdBoard.Migrations.Factories
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<MigrationsDbContext>
    {
        public MigrationsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MigrationsDbContext>();

            //получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            //получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString("PostgresAdBoardDb");
            optionsBuilder.UseNpgsql(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new MigrationsDbContext(optionsBuilder.Options);
        }
    }
}
