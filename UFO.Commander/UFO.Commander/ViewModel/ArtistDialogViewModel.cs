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
using UFO.Commander.Helper;
using UFO.Commander.Messages;
using UFO.Commander.Proxy;
using UFO.Commander.ViewModel.Entities;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("Artist Request Exception")]
    public class ArtistDialogViewModel : ViewModelBase
    {
        private ArtistViewModel _currentArtist;
        private readonly IAdminAccessBll _adminAccessBll = BllAccessHandler.AdminAccessBll;

        public ArtistViewModel CurrentArtist
        {
            get { return _currentArtist; }
            set { Set(ref _currentArtist, value); }
        }

        public ArtistDialogViewModel()
        {
            CurrentArtist = new ArtistViewModel();
            SaveCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send(new HideDialogMessage(Locator.ArtistDialogViewModel));
                Locator.ArtistOverviewViewModel.SaveCommand.Execute(null);
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
        public RelayCommand SaveCommand { get; set; }

        public override string ToString()
        {
            return "UFO Edit Artist";
        }
    }
}
