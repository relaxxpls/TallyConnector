﻿namespace TallyConnector.Core.Models.TallyComplexObjects;
[TDLCollection(ExplodeCondition = "NOT $$IsEmpty:{0}")]
public class TallyQuantityField : ITallyComplexObject, IBaseObject
{
    [TDLField(TallyType = "Quantity : UnitSymbol")]
    [XmlElement(ElementName = "UNIT")]
    public string Unit { get; set; }

    [TDLField(TallyType = "Number", Format = "TailUnits")]
    [XmlElement(ElementName = "QUANTITY")]
    [Column(TypeName = "decimal(20,4)")]
    public decimal Quantity { get; set; }


    public override string ToString()
    {
        return $" {Quantity} {Unit}";
    }
}
