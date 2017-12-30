using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NinCFGEditor.GameCube {
    public static class GameCubeDiscReader {
        public static async Task<GameCubeDiscHeader> ReadGameCubeDiscHeaderAsync(this Stream stream) {
            int size = 0x440;
            byte[] buffer = new byte[size];
            if (await stream.ReadAsync(buffer, 0, size) < size) {
                throw new Exception("Not enough data");
            }
            return GameCubeDiscHeader.FromByteArray(buffer);
        }

        public static async Task<FST> ReadFST(this Stream stream, int size) {
            byte[] buffer = new byte[size];
            if (await stream.ReadAsync(buffer, 0, size) < size) {
                throw new Exception("Not enough data");
            }
            return new FST(buffer);
        }
    }

    public unsafe class FST : IDisposable {
        public FSTHeader* Header => (FSTHeader*)Address;
        public readonly IntPtr Address;

        public IntPtr StringTable => Address + Header->numEntries * 12;

        public FST(byte[] buffer) {
            Address = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, Address, buffer.Length);
        }

        public IEnumerable<FSTEntryNode> GetAllEntries() {
            var list = new List<FSTEntryNode>();
            for (int i = 1; i < Header->numEntries; i++) {
                FSTEntry* e = (FSTEntry*)(Address + 12 * i);
                if ((e->flags & FSTFlags.Directory) != 0) {
                    FSTDirectory parent = e->fileOffset == 0
                        ? null
                        : (FSTDirectory)list[e->fileOffset - 1];
                    list.Add(new FSTDirectory(this, *e));
                } else {
                    list.Add(new FSTFile(this, *e, (FSTDirectory)list.LastOrDefault(x => x is FSTDirectory)));
                }
            }
            return list;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects).
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                Marshal.FreeHGlobal((IntPtr)Header);
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // Override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
         ~FST() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // Uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public abstract class FSTEntryNode {
        public readonly FST Root;
        private FSTEntry _entry;
        public readonly FSTDirectory Parent;

        public FSTEntryNode(FST root, FSTEntry entry, FSTDirectory parent = null) {
            this.Root = root;
            this._entry = entry;
            this.Parent = parent;
        }

        public unsafe string Name {
            get {
                return new string((sbyte*)Root.StringTable + _entry.filenameOffset);
            }
        }
    }

    public class FSTDirectory : FSTEntryNode {
        public FSTDirectory(FST root, FSTEntry entry, FSTDirectory parent = null) : base(root, entry, parent) { }
    }

    public class FSTFile : FSTEntryNode {
        public FSTFile(FST root, FSTEntry entry, FSTDirectory parent = null) : base(root, entry, parent) { }
    }
}
