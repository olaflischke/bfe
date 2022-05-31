using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Ei
    {
        public Ei(IEileger mutter)
        {
            Random random = new();
            this.Gewicht = random.Next(45, 80);
            this.Farbe = (EiFarbe)random.Next(Enum.GetValues(typeof(EiFarbe)).Length);
            this.Mutter = mutter;
        }

        public EiFarbe Farbe { get; set; }
        public double Gewicht { get; set; }
        public IEileger Mutter { get; set; }
    }

    public enum EiFarbe
    {
        Hell,
        Dunkel,
        Gruen
    }

}
