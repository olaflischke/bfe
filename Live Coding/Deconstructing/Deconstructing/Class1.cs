namespace Deconstructing
{
    public class DeconstructingSamples
    {
        #region Tuples
        void DeconstructingTuples()
        {
            Tuple<string, double, DateOnly> tpUsd = new("USD", 1.0753, new DateOnly(2022, 6, 2));

            string symbol1 = tpUsd.Item1;
            double kurs1 = tpUsd.Item2;
            DateOnly date1 = tpUsd.Item3;

            // Deconstructing:
            var (symbolDc1, kursDc1, dateDc1) = tpUsd;
            Console.WriteLine($"Der {symbolDc1} steht heute ({dateDc1}) bei {kursDc1}");

            // Rückgabe aus Funktion
            var (symbolJpy, kursJpy, dateJpy) = GetDataFromTuple();

            // Named Tuple
            var tpBgn = (Symbol: "BGN", Kurs: 1.95583, Datum: new DateOnly(2022, 6, 2));

            string symbol2 = tpBgn.Symbol;
            double kurs2 = tpBgn.Kurs;
            DateOnly date2 = tpBgn.Datum;

        }

        (string, double, DateOnly) GetDataFromTuple()
        {
            string symbol = "JPY";
            double value = 134.34;
            DateOnly date = new DateOnly(2022, 6, 2);

            return (symbol, value, date);
        }

        #endregion

        #region Deconstructing Records
        // Record class (Positional Record)
        record Ente(string Name, double Gewicht);

        // Positonal record struct
        record struct Gans(string Name, double Gewicht);

        // Record struct ohne positonal
        record struct Huhn
        {
            public string Name { get; set; }
            public double Gewicht { get; set; }

            public void Deconstruct(out string name, out double gewicht)
            {
                name = this.Name;
                gewicht = this.Gewicht;
            }
        }

        void DeconstructingRecord()
        {
            Ente ente = new Ente("Erika", 1000);
            var (name1, gewicht1) = ente;

            Console.WriteLine($"{name1} wiegt {gewicht1}g.");

            Gans gans = new("Gerda", 2000);
            var (name2, gewicht2) = gans;

            Huhn huhn = new Huhn() { Name = "Hilde", Gewicht = 2500 };
            var (name3, gewicht3) = huhn;


        }

        #endregion    }

        void DeconstructingClass()
        {
            Flugzeug flugzeug = new() { Kennzeichen = "D-ESOL", Spannweite = 12.34 };
            var (zeichen, fluegel) = flugzeug; // Erforderlich: Selbstgeschriebene Deconstrcut-Methode (in der Klasse oder als Extension Method)

            flugzeug.Deconstruct(out zeichen, out _); // auch direkt aufrufbar
        }

        Dictionary<string, double> rates = new()
        {
            {"USD", 1.0753 },
            {"RUB", 68.6},
            {"BGN", 1.95583 }
        };

        void DeconstructingDictionary()
        {
            foreach ((string symbol, double wert) in rates)
            {
                Console.WriteLine($"{symbol}: {wert}");
            }
        }

    }

    class Flugzeug
    {
        public double Spannweite { get; set; }
        public string Kennzeichen { get; set; }

        public string Besitzer { get; set; }
    }

    // Deconstruct als Extension Method
    static class FlugzeugExtensions
    {
        public static void Deconstruct(this Flugzeug flugzeug, out string kennzeichen, out double spannweite)
        {
            kennzeichen = flugzeug.Kennzeichen;
            spannweite = flugzeug.Spannweite;
        }

        public static void Deconstruct(this Flugzeug flugzeug, out string kennzeichen, out string besitzer, out double spannweite)
        {
            kennzeichen = flugzeug.Kennzeichen;
            besitzer = flugzeug.Besitzer;
            spannweite=flugzeug.Spannweite;
        }
    }
}