using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    //[ViewExceptionHandler("Request Exception")]
    public class ArtistListViewModel : ViewModelBase
    {
        private ObservableCollection<ArtistViewModel> _artists = new ObservableCollection<ArtistViewModel>();
        private readonly IViewAccessBll _viewAccessBll = BllFactory.CreateViewAccessBll();
        private PagingData Page { get; set; }

        public RelayCommand<ArtistViewModel> EditArtistCommand { get; private set; }
        public RelayCommand<ArtistViewModel> DeleteArtistCommand { get; private set; }
        public RelayCommand NewArtistCommand { get; private set; }
        public RelayCommand NextPageCommand { get; private set; }


        public ObservableCollection<ArtistViewModel> Artists
        {
            get { return _artists; }
            set { Set(ref _artists, value); }
        }

        public ArtistListViewModel()
        {
            Page = _viewAccessBll.RequestArtistPagingData();
            EditArtistCommand = new RelayCommand<ArtistViewModel>(a =>
            {
                var artistVm = ViewModelLocator.ArtistDialogViewModel;
                artistVm.Artist = a;
                Messenger.Default.Send(new ShowDialogMessage(artistVm));
            });

            NextPageCommand = new RelayCommand(ToNextPage);
        }

        public void ToNextPage()
        {
            var parcialArtists = _viewAccessBll.GetArtist(Page);
            if (parcialArtists == null)
                return;
            Page.ToNextPage();
            foreach (var artist in parcialArtists)
            {
                Artists.Add(artist.ToViewModelObject<ArtistViewModel>());
            }
        }
    }
}
