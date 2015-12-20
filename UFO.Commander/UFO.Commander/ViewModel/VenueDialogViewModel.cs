using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using UFO.Commander.Handler;
using UFO.Commander.Messages;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("Venue Request Exception")]
    public class VenueDialogViewModel : ViewModelBase
    {
        public RelayCommand CancelCommand { get; set; }

        public VenueDialogViewModel()
        {
            CancelCommand = new RelayCommand(() => Messenger.Default.Send(new HideDialogMessage(this)));
        }

        public override string ToString()
        {
            return "UFO Venue Edit";
        }
    }
}
