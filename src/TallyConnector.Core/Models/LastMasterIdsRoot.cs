using System;
using System.Xml.Serialization;

[XmlRoot(ElementName = "ENVELOPE")]
public class LastAlterIdsRoot
{
    // Backing field for MASTERSLASTID
    private string _mastersLastAlterIdRaw;

    // Backing field for VOUCHERSLASTID
    private string _vouchersLastAlterIdRaw;

    // Public property to get/set MASTERSLASTID
    [XmlElement(ElementName = "MASTERSLASTID")]
    public string MastersLastAlterIdRaw
    {
        get => _mastersLastAlterIdRaw;
        set
        {
            _mastersLastAlterIdRaw = value;
            MastersLastAlterId = ParseIntFromString(value);
        }
    }

    // Public property to get/set VOUCHERSLASTID
    [XmlElement(ElementName = "VOUCHERSLASTID")]
    public string VouchersLastAlterIdRaw
    {
        get => _vouchersLastAlterIdRaw;
        set
        {
            _vouchersLastAlterIdRaw = value;
            VouchersLastAlterId = ParseIntFromString(value);
        }
    }

    [XmlIgnore]
    public int MastersLastAlterId { get; private set; }

    [XmlIgnore]
    public int VouchersLastAlterId { get; private set; }

    // Method to parse the integer from string with special handling for "(-)"
    private int ParseIntFromString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return 0;
        }

        value = value.Trim();

        if (value.StartsWith("(-)"))
        {
            value = value.Substring(3).Trim();
            if (int.TryParse(value, out int result))
            {
                return -result;
            }
        }
        else if (int.TryParse(value, out int result))
        {
            return result;
        }

        throw new FormatException($"Invalid number format: {value}");
    }
}
