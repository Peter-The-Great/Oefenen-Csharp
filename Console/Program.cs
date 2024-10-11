using Sort;
using Hex;
using Calc;
using Word;
using Variance;
using System.Diagnostics;
public class Program
{
    public static void Sorting()
    {
        // Create a Sorter object
        Sorter sorter = new Sorter();

        // Define an array of strings to be sorted
        List<string> names = ["Banana", "Apple", "Orange", "Grape", "Pineapple", "Mango"];
        names.Add("Strawberry");

        // Display the unsorted array
        Console.WriteLine("Unsorted array:");
        Console.WriteLine(string.Join(",", names));

        // Call the BubbleSort method to sort the array
        var stopwatch = Stopwatch.StartNew();
        sorter.BubbleSort(names);
        stopwatch.Stop();

        // Display the sorted array
        Console.WriteLine("\nBubble Sorted array:");
        Console.WriteLine(string.Join(",", names));
        Console.WriteLine($"BubbleSort took {stopwatch.ElapsedMilliseconds} ms");

        // Call the InsertSort method to sort the array
        stopwatch = Stopwatch.StartNew();
        sorter.InsertSort(names);
        stopwatch.Stop();

        // Display the sorted array
        Console.WriteLine("\nInserted Sorted array:");
        Console.WriteLine(string.Join(",", names));
        Console.WriteLine($"InsertSort took {stopwatch.ElapsedMilliseconds} ms");
    }
    public static void Hexadecimal()
    {
       // Maak een HexaDecimaal object en stel in op 11 (B in hexadec)
        HexaDecimaal hex = new HexaDecimaal();
        hex.SetHex(1234);

        Console.WriteLine($"De hexadecimale waarde is: {hex.GetHex()}"); // Output is: 4D2
        Console.WriteLine($"De decimale waarde is: {hex.GetByte()}"); // Output is: 10011010010
        int hexSom = hex + hex;
        Console.WriteLine($"De som van de hexadecimale waarden is: {hexSom}"); // Output: 2468
    }
    public static void Calc()
    {
        Console.Write("Voer het eerste getal in: "); // Vraag de gebruiker om getallen​
        int getal1 = int.Parse(Console.ReadLine() ?? "");
        Console.Write("Voer het tweede getal in: ");
        int getal2 = int.Parse(Console.ReadLine() ?? "");
        SomInt som = new SomInt(getal1, getal2);
        Console.WriteLine($"De som van {getal1} en {getal2} is: {som.Waarde}");

        SomInt resultaat1 = new SomInt(50);
        SomInt resultaat2 = new SomInt(50);
        Console.WriteLine("Het resultaat van " + resultaat1.Waarde + " en " + resultaat2.Waarde + " is het volgende resultaat: " + (resultaat1 + resultaat2));

        // Vraag de gebruiker om het getal
        Console.Write("Voer een getal in: ");
        int getal;
        while (!int.TryParse(Console.ReadLine(), out getal))
        {
            Console.WriteLine("Ongeldige invoer. Voer een getal in: ");
        }
        int resultaat = new SomInt(getal, getal) + new SomInt(getal, getal);
        Console.WriteLine($"Waarde van het getal 4 keer opgeteld {resultaat}");
    }
    public static void Word()
    {
        string bestandPad = "invoer.txt";
        var woorden = new List<Woord>();

        try
        {
            if (!File.Exists(bestandPad))
            {
                Console.WriteLine("Het bestand bestaat niet.");
                File.WriteAllText(bestandPad, "Dit is een voorbeeldtekst");
                Console.WriteLine("Voorbeeldtekst is geschreven naar het bestand.");
                return;
            }

            string[] lijnen = File.ReadAllLines(bestandPad);

            foreach (string lijn in lijnen)
            {
                // Splits de regels op basis van spaties om woorden te krijgen
                string[] woordenInLijn = lijn.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string woord in woordenInLijn)
                {
                    // Maak een Woord-object via de Factory en voeg het toe aan de lijst
                    Woord nieuwWoord = WoordFactory.MaakWoord(woord);
                    if (!string.IsNullOrEmpty(nieuwWoord.Tekst))
                    {
                        woorden.Add(nieuwWoord);
                    }
                }
            }

            // Druk alle woorden af met hun klinker- en medeklinkertelling
            foreach (Woord woord in woorden)
            {
                Console.WriteLine(woord);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Er is een fout opgetreden bij het lezen van het bestand: {ex.Message}");
        }
    }
    public static void Variance()
    {
        //Covariance Example [Array +  IEnumerable<T> +  IEnumerator<T>  +  IInterface<Out T>  +  Func<T>]
        object obj = new string[] { "example" };
        object[] array = (string[]) obj;
        IEnumerable<object> enumerable = (IEnumerable<object>) obj;
        IEnumerator<object> enumerator = ((IEnumerable<object>) obj).GetEnumerator();
        IGoOut<object> goOut = new GoOutClass<string>();
        Func<object> func = () => obj;

        Console.WriteLine("Covariance Example");
        Console.WriteLine("Array: " + array.GetType());
        Console.WriteLine("IEnumerable: " + enumerable.GetType());
        Console.WriteLine("IEnumerator: " + enumerator.GetType());
        Console.WriteLine("IGoOut: " + goOut.GetType());
        Console.WriteLine("Func: " + func.GetType());

        //Contravariance Example[IInterface<in T>]
        IComeIn<string> comeIn = new ComeInClass<object>();
    }
    public static void Main(string[] args)
    {
        Hexadecimal();
        Calc();
        Sorting();
        Word();
        Variance();
    }
}
