using System.Collections.Generic;
using System.Data;

namespace UFO.Server.Dal.Common
{
    public class QueryParameter
    {
        public virtual object ParameterValue { get; set; }
    }

    public class QueryParameter<TDbType> : QueryParameter
    {
        public virtual TDbType DbType { get; set; }
    }
}
