using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Threading;
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
    [ViewExceptionHandler("Artist data access Exception")]
    public class ArtistOverviewViewModel : ViewModelBase
    {
        #region ViewModels

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

        private ObservableCollection<CountryViewModel> _countries = new ObservableCollection<CountryViewModel>();
        public ObservableCollection<CountryViewModel> Countries
        {
            get { return _countries; }
            set { Set(ref _countries, value); }
        }

        private ArtistViewModel _currentArtist;
        public ArtistViewModel CurrentArtist
        {
            get { return _currentArtist; }
            set { Set(ref _currentArtist, value); }
        }

        #endregion

        private readonly IViewAccessBll _viewAccessBll = BllAccessHandler.ViewAccessBll;
        private readonly IAdminAccessBll _adminAccessBll = BllAccessHandler.AuthAccessBll;

        public ArtistOverviewViewModel()
        {
            InitializeCommands();
            LoadInitialData();
        }

        public void InitializeCommands()
        {
            NewArtistCommand = new RelayCommand(
                () => Messenger.Default.Send(new ShowDialogMessage(Locator.ArtistDialogViewModel)));

            SaveCommand = new RelayCommand<ArtistViewModel>(a =>
            {
                Dispatcher.CurrentDispatcher.InvokeAsync(() =>
                {
                    if (!Artists.Contains(a))
                        Artists.Add(a);
                });
                if (DebugHelper.IsReleaseMode)
                    _adminAccessBll.ModifyArtist(BllAccessHandler.SessionToken, a.ToDomainObject<Artist>());
            });
            DeleteArtistCommand = new RelayCommand<ArtistViewModel>(a =>
            {
                Dispatcher.CurrentDispatcher.InvokeAsync(() => Artists.Remove(a));
                if (DebugHelper.IsReleaseMode)
                    _adminAccessBll.RemoveArtist(BllAccessHandler.SessionToken, a.ToDomainObject<Artist>());
            });
        }

#region LoadData

        private PagingData ArtistPage { get; set; }
        private PagingData CategoryPage { get; set; }
        private PagingData CountryPage { get; set; }

        public async void LoadInitialData()
        {
            await Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                ArtistPage = _viewAccessBll.RequestArtistPagingData();
                ToNextArtistPage();
            });
            await Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                CategoryPage = _viewAccessBll.RequestCategoryPagingData();
                GetAllCategories();
            });
            await Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                CountryPage = _viewAccessBll.RequestCountryPagingData();
                GetAllCountries();
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
            CategoryPage.ToFullRange();
            var categories = _viewAccessBll.GetCategories(CategoryPage);
            if (categories == null)
                return;
            foreach (var category in categories)
            {
                Categories.Add(category.ToViewModelObject<CategoryViewModel>());
            }
        }

        public void GetAllCountries()
        {
            CountryPage.ToFullRange();
            var countries = _viewAccessBll.GetCountries(CountryPage);
            if (countries == null)
                return;
            foreach (var country in countries)
            {
                Countries.Add(country.ToViewModelObject<CountryViewModel>());
            }
        }

#endregion

        public RelayCommand NewArtistCommand { get; set; }
        public RelayCommand<ArtistViewModel> SaveCommand { get; set; }
        public RelayCommand<ArtistViewModel> DeleteArtistCommand { get; set; }
    }
}
