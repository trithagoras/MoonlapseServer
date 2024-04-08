using MmoNet.Core.ServerApp;
using MmoNet.Core.Sessions;
using MmoNet.Core.States;
using MmoNet.Shared.Packets;
using Moonlapse.Shared.Packets;
using Moonlapse.Core.Services;
using Moonlapse.Core.Sessions;
using Moonlapse.Core.Sessions.States;

namespace Moonlapse.App.Controllers;
public class EntryController(ILoginService loginService) : Controller {
    readonly ILoginService loginService = loginService;

    [RequiresState<EntryState>]
    public async Task<IPacket> Login(LoginPacket packet, [FromSession] PlayerSession session) {
        await loginService.LoginAsync(session, packet.Username, packet.Password);
        return new PositionPacket {
            SessionId = session.Id,
            X = session.Player.InstancedEntity.X,
            Y = session.Player.InstancedEntity.Y
        };
    }

    [RequiresState<EntryState>]
    public async Task<IPacket> Register(RegisterPacket packet, [FromSession] PlayerSession session) {
        await loginService.RegisterAsync(packet.Username, packet.Password);
        return Ok(session, "register successful");
    }

    [RequiresState<PlayState>]
    public async Task<IPacket> Logout(LogoutPacket _, [FromSession] PlayerSession session) {
        await loginService.LogoutAsync(session);
        return Ok(session, "logout successful");
    }
}
