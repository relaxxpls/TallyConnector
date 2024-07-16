﻿using MongoDB.Bson;
using TallyConnector.Core.Models;

[XmlRoot(ElementName = "BATCH")]
public class Batch : TallyBaseObject
{
    private ObjectId? _id = ObjectId.Empty;
    
    [JsonPropertyName("_id")]
    public ObjectId? Id 
    { 
        get => _id;
        set => _id = value ?? ObjectId.Empty;
    }

    [JsonPropertyName("id")]
    public string IdStr => Id.ToString();

    [JsonPropertyName("company_id")]
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
