using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using UFO.Commander.Messages;

namespace UFO.Commander.ViewModel
{
    public class LocationDialogViewModel : ViewModelBase
    {
        public RelayCommand CancelCommand { get; set; }

        public LocationDialogViewModel()
        {
            CancelCommand = new RelayCommand(() => Messenger.Default.Send(new HideDialogMessage(this)));
        }
    }
}
