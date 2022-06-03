using GefluegelBl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GefluegelUi
{
    public class Stall
    {
        public Stall()
        {
        }

        public ObservableCollection<IEiLeger> Tiere { get; set; } = new ObservableCollection<IEiLeger>();
    }
}
