using Microsoft.Extensions.DependencyInjection;
using MmoNet.Core.Sessions;
using Moonlapse.Core.Sessions;

namespace Moonlapse.Core.Extensions; 
public static class ServiceCollectionExtensions {
    public static ServiceCollection AddPlayerSessionManager(this ServiceCollection services, bool debug = false) {
        if (debug) {
            return services.AddDebugPlayerSessionManager();
        }
        var playerSessionManager = new PlayerSessionManager();
        services.AddSingleton<ISessionManager>(playerSessionManager);
        services.AddSingleton<IPlayerSessionManager>(playerSessionManager);
        return services;
    }

    static ServiceCollection AddDebugPlayerSessionManager(this ServiceCollection services) {
        var playerSessionManager = new DebugPlayerSessionManager();
        services.AddSingleton<ISessionManager>(playerSessionManager);
        services.AddSingleton<IPlayerSessionManager>(playerSessionManager);
        return services;
    }
}
