using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MmoNet.Core.Network.Protocols;
using MmoNet.Core.ServerApp;
using MmoNet.Shared.Serializers;
using MoonlapseServer.App;
using MoonlapseServer.Core.Extensions;
using MoonlapseServer.Core.Services;
using MoonlapseServer.Data;

// configuring database connection
DotEnv.Load();
var onConfigure = (DbContextOptionsBuilder optionsBuilder) => {
    var connectionString = DotEnv.Read()["CONNECTION_STRING"];
    optionsBuilder.UseSqlite(connectionString);
    optionsBuilder.UseLazyLoadingProxies();
};

var serverBuilder = new ServerBuilder();
serverBuilder.Services.AddProtocolLayer<TcpLayer>();
serverBuilder.Services.AddSerializer<JsonSerializer>();
serverBuilder.Services.AddPlayerSessionManager(debug: true);
serverBuilder.Services.AddSingleton<ILoginService, LoginService>();
serverBuilder.Services.AddDbContext<MoonlapseDbContext>(onConfigure);
serverBuilder.Services.AddExceptionFilter<MoonlapseExceptionFilter>();

var (app, _) = serverBuilder.Build();
await app.StartAsync(42523);