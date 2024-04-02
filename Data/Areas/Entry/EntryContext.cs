
using Microsoft.EntityFrameworkCore;
using MoonlapseServer.Data.Areas.Entry.Models;

namespace MoonlapseServer.Data.Areas.Entry;
public class EntryContext(DbContextOptions<EntryContext> options) : DbContext(options) {
    public DbSet<User> Users { get; set; }
}