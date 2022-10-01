using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DykBits.Crm.Data
{
    public class RemoteStream: Stream
    {
        private Stream _baseStream;
        private RemoteDataService _client;
        public RemoteStream(Stream baseStream, RemoteDataService client)
        {
            this._baseStream = baseStream;
            this._client = client;
        }
        public override bool CanRead
        {
            get { return _baseStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _baseStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _baseStream.CanWrite; }
        }

        public override void Flush()
        {
            _baseStream.Flush();
        }

        public override long Length
        {
            get { return _baseStream.Length; }
        }

        public override long Position
        {
            get
            {
                return _baseStream.Position;
            }
            set
            {
                _baseStream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _baseStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _baseStream.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            _baseStream.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _baseStream.Write(buffer, offset, count);
        }
        public override void Close()
        {
            _baseStream.Close();
            _client.Close();
            base.Close();
        }
    }
}
