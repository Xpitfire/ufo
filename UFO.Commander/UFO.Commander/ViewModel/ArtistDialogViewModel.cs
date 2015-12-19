using System;
using System.Collections.Generic;
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
        private ArtistViewModel _currentArtist = new ArtistViewModel();
        public ArtistViewModel CurrentArtist
        {
            get { return _currentArtist; }
            set { Set(ref _currentArtist, value); }
        }

        public ArtistDialogViewModel()
        {
            SaveCommand = new RelayCommand<ArtistViewModel>(artist =>
            {
                Locator.ArtistOverviewViewModel.SaveCommand.Execute(artist);
                Messenger.Default.Send(new HideDialogMessage(Locator.ArtistDialogViewModel));
            });
            CancelCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send(new HideDialogMessage(Locator.ArtistDialogViewModel));
            });
        }

        private ArtistViewModel _artist;

        public ArtistViewModel Artist
        {
            get { return _artist; }
            set { Set(ref _artist, value); }
        }
        
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand<ArtistViewModel> SaveCommand { get; set; }
    }
}
