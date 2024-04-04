
using Microsoft.Extensions.Logging;
using MmoNet.Core.Network.Protocols;
using MmoNet.Core.ServerApp.Exceptions;
using MmoNet.Shared.Packets;
using MoonlapseServer.Core.Exceptions;

namespace MoonlapseServer.App;
public class MoonlapseExceptionFilter(IProtocolLayer protocol, ILogger<MoonlapseExceptionFilter> logger) : ExceptionFilter(protocol) {
    readonly ILogger<MoonlapseExceptionFilter> logger = logger;
    readonly IProtocolLayer protocol = protocol;

    public override void OnException(ActionExceptionContext ctx) {
        switch (ctx.Exception) {
            case EntryException entryEx:
                protocol.SendAsync(ctx.Session, new DenyPacket {
                    SessionId = ctx.Session.Id,
                    Result = entryEx.Message
                });
                return;
            default:
                logger.LogError(ctx.Exception, "An internal error was caught by the ExceptionFilter for session {s}.", ctx.Session.Id);
                break;
        }
        base.OnException(ctx);
    }
}
