using Microsoft.EntityFrameworkCore;
using MoonlapseServer.Data.Models;

namespace MoonlapseServer.Data.DbContexts; 
public partial class MoonlapseDbContext {
    public DbSet<Entity> Entities { get; set; }
    public DbSet<InstancedEntity> InstancedEntities { get; set; }
    public DbSet<Player> Players { get; set; }
}
