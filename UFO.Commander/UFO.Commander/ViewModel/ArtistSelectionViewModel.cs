using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using UFO.Commander.Helper;
using UFO.Commander.Messages;
using UFO.Commander.Proxy;
using UFO.Commander.ViewModel.Entities;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel
{
    public class ArtistSelectionViewModel : ViewModelBase
    {
        private readonly IViewAccessBll _viewAccessBll = BllAccessHandler.ViewAccessBll;


        private ObservableCollection<ArtistViewModel> _artists = new ObservableCollection<ArtistViewModel>();
        public ObservableCollection<ArtistViewModel> Artists
        {
            get { return _artists; }
            set { Set(ref _artists, value); }
        }

        private PagingData ArtistPage { get; set; }

        public async Task ToNextArtistPage()
        {
            var parcialArtists = await _viewAccessBll.GetArtistsAsync(ArtistPage);
            if (parcialArtists == null)
                return;
            ArtistPage.ToNextPage();
            foreach (var artist in parcialArtists)
            {
                Artists.Add(artist.ToViewModelObject<ArtistViewModel>());
            }
        }

        public ArtistViewModel CurrentArtistViewModel { get; set; }

        public ArtistSelectionViewModel()
        {
            CancelCommand = new RelayCommand(() => Messenger.Default.Send(new HideDialogMessage(this)));
            Dispatcher.CurrentDispatcher.Invoke(async () =>
            {
                ArtistPage = await _viewAccessBll.RequestArtistPagingDataAsync();
                await ToNextArtistPage();
            });
        }

        public RelayCommand CancelCommand { get; set; }

        public override string ToString()
        {
            return "Select an artist";
        }
    }
}
