using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public interface IEileger
    {
        double Gewicht { get; set; }
        List<Ei> Eier { get; set; }

        void EiLegen();
    }
}