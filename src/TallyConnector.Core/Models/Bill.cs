namespace TallyConnector.Core.Models;

[Serializable]
[XmlRoot(ElementName = "BILL", Namespace = "")]
//[TallyObjectType(TallyObjectType.Bills)]
public class Bill : BasicTallyObject, ITallyObject
{
    public Bill()
    {
        _DeliveryNotes = new();
    }

    [XmlElement(ElementName = "DATE")]
    public TallyDate Date { get; set; }

    [XmlElement(ElementName = "OPENINGBALANCE")]
    public decimal OpeningBalance { get; set; }

    [XmlElement(ElementName = "CLOSINGBALANCE")]
    public decimal ClosingBalance { get; set; }

    [XmlElement(ElementName = "FINALBALANCE")]
    public decimal FinalBalance { get; set; }

    [XmlElement(ElementName = "REFERENCEDATE")]
    public TallyDate? ReferenceDate { get; set; }

    [XmlElement(ElementName = "REFERENCE")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    public string? Reference { get; set; }

    [XmlElement(ElementName = "VOUCHERTYPENAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    public string VoucherType { get; set; }

    [XmlElement(ElementName = "VOUCHERTYPEID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    public string? VoucherTypeId { get; set; }

    [XmlElement(ElementName = "PERSISTEDVIEW")]
    [Column(TypeName = $"nvarchar(30)")]
    public VoucherViewType View { get; set; }

    [XmlElement(ElementName = "VCHGSTCLASS")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    public string? VoucherGSTClass { get; set; }

    [XmlElement(ElementName = "ISCOSTCENTRE")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    public TallyYesNo? IsCostCentre { get; set; }

    [XmlElement(ElementName = "COSTCENTRENAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    public string? CostCentreName { get; set; }

    [XmlElement(ElementName = "VCHENTRYMODE")]
    [Column(TypeName = $"nvarchar(30)")]
    public string? VoucherEntryMode { get; set; }

    [XmlElement(ElementName = "ISINVOICE")]
    public TallyYesNo IsInvoice { get; set; }

    [XmlElement(ElementName = "VOUCHERNUMBER")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    public string? VoucherNumber { get; set; }

    [XmlElement(ElementName = "ISOPTIONAL")]
    [Column(TypeName = "nvarchar(3)")]
    public TallyYesNo? IsOptional { get; set; }

    [XmlElement(ElementName = "EFFECTIVEDATE")]
    public TallyDate? EffectiveDate { get; set; }

    [XmlElement(ElementName = "NARRATION")]
    [Column(TypeName = $"nvarchar({Constants.MaxNarrLength})")]
    public string? Narration { get; set; }

    [XmlElement(ElementName = "PRICELEVEL")]
    [Column(TypeName = $"nvarchar({Constants.MaxNarrLength})")]
    public string? PriceLevel { get; set; }

    //E-Invoice Details
    [TallyCategory(Constants.Voucher.Category.EInvoiceDetails)]
    [XmlElement(ElementName = "BILLTOPLACE")]
    [Column(TypeName = $"nvarchar({Constants.MaxNarrLength})")]
    public string? BillToPlace { get; set; }

    [TallyCategory(Constants.Voucher.Category.EInvoiceDetails)]
    [XmlElement(ElementName = "IRN")]
    public string? IRN { get; set; }

    [TallyCategory(Constants.Voucher.Category.EInvoiceDetails)]
    [XmlElement(ElementName = "IRNACKNO")]
    public string? IRNAckNo { get; set; }

    [TallyCategory(Constants.Voucher.Category.EInvoiceDetails)]
    [XmlElement(ElementName = "IRNACKDATE")]
    public string? IRNAckDate { get; set; }

    //Dispatch Details
    [TallyCategory("DispatchDetails")]
    [XmlIgnore]
    public string? DeliveryNoteNo { get; set; }

    [TallyCategory("DispatchDetails")]
    [XmlIgnore]
    public TallyDate? ShippingDate { get; set; }

    private DeliveryNotes _DeliveryNotes;

    [TallyCategory("DispatchDetails")]
    [XmlElement(ElementName = "DISPATCHFROMNAME")]
    public string? DispatchFromName { get; set; }

    [TallyCategory("DispatchDetails")]
    [XmlElement(ElementName = "DISPATCHFROMSTATENAME")]
    public string? DispatchFromStateName { get; set; }

    [TallyCategory("DispatchDetails")]
    [XmlElement(ElementName = "DISPATCHFROMPINCODE")]
    public string? DispatchFromPinCode { get; set; }

    [TallyCategory("DispatchDetails")]
    [XmlElement(ElementName = "DISPATCHFROMPLACE")]
    public string? DispatchFromPlace { get; set; }

    //Shipping Details
    [TallyCategory("ShippingDetails")]
     
    [XmlElement(ElementName = "BASICSHIPDELIVERYNOTE")]
    public DeliveryNotes DeliveryNotes
    {
        get
        {
            DeliveryNoteNo = _DeliveryNotes.DeliveryNote;
            ShippingDate = _DeliveryNotes.ShippingDate;
            return _DeliveryNotes;
        }
        set
        {
            _DeliveryNotes.ShippingDate = value.ShippingDate;
            _DeliveryNotes.DeliveryNote = value.DeliveryNote;
            _DeliveryNotes = value;
        }
    }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "BASICSHIPDOCUMENTNO")]
    public string? DispatchDocNo { get; set; }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "BASICSHIPPEDBY")]
    public string? BasicShippedBy { get; set; }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "BASICFINALDESTINATION")]
    public string? Destination { get; set; }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "EICHECKPOST")]
    public string? CarrierName { get; set; }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "BILLOFLADINGNO")]
    public string? BillofLandingNo { get; set; }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "BILLOFLADINGDATE")]
    public string? BillofLandingDate { get; set; }

    //Export Shipping Details
    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICPLACEOFRECEIPT")]
    public string? PlaceOfReceipt { get; set; }

    /// <summary>
    /// Vehicle or Ship or Flight Number
    /// </summary>
    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICSHIPVESSELNO")]
    public string? ShipOrFlightNo { get; set; }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICPORTOFLOADING")]
    public string? LandingPort { get; set; }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICPORTOFDISCHARGE")]
    public string? DischargePort { get; set; }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICDESTINATIONCOUNTRY")]
    public string? DesktinationCountry { get; set; }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "SHIPPINGBILLNO")]
    public string? ShippingBillNo { get; set; }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "SHIPPINGBILLDATE")]
    public string? ShippingBillDate { get; set; }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "PORTCODE")]
    public string? PortCode { get; set; }

    //OrderDetails
    [TallyCategory("OrderDetails")]
    [XmlElement(ElementName = "BASICDUEDATEOFPYMT")]
    public string? BasicDueDateofPayment { get; set; }

    [TallyCategory("OrderDetails")]
    [XmlElement(ElementName = "BASICORDERREF")]
    public string? OrderReference { get; set; }

    //Party Details
    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PARTYNAME")]
    public string? PartyName { get; set; }

    [XmlElement(ElementName = "PARTYLEDGERID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    public string? PartyLedgerId { get; set; }

    [XmlElement(ElementName = "GSTREGISTRATION")]
    public GSTRegistration? GSTRegistration { get; set; }

    [XmlElement(ElementName = "VOUCHERNUMBERSERIES")]
    public string? VoucherNumberSeries { get; set; }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PARTYMAILINGNAME")]
    public string? PartyMailingName { get; set; }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "STATENAME")]
    public string? State { get; set; }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "COUNTRYOFRESIDENCE")]
    public string? Country { get; set; }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "GSTREGISTRATIONTYPE")]
    public string? RegistrationType { get; set; }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PARTYGSTIN")]
    public string? PartyGSTIN { get; set; }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PLACEOFSUPPLY")]
    public string? PlaceOfSupply { get; set; }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PARTYPINCODE")]
    public string? PINCode { get; set; }

    //Consignee Details
    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "BASICBUYERNAME")]
    public string? ConsigneeName { get; set; }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEEMAILINGNAME")]
    public string? ConsigneeMailingName { get; set; }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEESTATENAME")]
    public string? ConsigneeState { get; set; }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEECOUNTRYNAME")]
    public string? ConsigneeCountry { get; set; }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEEGSTIN")]
    public string? ConsigneeGSTIN { get; set; }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEEPINCODE")]
    public string? ConsigneePinCode { get; set; }

    [XmlArray(ElementName = "ADDRESS.LIST")]
    [XmlArrayItem(ElementName = "ADDRESS")]
    public List<string>? Address { get; set; }

    [XmlArray(ElementName = "BASICBUYERADDRESS.LIST")]
    [XmlArrayItem(ElementName = "BASICBUYERADDRESS")]
    public List<string>? BuyerAddress { get; set; }

    [XmlElement(ElementName = "ISCANCELLED")]
    public TallyYesNo? IsCancelled { get; set; }

    //EWAY Details
    [XmlElement(ElementName = "OVRDNEWAYBILLAPPLICABILITY")]
    public TallyYesNo? OverrideEWayBillApplicability { get; set; }

    [XmlElement(ElementName = "EWAYBILLDETAILS.LIST")]
    public List<EwayBillDetail>? EWayBillDetails { get; set; }

    [XmlElement(ElementName = "ALLLEDGERENTRIES.LIST", Type = typeof(VoucherLedger))]
    [XmlElement(ElementName = "LEDGERENTRIES.LIST", Type = typeof(EVoucherLedger))]
    public List<VoucherLedger>? Ledgers { get; set; }

    [XmlElement(ElementName = "ALLINVENTORYENTRIES.LIST", Type = typeof(AllInventoryAllocations))]
    [XmlElement(ElementName = "INVENTORYENTRIES.LIST", Type = typeof(InventoryEntries))]
    public List<AllInventoryAllocations>? InventoryAllocations { get; set; }

    [XmlElement(ElementName = "INVENTORYENTRIESOUT.LIST")]
    public List<InventoryoutAllocations>? InventoriesOut { get; set; }

    [XmlElement(ElementName = "INVENTORYENTRIESIN.LIST")]
    public List<InventoryinAllocations>? InventoriesIn { get; set; }

    [XmlElement(ElementName = "CATEGORYENTRY.LIST")]
    public CategoryEntry? CategoryEntry { get; set; }

    [XmlElement(ElementName = "ATTENDANCEENTRIES.LIST")]
    public List<AttendanceEntry>? AttendanceEntries { get; set; }

     
    [XmlAttribute(AttributeName = "DATE")]
    [NotMapped]
    public string? Dt
    {
        get
        {
            if (Date != null)
            {
                return ((DateTime)Date!).ToString("yyyMMdd");
            }
            else
            {
                return null;
            }
        }
        set => Date = value ?? string.Empty;
    }

     
    [NotMapped]
    [XmlAttribute(AttributeName = "VCHTYPE")]
    public string? VchType
    {
        get { return VoucherType; }
        set { VoucherType = value; }
    }

     
    [NotMapped]
    [XmlAttribute(AttributeName = "MASTERID")]
    public string? _MasterId
    {
        get { return MasterId.ToString(); }
        set { }
    }

    public void OrderLedgers()
    {
        //if (VchType != "Contra" && VchType != "Purchase" && VchType != "Receipt" && VchType != "Credit Note")
        //{
        //    Ledgers?.Sort((x, y) => y.LedgerName!.CompareTo(x.LedgerName));//First Sort Ledger list Using Ledger Names
        //    Ledgers?.Sort((x, y) => y.Amount!.Amount!.CompareTo(x.Amount!.Amount)); //Next sort Ledger List Using Ledger Amounts
        //    Ledgers?.Sort((x, y) => y.Amount!.IsDebit.CompareTo(x.Amount!.IsDebit));
        //}
        //else
        //{
        //    Ledgers?.Sort((x, y) => x.LedgerName!.CompareTo(y.LedgerName));//First Sort Ledger list Using Ledger Names
        //    Ledgers?.Sort((x, y) => x.Amount!.Amount.CompareTo(y.Amount!.Amount)); //Next sort Ledger List Using Ledger Amounts
        //    Ledgers?.Sort((x, y) => x.Amount!.IsDebit.CompareTo(y.Amount!.IsDebit));
        //}
    }

    public new string GetJson(bool Indented = false)
    {
        OrderLedgers();

        return base.GetJson(Indented);
    }

    public new string GetXML(XmlAttributeOverrides? attrOverrides = null)
    {
        OrderLedgers();
        GetJulianday();
        return base.GetXML(attrOverrides);
    }

    public void GetJulianday()
    {
        Ledgers?.ForEach(ledg =>
        {
            ledg.BillAllocations?.ForEach(billalloc =>
            {
                if (billalloc.BillCreditPeriod != null)
                {
                    EffectiveDate ??= Date;
                    DateTime dateTime = (DateTime)EffectiveDate!;
                    double days = dateTime.Subtract(new DateTime(1900, 1, 1)).TotalDays + 1;
                    // billalloc.BillCP.JD = days.ToString();
                }
            });
        });
    }

    public enum BillLookupField
    {
        MasterId = 1,
        AlterId = 2,
        VoucherNumber = 3,
        GUID = 4,
    }

    public new void PrepareForExport()
    {
        OrderLedgers(); //Ensures ledgers are ordered in correct way
        GetJulianday();
        //InventoryAllocations?.ForEach(c => c.BatchAllocations?.ForEach(btch => btch.OrderDueDate = Date));
    }

    /// <inheritdoc/>
    public override void RemoveNullChilds()
    {
        EWayBillDetails = EWayBillDetails
            ?.Where(Ewaybilldetail => !Ewaybilldetail.IsNull())
            ?.ToList();
        if (EWayBillDetails?.Count == 0)
        {
            EWayBillDetails = null;
        }
        AttendanceEntries = AttendanceEntries?.Where(attndentry => !attndentry.IsNull())?.ToList();
        if (AttendanceEntries != null && AttendanceEntries.Count == 0)
        {
            AttendanceEntries = null;
        }
        Ledgers = Ledgers?.Where(ledg => !ledg.IsNull())?.ToList();
        if (Ledgers != null && Ledgers.Count == 0)
        {
            Ledgers = null;
        }
    }

    public override string ToString()
    {
        return $"{VoucherType} - {VoucherNumber}";
    }
}
