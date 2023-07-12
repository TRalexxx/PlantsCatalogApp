using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using PlantsCatalogApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MaterialDesignThemes.Wpf;
using System.Windows;

namespace PlantsCatalogApp.ViewModel
{
    class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<Plant> Plants { get; set; }

        private Plant selectedPlant;

        private DBConnect connect;

        private string searchStr;


        private string passwordStr;
        public string PasswordStr
        {
            get { return passwordStr; }
            set { passwordStr = value; OnPropertyChanged("PasswordStr"); }
        }

        private string loginStr;
        public string LoginStr
        {
            get { return loginStr; }
            set { loginStr = value; OnPropertyChanged("LoginStr"); }
        }

        public string SearchStr
        {
            get { return searchStr; }
            set { searchStr = value; OnPropertyChanged("SearchStr"); }
        }
        public Plant SelectedPlant
        {
            get { return selectedPlant; }
            set { selectedPlant = value; OnPropertyChanged("SelectedPlant"); }
        }

        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new RelayCommand(SearchPlant);

                return searchCommand;
            }
        }

        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(AddPlant);

                return addCommand;
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(DeletePlant);

                return deleteCommand;
            }
        }

        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand(UpdatePlant);

                return updateCommand;
            }
        }

        private RelayCommand discardCommand;
        public RelayCommand DiscardCommand
        {
            get
            {
                if (discardCommand == null)
                    discardCommand = new RelayCommand(DiscardChanges);

                return discardCommand;
            }
        }

        private bool isDark;

        public bool IsDark
        {
            get { return isDark; }
            set
            {
                isDark = value;
                OnPropertyChanged("IsDark");
            }
        }

        private RelayCommand themeChangeCommand;
        public RelayCommand ThemeChangeCommand
        {
            get
            {
                if (themeChangeCommand == null)
                    themeChangeCommand = new RelayCommand(ThemeChange);

                return themeChangeCommand;
            }
        }

        private bool isElementEnable;

        public bool IsElementEnable
        {
            get { return isElementEnable; }
            set { isElementEnable = value; OnPropertyChanged("IsElementEnable"); }
        }

        private Visibility visibility;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;

                OnPropertyChanged("Visibility");
            }
        }


        private RelayCommand logInCommand;

        public RelayCommand LogInCommand
        {
            get
            {
                if (logInCommand == null)
                    logInCommand = new RelayCommand(LogIn);

                return logInCommand;
            }

        }

        private RelayCommand logOutCommand;

        public RelayCommand LogOutCommand
        {
            get
            {
                if (logOutCommand == null)
                    logOutCommand = new RelayCommand(LogOut);

                return logOutCommand;
            }

        }


        public MainVM()
        {
            using (connect = new DBConnect())
            {
                Plants = new ObservableCollection<Plant>();
                if (!connect.Plants.IsNullOrEmpty())
                {
                    foreach (Plant plant in connect.Plants)
                    {
                        Plants.Add(plant);
                    }
                }

                if (!Plants.IsNullOrEmpty())
                    selectedPlant = Plants[0];
            }
            Visibility = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void SearchPlant()
        {
            using (connect = new DBConnect())
            {

                if (connect.Plants.IsNullOrEmpty()) return;
                else
                {
                    Plants.Clear();

                    List<Plant> tempPlants = connect.Plants.ToList();

                    if (!SearchStr.IsNullOrEmpty())
                    {

                        foreach (Plant plant in tempPlants)
                        {
                            if (plant.LocalName.ToLower().Contains(SearchStr.ToLower()))
                            {
                                Plants.Add(plant);
                            }
                            else if (plant.ScientName.ToLower().Contains(SearchStr.ToLower()))
                            {
                                Plants.Add(plant);
                            }
                            else if (plant.GrowingArea.ToLower().Contains(searchStr.ToLower()))
                            {
                                Plants.Add(plant);
                            }
                            else if (plant.Description.ToLower().Contains(searchStr.ToLower()))
                            {
                                Plants.Add(plant);
                            }
                            else if (plant.PositiveEffects.ToLower().Contains(searchStr.ToLower()))
                            {
                                Plants.Add(plant);
                            }
                            else if (plant.NegativeEffects.ToLower().Contains(searchStr.ToLower()))
                            {
                                Plants.Add(plant);
                            }


                        }
                    }
                    else
                    {
                        if (!connect.Plants.IsNullOrEmpty())
                        {
                            foreach (Plant plantItem in connect.Plants)
                            {
                                Plants.Add(plantItem);
                            }
                        }

                        if (!Plants.IsNullOrEmpty())
                            selectedPlant = Plants[0];

                    }
                }
            }
        }

        public void AddPlant()
        {
            using (connect = new DBConnect())
            {
                connect.Plants.Add(new Plant() { });
                connect.SaveChanges();

                Plants.Clear();

                if (!connect.Plants.IsNullOrEmpty())
                {
                    foreach (Plant plant in connect.Plants)
                    {
                        Plants.Add(plant);
                    }
                }

                if (!Plants.IsNullOrEmpty())
                    selectedPlant = Plants.LastOrDefault();
            }
        }

        public void DeletePlant()
        {
            using (connect = new DBConnect())
            {
                connect.Remove(selectedPlant);
                connect.SaveChanges();

                Plants.Clear();

                if (!connect.Plants.IsNullOrEmpty())
                {
                    foreach (Plant plant in connect.Plants)
                    {
                        Plants.Add(plant);
                    }
                }

                if (!Plants.IsNullOrEmpty())
                    selectedPlant = Plants[0];
            }
        }

        public void UpdatePlant()
        {
            using (connect = new DBConnect())
            {
                int selectedId = SelectedPlant.Id;
                connect.Update(selectedPlant);
                connect.SaveChanges();

                Plants.Clear();

                if (!connect.Plants.IsNullOrEmpty())
                {
                    foreach (Plant plant in connect.Plants)
                    {
                        Plants.Add(plant);
                    }
                }

                SelectedPlant = Plants.FirstOrDefault(x => x.Id.Equals(selectedId));
            }
        }

        public void DiscardChanges()
        {
            using (connect = new DBConnect())
            {
                Plant temp = connect.Plants.FirstOrDefault(x => x.Id.Equals(SelectedPlant.Id));

                int selectedId = SelectedPlant.Id;                

                Plants.Clear();

                if (!connect.Plants.IsNullOrEmpty())
                {
                    foreach (Plant plant in connect.Plants)
                    {
                        Plants.Add(plant);
                    }
                }

                SelectedPlant = Plants.FirstOrDefault(x => x.Id.Equals(selectedId));
            }

        }

        public void ThemeChange()
        {
            PaletteHelper palette = new PaletteHelper();

            ITheme theme = palette.GetTheme();

            if(isDark)
            {
                theme.SetBaseTheme(Theme.Dark);
            }
            else
            {
                theme.SetBaseTheme(Theme.Light);
            }
            palette.SetTheme(theme);
        }

        

        public void LogIn()
        {
            using(connect = new DBConnect())
            {
                List<User> users = connect.Users.ToList();

                if (loginStr.Length > 0 && users.Any(x => x.Name.Equals(loginStr)))
                {
                    User user = new User();
                    user = users.FirstOrDefault(x => x.Name.Equals(loginStr));
                    if (user != null && user.Password.Equals(passwordStr))
                    {
                        loginStr = string.Empty; 
                        passwordStr = string.Empty;
                        
                        Visibility = Visibility.Visible;
                        IsElementEnable = true;
                    }
                    else return;
                }


            }
        }

        public void LogOut()
        {
            Visibility = Visibility.Hidden;
            IsElementEnable = false;
        }
    }
}
