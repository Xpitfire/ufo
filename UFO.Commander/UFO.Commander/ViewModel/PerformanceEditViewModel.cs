using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UFO.Commander.Helper;
using UFO.Commander.ViewModel.Entities;
using UFO.Server.Bll.Common;
using GalaSoft.MvvmLight.Messaging;
using UFO.Commander.Messages;
using UFO.Commander.Proxy;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel
{
    public class PerformanceEditViewModel : ViewModelBase
    {
        private readonly IViewAccessBll _viewAccessBll = BllAccessHandler.ViewAccessBll;
        private readonly IAdminAccessBll _adminAccessBll = BllAccessHandler.AdminAccessBll;


        public PerformanceEditViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            SaveCommand = new RelayCommand((() =>
            {
                if (CurrentVenueViewModel == null 
                || CurrentArtistViewModel == null 
                || string.IsNullOrEmpty(DateTimeViewModel.Hour))
                    return;

                var performance = new Performance
                {
                    DateTime = DateTimeViewModel.DateTime,
                    Artist = CurrentArtistViewModel.ToDomainObject<Artist>(),
                    Venue = CurrentVenueViewModel.ToDomainObject<Venue>()
                };
                _adminAccessBll.ModifyPerformance(BllAccessHandler.SessionToken, performance);
                Locator.PerformanceOverviewViewModel.Performances.Add(performance.ToViewModelObject<PerformanceViewModel>());
                ResetData();
                Locator.PerformanceOverviewViewModel.AddNotification(
                    performance.ToViewModelObject<PerformanceViewModel>(), (IsNew) ? NotificationType.Add : NotificationType.Modified);
                Messenger.Default.Send(new HideDialogMessage(Locator.PerformanceEditViewModel));
            }));
            CancelCommand = new RelayCommand((() =>
            {
                Messenger.Default.Send(new HideDialogMessage(Locator.PerformanceEditViewModel));
            }));

            DateTimeViewModel = new DateTimeViewModel(DateTime.Now);
            for (var i = 14; i < 25; i++)
            {
                var hour = $"{i%24}:00";
                if (i == 24)
                    hour = $"0{hour}";
                Hours.Add(hour);
            }

            LoadData();
        }

        private bool IsNew { get; set; }

        public void ResetData()
        {
            CurrentVenueViewModel = new VenueViewModel();
            CurrentArtistViewModel = new ArtistViewModel();
            DateTimeViewModel = new DateTimeViewModel(DateTime.Now);
            IsNew = true;
        }

        public void InitializePreset(VenueViewModel venue, ArtistViewModel artist, DateTimeViewModel dateTime)
        {
            CurrentVenueViewModel = venue;
            CurrentArtistViewModel = artist;
            DateTimeViewModel = dateTime;
            IsNew = false;
        }

        private async void LoadData()
        {
            await Task.Run((() =>
            {
                Artists.Clear();
                var page = _viewAccessBll.RequestArtistPagingData();
                var artists = _viewAccessBll.GetArtists(page);
                while (artists != null && artists.Any())
                {
                    foreach (var artist in artists)
                    {
                        Artists.Add(artist.ToViewModelObject<ArtistViewModel>());
                    }
                    page.ToNextPage();
                    artists = _viewAccessBll.GetArtists(page);
                }
                Artists = new ObservableCollection<ArtistViewModel>(Artists.OrderBy(model => model.ArtistId));

                Venues.Clear();
                page = _viewAccessBll.RequestVenuePagingData();
                var venues = _viewAccessBll.GetVenues(page);
                while (venues != null && venues.Any())
                {
                    foreach (var venue in venues)
                    {
                        Venues.Add(venue.ToViewModelObject<VenueViewModel>());
                    }
                    page.ToNextPage();
                    venues = _viewAccessBll.GetVenues(page);
                }
                Venues = new ObservableCollection<VenueViewModel>(Venues.OrderBy(model => model.VenueId));

            }));
        }
        
        private DateTimeViewModel _dateTimeViewModel;
        public DateTimeViewModel DateTimeViewModel
        {
            get { return _dateTimeViewModel; }
            set { Set(ref _dateTimeViewModel, value); }
        }
        
        public ObservableCollection<string> Hours { get; } = new ObservableCollection<string>();

        private ObservableCollection<ArtistViewModel> _artists = new ObservableCollection<ArtistViewModel>();
        public ObservableCollection<ArtistViewModel> Artists
        {
            get { return _artists; }
            set { Set(ref _artists, value); }
        }
        public ArtistViewModel CurrentArtistViewModel { get; set; }

        private ObservableCollection<VenueViewModel> _venues = new ObservableCollection<VenueViewModel>();
        public ObservableCollection<VenueViewModel> Venues
        {
            get { return _venues; }
            set { Set(ref _venues, value); }
        }
        public VenueViewModel CurrentVenueViewModel { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public override string ToString()
        {
            return "Add new Performance";
        }
    }

}
