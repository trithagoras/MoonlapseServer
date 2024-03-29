using Microsoft.Extensions.DependencyInjection;
using MmoNet.Core.Network.Protocols;
using MmoNet.Core.ServerApp;
using MmoNet.Shared.Packets;
using MmoNet.Shared.Serializers;
using MoonlapseServer.Core.Services;
using MoonlapseServer.Core.Sessions;

var serverBuilder = new ServerBuilder();
serverBuilder.Services.AddProtocolLayer<TcpLayer>();
serverBuilder.Services.AddSerializer<JsonSerializer>();
serverBuilder.Services.AddSessionManager<PlayerSessionManager>();
serverBuilder.Services.AddPacketRegistry<PacketRegistry>();
serverBuilder.Services.AddSingleton<ILoginService, LoginService>();

var (app, _) = serverBuilder.Build();
await app.StartAsync(42523);