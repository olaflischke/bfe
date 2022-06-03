using System;

namespace GefluegelBl
{
    public class Ei
    {
        public Ei()
        {
            Random rnd = new Random();
            this.Gewicht = rnd.Next(45, 81);
            this.Farbe = (EiFarbe)rnd.Next(3);
        }

        public int Gewicht { get;  set; }
        public EiFarbe Farbe { get;  set; }
    }

    public enum EiFarbe
    {
        Hell,
        Dunkel,
        Gruen
    }
}