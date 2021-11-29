using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Nicoe.BannerExtraction {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct BNR {
        public fixed sbyte tag[4];
        public fixed byte padding[28];
        private fixed byte _imageData[6144];
        public fixed sbyte game_short[32];
        public fixed sbyte developer_short[32];
        public fixed sbyte game_long[64];
        public fixed sbyte developer_long[64];
        public fixed sbyte description[128];

        internal bushort* imageData {
            get {
                fixed (byte* ptr = _imageData) return (bushort*)ptr;
            }
        }

        public Bitmap GetImage() {
            var b = new Bitmap(96, 32, PixelFormat.Format16bppArgb1555);
            BitmapData data = b.LockBits(new Rectangle(0, 0, 96, 32), ImageLockMode.ReadWrite, PixelFormat.Format16bppArgb1555);

            bushort* pixels = imageData;
            for (int colblock = 0; colblock < 8; colblock++) {
                ushort* row0 = (ushort*)data.Scan0 + 384 * colblock;
                ushort* row1 = row0 + 96;
                ushort* row2 = row1 + 96;
                ushort* row3 = row2 + 96;
                for (int rowblock = 0; rowblock < 24; rowblock++) {
                    for (int i = 0; i < 4; i++) *row0++ = *pixels++;
                    for (int i = 0; i < 4; i++) *row1++ = *pixels++;
                    for (int i = 0; i < 4; i++) *row2++ = *pixels++;
                    for (int i = 0; i < 4; i++) *row3++ = *pixels++;
                }
            }

            b.UnlockBits(data);
            return b;
        }

        public string GameShort {
            get {
                fixed (sbyte* ptr = game_short) return new string(ptr);
            }
        }

        public string GameLong {
            get {
                fixed (sbyte* ptr = game_long) return new string(ptr);
            }
        }

        public string DeveloperShort {
            get {
                fixed (sbyte* ptr = developer_short) return new string(ptr);
            }
        }

        public string DeveloperLong {
            get {
                fixed (sbyte* ptr = developer_long) return new string(ptr);
            }
        }

        public string DescriptionString {
            get {
                fixed (sbyte* ptr = description) return new string(ptr);
            }
        }
    }
}
