namespace Calc;
public class SomInt
{
    public int Waarde { get; private set; }
    public SomInt(int waarde)
    {
        Waarde = waarde;
    }
    public SomInt(int getal1, int getal2)
    {
        try
        {
            checked
            {
                int result = getal1 + getal2;
            }
        }
        catch (OverflowException)
        {
            Waarde = -1;
        }

        Waarde = getal1 + getal2;
    }
    public static SomInt operator+ (SomInt a, SomInt b)
    {
        return new SomInt(a.Waarde + b.Waarde);
    }
}