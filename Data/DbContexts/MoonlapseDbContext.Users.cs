using Microsoft.EntityFrameworkCore;
using MoonlapseServer.Data.Models;

namespace MoonlapseServer.Data.DbContexts; 
public partial class MoonlapseDbContext {
    public DbSet<User> Users { get; set; }
}
