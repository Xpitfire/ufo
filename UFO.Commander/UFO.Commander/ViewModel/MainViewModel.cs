using System.ComponentModel;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PostSharp.Patterns.Model;
using UFO.Commander.Handler;
using UFO.Commander.Messages;
using UFO.Commander.Views;
using UFO.Commander.Views.Dialogs;
using UFO.Commander.Views.UserControls;

namespace UFO.Commander.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    [ViewExceptionHandler("Application Exception")]
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentContent;
        public ViewModelBase CurrentContent
        {
            get { return _currentContent; }
            set { Set(ref _currentContent, value); }
        }
        
        public MainViewModel()
        {
            Messenger.Default.Register<ShowContentMessage>(this, msg => CurrentContent = msg.ViewModel);
        }

        public override string ToString()
        {
            return "UFO Commander";
        }
    }
}