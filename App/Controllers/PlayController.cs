using MmoNet.Core.ServerApp;
using MmoNet.Core.Sessions;
using MmoNet.Core.States;
using MmoNet.Shared.Packets;
using Moonlapse.Shared.Packets;
using Moonlapse.Core.Services;
using Moonlapse.Core.Sessions;
using Moonlapse.Core.Sessions.States;

namespace Moonlapse.App.Controllers; 
public class PlayController(IMovementService movement) : Controller {
    readonly IMovementService movement = movement;

    [RequiresState<PlayState>]
    public async Task<IPacket> Move(MovePacket packet, [FromSession] PlayerSession session) {
        await movement.Translate(session.Instance, packet.Dx, packet.Dy);

        // return authoritive position packet
        return new PositionPacket {
            SessionId = session.Id,
            X = session.Instance.X,
            Y = session.Instance.Y
        };
    }
}
