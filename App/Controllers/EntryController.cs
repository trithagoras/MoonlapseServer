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
        await loginService.LoginAsync(session, packet.Username, packet.Password);
        return Ok(session, "login successful");
    }
    public async Task<IPacket> LogoutAsync(LogoutPacket _, [FromSession] PlayerSession session) {
        await loginService.LogoutAsync(session);
        return Ok(session, "logout successful");
    }

    public async Task<IPacket> RegisterAsync(RegisterPacket packet, [FromSession] PlayerSession session) {
        await loginService.RegisterAsync(packet.Username, packet.Password);
        return Ok(session, "register successful");
    }
}
