using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Schnabeltier : Saeugetier, IEileger
    {
        public double Gewicht { get; set; }

        public List<Ei> Eier { get; set; }

        public void EiLegen()
        {
            if (this.Gewicht>2500)
            {
                Ei ei = new(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }
    }
}