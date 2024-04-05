using Microsoft.EntityFrameworkCore;

namespace MoonlapseServer.Data.DbContexts;
public partial class MoonlapseDbContext(DbContextOptions<MoonlapseDbContext> options) : DbContext(options) {

}