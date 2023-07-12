using PlantsCatalogApp.ViewModel;
using System.Windows;

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

        }
        
    }
}
