using PostSharp.Patterns.Model;
using UFO.Commander.Helper;
using UFO.Commander.Proxy;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class ArtistViewModel : Artist
    {
        public override int ArtistId { get; set; }
        public override string Name { get; set; }
        public override string EMail { get; set; }
        public override string PromoVideo { get; set; }
        public override Category Category { get; set; }
        public override Country Country { get; set; }
        public override BlobData Picture { get; set; }
        
        [SafeForDependencyAnalysis]
        public virtual CategoryViewModel CategoryViewModel
        {
            get { return Category.ToViewModelObject<CategoryViewModel>(); }
            set { Category = value.ToDomainObject<Category>(); }
        }

        // TODO
        [SafeForDependencyAnalysis]
        public virtual CountryViewModel CountryViewModel => Country?.ToViewModelObject<CountryViewModel>();    
    }
}
