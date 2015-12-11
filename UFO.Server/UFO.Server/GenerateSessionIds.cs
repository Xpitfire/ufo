using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server
{
    class GenerateSessionIds
    {
        private const int SessionKeyLength = 128;
        // available char
        private static string possibleChars = "0123456789ABCDEF";
        // optimized (?) what's available
        private static readonly char[] PossibleCharsArray = possibleChars.ToCharArray();
        // optimized (precalculated) count
        private static readonly int PossibleCharsAvailable = possibleChars.Length;
        // shared randomization thingy
        private static readonly Random Random = new Random();
        
        public static string GenerateRandomString()
        {
            var num = SessionKeyLength;
            var rBytes = new byte[num];
            Random.NextBytes(rBytes);
            var rName = new char[num];
            while (num-- > 0)
                rName[num] = PossibleCharsArray[rBytes[num] % PossibleCharsAvailable];
            return new string(rName);
        }
    }
}
