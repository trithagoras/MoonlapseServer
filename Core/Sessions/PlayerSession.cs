using MmoNet.Core.Sessions;

namespace MoonlapseServer.Core.Sessions;
public class PlayerSession(Guid id) : ISession {
    public Guid Id { get; } = id;
}
