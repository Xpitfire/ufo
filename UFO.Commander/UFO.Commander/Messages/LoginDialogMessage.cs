using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.ViewModel;
using UFO.Commander.Views.UserControls;

namespace UFO.Commander.Messages
{
    class LoginDialogMessage : MessageBase
    {
        private readonly MetroWindow _window;
        private readonly CustomDialog _customDialog;
        private readonly CustomLoginDialog _loginDialog;

        public LoginDialogMessage(MetroWindow window)
        {
            this._window = window;
            window.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            _customDialog = new CustomDialog
            {
                Title = "Pleas enter your user credentials ..."
            };
            _loginDialog = new CustomLoginDialog();
            _loginDialog.ButtonCancel.Click += ButtonCancelOnClick;
            _loginDialog.ButtonLogin.Click += ButtonLoginOnClick;
            _customDialog.Content = _loginDialog;

            var loginViewModel = ViewModelLocator.LoginViewModel;
            loginViewModel.LogoutEvent += (sender, args) => _window.ShowMetroDialogAsync(_customDialog);
        }

        private void ButtonLoginOnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = ViewModelLocator.LoginViewModel;

            if (viewModel.RequestSessionToken(_loginDialog.TextBoxUserName.Text, _loginDialog.PasswordBox.Password))
            {
                viewModel.Login();
                _window.HideMetroDialogAsync(_customDialog);
                Messenger.Default.Send(new ShowMainContentMessage(ViewModelLocator.TabControlViewModel));
            }
            else
            {
                _loginDialog.InvalidLogin.Visibility = Visibility.Visible;
            }
        }

        private void ButtonCancelOnClick(object sender, RoutedEventArgs e)
        {
            _window.Close();
        }

        public Task ShowDialog()
        {
            return _window.ShowMetroDialogAsync(_customDialog);
        }
    }
}
