using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlantsCatalogApp.Model
{
    class Plant : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string localName;

        public string LocalName
        {
            get { return localName; }
            set { localName = value; OnPropertyChanged("LocalName"); }
        }

        private string scientName;

        public string ScientName
        {
            get { return scientName; }
            set { scientName = value; OnPropertyChanged("ScientName"); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private string positiveEffects;

        public string PositiveEffects
        {
            get { return positiveEffects; }
            set { positiveEffects = value; OnPropertyChanged("PositiveEffects"); }
        }

        private string negativeEffects;

        public string NegativeEffects
        {
            get { return negativeEffects; }
            set { negativeEffects = value; OnPropertyChanged("NegativeEffects"); }
        }

        private string growingArea;

        public string GrowingArea
        {
            get { return growingArea; }
            set { growingArea = value; OnPropertyChanged("GrowingArea"); }
        }

        public Plant()
        {
            Id = 0;
            localName = string.Empty;
            scientName = string.Empty;
            description = string.Empty;
            positiveEffects = string.Empty;
            negativeEffects = string.Empty;
            growingArea = string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
