using Microsoft.Extensions.DependencyInjection;
using MmoNet.Core.Sessions;
using MoonlapseServer.Core.Sessions;

namespace MoonlapseServer.Core.Extensions; 
public static class ServiceCollectionExtensions {
    public static ServiceCollection AddPlayerSessionManager(this ServiceCollection services) {
        var playerSessionManager = new PlayerSessionManager();
        services.AddSingleton<ISessionManager>(playerSessionManager);
        services.AddSingleton<IPlayerSessionManager>(playerSessionManager);
        return services;
    }
}
