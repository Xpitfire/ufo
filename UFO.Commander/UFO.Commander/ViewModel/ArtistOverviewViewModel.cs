using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
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
    [ViewExceptionHandler("Artist Request Exception")]
    public class ArtistOverviewViewModel : ViewModelBase
    {
        #region ViewModels

        private ObservableCollection<ArtistViewModel> _artists = new ObservableCollection<ArtistViewModel>();
        public ObservableCollection<ArtistViewModel> Artists
        {
            get { return _artists; }
            set { Set(ref _artists, value); }
        }

        private ObservableCollection<ArtistViewModel> _modifiedArtists = new ObservableCollection<ArtistViewModel>();
        public ObservableCollection<ArtistViewModel> ModifiedArtists
        {
            get { return _modifiedArtists; }
            set { Set(ref _modifiedArtists, value); }
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
        private readonly IAdminAccessBll _adminAccessBll = BllAccessHandler.AdminAccessBll;

        public ArtistOverviewViewModel()
        {
            InitializeCommands();
            LoadInitialData();
        }
        
        public void InitializeCommands()
        {
            NewArtistCommand = new RelayCommand(
                () => Messenger.Default.Send(new ShowDialogMessage(Locator.ArtistDialogViewModel)));

            SaveCommand = new RelayCommand(async () =>
            {
                await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
                {
                    foreach (var modifiedArtist in ModifiedArtists)
                    {
                        CheckedAdd(Artists, modifiedArtist, model => model.ArtistId == modifiedArtist.ArtistId);
                    }
                    if (DebugHelper.IsReleaseMode)
                    {
                        var artistList = ProxyHelper.ToListOf<ArtistViewModel, Artist>(new List<ArtistViewModel>(ModifiedArtists));
                        await _adminAccessBll.ModifyArtistRangeAsync(BllAccessHandler.SessionToken, artistList);
                    }
                    lock (ModifiedArtists)
                    {
                        ModifiedArtists.Clear();
                    }
                });

            });
            DeleteArtistCommand = new RelayCommand<ArtistViewModel>(async a =>
            {
                await Dispatcher.CurrentDispatcher.InvokeAsync(() =>
                {
                    lock (Artists)
                    {
                        Artists.Remove(a);
                    }
                });
                if (DebugHelper.IsReleaseMode)
                    await _adminAccessBll.RemoveArtistAsync(BllAccessHandler.SessionToken, a.ToDomainObject<Artist>());
            });
        }

#region LoadData

        private PagingData ArtistPage { get; set; }
        private PagingData CategoryPage { get; set; }
        private PagingData CountryPage { get; set; }

        public async void LoadInitialData()
        {
            await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
            {
                ArtistPage = await _viewAccessBll.RequestArtistPagingDataAsync();
                await ToNextArtistPage();
            });
            await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
            {
                CategoryPage = await _viewAccessBll.RequestCategoryPagingDataAsync();
                await GetAllCategories();
            });
            await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
            {
                CountryPage = await _viewAccessBll.RequestCountryPagingDataAsync();
                await GetAllCountries();
            });
        }
        
        public async Task ToNextArtistPage()
        {
            var parcialArtists = await _viewAccessBll.GetArtistAsync(ArtistPage);
            if (parcialArtists == null)
                return;
            ArtistPage.ToNextPage();
            foreach (var artist in parcialArtists)
            {
                var artistViewModel = artist.ToViewModelObject<ArtistViewModel>();
                artistViewModel.PropertyChanged += (sender, args) =>
                {
                    if (CurrentArtist != null && (!Equals((ArtistViewModel) sender, CurrentArtist)))
                    {
                        CheckedAdd(ModifiedArtists, CurrentArtist, model => model.ArtistId == CurrentArtist.ArtistId);
                    }
                };
                CheckedAdd(Artists, artistViewModel, model => model.ArtistId == artistViewModel.ArtistId);
            }
        }

        private void CheckedAdd<TValue>(ObservableCollection<TValue> collection, TValue value, Func<TValue, bool> criteria)
        {
            lock (collection)
            {
                var contains = collection.Any(criteria);
                if (!contains)
                    collection.Add(value);
            }
        }

        public async Task GetAllCategories()
        {
            CategoryPage.ToFullRange();
            var categories = await _viewAccessBll.GetCategoriesAsync(CategoryPage);
            if (categories == null)
                return;
            foreach (var category in categories)
            {
                Categories.Add(category.ToViewModelObject<CategoryViewModel>());
            }
        }

        public async Task GetAllCountries()
        {
            CountryPage.ToFullRange();
            var countries = await _viewAccessBll.GetCountriesAsync(CountryPage);
            if (countries == null)
                return;
            foreach (var country in countries)
            {
                Countries.Add(country.ToViewModelObject<CountryViewModel>());
            }
        }

#endregion

        public RelayCommand NewArtistCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand<ArtistViewModel> DeleteArtistCommand { get; set; }

        public override string ToString()
        {
            return "UFO Artist Overview";
        }
    }
}
