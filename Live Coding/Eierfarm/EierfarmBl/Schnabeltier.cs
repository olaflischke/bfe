using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Schnabeltier : Saeugetier, IEileger, IFresser
    {
        public double Weight { get; set; }

        public List<Ei> Eier { get; set; }
        public double MindestEiLegeGewicht { get; set; }

        public event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        public void EiLegen()
        {
            if (this.Weight>2500)
            {
                Ei ei = new(this);
                this.Weight -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public void Fressen()
        {
            throw new NotImplementedException();
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }
    }
}