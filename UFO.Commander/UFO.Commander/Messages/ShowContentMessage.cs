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
    class ShowContentMessage<TControl> : MessageBase where TControl : UserControl
    {
        public TControl UserControl { get; set; }
        public ViewModelBase ViewModel { get; set; }

        public ShowContentMessage(ViewModelBase viewModel) : base(viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
