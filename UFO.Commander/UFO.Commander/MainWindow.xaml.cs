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
                    new ShowDialogMessage(Locator.LoginViewModel));
        }

        private void RegisterDialogs()
        {
            Messenger.Default.Register<ShowDialogMessage>(this, async p => await Dispatcher.InvokeAsync(() => ShowDialog(p)));
            Messenger.Default.Register<HideDialogMessage>(this, async p => await Dispatcher.InvokeAsync(() => HideDialog(p)));
            Messenger.Default.Register<ShowExceptionDialogMessage>(this, async p => await Dispatcher.InvokeAsync(() => ShowExceptionDialog(p)));
            Messenger.Default.Register<HideExceptionDialogMessage>(this, async p => await Dispatcher.InvokeAsync(() => HideExceptionDialog(p)));
        }

        private async Task HideDialog(HideDialogMessage dialogMsg)
        {
            var dialog = Locator.CustomViewDialog;
            await this.HideMetroDialogAsync(dialog);
        }

        private async Task ShowDialog(ShowDialogMessage dialogMsg)
        {
            var dialog = Locator.CustomViewDialog;
            dialog.Content = dialogMsg.ViewModel;
            dialog.Title = dialogMsg.Title;
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            await this.ShowMetroDialogAsync(dialog);
        }

        private bool _recallPreviousState;

        private async Task HideExceptionDialog(HideExceptionDialogMessage dialogMsg)
        {
            var exceptionDialog = Locator.CustomExceptionDialog;
            await this.HideMetroDialogAsync(exceptionDialog);
            if (_recallPreviousState)
            {
                var dialog = Locator.CustomViewDialog;
                await this.ShowMetroDialogAsync(dialog);
            }
        }

        private async Task ShowExceptionDialog(ShowExceptionDialogMessage dialogMsg)
        {
            var dialog = Locator.CustomViewDialog;
            if (dialog.IsVisible)
            {
                await this.HideMetroDialogAsync(dialog);
                _recallPreviousState = true;
            }
            var exceptionDialog = Locator.CustomExceptionDialog;
            var viewModel = dialogMsg.ViewModel as ExceptionDialogViewModel;
            exceptionDialog.Content = dialogMsg.ViewModel;
            exceptionDialog.Title = viewModel?.Title ?? dialogMsg.Title;
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            await this.ShowMetroDialogAsync(exceptionDialog);
        }
    }

}
