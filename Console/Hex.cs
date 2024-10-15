namespace Hex;
/// <summary>
/// HexaDecimaal klasse met een integerwaarde en een hexadecimale waarde
/// </summary>
/// <remarks>
/// Deze klasse bevat een integerwaarde die wordt omgezet naar een hexadecimale waarde
/// </remarks>
public class HexaDecimaal  //hex1
{
    private string hexWaarde = ""; // Private char veld om de hexadecimale waarde op te slaan (0-F)

    /// <summary>
    /// Set-methode die de integerwaarde omzet naar hexadecimaal 
    /// </summary>
    public void SetHex(int waarde)
    {
        if(waarde < 0 || waarde > 0xFFFF)
        {
            throw new ArgumentOutOfRangeException("Waarde moet tussen 0 en 65535 liggen");
        }
        hexWaarde = waarde.ToString("X");
    }
    /// <summary>
    /// Operator-overloading om de hexadecimale waarden op te tellen
    /// </summary>
    /// <returns> De som van de hexadecimale waarden</returns>
    public static int operator+ (HexaDecimaal hex1, HexaDecimaal hex2)
    {
        int som = hex1.GetDec() + hex2.GetDec();
        if(som < 0 || som > 65535)
        {
            throw new ArgumentOutOfRangeException("Waarde moet tussen 0 en 65535 liggen");
        }
        return hex1.GetDec() + hex2.GetDec();
    }
    /// <summary>
    /// Get-methode die de hexadecimale waarde teruggeeft
    /// </summary>
    /// <returns>De waarde van dat je hebt ingevuld</returns>
    public virtual string GetHex()
    {
        return hexWaarde;
    }
    /// <summary>
    /// Get-methode die de decimale waarde teruggeeft
    /// </summary>
    /// <returns>De decimale waarde van de hexadecimale waarde</returns>
    public virtual int GetDec()
    {
        return int.Parse(hexWaarde, System.Globalization.NumberStyles.HexNumber);
    }
    public virtual string GetByte()
    {
        return Convert.ToString(GetDec(), 2);
    }

}