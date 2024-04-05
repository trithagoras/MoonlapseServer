using MmoNet.Shared.Packets;

namespace Moonlapse.Shared.Packets {
    [PacketId((int)PacketIds.RegisterPacket)]
    public class RegisterPacket : Packet {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
