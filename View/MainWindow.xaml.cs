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
        private bool isLogin = false;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();

            LocalNameTB.IsEnabled = false;
            ScientNameTB.IsEnabled = false;
            GrowingAreaTB.IsEnabled = false;
            PhotoUriTBlock.Visibility = Visibility.Hidden;
            PhotoUriTBox.Visibility = Visibility.Hidden;
            DescriptionTB.IsEnabled = false;
            PositiveEffectsTB.IsEnabled = false;
            NegativeEffectsTB.IsEnabled = false;

            AddBtn.Visibility = Visibility.Hidden;
            DeleteBtn.Visibility = Visibility.Hidden;
            UpdateBtn.Visibility = Visibility.Hidden;
            DiscardBtn.Visibility = Visibility.Hidden;
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            using(DBConnect con = new DBConnect())
            {
                List<User> users = con.Users.ToList();

                if(LoginTextBox.Text.Length > 0 && users.Any(x => x.Name.Equals(LoginTextBox.Text))) 
                {
                    User user = new User();
                    user = users.FirstOrDefault(x=>x.Name.Equals(LoginTextBox.Text));
                    if (user != null && user.Password.Equals(PasswordBox.Password))
                    {
                        isLogin = true;

                        LocalNameTB.IsEnabled = true;
                        ScientNameTB.IsEnabled = true;
                        GrowingAreaTB.IsEnabled = true;
                        PhotoUriTBlock.Visibility = Visibility.Visible;
                        PhotoUriTBox.Visibility = Visibility.Visible;
                        DescriptionTB.IsEnabled = true;
                        PositiveEffectsTB.IsEnabled = true;
                        NegativeEffectsTB.IsEnabled = true;

                        AddBtn.Visibility = Visibility.Visible;
                        DeleteBtn.Visibility = Visibility.Visible;
                        UpdateBtn.Visibility = Visibility.Visible;
                        DiscardBtn.Visibility = Visibility.Visible;

                    }
                    else return;
                }


            }
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            isLogin = false;

            LocalNameTB.IsEnabled = false;
            ScientNameTB.IsEnabled = false;
            GrowingAreaTB.IsEnabled = false;
            PhotoUriTBlock.Visibility = Visibility.Hidden;
            PhotoUriTBox.Visibility = Visibility.Hidden;
            DescriptionTB.IsEnabled = false;
            PositiveEffectsTB.IsEnabled = false;
            NegativeEffectsTB.IsEnabled = false;

            AddBtn.Visibility = Visibility.Hidden;
            DeleteBtn.Visibility = Visibility.Hidden;
            UpdateBtn.Visibility = Visibility.Hidden;
            DiscardBtn.Visibility = Visibility.Hidden;
        }

        private void DarkThemeToggle_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
