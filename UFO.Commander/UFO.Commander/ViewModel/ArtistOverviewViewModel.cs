using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PostSharp.Patterns.Model;
using UFO.Commander.Helper;
using UFO.Commander.Messages;
using UFO.Commander.Proxy;
using UFO.Commander.ViewModel.Entities;
using UFO.Commander.Views.Dialogs;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel
{
    public class ArtistOverviewViewModel : ViewModelBase
    {
        private ObservableCollection<ArtistViewModel> _artists = new ObservableCollection<ArtistViewModel>();
        public ObservableCollection<ArtistViewModel> Artists
        {
            get { return _artists; }
            set { Set(ref _artists, value); }
        }

        private ObservableCollection<CategoryViewModel> _categories = new ObservableCollection<CategoryViewModel>();
        public ObservableCollection<CategoryViewModel> Categories
        {
            get { return _categories; }
            set { Set(ref _categories, value); }
        }

        private readonly IViewAccessBll _viewAccessBll = BllFactory.CreateViewAccessBll();
        private PagingData ArtistPage { get; set; }
        private PagingData CategoryPage { get; set; }

        public ArtistOverviewViewModel()
        {
            InitializeData();
            LoadInitialData();
        }

        public void InitializeData()
        {
            NextPageCommand = new RelayCommand(ToNextArtistPage);
            EditArtistCommand = new RelayCommand<ArtistViewModel>(a =>
            {
                var artistVm = Locator.ArtistDialogViewModel;
                artistVm.Artist = a;
                Messenger.Default.Send(new ShowDialogMessage<ArtistDialog>(artistVm));
            });
        }

        public void LoadInitialData()
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                ArtistPage = _viewAccessBll.RequestArtistPagingData();
                ToNextArtistPage();
            });
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                CategoryPage = _viewAccessBll.RequestCategoryPagingData();
                GetAllCategories();
            });
        }

        public void ToNextArtistPage()
        {
            var parcialArtists = _viewAccessBll.GetArtist(ArtistPage);
            if (parcialArtists == null)
                return;
            ArtistPage.ToNextPage();
            foreach (var artist in parcialArtists)
            {
                Artists.Add(artist.ToViewModelObject<ArtistViewModel>());
            }
        }

        public void GetAllCategories()
        {
            CategoryPage.ToLastPage();
            var artists = _viewAccessBll.GetArtist(CategoryPage);
            if (artists == null)
                return;
            foreach (var category in artists)
            {
                Categories.Add(category.ToViewModelObject<CategoryViewModel>());
            }
        }

        public RelayCommand NewArtistCommand { get; private set; }
        public RelayCommand NextPageCommand { get; private set; }
        public RelayCommand<ArtistViewModel> EditArtistCommand { get; private set; }
        public RelayCommand<ArtistViewModel> DeleteArtistCommand { get; private set; }

    }
}
