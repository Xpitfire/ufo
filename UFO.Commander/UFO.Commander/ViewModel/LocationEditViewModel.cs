using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using UFO.Commander.Handler;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("Location Request Exception")]
    public class LocationEditViewModel : ViewModelBase
    {
        public override string ToString()
        {
            return "UFO Location Edit";
        }
    }
}
