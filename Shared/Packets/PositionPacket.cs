using MmoNet.Shared.Packets;

namespace Moonlapse.Shared.Packets {
    [PacketId(((int)PacketIds.PositionPacket))]
    public class PositionPacket : Packet {
        public float X { get; set; }
        public float Y { get; set; }
    }
}
