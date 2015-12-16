﻿using System;
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
        private CustomDialog _customDialog;
        private CustomLoginDialog _loginDialog;

        public MainWindow()
        {
            InitializeComponent();
            PresentLoginScreen();
        }

        private void PresentLoginScreen()
        {
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
            authViewModel.LogoutEvent += LogoutEvent;
        }

        private async void LogoutEvent(object sender, EventArgs e)
        {
            await this.ShowMetroDialogAsync(_customDialog);
        }
        
        private async void LoginEvent(object sender, RoutedEventArgs e)
        {
            await this.ShowMetroDialogAsync(_customDialog);
        }

        private void ButtonLoginOnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (AuthAccessViewModel) this.DataContext;

            if (viewModel.RequestSessionToken(_loginDialog.TextBoxUserName.Text, _loginDialog.PasswordBox.Password))
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
