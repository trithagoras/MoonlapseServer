
using Microsoft.EntityFrameworkCore;
using MoonlapseServer.Data.Areas.Entry.Models;

namespace MoonlapseServer.Data.Areas.Entry; 
public class EntryContext : DbContext {
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source=moonlapse.db");
    }
}
