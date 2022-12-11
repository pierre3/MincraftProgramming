using Microsoft.Extensions.Options;
using MinecraftConnection;

class MinecraftApp : ConsoleAppBase
{
    private MinecraftCommands command;
    private IOptions<AppSettings> options;
    public MinecraftApp(IOptions<AppSettings> options)
    {
        this.options = options;
        var server = options.Value.MinecraftServer;
        command = new MinecraftCommands(server.Address, server.Port, server.Pass);
    }

    [Command("title")]
    public void DisplayTitle([Option("t")] string title)
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

    [Command("setBlock")]
    public void SetBlock([Option("x")] int x, [Option("y")] int y, [Option("z")] int z, [Option("id")] string blockId)
    {
        command.SetBlock(x, y, z, blockId);
    }

    [Command("setBlockP")]
    public void SetBlockP([Option("id")] string blockId, [Option("p")] string? playerName = default)
    {
        var p = command.GetPlayerData(playerName ?? options.Value.DefaultPlayer).Postision;
        command.SetBlock((int)p.X, (int)p.Y, (int)p.Z, blockId);
    }

    [Command("giveItem")]
    public void GiveItem([Option("i")] string itemName, [Option("c")]int count = 1, [Option("p")] string? playerName = default)
    {
        command.SendCommand($"give {playerName ?? options.Value.DefaultPlayer} {itemName} {count}");
    }
}