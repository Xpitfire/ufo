using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
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
        public const int MaxPerformances = 24;

        public event EventHandler<ObservableCollection<TimeSlotPerformanceViewModel>> DataAvailableEvent;

        private readonly IViewAccessBll _viewAccessBll = BllAccessHandler.ViewAccessBll;
        private readonly IAdminAccessBll _adminAccessBll = BllAccessHandler.AdminAccessBll;

        private DateTime _currentPerformanceDateTime = DateTime.Parse("2015-11-15");
        public DateTime CurrentPerformanceDateTime
        {
            get { return _currentPerformanceDateTime; }
            set
            {
                Set(ref _currentPerformanceDateTime, value);
                LoadInitialData();
            }
        }

        public ObservableCollection<TimeSlotPerformanceViewModel> TimeSlotPerformanceViewModels { get; } = new ObservableCollection<TimeSlotPerformanceViewModel>();
        
        public class TimeSlotPerformanceViewModel : ViewModelBase
        {
            private string _timeKey;
            public string TimeKey
            {
                get { return _timeKey; }
                set { Set(ref _timeKey, value); }
            }
            
            private PerformanceViewModel _performanceViewModel;
            public PerformanceViewModel PerformanceViewModel
            {
                get { return _performanceViewModel; }
                set { Set(ref _performanceViewModel, value); }
            }
        }

        private TimeSlotPerformanceViewModel _currentPerformanceViewModel;
        public TimeSlotPerformanceViewModel CurrentPerformanceViewModel
        {
            get { return _currentPerformanceViewModel; }
            set { Set(ref _currentPerformanceViewModel, value); }
        }
        
        public PerformanceOverviewViewModel()
        {
            LoadInitialData();
        }

        public async void LoadInitialData()
        {
            await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
            {
                TimeSlotPerformanceViewModels.Clear();
                await InitializeData();
            });
        }

        public async Task InitializeData()
        {

            var performances = await _viewAccessBll.GetPerformancesPerDateAsync(CurrentPerformanceDateTime);
            if (performances == null) return;
            
            foreach (var performance in performances)
            {
                var time = performance.DateTime.ToString("HH:mm");
                var timeSlot = new TimeSlotPerformanceViewModel
                {
                    TimeKey = time,
                    PerformanceViewModel = performance.ToViewModelObject<PerformanceViewModel>()
                };
                TimeSlotPerformanceViewModels.Add(timeSlot);
            }

            DataAvailableEvent?.Invoke(this, TimeSlotPerformanceViewModels);
        }

        public override string ToString()
        {
            return "UFO Performance Overview";
        }
    }
}
