using TallyConnector.Core.Models;

[XmlRoot(ElementName = "BATCH")]
public class Batch : TallyBaseObject
{

    [JsonIgnore]
    public string Id { get; set; }

    public string? CompanyId { get; set; }

    [XmlElement(ElementName = "BATCHNAME")]
    public string Name { get; set; }

    [XmlElement(ElementName = "BATCHID")]
    public int BatchId { get; set; }

    [XmlElement(ElementName = "PARENT")]
    public string ItemName { get; set; }

    [XmlElement(ElementName = "DATE")]
    public TallyDate Date { get; set; }

    [XmlElement(ElementName = "MFDON")]
    public TallyDate ManufacturingDate { get; set; }

    [XmlElement(ElementName = "GODOWNNAME")]
    public string GodownName { get; set; }

    [XmlElement(ElementName = "CLOSINGBALANCE")]
    public TallyQuantity ClosingBal { get; set; }

    [XmlElement(ElementName = "CLOSINGRATE")]
    public TallyRate? ClosingRate { get; set; }

    [XmlElement(ElementName = "CLOSINGVALUE")]
    public TallyAmount? ClosingValue { get; set; }
}
