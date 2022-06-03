using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GefluegelBl
{
    public abstract class Gefluegel : IEiLeger, INotifyPropertyChanged
    {
        private int _gewicht;

        public int Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();

        private string _strName;
        public string Name
        {
            get
            {
                return _strName;
            }

            set
            {
                _strName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract void EiLegen();
        public abstract void Fressen();

    }
}
