using MmoNet.Core.Sessions;

namespace MoonlapseServer.Core.Sessions;
public class DebugPlayerSessionManager : IPlayerSessionManager {
    readonly Dictionary<Guid, ISession> sessions = [];
    int Seed => 1 + sessions.Count;

    public ISession this[Guid id] {
        get {
            if (sessions.TryGetValue(id, out ISession? value)) {
                return value;
            }
            throw new KeyNotFoundException($"Session with id {id} not found.");
        }
        set {
            sessions[id] = value;
        }
    }

    public IEnumerable<ISession> Sessions => sessions.Values;

    public ISession CreateSession() {
        var guid = GenerateSeededGuid(Seed);
        var session = new PlayerSession(guid);
        sessions.Add(guid, session);
        return session;
    }

    public void RemoveSession(Guid id) {
        sessions.Remove(id);
    }

    static Guid GenerateSeededGuid(int seed) {
        var r = new Random(seed);
        var guid = new byte[16];
        r.NextBytes(guid);

        return new Guid(guid);
    }
}
