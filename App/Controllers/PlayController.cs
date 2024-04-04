using MmoNet.Core.ServerApp;
using MmoNet.Core.Sessions;
using MmoNet.Core.States;
using MmoNet.Shared.Packets;
using MoonlapseServer.App.Packets;
using MoonlapseServer.Core.Services;
using MoonlapseServer.Core.Sessions;
using MoonlapseServer.Core.Sessions.States;
using System.Numerics;

namespace MoonlapseServer.App.Controllers; 
public class PlayController(IMovementService movement) : Controller {
    readonly IMovementService movement = movement;

    [RequiresState<PlayState>]
    public async Task<IPacket> Move(MovePacket packet, [FromSession] PlayerSession session) {
        movement.Translate(session.Instance, packet.Dx, packet.Dy);

        // return authoritive position packet
        return new PositionPacket {
            SessionId = session.Id,
            X = session.Instance.X,
            Y = session.Instance.Y
        };
    }
}
