using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace UFO.Commander.Messages
{
    public class ShowDialogMessage : MessageBase
    {
        public UserControl CustomDialog { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public ViewModelBase ViewModel { get; set; }
        public ShowDialogMessage(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
