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


