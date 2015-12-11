using System;
using System.Linq;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    [Serializable]
    public class SessionToken
    {
        public char[] SessionId { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return Convert.ToString(SessionId);
        }

        public override bool Equals(object obj)
        {
            var token = obj as SessionToken;
            return token != null 
                && SessionId.SequenceEqual(token.SessionId)
                && User.Equals(token.User);
        }

        public override int GetHashCode()
        {
            var hashCode = 34;
            hashCode += SessionId?.GetHashCode() ?? 0;
            hashCode += User?.GetHashCode() ?? 0;
            return hashCode;
        }
    }
}
