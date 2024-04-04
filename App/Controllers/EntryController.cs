using MmoNet.Core.ServerApp;
using MmoNet.Core.Sessions;
using MmoNet.Core.States;
using MmoNet.Shared.Packets;
using MoonlapseServer.App.Packets;
using MoonlapseServer.Core.Services;
using MoonlapseServer.Core.Sessions;
using MoonlapseServer.Core.Sessions.States;

namespace MoonlapseServer.App.Controllers;
public class EntryController(ILoginService loginService) : Controller {
    readonly ILoginService loginService = loginService;

    [RequiresState<EntryState>]
    public async Task<IPacket> Login(LoginPacket packet, [FromSession] PlayerSession session) {
        await loginService.LoginAsync(session, packet.Username, packet.Password);
        return Ok(session, "login successful");
    }

    [RequiresState<EntryState>]
    public async Task<IPacket> RegisterAsync(RegisterPacket packet, [FromSession] PlayerSession session) {
        await loginService.RegisterAsync(packet.Username, packet.Password);
        return Ok(session, "register successful");
    }

    [RequiresState<PlayState>]
    public async Task<IPacket> LogoutAsync(LogoutPacket _, [FromSession] PlayerSession session) {
        await loginService.LogoutAsync(session);
        return Ok(session, "logout successful");
    }
}
