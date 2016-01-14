namespace UFO.Server.Bll.Common
{
    public interface IBllProviderFactory
    {
        AAdminAccessBll CreateAAdminAccessBll();
        AViewAccessBll CreateAViewAccessBll();
    }
}
