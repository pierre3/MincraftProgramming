internal class AppSettings
{
    public MinecraftServer MinecraftServer { get; set; } = new MinecraftServer();
}

class MinecraftServer
{
    public string Address { get; set; } = "127.0.0.1";
    public ushort Port { get; set; } = 25575;
    public string Pass { get; set; } = "password";
}
