using System.ComponentModel;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PostSharp.Patterns.Model;
using UFO.Commander.Messages;
using UFO.Commander.Views;
using UFO.Commander.Views.Dialogs;
using UFO.Commander.Views.UserControls;

namespace UFO.Commander.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentContent;
        public ViewModelBase CurrentContent
        {
            get { return _currentContent; }
            set
            {
                Set(ref _currentContent, value);
                if (_currentContent == null)
                {
                    // TODO: Send logout msg
                }
            }
        }
        
        public MainViewModel()
        {
            RegisterUserControls();
        }

        private void RegisterUserControls()
        {
            Messenger.Default.Register<ShowContentMessage<TabContentView>>(this, msg => CurrentContent = msg.ViewModel);
            Messenger.Default.Register<ShowContentMessage<ArtistList>>(this, msg => CurrentContent = msg.ViewModel);
        }

        public override string ToString()
        {
            return "UFO Commander";
        }
    }
}