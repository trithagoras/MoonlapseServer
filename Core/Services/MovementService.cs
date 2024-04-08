using Moonlapse.Data.DbContexts;
using Moonlapse.Data.Models;

namespace Moonlapse.Core.Services;
public class MovementService(MoonlapseDbContext db) : IMovementService {
    readonly MoonlapseDbContext db = db;
    public async Task Translate(InstancedEntity instance, float dx, float dy) {
        instance.X += dx;
        instance.Y += dy;
        // todo: notify other players

        // todo: remove these following lines. They are unperformant.
        db.InstancedEntities.Update(instance);
        await db.SaveChangesAsync();
    }
}
