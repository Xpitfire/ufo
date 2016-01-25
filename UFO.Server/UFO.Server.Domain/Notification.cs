using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Domain
{
    [Serializable]
    [DataContract(Name = nameof(Notification))]
    public class Notification : DomainObject
    {
        [DataMember(Name = nameof(Sender))]
        public virtual string Sender { get; set; }

        [DataMember(Name = nameof(Recipient))]
        public virtual string Recipient { get; set; }
        
        [DataMember(Name = nameof(Subject))]
        public virtual string Subject { get; set; }

        [DataMember(Name = nameof(Body))]
        public virtual string Body { get; set; }
        
        public override string ToString()
        {
            return $"Subject: {Subject}, Message: {Body}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var other = obj as Notification;

            return other != null 
                && Equals(Recipient, other.Recipient)
                && string.Equals(Subject, other.Subject)
                && string.Equals(Body, other.Body);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Recipient?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (Subject?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Body?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
