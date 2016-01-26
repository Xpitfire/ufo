using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using UFO.Commander.Handler;
using UFO.Commander.Helper;
using UFO.Commander.Proxy;
using UFO.Commander.ViewModel.Entities;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("Performance Request Exception")]
    public class PerformanceOverviewViewModel : ViewModelBase
    {
        public event EventHandler<ObservableCollection<PerformanceViewModel>> DataAvailableEvent;

        private readonly IViewAccessBll _viewAccessBll = BllAccessHandler.ViewAccessBll;
        private readonly IAdminAccessBll _adminAccessBll = BllAccessHandler.AdminAccessBll;
        
        public ObservableCollection<DateTimeViewModel> PerformanceDates { get; } = new ObservableCollection<DateTimeViewModel>();
        public ObservableCollection<PerformanceViewModel> Performances { get; } = new ObservableCollection<PerformanceViewModel>();

        private PerformanceViewModel _currentPerformanceViewModel;
        public PerformanceViewModel CurrentPerformanceViewModel
        {
            get { return _currentPerformanceViewModel; }
            set { Set(ref _currentPerformanceViewModel, value); }
        }

        private DateTime _currentPerformanceDateTime;
        public DateTime CurrentPerformanceDateTime
        {
            get { return _currentPerformanceDateTime; }
            set
            {
                if (_currentPerformanceDateTime != value)
                {
                    Set(ref _currentPerformanceDateTime, value);
                    Dispatcher.CurrentDispatcher.InvokeAsync(async () => await LoadData());
                }
            }
        }

        public PerformanceOverviewViewModel()
        {
            InitializeData();
        }

        public async void InitializeData()
        {
            await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
            {
                var dates = await _viewAccessBll.GetAllPerformanceDatesAsync();
                CurrentPerformanceDateTime = dates.FirstOrDefault();
                foreach (var dateTime in dates)
                {
                    PerformanceDates.Add(new DateTimeViewModel(dateTime));
                }
            });
            AddNewPerformanceCommand = new RelayCommand(() =>
            {
                
            });
            DeletePerformanceCommand = new RelayCommand<PerformanceViewModel>(p =>
            {
                var result = _adminAccessBll.RemovePerformance(BllAccessHandler.SessionToken, p.ToDomainObject<Performance>());
                if (result)
                {
                    Performances.Remove(p);
                }
            });
        }

        public async Task LoadData()
        {
            var performances = await _viewAccessBll.GetPerformancesPerDateAsync(CurrentPerformanceDateTime);
            if (performances != null)
            {
                performances.Sort((p1, p2) => 
                p1.DateTime.CompareTo(p2.DateTime) + string.Compare(p1.Venue.VenueId, p2.Venue.VenueId, StringComparison.Ordinal));
               Performances.Clear();
                foreach (var p in performances)
                {
                    var pvm = p.ToViewModelObject<PerformanceViewModel>();
                    pvm.DateTimeViewModel = new DateTimeViewModel(p.DateTime);
                    Performances.Add(pvm);
                }
                DataAvailableEvent?.Invoke(this, Performances);
            }
        }

        public ICommand AddNewPerformanceCommand { get; set; }

        public ICommand DeletePerformanceCommand { get; set; }

        public override string ToString()
        {
            return "UFO Performance Overview";
        }
    }
}
