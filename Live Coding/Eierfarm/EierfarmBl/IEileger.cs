using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public interface IEileger
    {
        event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        double Weight { get; set; }
        List<Ei> Eier { get; set; }
        double MindestEiLegeGewicht { get; set; }

        void EiLegen()
        {
            if (this.Weight > this.MindestEiLegeGewicht)
            {
                Ei ei = new Ei(this);
                this.Weight -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }
    }
}