using System.Runtime.InteropServices;

namespace Nicoe.BannerExtraction {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal unsafe struct BInt16 {
		internal byte _dat08, _dat00;

		internal short Value {
			get => (short)((_dat08 << 8) | _dat00);
			set {
				_dat08 = (byte)((value >> 8) & 0xFF);
				_dat00 = (byte)((value) & 0xFF);
			}
		}

		public static implicit operator short(BInt16 val) => val.Value;
		public static implicit operator BInt16(short val) => new BInt16(val);

		internal BInt16(short value) {
			_dat00 = (byte)((value) & 0xFF);
			_dat08 = (byte)((value >> 8) & 0xFF);
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal unsafe struct BUInt16 {
		internal byte _dat08, _dat00;

		internal ushort Value {
			get => (ushort)((_dat08 << 8) | _dat00);
			set {
				_dat08 = (byte)((value >> 8) & 0xFF);
				_dat00 = (byte)((value) & 0xFF);
			}
		}

		public static implicit operator ushort(BUInt16 val) => val.Value;
		public static implicit operator BUInt16(ushort val) => new BUInt16(val);

		internal BUInt16(ushort value) {
			_dat00 = (byte)((value) & 0xFF);
			_dat08 = (byte)((value >> 8) & 0xFF);
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal unsafe struct BUInt24 {
		internal byte _dat16, _dat08, _dat00;

		internal uint Value {
			get => ((uint)_dat16 << 16) | ((uint)_dat08 << 8) | ((uint)_dat00);
			set {
				_dat00 = (byte)((value) & 0xFF);
				_dat08 = (byte)((value >> 8) & 0xFF);
				_dat16 = (byte)((value >> 16) & 0xFF);
			}
		}

		public static implicit operator uint(BUInt24 val) => val.Value;
		public static implicit operator BUInt24(uint val) => new BUInt24(val);

		internal BUInt24(uint value) {
			_dat00 = (byte)((value) & 0xFF);
			_dat08 = (byte)((value >> 8) & 0xFF);
			_dat16 = (byte)((value >> 16) & 0xFF);
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal unsafe struct BInt32 {
		internal byte _dat24, _dat16, _dat08, _dat00;

		internal int Value {
			get => (_dat24 << 24) | (_dat16 << 16) | (_dat08 << 8) | _dat00;
			set {
				_dat24 = (byte)((value >> 24) & 0xFF);
				_dat16 = (byte)((value >> 16) & 0xFF);
				_dat08 = (byte)((value >> 8) & 0xFF);
				_dat00 = (byte)((value) & 0xFF);
			}
		}

		public static implicit operator int(BInt32 val) => val.Value;
		public static implicit operator BInt32(int val) => new BInt32(val);

		internal BInt32(int value) {
			_dat00 = (byte)((value) & 0xFF);
			_dat08 = (byte)((value >> 8) & 0xFF);
			_dat16 = (byte)((value >> 16) & 0xFF);
			_dat24 = (byte)((value >> 24) & 0xFF);
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal unsafe struct BUInt32 {
		internal byte _dat24, _dat16, _dat08, _dat00;

		internal uint Value {
			get => (uint)((_dat24 << 24) | (_dat16 << 16) | (_dat08 << 8) | _dat00);
			set {
				_dat24 = (byte)((value >> 24) & 0xFF);
				_dat16 = (byte)((value >> 16) & 0xFF);
				_dat08 = (byte)((value >> 8) & 0xFF);
				_dat00 = (byte)((value) & 0xFF);
			}
		}

		public static implicit operator uint(BUInt32 val) => val.Value;
		public static implicit operator BUInt32(uint val) => new BUInt32(val);

		internal BUInt32(uint value) {
			_dat00 = (byte)((value) & 0xFF);
			_dat08 = (byte)((value >> 8) & 0xFF);
			_dat16 = (byte)((value >> 16) & 0xFF);
			_dat24 = (byte)((value >> 24) & 0xFF);
		}
	}
}
