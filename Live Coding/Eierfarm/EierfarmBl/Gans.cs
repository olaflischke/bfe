using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Gans : Gefluegel
    {
        public Gans() : base("Neue Gans")
        {
            this.Weight = 2000;
        }

        public Gans(string name) : this()
        {
            this.Name = name;
        }

        public int Steuerkurs { get; set; }

        public void EiLegen()
        {
            if (this.Weight > 2000)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
            }
        }

        public override void Fressen()
        {
            if (this.Weight < 5000)
            {
                this.Weight += 250;
            }
        }
    }
}
