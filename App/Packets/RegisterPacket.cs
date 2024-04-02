using MmoNet.Shared.Packets;

namespace MoonlapseServer.App.Packets;
[PacketId((int)PacketIds.RegisterPacket)]
public class RegisterPacket : Packet {
    public required string Username { get; set; }
    public required string Password { get; set; }
}
