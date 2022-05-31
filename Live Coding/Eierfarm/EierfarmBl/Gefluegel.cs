using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public abstract class Gefluegel : IEileger
    {
        public Gefluegel(string name)
        {
            this.Name = name;
        }

        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateOnly Schuepfdatum { get; set; }

        public double Gewicht { get; set; }
        public List<Ei> Eier { get; set; } = new List<Ei>();

        public abstract void Fressen();
        public abstract void EiLegen();
    }
}
