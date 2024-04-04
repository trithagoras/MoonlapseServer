using MmoNet.Shared.Packets;

namespace MoonlapseServer.App.Packets;
[PacketId(((int)PacketIds.PositionPacket))]
public class PositionPacket : Packet {
    public required float X { get; set; }
    public required float Y { get; set; }
}
