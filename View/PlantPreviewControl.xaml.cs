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
            //LocalNameTB.Text = LocalName;
            //ScientNameTB.Text = ScientName;
        }
    }
}
