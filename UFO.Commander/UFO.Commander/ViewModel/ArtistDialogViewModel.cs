using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PostSharp.Patterns.Model;
using UFO.Commander.Handler;
using UFO.Commander.Messages;
using UFO.Commander.ViewModel.Entities;
using UFO.Commander.Views.Dialogs;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("User Request Exception")]
    public class ArtistDialogViewModel : ViewModelBase
    {
        public ArtistDialogViewModel()
        {
            SaveCommand = new RelayCommand(() =>
            {
                // DO ME
                Console.WriteLine();
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

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
    }
}
