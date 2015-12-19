using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
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
        public virtual BitmapImage Image => LoadImage(Picture?.DataStream);

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

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
