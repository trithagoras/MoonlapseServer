using MmoNet.Shared.Packets;

namespace Moonlapse.Shared.Packets {
    [PacketId(((int)PacketIds.PlayerJoinedPacket))]
    public class PlayerJoinedPacket : Packet {
        public int PlayerId { get; set; }
        public int InstanceId { get; set; }
        public string PlayerName { get; set; } = null!;
        public float X { get; set; }
        public float Y { get; set; }
        public float MoveSpeed { get; set; }
    }
}
