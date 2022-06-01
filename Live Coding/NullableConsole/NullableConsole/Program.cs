using EierfarmBl;

// Warning wg. null
Huhn hilde = null; // = new();

// Keine Warning
if (hilde != null)
{
    // Keine Warning
    Console.WriteLine($"Das Huhn heißt {hilde.Name}");

    Huhn herta = hilde;
}

// Warning
Huhn hanne = hilde;
hanne.Name = "Hanne";

#nullable disable
hanne.Name = "Hanne";

#nullable enable

// Statt
//if (hilde==null)
//{
//    hilde = new();
//}

// Null-Coalescing Assignment
hilde ??= new();

System.Nullable<int> a1 = null;
int? a = null;
int b = 12;
int c = (a.HasValue ? a.Value : -1) + b;
int d = (a ?? -1) + b;

List<int> zahlen = null;
(zahlen ??= new List<int>()).Add(c);

// Warnung: Verwechslungsgefahr:
zahlen.Add(a ?? 0);
zahlen.Add(a ??= 0);

