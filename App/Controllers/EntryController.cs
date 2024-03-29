using MmoNet.Core.ServerApp;
using MmoNet.Core.Sessions;
using MmoNet.Shared.Packets;
using MoonlapseServer.App.Packets;
using MoonlapseServer.Core.Services;
using MoonlapseServer.Core.Sessions;

namespace MoonlapseServer.App.Controllers; 
public class EntryController(ILoginService loginService) : Controller {
    readonly ILoginService loginService = loginService;

    public async Task<IPacket> Login(LoginPacket packet, [FromSession] PlayerSession session) {
        var result = await loginService.LoginAsync(packet.Username, packet.Password);
        if (!result.Success) {
            return Deny(session, "login failed");
        }
        return Ok(session, "login successful");
    }

    public async Task<IPacket> LogoutAsync(LogoutPacket _, [FromSession] PlayerSession session) {
        var result = await loginService.LogoutAsync(session);
        if (!result.Success) {
            return Deny(session, "logout failed");
        }
        return Ok(session, "logout successful");
    }
}
