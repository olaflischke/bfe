﻿using System;
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
            this.Gewicht = 2000;
        }

        public Gans(string name) : this()
        {
            this.Name = name;
        }

        public int Steuerkurs { get; set; }

        public override void EiLegen()
        {
            if (this.Gewicht > 2000)
            {
                Ei ei = new Ei(this);
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 5000)
            {
                this.Gewicht += 250;
            }
        }
    }
}
