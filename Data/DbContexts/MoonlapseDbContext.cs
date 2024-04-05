using Microsoft.EntityFrameworkCore;

namespace Moonlapse.Data.DbContexts;
public partial class MoonlapseDbContext(DbContextOptions<MoonlapseDbContext> options) : DbContext(options) {

}