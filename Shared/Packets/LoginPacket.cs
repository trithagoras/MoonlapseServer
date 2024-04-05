using MmoNet.Shared.Packets;

namespace Moonlapse.Shared.Packets {
    [PacketId((int)PacketIds.LoginPacket)]
    public class LoginPacket : Packet {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
