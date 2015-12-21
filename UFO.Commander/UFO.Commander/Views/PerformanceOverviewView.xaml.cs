using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UFO.Commander.Views
{
    /// <summary>
    /// Interaction logic for PerformanceOverviewView.xaml
    /// </summary>
    public partial class PerformanceOverviewView : UserControl
    {
        public PerformanceOverviewView()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                var viewModel = Locator.PerformanceOverviewViewModel;
                viewModel.DataAvailableEvent += (o, models) =>
                {
                    var performancesView = CollectionViewSource.GetDefaultView(models);
                    var grouping = new PropertyGroupDescription("PerformanceViewModel.VenueViewModel.LocationViewModel");
                    performancesView.GroupDescriptions.Clear();
                    performancesView.GroupDescriptions.Add(grouping);
                };
                PerformancesDataGrid.SelectedCellsChanged += (o, eventArgs) =>
                {
                    var item = PerformancesDataGrid.CurrentCell.Item as PerformanceOverviewViewModel.TimeSlotPerformanceViewModel;
                    if (item != null)
                    {
                        //var columnValue = PerformancesDataGrid.CurrentColumn.Header.ToString();
                        //item = item.TimeKey.Equals(columnValue) ? item : null;
                        
                    }
                    Locator.PerformanceOverviewViewModel.SelectedTimeSlotPerformanceChanged(item);
                };
            };
        }
    }
}
