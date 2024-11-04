﻿using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using TallyConnector.Core.Models.Masters.Inventory;

namespace TallyConnector.Core.Converters.XMLConverterHelpers;
[DebuggerDisplay("{ToString()}")]
[JsonConverter(typeof(TallyQuantityJsonConverter))]
public class TallyQuantity : IXmlSerializable
{
    public TallyQuantity()
    {
    }
    //public TallyQuantity(StockItem stockItem, decimal number)
    //{
    //    Number = number;
    //    if (stockItem.BaseUnit != null && stockItem.BaseUnit != string.Empty)
    //    {
    //        PrimaryUnits = new(number, stockItem.BaseUnit);
    //    }

    //}
    public TallyQuantity(StockItem stockItem, decimal quantity)
    {
        Number = quantity;
        if (stockItem.BaseUnit != null && stockItem.BaseUnit != string.Empty)
        {
            PrimaryUnits = new(quantity, stockItem.BaseUnit);
        }
        if (stockItem.AdditionalUnits != null && stockItem.AdditionalUnits != string.Empty)
        {
            if (stockItem.Conversion != null && stockItem.Denominator != null)
            {
                SecondaryUnits = new(quantity * Math.Round(((decimal)stockItem.Conversion / (decimal)stockItem.Denominator), 2), stockItem.AdditionalUnits);
            }
        }
    }

    public TallyQuantity(decimal quantity, string unit = "")
    {
        Number = quantity;
        PrimaryUnits = new(quantity, unit);
    }
    public TallyQuantity(decimal quantity,
                         string unit,
                         decimal secondaryQuantity,
                         string secondaryUnit)
    {
        Number = quantity;
        PrimaryUnits = new(quantity, unit);
        SecondaryUnits = new(secondaryQuantity, secondaryUnit);
    }

    [Column(TypeName = "decimal(20,6)")]
    public decimal Number
    {
        get; set;
    }
    public BaseTallyQuantity? PrimaryUnits
    {
        get; set;
    }
    public BaseTallyQuantity? SecondaryUnits
    {
        get; set;
    }
    public XmlSchema? GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        bool isEmptyElement = reader.IsEmptyElement;
        if (!isEmptyElement)
        {
            string content = reader.ReadElementContentAsString();

            if (content != null && content != string.Empty)
            {
                content = content.Trim();
                var matches = Regex.Matches(content, @"\b[0-9.]+\b");
                if (matches.Count == 2 && matches[1].Value != ".")
                {
                    Number = decimal.Parse(matches[0].Value, CultureInfo.InvariantCulture);
                    var splittedtext = content.Split('=');
                    if (!content.Contains('='))
                    {
                        splittedtext = new string[] { content.Substring(0, content.Length / 2), content.Substring(content.Length / 2) };
                    }
                    PrimaryUnits = new(Number, splittedtext.First().Trim().Split(' ').Last().Trim());
                    SecondaryUnits = new(decimal.Parse(matches[1].Value, CultureInfo.InvariantCulture), splittedtext.Last().Trim().Split(' ').Last().Trim());
                }
                else
                {
                    var splittedtext = content.Split(' ');
                    Number = decimal.Parse(matches[0].Value, CultureInfo.InvariantCulture);
                    PrimaryUnits = new(Number, splittedtext.Last().Trim());
                }
            }
        }

    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteString(this.ToString());
    }

    public override string ToString()
    {
        if (SecondaryUnits != null)
        {
            return $"{PrimaryUnits?.Number.ToString(CultureInfo.InvariantCulture)} {PrimaryUnits?.Unit.ToString(CultureInfo.InvariantCulture)} = {SecondaryUnits?.Number.ToString(CultureInfo.InvariantCulture)} {SecondaryUnits?.Unit.ToString(CultureInfo.InvariantCulture)}";
        }
        else
        {
            return $"{PrimaryUnits?.Number.ToString(CultureInfo.InvariantCulture)} {PrimaryUnits?.Unit.ToString(CultureInfo.InvariantCulture)}";
        }
    }

    public static implicit operator decimal(TallyQuantity amount)
    {
        return amount.Number;
    }

    public static implicit operator TallyQuantity(decimal amount)
    {
        return new TallyQuantity(amount);
    }
}

public class BaseTallyQuantity
{
    [Column(TypeName = "decimal(20,6)")]
    public decimal Number
    {
        get; set;
    }

    public string Unit
    {
        get; set;
    }

    public BaseTallyQuantity(decimal number, string unit)
    {
        Number = number;
        Unit = unit;
    }
}

