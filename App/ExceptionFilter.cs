
using Microsoft.Extensions.Logging;
using MmoNet.Core.Network.Protocols;
using MmoNet.Core.ServerApp.Exceptions;
using MmoNet.Shared.Packets;
using MoonlapseServer.Core.Exceptions;

namespace MoonlapseServer.App;
public class ExceptionFilter(IProtocolLayer protocol, ILogger<ExceptionFilter> logger) : IExceptionFilter {
    readonly IProtocolLayer protocol = protocol;
    readonly ILogger<ExceptionFilter> logger = logger;

    public void OnException(ActionExceptionContext ctx) {
        switch (ctx.Exception) {
            case EntryException entryEx:
                protocol.SendAsync(ctx.Session, new DenyPacket {
                    SessionId = ctx.Session.Id,
                    Result = entryEx.Message
                });
                break;
            case InvalidStateException invalidStateException:
                protocol.SendAsync(ctx.Session, new DenyPacket {
                    SessionId = ctx.Session.Id,
                    Result = invalidStateException.Message
                });
                break;
            default:
                logger.LogError(ctx.Exception, "An internal error was caught by the ExceptionFilter for session {s}.", ctx.Session.Id);
                protocol.SendAsync(ctx.Session, new DenyPacket {
                    SessionId = ctx.Session.Id,
                    Result = "An internal error occurred."
                });
                break;
        }
    }
}
