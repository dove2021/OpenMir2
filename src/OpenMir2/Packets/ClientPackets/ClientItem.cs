using OpenMir2.Extensions;
using System.IO;

namespace OpenMir2.Packets.ClientPackets
{
    public class ClientItem : ClientPacket
    {
        public ClientStdItem Item;
        public int MakeIndex;
        public ushort Dura;
        public ushort DuraMax;
        public byte[] Desc;

        public ClientItem()
        {
            Item = new ClientStdItem();
            Desc = new byte[14];
        }

        protected override void ReadPacket(BinaryReader reader)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 严格匹配 Delphi 客户端 TClientItem 字节布局 (Grobal2.pas)：
        /// TClientStdItem(116字节) + MakeIndex(4) + Dura(2) + DuraMax(2) = 124字节
        /// 客户端 DecodeBuffer 裸 memcpy，布局必须逐字节一致
        /// </summary>
        protected override void WritePacket(BinaryWriter writer)
        {
            writer.WriteAsciiString(Item.Name, 20); // shortstring[ItemNameLen=20]: 1字节长度前缀 + 20字节
            writer.Write(Item.StdMode);
            writer.Write(Item.Shape);
            writer.Write(Item.Weight);
            writer.Write((ushort)Item.AniCount); // 客户端为 Word
            writer.Write(Item.SpecialPwr);       // Source
            writer.Write(Item.ItemDesc);         // Reserved
            writer.Write(Item.NeedIdentify);
            writer.Write(Item.Looks);
            writer.Write(Item.DuraMax);
            writer.Write(UnpackAbil(Item.AC));  // 客户端为 Integer: LoWord=最小值 HiWord=最大值
            writer.Write(UnpackAbil(Item.MAC));
            writer.Write(UnpackAbil(Item.DC));
            writer.Write(UnpackAbil(Item.MC));
            writer.Write(UnpackAbil(Item.SC));
            writer.Write((int)Item.Need);       // 客户端为 Integer
            writer.Write((int)Item.NeedLevel);  // 客户端为 Integer
            writer.Write(Item.Price);
            writer.Write(Item.UniqueItem);
            writer.Write(Item.OverlapItem);
            writer.Write(Item.ItemType);
            writer.Write(Item.ItemSet);
            writer.Write((byte)0);              // Binded
            writer.Write(new byte[9]);          // reserve
            writer.Write(new byte[10]);         // AddOn
            writer.Write(new byte[26]);         // Eva (TEvaluation)
            writer.Write(MakeIndex);
            writer.Write(Dura);
            writer.Write(DuraMax);
        }

        /// <summary>
        /// 服务端属性打包格式 min|max&lt;&lt;8 (ushort) 转换为客户端 Integer 格式 LoWord=min, HiWord=max
        /// </summary>
        private static int UnpackAbil(ushort abil)
        {
            return (abil & 0xFF) | ((abil >> 8) << 16);
        }

        public class ClientStdItem
        {
            public string Name;
            public byte StdMode;
            public byte Shape;
            public byte Weight;
            public byte AniCount;
            public sbyte SpecialPwr;
            public byte ItemDesc;
            public ushort Looks;
            public ushort DuraMax;
            public ushort AC;
            public ushort MAC;
            public ushort DC;
            public ushort MC;
            public ushort SC;
            public byte Need;
            public byte NeedLevel;
            public byte NeedIdentify;
            public int Price;
            public int Stock;
            public byte AtkSpd;
            public byte Agility;
            public byte Accurate;
            public byte MgAvoid;
            public byte Strong;
            public byte Undead;
            public int HpAdd;
            public int MpAdd;
            public int ExpAdd;
            public byte EffType1;
            public byte EffRate1;
            public byte EffValue1;
            public byte EffType2;
            public byte EffRate2;
            public byte EffValue2;
            public byte Slowdown;
            public byte Tox;
            public byte ToxAvoid;
            public byte UniqueItem;
            public byte OverlapItem;
            public byte Light;
            public byte ItemType;
            public ushort ItemSet;
            public string Reference;
        }
    }
}