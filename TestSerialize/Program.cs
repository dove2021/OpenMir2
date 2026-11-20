using System;
using System.Runtime.InteropServices;
using MemoryPack;
using OpenMir2.Packets.ServerPackets;

var pkt = new ServerDataPacket { PacketCode = 0x4D4F5246, PacketLen = 351 };
var bytes = SerializerUtil.Serialize(pkt);
Console.WriteLine($"Serialized ServerDataPacket length: {bytes.Length} (expected 6)");
Console.WriteLine($"Hex: {BitConverter.ToString(bytes)}");

// Also test ServerDataMessage with 351-byte data
var msg = new ServerDataMessage
{
    Type = ServerDataType.Data,
    SocketId = "test-123",
    DataLen = 351,
    Data = new byte[351]
};
var msgBytes = SerializerUtil.Serialize(msg);
Console.WriteLine($"Serialized ServerDataMessage length: {msgBytes.Length}");

static class SerializerUtil
{
    public static byte[] Serialize<T>(T origin)
    {
        return MemoryPackSerializer.Serialize(origin, MemoryPackSerializerOptions.Utf16);
    }
}
