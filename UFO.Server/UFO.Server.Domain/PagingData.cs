using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Domain
{
    [Serializable]
    [DataContract(Name = nameof(PagingData))]
    public class PagingData : DomainObject
    {
        [DataMember(Name = nameof(Offset))]
        public virtual long Offset { get; set; } = Constants.InitPageOffset;

        [DataMember(Name = nameof(Request))]
        public virtual long Request { get; set; } = Constants.DefaultPageResultCount;

        [DataMember(Name = nameof(Size))]
        public virtual long Size { get; set; } = Constants.InvalidIdValue;

        [DataMember(Name = nameof(Remaining))]
        public virtual long Remaining { get; set; }

        public void Reset(int pageResultCount = Constants.DefaultPageResultCount)
        {
            Offset = Constants.InitPageOffset;
            Request = pageResultCount;
        }

        public void ToFullRange()
        {
            Reset(Constants.LastPage);
        }

        public void ToNextPage()
        {
            Offset += Request;
        }

        public void ToLastPage()
        {
            Offset = Size - Request;
            Request = Size;
        }

        public override string ToString()
        {
            return $"BlobDataName: {Offset}, BlobDataPath: {Request}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var other = obj as PagingData;
            return other != null 
                && Offset == other.Offset 
                && Request == other.Request;
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Offset.GetHashCode();
                hashCode = (hashCode * 397) ^ Request.GetHashCode();
                hashCode = (hashCode * 397) ^ Size.GetHashCode();
                return hashCode;
            }
        }
    }
}
