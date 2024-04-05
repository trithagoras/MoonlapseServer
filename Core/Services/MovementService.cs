using MoonlapseServer.Data.DbContexts;
using MoonlapseServer.Data.Models;

namespace MoonlapseServer.Core.Services;
public class MovementService(MoonlapseDbContext db) : IMovementService {
    readonly MoonlapseDbContext db = db;
    public void Translate(InstancedEntity instance, float dx, float dy) {
        instance.X += dx;
        instance.Y += dy;
        // todo: notify other players

        // todo: remove these following lines. They are unperformant.
        db.InstancedEntities.Update(instance);
        db.SaveChanges();
    }
}
