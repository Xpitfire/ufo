using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FH.SEv.UFO.Server.Model.Commands
{
    public enum DaoStatus
    {
        Successful,
        Failed,
        Invalid,
        Unknown
    }

    public class DaoResponse
    {
        public DaoStatus ResponseStatus { get; set; } = DaoStatus.Unknown;

        public string ErrorMessage { get; set; }

        public object ResultObject { get; set; }
    }

    public class DaoResponse<T> : DaoResponse
    {
        public new T ResultObject { get; set; }
    }
}
