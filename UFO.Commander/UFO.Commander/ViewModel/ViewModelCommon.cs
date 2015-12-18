using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using PostSharp.Patterns.Model;

namespace UFO.Commander.ViewModel
{
    public class ViewModelCommon : ViewModelBase
    {
        private ViewModelBase _viewModel;
        public virtual ViewModelBase ViewModelBase
        {
            get { return _viewModel; }
            set { Set(ref _viewModel, value); }
        }
    }
}
