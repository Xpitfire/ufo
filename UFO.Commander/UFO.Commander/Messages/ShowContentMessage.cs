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
    public class ShowContentMessage : MessageBase
    {
        public ViewModelBase ViewModel { get; set; }

        public string Title { get; set; }

        public ShowContentMessage(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
