using MmoNet.Core.ServerApp;
using MmoNet.Core.Sessions;
using MmoNet.Core.States;
using MmoNet.Shared.Packets;
using MoonlapseServer.App.Packets;
using MoonlapseServer.Core.Sessions;
using MoonlapseServer.Core.Sessions.States;
using System.Numerics;

namespace MoonlapseServer.App.Controllers; 
public class PlayController : Controller {

    [RequiresState<PlayState>]
    public async Task<IPacket> Move(MovePacket packet, [FromSession] PlayerSession session) {
        session.Translate(new Vector2(packet.Dx, packet.Dy));

        // return authoritive position packet
        return new PositionPacket {
            SessionId = session.Id,
            X = session.Position.X,
            Y = session.Position.Y
        };
    }
}
