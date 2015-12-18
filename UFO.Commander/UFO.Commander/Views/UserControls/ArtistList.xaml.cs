using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UFO.Commander.ViewModel;

namespace UFO.Commander.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ArtistList.xaml
    /// </summary>
    public partial class ArtistList : UserControl
    {
        public ArtistList()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            ArtistOverviewViewModel vm = (ArtistOverviewViewModel)DataContext;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            if (Math.Abs(scv.VerticalOffset - scv.ScrollableHeight) < 5)
                vm.ToNextArtistPage();
            e.Handled = true;
        }
    }
}
