using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinCFGEditor {
    public class ReadOnlyByteProvider : IByteProvider {
        private byte[] _data;

        public ReadOnlyByteProvider(IEnumerable<byte> data) {
            _data = data.ToArray();
        }

        public long Length => _data.Length;

        public event EventHandler LengthChanged;
        public event EventHandler Changed;

        public void ApplyChanges() {
            return;
        }

        public void DeleteBytes(long index, long length) {
            throw new NotSupportedException();
        }

        public bool HasChanges() {
            return false;
        }

        public void InsertBytes(long index, byte[] bs) {
            throw new NotSupportedException();
        }

        public byte ReadByte(long index) {
            return _data[index];
        }

        public bool SupportsDeleteBytes() {
            return false;
        }

        public bool SupportsInsertBytes() {
            return false;
        }

        public bool SupportsWriteByte() {
            return false;
        }

        public void WriteByte(long index, byte value) {
            throw new NotSupportedException();
        }
    }
}
