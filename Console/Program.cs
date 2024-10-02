using Sort;
using Hex;
using Calc;
using Word;
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
        Console.Write("Voer het eerste getal in: ");
        int getal1 = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Voer het tweede getal in: ");
        int getal2 = int.Parse(Console.ReadLine() ?? "0");

        SomInt resultaat1 = new(getal1, getal2);
        SomInt resultaat2 = new(13, 15);
        SomInt resultaat3 = resultaat1 + resultaat2;
                
        Console.WriteLine(resultaat3.Waarde);
        Console.WriteLine($"13 + 15 plus de getallen is { resultaat3.Waarde }");

        // Vraag de gebruiker om het getal
        Console.Write("Voer het getal in: ");
        int getal3;
        while (!int.TryParse(Console.ReadLine(), out getal3))
        {
            Console.Write("Ongeldige invoer. Voer een geldig getal in: ");
        }

        SomInt resultaat = new SomInt(getal3, getal3) + new SomInt(getal3, getal3);
        Console.WriteLine($"Waarde van het getal 4 keer opgeteld {resultaat.Waarde}");
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
    public static void Main(string[] args)
    {
        //Hexadecimal();
        //Calc();
        //Sorting();
        Word();
    }
}
