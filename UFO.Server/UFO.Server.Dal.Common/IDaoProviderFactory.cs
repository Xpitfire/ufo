namespace UFO.Server.Dal.Common
{
    public interface IDaoProviderFactory
    {
        IAgendaDao CreateAgendaDao();

        IArtistDao CreateArtistDao();

        IPerformanceDao CreatePerformanceDao();

        IUserDao CreateUserDao();

        IVenueDao CreateVenueDao();
    }
}
