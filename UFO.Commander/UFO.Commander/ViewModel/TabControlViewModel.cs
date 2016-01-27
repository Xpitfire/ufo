using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PostSharp.Patterns.Model;
using UFO.Commander.Handler;
using UFO.Commander.Helper;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("Content Request Exception")]
    public class TabControlViewModel : ViewModelBase
    {
        public TabControlViewModel()
        {
            ReconnectCommand = new RelayCommand((() =>
            {
                BllAccessHandler.Reconnect();
                BllAccessHandler.SessionToken =
                    BllAccessHandler.AdminAccessBll.RequestSessionToken(BllAccessHandler.SessionToken.User);
            }));
        }

        public override string ToString()
        {
            return "UFO";
        }

        public RelayCommand ReconnectCommand { get; set; }
    }
}
