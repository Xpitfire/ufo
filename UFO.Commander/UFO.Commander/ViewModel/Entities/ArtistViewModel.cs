using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PostSharp.Patterns.Model;
using UFO.Commander.Annotations;
using UFO.Commander.Helper;
using UFO.Commander.Proxy;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class ArtistViewModel : Artist, INotifyPropertyChanged
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
            get { return Category?.ToViewModelObject<CategoryViewModel>(); }
            set { Category = value?.ToDomainObject<Category>(); }
        }

        [SafeForDependencyAnalysis]
        public virtual CountryViewModel CountryViewModel
        {
            get { return Country?.ToViewModelObject<CountryViewModel>(); }
            set { Country = value?.ToDomainObject<Country>(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
