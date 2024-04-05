using Microsoft.EntityFrameworkCore;
using Moonlapse.Data.Models;

namespace Moonlapse.Data.DbContexts; 
public partial class MoonlapseDbContext {
    public DbSet<User> Users { get; set; }
}
