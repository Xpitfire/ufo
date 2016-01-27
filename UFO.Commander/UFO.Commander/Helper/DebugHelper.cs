using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Commander.Helper
{
    public static class DebugHelper
    {
        private static bool IsDebugMode
        {
            get
            {
#if DEBUG
                return true;
#endif
                return false;
            }
        }
        public static bool IsReleaseMode { get; } = IsDebugMode;
    }
}
