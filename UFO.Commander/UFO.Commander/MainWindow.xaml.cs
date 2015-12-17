using System;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.Messages;
using UFO.Commander.ViewModel;
using UFO.Commander.Views.Dialogs;

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
            Messenger.Default.Register<ShowDialogMessage<CustomLoginDialog>>(this, ShowDialog);
            Messenger.Default.Register<HideDialogMessage<CustomLoginDialog>>(this, HideDialog);
            
            this.Loaded += 
                (s, e) => Messenger.Default.Send(
                    new ShowDialogMessage<CustomLoginDialog>(ViewModelLocator.LoginViewModel));
        }
        
        private async void HideDialog(HideDialogMessage<CustomLoginDialog> obj)
        {
            if (obj.Dialog.IsVisible)
                await this.HideMetroDialogAsync(obj.Dialog);
        }

        private async void ShowDialog(ShowDialogMessage<CustomLoginDialog> dialogMsg)
        {
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            await this.ShowMetroDialogAsync(dialogMsg.Dialog);
        }
    }

}
