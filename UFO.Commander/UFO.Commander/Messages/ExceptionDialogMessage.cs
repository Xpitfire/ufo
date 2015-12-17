using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using UFO.Commander.ViewModel;
using UFO.Commander.Views.Dialogs;

namespace UFO.Commander.Messages
{
    public class ExceptionDialogMessage : ShowDialogMessage
    {
        public ExceptionDialogMessage(ViewModelBase viewModel) : base(viewModel)
        {
            CustomDialog = new ExceptionDialog();
            Title = "Failed to perform operation ...";
        }
    }
}
