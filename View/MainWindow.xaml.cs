using PlantsCatalogApp.Model;
using PlantsCatalogApp.ViewModel;
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

namespace PlantsCatalogApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();

            //LocalNameTB.IsEnabled = false;
            //ScientNameTB.IsEnabled = false;
            //GrowingAreaTB.IsEnabled = false;
            //PhotoUriTBlock.Visibility = Visibility.Hidden;
            //PhotoUriTBox.Visibility = Visibility.Hidden;
            //DescriptionTB.IsEnabled = false;
            //PositiveEffectsTB.IsEnabled = false;
            //NegativeEffectsTB.IsEnabled = false;

            //AddBtn.Visibility = Visibility.Hidden;
            //DeleteBtn.Visibility = Visibility.Hidden;
            //UpdateBtn.Visibility = Visibility.Hidden;
            //DiscardBtn.Visibility = Visibility.Hidden;
        }
        
    }
}
