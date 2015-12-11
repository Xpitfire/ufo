using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.ViewModels;
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
        }

        private CustomDialog _customDialog;
        private CustomLoginDialog _loginDialog;

        private async void LoginEvent(object sender, RoutedEventArgs e)
        {
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            _customDialog = new CustomDialog
            {
                Title = "Pleas enter user credentials ..."
            };
            _loginDialog = new CustomLoginDialog();
            _loginDialog.ButtonCancel.Click += ButtonCancelOnClick;
            _loginDialog.ButtonLogin.Click += ButtonLoginOnClick;
            _customDialog.Content = _loginDialog;
            await this.ShowMetroDialogAsync(_customDialog);
        }

        private void ButtonLoginOnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (AuthAccessViewModel) this.DataContext;

            if (viewModel.IsValidLogin(_loginDialog.TextBoxUserName.Text, _loginDialog.PasswordBox.Password))
            {
                viewModel.LoginAdmin(_loginDialog.TextBoxUserName.Text, _loginDialog.PasswordBox.Password);
                this.HideMetroDialogAsync(_customDialog);
            }
            else
            {
                _loginDialog.InvalidLogin.Visibility = Visibility.Visible;
            }
        }

        private void ButtonCancelOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }    
    }
    
}
