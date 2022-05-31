using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        private void OnEigenschaftGeaendert([CallerMemberName] string propertyName = "")
        {
            if (EigenschaftGeaendert != null)
            {
                EigenschaftGeaendert(this, new GefluegelEventArgs(propertyName));
            }
        }

        public Guid Id { get; init; } = Guid.NewGuid();
        public DateOnly Schuepfdatum { get; set; }
        public double MindestEiLegeGewicht { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnEigenschaftGeaendert();
            }
        }

        private double _gewicht;
        public double Weight
        {
            get
            {
                return _gewicht;
            }
            set
            {
                _gewicht = value;
                OnEigenschaftGeaendert(nameof(this.Weight));
            }
        }

        public List<Ei> Eier { get; set; } = new List<Ei>();


        public abstract void Fressen();
        //public abstract void EiLegen();
    }
}
