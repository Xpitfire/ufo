using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.ViewModel;
using UFO.Commander.Views.Dialogs;

namespace UFO.Commander.Messages
{
    public class LoginDialogMessage : ShowDialogMessage
    {
        private readonly MetroWindow _window;
        private readonly BaseMetroDialog _dialog;

        public LoginDialogMessage(MetroWindow window, BaseMetroDialog dialog) : base(ViewModelLocator.LoginViewModel)
        {
            this._window = window;
            this._dialog = dialog;
            //window.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            //_customDialog = new CustomDialog
            //{
            //    Title = "Pleas enter your user credentials ..."
            //};
            var customDialog = new CustomLoginDialog();
            customDialog.ButtonCancel.Click += ButtonCancelOnClick;
            customDialog.ButtonLogin.Click += ButtonLoginOnClick;
            CustomDialog = customDialog;
            Title = "Login";

            //var loginViewModel = ViewModelLocator.LoginViewModel;
            //loginViewModel.LogoutEvent += (sender, args) => _window.ShowMetroDialogAsync(_customDialog);
        }

        private async void ButtonLoginOnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = ViewModelLocator.LoginViewModel;
            var userDialog = CustomDialog as CustomLoginDialog;

            var result = await Task.Run(() => viewModel.RequestSessionToken(userDialog.TextBoxUserName.Text, userDialog.PasswordBox.Password));

            if (result)
            {
                viewModel.Login();
                lock (MainWindow.CurrentDialog)
                {
                    _window.HideMetroDialogAsync(_dialog).RunSynchronously();
                }
                Messenger.Default.Send(new ShowMainContentMessage(ViewModelLocator.TabControlViewModel));
            }
            else
            {
                userDialog.InvalidLogin.Visibility = Visibility.Visible;
            }
        }

        private void ButtonCancelOnClick(object sender, RoutedEventArgs e)
        {
            _window.Close();
        }
        
    }
}
