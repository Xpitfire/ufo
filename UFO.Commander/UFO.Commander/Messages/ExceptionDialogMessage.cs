using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace UFO.Commander.Messages
{
    public class ExceptionDialogMessage : ShowDialogMessage
    {
        public ExceptionDialogMessage(ViewModelBase viewModel) : base(viewModel)
        {
        }
    }
}
