using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nicoe.BannerExtraction {
    public static class Banner {
        private static Task<string> FindISOPath(string relativePath) {
            return Task.Run(() => {
                while (relativePath.Length > 0 && relativePath[0] == '/') {
                    relativePath = relativePath.Substring(1);
                }
                foreach (var driveInfo in DriveInfo.GetDrives()) {
                    string p = Path.Combine(driveInfo.RootDirectory.FullName, relativePath);
                    try {
                        if (File.Exists(p)) return p;
                    } catch (Exception ex) {
                        Console.Error.WriteLine(ex.Message);
                        Console.Error.WriteLine(ex.StackTrace);
                    }
                }
                throw new Exception("The GameCube disc image could not be found on any attached drives. Make sure the path is correct.");
            });
        }

        public static async Task<string> ReadGameId(string relativePath) {
            string path = await FindISOPath(relativePath);
            byte[] buffer = new byte[4];
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                fs.Read(buffer, 0, 4);
            }
            char[] characters = buffer.Select(b => (char)b).ToArray();
            return new string(characters);
        }

        private static FSTFile FindFile(IEnumerable<FSTEntryNode> entries, string name) {
            foreach (var e in entries) {
                var f = e as FSTFile;
                if (f != null && f.Name == name) return f;
            }
            foreach (var e in entries) {
                var d = e as FSTDirectory;
                if (d != null) {
                    var f = FindFile(d.Children, name);
                    if (f != null) return f;
                }
            }
            return null;
        }

        public static async Task<BNR> ExportGameCubeBanner(string relativePath) {
            string path = await FindISOPath(relativePath);
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1048576)) {
                var h = await fs.ReadGameCubeDiscHeaderAsync();

                if (h.header.gcnMagicWord != 0xc2339f3d) {
                    throw new Exception("This does not look like a GameCube disc.");
                }

                fs.Position = h.fstOffset;
                var fst = await fs.ReadFSTAsync(h.fstSize);

                var entry = FindFile(fst.RootEntries, "opening.bnr");

                if (entry == null) {
                    throw new Exception("Could not find opening.bnr.");
                }

                fs.Position = entry.FileOffset;
                return await fs.ReadBNRAsync();
            }
        }
    }
}
