using PostSharp.Patterns.Model;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class ArtistViewModel : Artist
    {
        public override int ArtistId { get; set; }
        public override string Name { get; set; }
        public override string EMail { get; set; }
        public new CategoryViewModel Category { get; set; }
        public new CountryViewModel Country { get; set; }
        public new BlobDataViewModel Picture { get; set; }
        public override string PromoVideo { get; set; }
    }
}
