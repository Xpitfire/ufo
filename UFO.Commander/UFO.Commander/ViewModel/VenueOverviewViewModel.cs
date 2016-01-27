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
using UFO.Commander.Handler;
using UFO.Commander.Helper;
using UFO.Commander.Messages;
using UFO.Commander.Proxy;
using UFO.Commander.ViewModel.Entities;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("Venue data access Exception")]
    public class VenueOverviewViewModel : ViewModelBase
    {
        private ViewModelBase _currentContent;
        public ViewModelBase CurrentContent
        {
            get { return _currentContent; }
            set { Set(ref _currentContent, value); }
        }

        private ObservableCollection<LocationViewModel> _locations = new ObservableCollection<LocationViewModel>();
        public ObservableCollection<LocationViewModel> Locations
        {
            get { return _locations; }
            set { Set(ref _locations, value); }
        }

        private ObservableCollection<LoctionTreeItemViewModel> _loctionTreeViewModel = new ObservableCollection<LoctionTreeItemViewModel>();
        public ObservableCollection<LoctionTreeItemViewModel> LocationTreeViewModel
        {
            get { return _loctionTreeViewModel; }
            set { Set(ref _loctionTreeViewModel, value); }
        }

        private LoctionTreeItemViewModel _currentLocationTreeItem;
        public LoctionTreeItemViewModel CurrentLocationTreeItem
        {
            get { return _currentLocationTreeItem; }
            set { Set(ref _currentLocationTreeItem, value); }
        }

        private VenueViewModel _currentVenueViewModel;
        public VenueViewModel CurrentVenueViewModel
        {
            get { return _currentVenueViewModel; }
            set { Set(ref _currentVenueViewModel, value); }
        }

        public void SetSelectedItem(object item)
        {
            var venueViewModel = item as VenueViewModel;
            if (venueViewModel != null)
            {
                CurrentVenueViewModel = venueViewModel;
                Messenger.Default.Send(new ShowVenueOverviewContentMessage(Locator.VenueEditViewModel));
            }
            var locationTreeItem = item as LoctionTreeItemViewModel;
            if (locationTreeItem != null)
            {
                CurrentLocationTreeItem = locationTreeItem;
                Messenger.Default.Send(new ShowVenueOverviewContentMessage(Locator.LocationEditViewModel));
            }
        }

        private readonly IViewAccessBll _viewAccessBll = BllAccessHandler.ViewAccessBll;
        private readonly IAdminAccessBll _adminAccessBll = BllAccessHandler.AdminAccessBll;

        public VenueOverviewViewModel()
        {
            LoadInitialData();
            InitializeCommands();
            Messenger.Default.Register<ShowVenueOverviewContentMessage>(this, msg => CurrentContent = msg.ViewModel);
        }

        private void InitializeCommands()
        {
            SaveVenueCommand = new RelayCommand(async () =>
            {
                await Dispatcher.CurrentDispatcher.InvokeAsync(() =>
                {
                    foreach (var treeItemViewModel in LocationTreeViewModel)
                    {
                        if (!treeItemViewModel.Venues.Contains(CurrentVenueViewModel)
                        && treeItemViewModel.LocationViewModel.LocationId == CurrentVenueViewModel.LocationViewModel.LocationId)
                        {
                            treeItemViewModel.Venues.Add(CurrentVenueViewModel);
                            Messenger.Default.Send(new HideDialogMessage(Locator.VenueDialogViewModel));
                            break;
                        }
                    }
                });
                if (DebugHelper.IsReleaseMode)
                    await _adminAccessBll.ModifyVenueAsync(BllAccessHandler.SessionToken,
                        CurrentVenueViewModel.ToDomainObject<Venue>());
                Locator.LocationEditViewModel.IsNew = new object();
            });

            DeleteVenueCommand = new RelayCommand(async () =>
            {
                await Dispatcher.CurrentDispatcher.InvokeAsync(() =>
                {
                    foreach (var treeItemViewModel in LocationTreeViewModel)
                    {
                        if (treeItemViewModel.Venues.Contains(CurrentVenueViewModel))
                            treeItemViewModel.Venues.Remove(CurrentVenueViewModel);
                    }
                });
                if (DebugHelper.IsReleaseMode)
                    await _adminAccessBll.RemoveVenueAsync(BllAccessHandler.SessionToken,
                        CurrentVenueViewModel.ToDomainObject<Venue>());
                Locator.LocationEditViewModel.IsNew = new object();
            });

            SaveLocationCommand = new RelayCommand(async () =>
            {
                await Dispatcher.CurrentDispatcher.InvokeAsync(() =>
                {
                    if (!LocationTreeViewModel.Contains(CurrentLocationTreeItem))
                    {
                        Locations.Add(CurrentLocationTreeItem.LocationViewModel);
                        LocationTreeViewModel.Add(CurrentLocationTreeItem);
                        Messenger.Default.Send(new HideDialogMessage(Locator.LocationDialogViewModel));
                    }
                });
                if (DebugHelper.IsReleaseMode)
                    await _adminAccessBll.ModifyLocationAsync(BllAccessHandler.SessionToken,
                        CurrentLocationTreeItem.LocationViewModel.ToDomainObject<Location>());
                Locator.LocationEditViewModel.IsNew = new object();
            });

            DeleteLocationCommand = new RelayCommand(async () =>
            {
                await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
                {
                    var curLocationItem = CurrentLocationTreeItem;
                    foreach (var venue in curLocationItem.Venues)
                    {
                        if (DebugHelper.IsReleaseMode)
                            await _adminAccessBll.RemoveVenueAsync(BllAccessHandler.SessionToken,
                                venue.ToDomainObject<Venue>());
                    }
                    curLocationItem.Venues.Clear();
                    LocationTreeViewModel.Remove(curLocationItem);
                    if (DebugHelper.IsReleaseMode)
                        await _adminAccessBll.RemoveLocationAsync(BllAccessHandler.SessionToken,
                            curLocationItem.LocationViewModel.ToDomainObject<Location>());
                    Locator.LocationEditViewModel.IsNew = new object();
                });
            });

            NewLocationCommand = new RelayCommand(() =>
            {
                CurrentLocationTreeItem = new LoctionTreeItemViewModel(new List<VenueViewModel>())
                {
                    LocationViewModel = new LocationViewModel()
                };
                Locator.LocationEditViewModel.IsNew = null;
                Messenger.Default.Send(new ShowDialogMessage(Locator.LocationDialogViewModel));
            });
            NewVenueCommand = new RelayCommand(() =>
            {
                CurrentVenueViewModel = new VenueViewModel();
                Locator.LocationEditViewModel.IsNew = null;
                Messenger.Default.Send(new ShowDialogMessage(Locator.VenueDialogViewModel));
            });
        }

        private PagingData LocationPage { get; set; }
        private PagingData VenuePage { get; set; }

        public async void LoadInitialData()
        {
            await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
            {
                LocationPage = await _viewAccessBll.RequestLocationPagingDataAsync();
                VenuePage = await _viewAccessBll.RequestVenuePagingDataAsync();
                await InitializeData();
            });
        }

        public async Task InitializeData()
        {
            LocationPage.ToFullRange();
            var locations = await _viewAccessBll.GetLocationsAsync(LocationPage);
            if (locations == null) return;

            VenuePage.ToFullRange();
            var venueList = ProxyHelper.ToListOf<Venue, VenueViewModel>(await _viewAccessBll.GetVenuesAsync(VenuePage));
            if (venueList == null) return;

            foreach (var location in locations)
            {
                var venues = venueList.Where(v => v.Location.LocationId == location.LocationId);
                var locationTreeItem = new LoctionTreeItemViewModel(venues.ToList())
                {
                    LocationViewModel = location.ToViewModelObject<LocationViewModel>()
                };
                LocationTreeViewModel.Add(locationTreeItem);
                Locations.Add(location.ToViewModelObject<LocationViewModel>());
            }
        }

        public RelayCommand SaveVenueCommand { get; set; }
        public RelayCommand DeleteVenueCommand { get; set; }
        public RelayCommand NewVenueCommand { get; set; }
        public RelayCommand SaveLocationCommand { get; set; }
        public RelayCommand DeleteLocationCommand { get; set; }
        public RelayCommand NewLocationCommand { get; set; }

        public class LoctionTreeItemViewModel : ViewModelBase
        {
            public LoctionTreeItemViewModel(IList<VenueViewModel> venues)
            {
                Venues = new ObservableCollection<VenueViewModel>(venues);
            }

            private ObservableCollection<VenueViewModel> _venues;
            public ObservableCollection<VenueViewModel> Venues
            {
                get { return _venues; }
                set { Set(ref _venues, value); }
            }

            public LocationViewModel LocationViewModel { get; set; }
        }

        public override string ToString()
        {
            return "UFO Venue Overview";
        }
    }
}
