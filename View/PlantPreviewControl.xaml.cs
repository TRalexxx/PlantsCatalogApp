using System.Windows;
using System.Windows.Controls;

namespace PlantsCatalogApp.View
{
    /// <summary>
    /// Interaction logic for PlantPreviewControl.xaml
    /// </summary>
    public partial class PlantPreviewControl : UserControl
    {
        public static readonly DependencyProperty LocalNameProperty = DependencyProperty.Register(nameof(LocalName), typeof(string), typeof(PlantPreviewControl));

        public string LocalName
        {
            get { return (string)GetValue(LocalNameProperty); }
            set { SetValue(LocalNameProperty, value); }
        }

        public static readonly DependencyProperty ScientNameProperty = DependencyProperty.Register(nameof(ScientName), typeof(string), typeof(PlantPreviewControl));

        public string ScientName
        {
            get { return (string)GetValue(ScientNameProperty); }
            set { SetValue(ScientNameProperty, value); }
        }
        public PlantPreviewControl()
        {
            InitializeComponent();
        }
    }
}
