using System;
using System.Runtime.InteropServices;

namespace Nicoe.BannerExtraction {
	public static class Int16Extension {
		public static short Reverse(this Int16 value) {
			return (short)(((value >> 8) & 0xFF) | (value << 8));
		}
	}

	public static class Int32Extension {
		public static unsafe int Reverse(this Int32 value) {
			return ((value >> 24) & 0xFF) | (value << 24) | ((value >> 8) & 0xFF00) | ((value & 0xFF00) << 8);
		}
	}

	public static class UInt16Extension {
		public static ushort Reverse(this UInt16 value) {
			return (ushort)((value >> 8) | (value << 8));
		}
	}

	public static class UInt32Extension {
		public static uint Reverse(this UInt32 value) {
			return ((value >> 24) & 0xFF) | (value << 24) | ((value >> 8) & 0xFF00) | ((value & 0xFF00) << 8);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct bint {
		internal int _data;
		public static implicit operator int(bint val) => val._data.Reverse();
		public static implicit operator bint(int val) => new bint { _data = val.Reverse() };
		public static explicit operator uint(bint val) => (uint)val._data.Reverse();
		public static explicit operator bint(uint val) => new bint { _data = (int)val.Reverse() };

		internal int Value => this;
		public override string ToString() {
			return Value.ToString();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct buint {
		internal uint _data;
		public static implicit operator uint(buint val) => val._data.Reverse();
		public static implicit operator buint(uint val) => new buint { _data = val.Reverse() };
		public static explicit operator int(buint val) => (int)val._data.Reverse();
		public static explicit operator buint(int val) => new buint { _data = (uint)val.Reverse() };

		internal uint Value => this;
		public override string ToString() {
			return Value.ToString();
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal unsafe struct bshort {
		internal short _data;
		public static implicit operator short(bshort val) => val._data.Reverse();
		public static implicit operator bshort(short val) => new bshort { _data = val.Reverse() };
		public static explicit operator ushort(bshort val) => (ushort)val._data.Reverse();
		public static explicit operator bshort(ushort val) => new bshort { _data = (short)val.Reverse() };

		internal short Value => this;
		public override string ToString() {
			return Value.ToString();
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal unsafe struct bushort {
		internal ushort _data;
		public static implicit operator ushort(bushort val) => val._data.Reverse();
		public static implicit operator bushort(ushort val) => new bushort { _data = val.Reverse() };
		public static explicit operator short(bushort val) => (short)val._data.Reverse();
		public static explicit operator bushort(short val) => new bushort { _data = (ushort)val.Reverse() };

		internal ushort Value => this;
		public override string ToString() {
			return Value.ToString();
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal unsafe struct BUInt24 {
		internal byte _dat0, _dat1, _dat2;

		internal uint Value {
			get => ((uint)_dat0 << 16) | ((uint)_dat1 << 8) | ((uint)_dat2);
			set {
				_dat2 = (byte)((value) & 0xFF);
				_dat1 = (byte)((value >> 8) & 0xFF);
				_dat0 = (byte)((value >> 16) & 0xFF);
			}
		}

		public static implicit operator int(BUInt24 val) => (int)val.Value;
		public static implicit operator BUInt24(int val) => new BUInt24((uint)val);
		public static implicit operator uint(BUInt24 val) => (uint)val.Value;
		public static implicit operator BUInt24(uint val) => new BUInt24(val);

		internal BUInt24(uint value) {
			_dat2 = (byte)((value) & 0xFF);
			_dat1 = (byte)((value >> 8) & 0xFF);
			_dat0 = (byte)((value >> 16) & 0xFF);
		}

		internal BUInt24(byte v0, byte v1, byte v2) {
			_dat2 = v2;
			_dat1 = v1;
			_dat0 = v0;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal unsafe struct UInt24 {
		internal byte _dat2, _dat1, _dat0;

		internal uint Value {
			get => ((uint)_dat0 << 16) | ((uint)_dat1 << 8) | ((uint)_dat2);
			set {
				_dat2 = (byte)((value) & 0xFF);
				_dat1 = (byte)((value >> 8) & 0xFF);
				_dat0 = (byte)((value >> 16) & 0xFF);
			}
		}

		public static implicit operator int(UInt24 val) => (int)val.Value;
		public static implicit operator UInt24(int val) => new UInt24((uint)val);
		public static implicit operator uint(UInt24 val) => (uint)val.Value;
		public static implicit operator UInt24(uint val) => new UInt24(val);

		internal UInt24(uint value) {
			_dat2 = (byte)((value) & 0xFF);
			_dat1 = (byte)((value >> 8) & 0xFF);
			_dat0 = (byte)((value >> 16) & 0xFF);
		}

		internal UInt24(byte v0, byte v1, byte v2) {
			_dat2 = v2;
			_dat1 = v1;
			_dat0 = v0;
		}
	}
}
