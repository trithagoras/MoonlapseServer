using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MoonlapseServer.Data;
public class MoonlapseDbContextFactory : IDesignTimeDbContextFactory<MoonlapseDbContext> {
    public MoonlapseDbContext CreateDbContext(string[] args) {
        DotEnv.Load();
        var connectionString = DotEnv.Read()["CONNECTION_STRING"];
        var optionsBuilder = new DbContextOptionsBuilder<MoonlapseDbContext>();
        optionsBuilder.UseSqlite(connectionString);
        optionsBuilder.UseLazyLoadingProxies();

        return new MoonlapseDbContext(optionsBuilder.Options);
    }
}