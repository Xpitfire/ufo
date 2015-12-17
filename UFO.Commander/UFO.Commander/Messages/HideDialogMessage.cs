using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.Views;

namespace UFO.Commander.Messages
{
    public class HideDialogMessage<TDialog> : MessageBase where TDialog : BaseMetroDialog
    {
        public TDialog Dialog { get; set; } = DialogLocator.GetInstance<TDialog>();
        
        public HideDialogMessage(ViewModelBase viewModel) : base(viewModel)
        {
        }
    }
}
