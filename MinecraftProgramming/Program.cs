using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = ConsoleApp.CreateBuilder(args);
builder.ConfigureServices((ctx, services) =>
{
    services.Configure<AppSettings>(ctx.Configuration);
});
var app = builder.Build();
app.AddCommands<MinecraftApp>();
app.Run();
