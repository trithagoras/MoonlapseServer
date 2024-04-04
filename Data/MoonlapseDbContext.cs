using Microsoft.EntityFrameworkCore;
using MoonlapseServer.Data.Models;

namespace MoonlapseServer.Data;
public class MoonlapseDbContext(DbContextOptions<MoonlapseDbContext> options) : DbContext(options) {
    public DbSet<User> Users { get; set; }
    public DbSet<Entity> Entities { get; set; }
    public DbSet<InstancedEntity> InstancedEntities { get; set; }
    public DbSet<Player> Players { get; set; }
}