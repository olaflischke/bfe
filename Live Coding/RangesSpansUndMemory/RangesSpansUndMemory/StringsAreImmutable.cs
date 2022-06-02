using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangesSpansUndMemory
{
    internal class StringsAreImmutable
    {
        void Strings()
        {
            string hallo = "Hallo";
            string welt = "Welt";

            // Schnell
            string message = hallo + " " + welt + "!";

            // Speicher sparen
            StringBuilder sb = new StringBuilder("Hallo");
            sb.Append(" ");
            sb.Append(welt);
            sb.Append("!");

            string msg=sb.ToString();

            // $ als Syntaxvereinfachung für StringBuilder
            string msgNeu = $"{hallo} {welt}!";
        }
    }
}
