using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MmoNet.Core.Network.Protocols;
using MmoNet.Core.ServerApp;
using MmoNet.Shared.Packets;
using MmoNet.Shared.Serializers;
using MoonlapseServer.App;
using MoonlapseServer.Core.Extensions;
using MoonlapseServer.Core.Services;
using MoonlapseServer.Data.Areas.Entry;

// configuring database connection
DotEnv.Load();
var onConfigure = (DbContextOptionsBuilder optionsBuilder) => {
    var connectionString = DotEnv.Read()["CONNECTION_STRING"];
    optionsBuilder.UseSqlite(connectionString);
};

var serverBuilder = new ServerBuilder();
serverBuilder.Services.AddProtocolLayer<TcpLayer>();
serverBuilder.Services.AddSerializer<JsonSerializer>();
serverBuilder.Services.AddPlayerSessionManager();
serverBuilder.Services.AddSingleton<ILoginService, LoginService>();
serverBuilder.Services.AddDbContext<EntryContext>(onConfigure);
serverBuilder.Services.AddExceptionFilter<MoonlapseExceptionFilter>();

var (app, _) = serverBuilder.Build();
await app.StartAsync(42523);