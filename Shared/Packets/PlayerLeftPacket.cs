
using MmoNet.Shared.Packets;

namespace Moonlapse.Shared.Packets {
    [PacketId(((int)PacketIds.PlayerLeftPacket))]
    public class PlayerLeftPacket : Packet {
        public int PlayerId { get; set; }
    }
}
