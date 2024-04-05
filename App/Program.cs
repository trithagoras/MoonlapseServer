using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MmoNet.Core.Network.Protocols;
using MmoNet.Core.ServerApp;
using MmoNet.Shared.Serializers;
using MoonlapseServer.App;
using MoonlapseServer.Core.Extensions;
using MoonlapseServer.Core.Services;
using MoonlapseServer.Data.DbContexts;

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
serverBuilder.Services.AddProtocolLayer<TcpLayer>();
serverBuilder.Services.AddSerializer<JsonSerializer>();
serverBuilder.Services.AddPlayerSessionManager(debug);
serverBuilder.Services.AddSingleton<ILoginService, LoginService>();
serverBuilder.Services.AddSingleton<IMovementService, MovementService>();
serverBuilder.Services.AddDbContext<MoonlapseDbContext>(onConfigure);
serverBuilder.Services.AddExceptionFilter<MoonlapseExceptionFilter>();

var (app, _) = serverBuilder.Build();
await app.StartAsync(42523);