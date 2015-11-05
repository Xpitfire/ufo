namespace UFO.Server.Dal.Common
{
    public enum DaoStatus
    {
        Successful,
        Failed,
        Invalid,
        Unknown
    }

    /// <summary>
    /// DAO Interface response wrapper object holding status information, possible occurred 
    /// error messages and/or the resulting typed object.
    /// </summary>
    public class DaoResponse
    {
        public DaoStatus ResponseStatus { get; set; } = DaoStatus.Unknown;

        public string ErrorMessage { get; set; }

        public object ResultObject { get; set; }
    }

    /// <summary>
    /// Typed DAO Interface response wrapper object.
    /// </summary>
    /// <typeparam name="TDaoType"></typeparam>
    public class DaoResponse<TDaoType> : DaoResponse
    {
        public new TDaoType ResultObject { get; set; }
    }
}
