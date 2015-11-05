using System;

namespace UFO.Server.Domain
{
    [Serializable]
    public class BlobData
    {
        public byte[] DataStream { get; set; }
    }
}
