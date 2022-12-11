using Microsoft.Extensions.Options;
using MinecraftConnection;
using System.Runtime.CompilerServices;

class MinecraftApp : ConsoleAppBase
{
    private MinecraftCommands command;
    private IOptions<AppSettings> options;
    public MinecraftApp(IOptions<AppSettings> options)
    {
        this.options= options;
        var server = options.Value.MinecraftServer;
        command = new MinecraftCommands(server.Address, server.Port, server.Pass);
    }

    [Command("title")]
    public void DisplayTitle([Option("t")]string title)
    {
        command.DisplayTitle(title);
    }

    [Command("message")]
    public void DisplayMessage([Option("m")] string message)
    {
        command.DisplayMessage(message);
    }

    [Command("repeatMessage")]
    public void RepeatMessage([Option("m")] string message, [Option("w")] ushort wait, [Option("t")] int times)
    {
        for (var i = 0; i < times; i++)
        {
            command.DisplayMessage(message);
            command.Wait(wait);
        }
    }
}