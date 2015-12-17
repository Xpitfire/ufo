using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace UFO.Commander.ViewModel
{
    public class ExceptionDialogViewModel : ViewModelBase
    {
        public ExceptionDialogViewModel()
        {
            ConfirmCommand = new RelayCommand(() =>
            {
                //Messenger.Default.Send(new HideDialogMessage());
            });
        }

        public RelayCommand ConfirmCommand { get; set; }

        public Exception Exception { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
    }
}
