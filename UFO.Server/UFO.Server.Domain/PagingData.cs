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
        public virtual int Offset { get; set; } = Constants.InitPageOffset;

        [DataMember(Name = nameof(ResultCount))]
        public virtual int ResultCount { get; set; } = Constants.DefaultPageResultCount;

        public void Reset(int pageResultCount = Constants.DefaultPageResultCount)
        {
            Offset = Constants.InitPageOffset;
            ResultCount = pageResultCount;
        }
        
        public void ToNextPage()
        {
            Offset += ResultCount;
        }

        public void ToLastPage()
        {
            ResultCount = Constants.LastPage;
        }

        public override string ToString()
        {
            return $"BlobDataName: {Offset}, BlobDataPath: {ResultCount}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var other = obj as PagingData;
            return other != null 
                && Offset == other.Offset 
                && ResultCount == other.ResultCount;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Offset * 397) ^ ResultCount;
            }
        }

    }
}
