using System;
using System.Runtime.InteropServices;

namespace Nicoe.BannerExtraction {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct NintendoDiscHeader {
        public sbyte discId;
        public fixed sbyte gameCode[2];
        public sbyte regionCode;
        public fixed sbyte makerCode[2];
        public byte discNumber;
        byte discVersion;
        public byte audioStreaming;
        public byte streamingBufferSize;
        public fixed byte unused[14];
        public BUInt32 wiiMagicWord;
        public BUInt32 gcnMagicWord;
        public fixed sbyte gameTitle[64];

        public string GameID {
            get {
                fixed (sbyte* ptr = &discId) {
                    return new string(ptr);
                }
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x440)]
    internal unsafe struct GameCubeDiscHeader {
        [FieldOffset(0)]
        public NintendoDiscHeader header;
        [FieldOffset(0x420)]
        public BInt32 dolOffset;
        [FieldOffset(0x424)]
        public BInt32 fstOffset;
        [FieldOffset(0x428)]
        public BInt32 fstSize;
        [FieldOffset(0x42C)]
        public BInt32 multiDiscMaxFstSize;

        public static GameCubeDiscHeader FromByteArray(byte[] data, int offset = 0) {
            if (data.Length - offset < sizeof(GameCubeDiscHeader)) {
                throw new ArgumentException("Data after offset too short");
            }
            GameCubeDiscHeader h;
            Marshal.Copy(data, offset, new IntPtr(&h), sizeof(GameCubeDiscHeader));
            return h;
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    internal unsafe struct FSTHeader {
        [FieldOffset(8)]
        public BInt32 numEntries;
    }

    internal enum FSTFlags : byte {
        File = 0,
        Directory = 1
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    internal unsafe struct FSTEntry {
        [FieldOffset(0)]
        public FSTFlags flags;
        [FieldOffset(1)]
        public BUInt24 filenameOffset;
        [FieldOffset(4)]
        public BInt32 fileOffset;
        [FieldOffset(4)]
        public BInt32 parentOffset;
        [FieldOffset(8)]
        public BUInt32 fileLength;
    }
}
