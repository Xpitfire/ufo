using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using UFO.Commander.Handler;
using UFO.Commander.Messages;
using UFO.Commander.ViewModel.Entities;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("User Request Exception")]
    public class ArtistDialogViewModel : ViewModelBase
    {
        private ArtistViewModel _currentArtist;
        public ArtistViewModel CurrentArtist
        {
            get { return _currentArtist; }
            set { Set(ref _currentArtist, value); }
        }

        public ArtistDialogViewModel()
        {
            CurrentArtist = new ArtistViewModel();
            CurrentArtist.PropertyChanged += NewUserPropertyChangedEvent;
            SaveCommand = new RelayCommand(() =>
            {
                Locator.ArtistOverviewViewModel.SaveCommand.Execute(null);
                Messenger.Default.Send(new HideDialogMessage(Locator.ArtistDialogViewModel));
                CurrentArtist = new ArtistViewModel();
                CurrentArtist.PropertyChanged += NewUserPropertyChangedEvent;
            });
            CancelCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send(new HideDialogMessage(Locator.ArtistDialogViewModel));
            });
        }

        private void NewUserPropertyChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            var value = (ArtistViewModel)sender;
            if (!Locator.ArtistOverviewViewModel.ModifiedArtists.Contains(value))
                Locator.ArtistOverviewViewModel.ModifiedArtists.Add(value);
        }

        private ArtistViewModel _artist;

        public ArtistViewModel Artist
        {
            get { return _artist; }
            set { Set(ref _artist, value); }
        }
        
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
    }
}
