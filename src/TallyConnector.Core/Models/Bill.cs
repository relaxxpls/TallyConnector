using TallyConnector.Core.Models;

[XmlRoot(ElementName = "BILL")]
public class Bill : TallyBaseObject
{
    [XmlAttribute(AttributeName = "NAME")]
    public string Name { get; set; }

    [XmlElement(ElementName = "BILLDATE")]
    public TallyDate BillDate { get; set; }

    [XmlElement(ElementName = "BILLID")]
    public int BillId { get; set; }

    [XmlElement(ElementName = "OPENINGBALANCE")]
    public TallyAmount OpeningBal { get; set; }

    [XmlElement(ElementName = "CLOSINGBALANCE")]
    public TallyAmount ClosingBal { get; set; }

    [XmlElement(ElementName = "FINALBALANCE")]
    public TallyAmount FinalBal { get; set; }

    [XmlElement(ElementName = "BILLCREDITPERIOD")]
    public TallyDate BillCreditPeriod { get; set; }
}
