using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Model;
using UFO.Commander.Annotations;
using UFO.Commander.Proxy;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class NotificationViewModel : Notification, INotifyPropertyChanged
    {
        public NotificationType NotificationType { get; set; }

        public PerformanceViewModel Performance { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum NotificationType
    {
        Add,
        Removed,
        Modified
    }
}
