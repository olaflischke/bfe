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
    [ExportMetadata("TypeName", "Huhn")]
    class Huhn : Gefluegel
    {
        public Huhn()
        {
            this.Gewicht = 1000;
            this.Name = "Neues Huhn";
        }

        public override void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new Ei();
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                this.Gewicht += 100;
            }
        }
    }
}
