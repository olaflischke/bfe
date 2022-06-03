using GefluegelBl;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GefluegelTypes
{
    [Export(typeof(IEiLeger))]
    [ExportMetadata("TypeName", "Gans")]
    class Gans : Gefluegel
    {
        public Gans()
        {
            this.Gewicht = 1500;
            this.Name = "Neue Gans";
        }
        public override void EiLegen()
        {
            if (this.Gewicht>2000)
            {
                Ei ei = new Ei();
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht<5000)
            {
                this.Gewicht += 250;
            }
        }
    }
}
