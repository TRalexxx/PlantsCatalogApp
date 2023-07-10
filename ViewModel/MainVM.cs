using Microsoft.IdentityModel.Tokens;
using PlantsCatalogApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlantsCatalogApp.ViewModel
{
    class MainVM : INotifyPropertyChanged
    {
        public List<Plant> Plants { get; set; }

        private Plant selectedPlant;

        public Plant SelectedPlant
        {
            get { return selectedPlant; }
            set { selectedPlant = value; OnPropertyChanged("SelectedPlant"); }
        }

        public MainVM()
        {
            using(DBConnect con = new DBConnect())
            {
                if (!con.Plants.IsNullOrEmpty()) { }
                    Plants = con.Plants.ToList();
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
    }
}
