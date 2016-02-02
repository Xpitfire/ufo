using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using UFO.Commander.Handler;
using UFO.Commander.Helper;
using UFO.Commander.Proxy;
using UFO.Commander.ViewModel.Entities;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;
using GalaSoft.MvvmLight.Messaging;
using UFO.Commander.Messages;

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

        private Dictionary<string, List<NotificationViewModel>> _notificationCollection;
        public Dictionary<string, List<NotificationViewModel>> NotificationCollection
        {
            get { return _notificationCollection; }
            set { Set(ref _notificationCollection, value); }
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
            AddNewPerformanceCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send(new ShowDialogMessage(Locator.PerformanceEditViewModel));
            });
            DeletePerformanceCommand = new RelayCommand<PerformanceViewModel>(p =>
            {
                var result = _adminAccessBll.RemovePerformance(BllAccessHandler.SessionToken, p.ToDomainObject<Performance>());
                if (!result) return;
                Performances.Remove(p);
                AddNotification(p, NotificationType.Removed);
            });
            EditPerformanceCommand = new RelayCommand<PerformanceViewModel>(p =>
            {
                Locator.PerformanceEditViewModel.InitializePreset(
                    p.VenueViewModel, 
                    p.ArtistViewModel, 
                    p.DateTime);
                Messenger.Default.Send(new ShowDialogMessage(Locator.PerformanceEditViewModel));
            });
            SendNotificationsCommand = new RelayCommand(async () =>
            {
                if (NotificationCollection != null)
                {
                    foreach (var notify in NotificationCollection)
                    {
                        var sb = new StringBuilder();
                        foreach (var message in notify.Value)
                        {
                            switch (message.NotificationType)
                            {
                                case NotificationType.Add:
                                    sb.Append("The following event has been assigned: \n");
                                    break;
                                case NotificationType.Modified:
                                    sb.Append("The following event has changed: \n");
                                    break;
                                case NotificationType.Removed:
                                    sb.Append("The following event has been canceled: \n");
                                    break;
                            }
                            sb.Append("Artist: ").Append(message.Performance.ArtistViewModel.Name).AppendLine()
                                .Append("Venue: ").Append(message.Performance.VenueViewModel.Name)
                                .Append(", ")
                                .Append(message.Performance.VenueViewModel.Location.Name).AppendLine()
                                .Append("Date: ")
                                .Append(message.Performance.DateTimeViewModel.DateTime.ToString("dd-MM-yyyy HH:mm"))
                                .AppendLine().AppendLine().Append("---------------------------");
                        }
                        var tmp = new Notification
                        {
                            Recipient = notify.Key,
                            Sender = BllAccessHandler.SessionToken?.User?.EMail,
                            Subject = $"UFO administration notification",
                            Body = sb.ToString()
                        };
                        await _adminAccessBll.SendNotificationAsync(BllAccessHandler.SessionToken, tmp);
                    }
                }
                NotificationCollection = null;
            });

            await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
            {
                var dates = await _viewAccessBll.GetAllPerformanceDatesAsync();
                CurrentPerformanceDateTime = dates.FirstOrDefault();
                foreach (var dateTime in dates)
                {
                    PerformanceDates.Add(dateTime);
                }
            });
        }

        public async Task LoadData()
        {
            Performances.Clear();
            var performances = await _viewAccessBll.GetPerformancesPerDateAsync(CurrentPerformanceDateTime);
            if (performances != null && performances.Any())
            {
                performances.Sort((p1, p2) =>
                p1.DateTime.CompareTo(p2.DateTime) + string.Compare(p1.Venue.VenueId, p2.Venue.VenueId, StringComparison.Ordinal));
                foreach (var p in performances)
                {
                    var pvm = p.ToViewModelObject<PerformanceViewModel>();
                    pvm.DateTimeViewModel = p.DateTime;
                    Performances.Add(pvm);
                }
            }
            DataAvailableEvent?.Invoke(this, Performances);
        }

        public void AddNotification(PerformanceViewModel performance, NotificationType type)
        {
            if (NotificationCollection == null)
            {
                NotificationCollection = new Dictionary<string, List<NotificationViewModel>>();
            }
            List<NotificationViewModel> list;
            if (!NotificationCollection.TryGetValue(performance.ArtistViewModel.EMail, out list))
            {
                list = new List<NotificationViewModel>();
            }
            list.Add(new NotificationViewModel { Performance = performance, NotificationType = type });
            NotificationCollection[performance.ArtistViewModel.EMail] = list;
        }

        public RelayCommand AddNewPerformanceCommand { get; set; }

        public RelayCommand<PerformanceViewModel> DeletePerformanceCommand { get; set; }

        public RelayCommand<PerformanceViewModel> EditPerformanceCommand { get; set; }

        public RelayCommand SendNotificationsCommand { get; set; }

        public override string ToString()
        {
            return "UFO Performance Overview";
        }
    }
}
