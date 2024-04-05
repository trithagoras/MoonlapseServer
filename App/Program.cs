using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MmoNet.Core.Network.Protocols;
using MmoNet.Core.ServerApp;
using MmoNet.Shared.Packets;
using MmoNet.Shared.Serializers;
using Moonlapse.App;
using Moonlapse.Core.Extensions;
using Moonlapse.Core.Services;
using Moonlapse.Data.DbContexts;
using System.Reflection;

// loading environment variables and setting debug mode
DotEnv.Load();
var env = DotEnv.Read();
var debug = false;
#if DEBUG
    debug = true;
#endif

// configuring database connection
var onConfigure = (DbContextOptionsBuilder optionsBuilder) => {
    var connectionString = env["CONNECTION_STRING"];
    optionsBuilder.UseSqlite(connectionString);
    optionsBuilder.UseLazyLoadingProxies();
};

var serverBuilder = new ServerBuilder();

// essential services
serverBuilder.Services.AddProtocolLayer<TcpLayer>();
serverBuilder.Services.AddSerializer<JsonSerializer>();
serverBuilder.Services.AddPlayerSessionManager(debug);
serverBuilder.Services.AddLogging(o => o.AddConsole());
serverBuilder.Services.AddPacketRegistry<PacketRegistry>();
serverBuilder.Services.AddExceptionFilter<MoonlapseExceptionFilter>();

// custom services
serverBuilder.Services.AddDbContext<MoonlapseDbContext>(onConfigure);
serverBuilder.Services.AddSingleton<ILoginService, LoginService>();
serverBuilder.Services.AddSingleton<IMovementService, MovementService>();

// preloading assembly to register packets during server build process
Assembly.Load("Moonlapse.Shared");

var (app, _) = serverBuilder.Build();
await app.StartAsync(42523);