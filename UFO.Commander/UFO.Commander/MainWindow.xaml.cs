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
        private CustomDialog currentDialog;

        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<LoginDialogMessage>(new LoginDialogMessage(this), dialog => dialog.ShowDialog());
            this.Loaded += (s, e) => new LoginDialogMessage(this).ShowDialog();
            Messenger.Default.Register<ShowDialogMessage>(this, ShowDialg);
            Messenger.Default.Register<HideDialogMessage>(this, HideDialog);
        }

        private void HideDialog(HideDialogMessage obj)
        {
            if (currentDialog != null)
            {
                this.HideMetroDialogAsync(currentDialog);
            }
        }

        private void ShowDialg(ShowDialogMessage dialogMsg)
        {
            currentDialog = new CustomDialog
            {
                Title = "Pleas enter your user credentials ..."
            };

            currentDialog.Content = dialogMsg.ViewModel;

            this.ShowMetroDialogAsync(currentDialog);
        }
    }

}
