using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.ViewModel;
using UFO.Commander.Views.UserControls;

namespace UFO.Commander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly CustomDialog _customDialog;
        private readonly CustomLoginDialog _loginDialog;

        public MainWindow()
        {
            InitializeComponent();
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            _customDialog = new CustomDialog
            {
                Title = "Pleas enter your user credentials ..."
            };
            _loginDialog = new CustomLoginDialog();
            _loginDialog.ButtonCancel.Click += ButtonCancelOnClick;
            _loginDialog.ButtonLogin.Click += ButtonLoginOnClick;
            _customDialog.Content = _loginDialog;

            var authViewModel = (AuthAccessViewModel)this.DataContext;
            var mainWindow = this;
            authViewModel.LogoutEvent += (sender, args) =>
            {
                mainWindow.ShowMetroDialogAsync(_customDialog);
            };
        }
        
        private async void LoginEvent(object sender, RoutedEventArgs e)
        {
            await this.ShowMetroDialogAsync(_customDialog);
        }

        private void ButtonLoginOnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (AuthAccessViewModel) this.DataContext;

            if (viewModel.IsCredentialsValid(_loginDialog.TextBoxUserName.Text, _loginDialog.PasswordBox.Password))
            {
                viewModel.Login();
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
