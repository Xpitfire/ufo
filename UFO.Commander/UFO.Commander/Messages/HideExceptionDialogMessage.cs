using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace UFO.Commander.Messages
{
    class HideExceptionDialogMessage : HideDialogMessage
    {
        public HideExceptionDialogMessage(ViewModelBase viewModel) : base(viewModel)
        {
        }
    }
}
