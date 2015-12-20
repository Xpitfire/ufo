/*
  In App.xaml:
  <Application.Resources>
      <vm:Locator xmlns:vm="clr-namespace:UFO.Commander"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.ServiceLocation;
using UFO.Commander.Views;
using UFO.Commander.Views.Dialogs;
using UFO.Commander.Views.UserControls;

namespace UFO.Commander.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class Locator
    {
        public Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<TabControlViewModel>();
            SimpleIoc.Default.Register<ArtistDialogViewModel>();
            SimpleIoc.Default.Register<ArtistOverviewViewModel>();
            SimpleIoc.Default.Register<ExceptionDialogViewModel>();
            SimpleIoc.Default.Register<CustomViewDialog>();
            SimpleIoc.Default.Register<CustomExceptionDialog>();
            SimpleIoc.Default.Register<VenueOverviewViewModel>();
            SimpleIoc.Default.Register<VenueEditViewModel>();
            SimpleIoc.Default.Register<LocationEditViewModel>();
            SimpleIoc.Default.Register<VenueDialogViewModel>();
            SimpleIoc.Default.Register<LocationDialogViewModel>();
        }

        public static MainViewModel MainViewModel 
            => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static LoginViewModel LoginViewModel 
            => ServiceLocator.Current.GetInstance<LoginViewModel>();
        
        public static ArtistDialogViewModel ArtistDialogViewModel
            => ServiceLocator.Current.GetInstance<ArtistDialogViewModel>();

        public static TabControlViewModel TabControlViewModel
            => ServiceLocator.Current.GetInstance<TabControlViewModel>();

        public static ExceptionDialogViewModel ExceptionDialogViewModel
            => ServiceLocator.Current.GetInstance<ExceptionDialogViewModel>();

        public static ArtistOverviewViewModel ArtistOverviewViewModel
            => ServiceLocator.Current.GetInstance<ArtistOverviewViewModel>();

        public static CustomViewDialog CustomViewDialog
            => ServiceLocator.Current.GetInstance<CustomViewDialog>();

        public static CustomExceptionDialog CustomExceptionDialog
            => ServiceLocator.Current.GetInstance<CustomExceptionDialog>();

        public static VenueOverviewViewModel VenueOverviewViewModel
            => ServiceLocator.Current.GetInstance<VenueOverviewViewModel>();

        public static VenueEditViewModel VenueEditViewModel
            => ServiceLocator.Current.GetInstance<VenueEditViewModel>();

        public static LocationEditViewModel LocationEditViewModel
            => ServiceLocator.Current.GetInstance<LocationEditViewModel>();

        public static VenueDialogViewModel VenueDialogViewModel
            => ServiceLocator.Current.GetInstance<VenueDialogViewModel>();

        public static LocationDialogViewModel LocationDialogViewModel
            => ServiceLocator.Current.GetInstance<LocationDialogViewModel>();

    }
}