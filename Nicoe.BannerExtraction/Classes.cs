using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Nicoe.BannerExtraction {
    internal static class GameCubeDiscReader {
        public static async Task<GameCubeDiscHeader> ReadGameCubeDiscHeaderAsync(this Stream stream) {
            int size = 0x440;
            byte[] buffer = new byte[size];
            if (await stream.ReadAsync(buffer, 0, size) < size) {
                throw new Exception("Not enough data");
            }
            return GameCubeDiscHeader.FromByteArray(buffer);
        }

        public static async Task<FST> ReadFSTAsync(this Stream stream, int size) {
            byte[] buffer = new byte[size];
            if (await stream.ReadAsync(buffer, 0, size) < size) {
                throw new Exception("Not enough data");
            }
            return new FST(buffer);
        }

        public static async Task<BNR> ReadBNRAsync(this Stream stream) {
            int size = 6496;
            byte[] buffer = new byte[size];
            if (await stream.ReadAsync(buffer, 0, size) < size) {
                throw new Exception("Not enough data");
            }
            return ReadBNR(buffer);
        }

        private static unsafe BNR ReadBNR(byte[] data) {
            fixed (byte* ptr = data) {
                return *(BNR*)ptr;
            }
        }
    }

    internal unsafe class FST : IDisposable {
        public readonly IntPtr Address;
        public readonly IReadOnlyList<FSTEntryNode> RootEntries;
        public readonly IReadOnlyList<FSTEntryNode> AllEntries;

        public FSTHeader* Header => (FSTHeader*)Address;
        public IntPtr StringTable => Address + Header->numEntries * 12;

        public FST(byte[] buffer) {
            Address = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, Address, buffer.Length);

            var list = new List<FSTEntryNode>();
            for (int i = 0; i < Header->numEntries; i++) {
                FSTEntry* e = (FSTEntry*)(Address + 12 * i);
                if ((e->flags & FSTFlags.Directory) != 0) {
                    FSTDirectory parent = !list.Any()
                        ? null
                        : (FSTDirectory)list[e->parentOffset];
                    var entry = new FSTDirectory(this, *e);
                    parent?.Children?.Add(entry);
                    list.Add(entry);
                } else {
                    var parent = (FSTDirectory)list.LastOrDefault(x => x is FSTDirectory);
                    var entry = new FSTFile(this, *e);
                    parent?.Children?.Add(entry);
                    list.Add(entry);
                }
            }

            AllEntries = list;
            RootEntries = (list[0] as FSTDirectory)?.Children;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                Marshal.FreeHGlobal((IntPtr)Header);
                disposedValue = true;
            }
        }
        
         ~FST() {
            Dispose(false);
        }
        
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    internal abstract class FSTEntryNode {
        public readonly FST Root;
        protected FSTEntry _entry;

        public FSTEntryNode(FST root, FSTEntry entry) {
            this.Root = root;
            this._entry = entry;
        }

        public unsafe string Name {
            get {
                return new string((sbyte*)Root.StringTable + _entry.filenameOffset);
            }
        }

        public override string ToString() {
            return $"{GetType().Name} {Name}";
        }
    }

    internal class FSTDirectory : FSTEntryNode {
        public readonly List<FSTEntryNode> Children = new List<FSTEntryNode>();

        public FSTDirectory(FST root, FSTEntry entry) : base(root, entry) { }

        public override string ToString() {
            return $"{base.ToString()} ({Children.Count} entries)";
        }
    }

    internal class FSTFile : FSTEntryNode {
        public FSTFile(FST root, FSTEntry entry) : base(root, entry) { }

        public int FileOffset => _entry.fileOffset;
        public uint Length => _entry.fileLength;
    }
}
