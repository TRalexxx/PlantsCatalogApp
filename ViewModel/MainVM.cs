using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlantsCatalogApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlantsCatalogApp.ViewModel
{
    class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<Plant> Plants { get; set; }

        private Plant selectedPlant;

        private DBConnect connect;

        private string searchStr;

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
                if (!Plants.IsNullOrEmpty())
                    selectedPlant = Plants[0];
            }
        }


    }
}
