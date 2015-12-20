using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using PostSharp.Patterns.Model;
using UFO.Commander.Handler;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("Content Request Exception")]
    public class TabControlViewModel : ViewModelBase
    {
        public override string ToString()
        {
            return "UFO";
        }
    }
}
