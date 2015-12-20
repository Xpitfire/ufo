using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace UFO.Commander.Messages
{
    public class ShowExceptionDialogMessage
    {
        public ViewModelBase ViewModel { get; set; }

        public string Title { get; set; }

        public ShowExceptionDialogMessage(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
            Title = ViewModel.ToString();
        }
    }
}
