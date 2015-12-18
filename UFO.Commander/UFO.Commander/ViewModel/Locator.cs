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
using Microsoft.Practices.ServiceLocation;

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
            SimpleIoc.Default.Register<ViewAccessViewModel>();
            SimpleIoc.Default.Register<TabControlViewModel>();
            SimpleIoc.Default.Register<ArtistDialogViewModel>();
            SimpleIoc.Default.Register<ArtistOverviewViewModel>();
            SimpleIoc.Default.Register<ExceptionDialogViewModel>();
        }

        public static MainViewModel MainViewModel 
            => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static LoginViewModel LoginViewModel 
            => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public static ViewAccessViewModel ViewAccessViewModel 
            => ServiceLocator.Current.GetInstance<ViewAccessViewModel>();
        
        public static ArtistDialogViewModel ArtistDialogViewModel
            => ServiceLocator.Current.GetInstance<ArtistDialogViewModel>();

        public static TabControlViewModel TabControlViewModel
            => ServiceLocator.Current.GetInstance<TabControlViewModel>();

        public static ExceptionDialogViewModel ExceptionDialogViewModel
            => ServiceLocator.Current.GetInstance<ExceptionDialogViewModel>();

        public static ArtistOverviewViewModel ArtistOverviewViewModel
            => ServiceLocator.Current.GetInstance<ArtistOverviewViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}