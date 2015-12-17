using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.Messages;
using UFO.Commander.ViewModel;
using UFO.Commander.Views.UserControls;

namespace UFO.Commander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private CustomDialog _currentDialog;

        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<ExceptionDialogMessage>(ViewModelLocator.ExceptionDialogViewModel, ShowDialg);
            Messenger.Default.Register<LoginDialogMessage>(this, dialog => dialog.ShowDialog());
            Messenger.Default.Register<ShowDialogMessage>(this, ShowDialg);
            Messenger.Default.Register<HideDialogMessage>(this, HideDialog);

            this.Loaded += (s, e) => new LoginDialogMessage(this).ShowDialog();
        }
        
        private void HideDialog(HideDialogMessage obj)
        {
            if (_currentDialog != null)
            {
                this.HideMetroDialogAsync(_currentDialog);
            }
        }

        private void ShowDialg(ShowDialogMessage dialogMsg)
        {
            if (_currentDialog != null)
                this.HideMetroDialogAsync(_currentDialog);

            _currentDialog = new CustomDialog
            {
                Title = "Pleas enter your user credentials ...",
                Content = dialogMsg.ViewModel
            };
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            this.ShowMetroDialogAsync(_currentDialog);
        }
    }

}
