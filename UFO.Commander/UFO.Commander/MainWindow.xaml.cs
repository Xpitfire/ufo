using System;
using System.Threading.Tasks;
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
        public static readonly CustomDialog CurrentDialog = new CustomDialog();

        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<ExceptionDialogMessage>(this, ShowDialog);
            Messenger.Default.Register<LoginDialogMessage>(this, ShowDialog);
            Messenger.Default.Register<ShowDialogMessage>(this, ShowDialog);
            Messenger.Default.Register<HideDialogMessage>(this, HideDialog);
            
            this.Loaded += (s, e) => Messenger.Default.Send(new LoginDialogMessage(this, CurrentDialog));
        }
        
        private void HideDialog(HideDialogMessage obj)
        {
            lock (CurrentDialog)
            {
                if (CurrentDialog.IsVisible)
                {
                    this.HideMetroDialogAsync(CurrentDialog).GetAwaiter();
                }
            }
        }

        private void ShowDialog(ShowDialogMessage dialogMsg)
        {
            lock (CurrentDialog)
            {
                HideDialog(null);
                MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
                CurrentDialog.Title = "Info";
                CurrentDialog.Content = dialogMsg.CustomDialog;
                this.ShowMetroDialogAsync(CurrentDialog);
            }
        }
    }

}
