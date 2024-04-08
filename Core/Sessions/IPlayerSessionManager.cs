using MmoNet.Core.Sessions;

namespace Moonlapse.Core.Sessions; 
public interface IPlayerSessionManager : ISessionManager {
    PlayerSession? GetSessionByUsername(string username);
}
