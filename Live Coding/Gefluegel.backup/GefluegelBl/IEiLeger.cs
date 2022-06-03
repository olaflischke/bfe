using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GefluegelBl
{
    public interface IEiLeger : INotifyPropertyChanged
    {
        ObservableCollection<Ei> Eier { get; set; }
        int Gewicht { get; set; }
        string Name { get; set; }

        void EiLegen();
        void Fressen();
    }

    public interface IEiLegerInfo
    {
        string TypeName { get;  }
    }
}