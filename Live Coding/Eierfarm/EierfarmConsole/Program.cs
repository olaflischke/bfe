// See https://aka.ms/new-console-template for more information
using EierfarmBl;

Console.WriteLine("Hello, World!");


int zahl = 0;

switch (zahl)
{
    case 0:
        Console.WriteLine("Zahl ist 0.");
        break;
    case > 0:
        Console.WriteLine("Zahl ist größer als 0.");
        break;
    default:
        break;
}


// Neu: Switch auf Typen
IEileger tier = new Huhn();

switch (tier)
{
    case Huhn huhn:
        Console.WriteLine($"Das Huhn heißt {huhn.Name}");
        break;
    case Gans gans:
        break;
    case Schnabeltier schnabeltier:
        break;

    default:
        break;
}

Huhn huhn1 = new() { Name = "Hilde" };

string stall1 = huhn1.Name switch
{
    "Hilde" => "Gryffindor",
    "Herta" => "Hufflepuff",
    _ => "Unbekannt"
};

//string stallPlain = "";

//if (huhn1.Name=="Hilde")
//{
//    stallPlain = "Gryffindor";
//}
//else if (huhn1.Name=="Herta")
//{
//    stallPlain = "Hufflepuff";
//}
//else
//{
//    stallPlain = "Unbekannt";
//}

string stall2 = huhn1 switch
{
    { Name: "Hilde" } => "Gryffindor",
    { Name: "Herta" } => "Hufflepuff",
    _ => "Unbekannt"
};

IEileger tier2 = new Huhn();

string stall3 = tier2 switch
{
    Huhn huhn2 when huhn2.Weight < 1000 => $"{huhn2.Name} wohnt in Slytherin",
    Huhn huhn2 => $"{huhn2.Name} wohnt in Gryffindor",
    Gans gans2 => $"{gans2.Name} wohnt in Ravenclaw",
    _ => "Unbekannt"
};

switch (tier)
{
    case Huhn huhn12 when huhn12.Weight < 1000:
        Console.WriteLine($"Das Huhn {huhn12.Name} sollte fressen.");
        break;
    case Huhn huhn13:
        Console.WriteLine($"Das Huhn heißt {huhn13.Name}");
        break;
    case Gans gans:
        break;
    case Schnabeltier schnabeltier:
        break;

    default:
        break;
}

if (tier is Huhn { Name: "Hilde" } huhn3)
{

}

if (tier is Huhn { Weight: > 1500 and < 2000 } huhn)
{

}

if (tier is Huhn { Weight: > 1500 and < 2000, Name: not "Hilde" } huhn4)
{

}

Huhn huhn5 = new Huhn();
object ei = new Ei(huhn5);

if (ei is Ei { Gewicht: > 53 and < 63, Mutter: var mutter, Farbe: EiFarbe farbe })
{
    Console.WriteLine($"Die Mutter des Eis wiegt {mutter.Weight}g.");
    Console.WriteLine($"Das Ei ist {farbe}");
}


