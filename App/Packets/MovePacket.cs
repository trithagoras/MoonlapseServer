
using MmoNet.Shared.Packets;

namespace MoonlapseServer.App.Packets;
[PacketId(((int)PacketIds.MovePacket))]
public class MovePacket : Packet {
    public float Dx { get; set; }
    public float Dy { get; set; }
}
