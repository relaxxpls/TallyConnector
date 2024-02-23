using TallyConnector.Core.Models;

[XmlRoot(ElementName = "BATCH")]
public class Batch : TallyBaseObject
{
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
    public TallyAmount ClosingBal { get; set; }
}
