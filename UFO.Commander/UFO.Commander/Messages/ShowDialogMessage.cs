using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.Views;

namespace UFO.Commander.Messages
{
    public class ShowDialogMessage : MessageBase
    {
        public ViewModelBase ViewModel { get; set; }

        public CustomDialog df;
        public BaseMetroDialog dfd;

        public ShowDialogMessage(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
