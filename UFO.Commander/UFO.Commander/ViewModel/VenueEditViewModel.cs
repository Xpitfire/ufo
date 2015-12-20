using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using UFO.Commander.Handler;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("Venue Request Exception")]
    public class VenueEditViewModel : ViewModelBase
    {
        public override string ToString()
        {
            return "UFO Edit Venue";
        }
    }
}
