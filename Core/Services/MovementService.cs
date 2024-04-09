using Microsoft.Extensions.Logging;
using MmoNet.Core.ServerApp;
using Moonlapse.Data.DbContexts;
using System.Numerics;

namespace Moonlapse.Core.Services;
public class MovementService : IMovementService {

    readonly MoonlapseDbContext db;
    readonly IServerEngine engine;
    readonly ILogger<MovementService> logger;
    readonly Dictionary<int, Vector2> movementStates = [];

    public MovementService(MoonlapseDbContext db, IServerEngine engine, ILogger<MovementService> logger) {
        this.db = db;
        this.engine = engine;
        this.logger = logger;
        engine.OnTick += UpdateMovements;
    }

    public void BeginTranslate(int instanceId, float dx, float dy) {
        var instance = db.InstancedEntities.Single(i => i.Id == instanceId);
        var move = new Vector2(dx, dy);

        // cannot normalize 0 vector
        if (move != Vector2.Zero) {
            var velocity = instance.MoveSpeed * Vector2.Normalize(move) ?? Vector2.Zero;
            movementStates[instanceId] = velocity;
        } else {
            movementStates[instanceId] = Vector2.Zero;
        }
    }

    void UpdateMovements(object? sender, EventArgs args) {
        var delta = engine.DeltaTime;

        foreach (var (instanceId, state) in movementStates) {
            var instance = db.InstancedEntities.Find(instanceId);
            if (instance != null) {
                instance.X += state.X * delta;
                instance.Y += state.Y * delta;
            }
        }
    }
}
