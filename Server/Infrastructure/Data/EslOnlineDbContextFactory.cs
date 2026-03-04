using EslOnline.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EslOnline.Infrastructure.Data;

public class EslOnlineDbContextFactory : IDesignTimeDbContextFactory<EslOnlineDbContext>
{
    public EslOnlineDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Host"))
                    .AddJsonFile("appsettings.json")
                    .Build();

        var dbOptions = configuration
            .GetSection(DatabaseOptions.SectionName)
            .Get<DatabaseOptions>();

        var optionsBuilder = new DbContextOptionsBuilder<EslOnlineDbContext>();
        optionsBuilder.UseSqlServer(dbOptions!.Default, o =>
            o.MigrationsAssembly("EslOnline.Infrastructure"));

        return new EslOnlineDbContext(optionsBuilder.Options);
    }
}