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

namespace UFO.Commander.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ArtistEdit.xaml
    /// </summary>
    public partial class ArtistEdit : UserControl
    {
        public ArtistEdit()
        {
            InitializeComponent();
        }

        public static Visibility GetSaveButtonVisibility(ArtistEdit element)
        {
            return (Visibility)element.GetValue(SaveButtonVisibilityProperty);
        }

        public static void SetSaveButtonVisibility(ArtistEdit element, Visibility value)
        {
            element.SetValue(SaveButtonVisibilityProperty, value);
        }

        public Visibility SaveButtonVisibility
        {
            get { return (Visibility)GetValue(SaveButtonVisibilityProperty); }
            set { SetValue(SaveButtonVisibilityProperty, value); }
        }

        public static readonly DependencyProperty SaveButtonVisibilityProperty =
            DependencyProperty.RegisterAttached(nameof(SaveButtonVisibility), typeof(Visibility), typeof(ArtistEdit), new PropertyMetadata(Visibility.Visible));

    }
}
