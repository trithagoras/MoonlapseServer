using Microsoft.EntityFrameworkCore;
using Moonlapse.Data.Models;

namespace Moonlapse.Data.DbContexts; 
public partial class MoonlapseDbContext {
    public DbSet<Entity> Entities { get; set; }
    public DbSet<InstancedEntity> InstancedEntities { get; set; }
    public DbSet<Player> Players { get; set; }
}
