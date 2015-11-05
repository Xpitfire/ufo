namespace UFO.Server.Dal.Common
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
