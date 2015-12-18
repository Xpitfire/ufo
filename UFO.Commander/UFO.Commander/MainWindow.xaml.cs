using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.Messages;
using UFO.Commander.ViewModel;
using UFO.Commander.Views;
using UFO.Commander.Views.Dialogs;
using UFO.Commander.Views.UserControls;

namespace UFO.Commander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            RegisterDialogs();

            this.Loaded += 
                (s, e) => Messenger.Default.Send(
                    new ShowDialogMessage<CustomLoginDialog>(Locator.LoginViewModel));
        }

        private void RegisterDialogs()
        {
            Messenger.Default.Register<ShowDialogMessage<CustomLoginDialog>>(this, async p => await Dispatcher.InvokeAsync(() => ShowDialog(p)));
            Messenger.Default.Register<HideDialogMessage<CustomLoginDialog>>(this, async p => await Dispatcher.InvokeAsync(() => HideDialog(p)));
            Messenger.Default.Register<ShowDialogMessage<ArtistDialog>>(this, async p => await Dispatcher.InvokeAsync(() => ShowDialog(p)));
            Messenger.Default.Register<HideDialogMessage<ArtistDialog>>(this, async p => await Dispatcher.InvokeAsync(() => HideDialog(p)));
            Messenger.Default.Register<ShowDialogMessage<ExceptionDialog>>(this, async p => await Dispatcher.InvokeAsync(() => ShowDialog(p)));
            Messenger.Default.Register<HideDialogMessage<ExceptionDialog>>(this, async p => await Dispatcher.InvokeAsync(() => HideDialog(p)));
        }


        private async Task HideDialog<TDialog>(HideDialogMessage<TDialog> obj) where TDialog : BaseMetroDialog
        {
            if (obj.Dialog.IsVisible)
                await this.HideMetroDialogAsync(obj.Dialog);
        }

        private async Task ShowDialog<TDialog>(ShowDialogMessage<TDialog> dialogMsg) where TDialog : BaseMetroDialog
        {
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            await this.ShowMetroDialogAsync(dialogMsg.Dialog);
        }
    }

}
