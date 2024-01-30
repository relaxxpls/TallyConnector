namespace TallyConnector.Core.Models;

[Serializable]
[XmlRoot(ElementName = "VOUCHER", Namespace = "")]
[TallyObjectType(TallyObjectType.Vouchers)]
public class Voucher : BasicTallyObject, ITallyObject
{
    public Voucher ()
    {
        _DeliveryNotes = new();
    }

    [XmlElement(ElementName = "DATE")]
    [JsonPropertyName("date")]
    public TallyDate Date
    {
        get; set;
    }

    [XmlElement(ElementName = "REFERENCEDATE")]
    [JsonPropertyName("reference_date")]
    public TallyDate? ReferenceDate
    {
        get; set;
    }

    [XmlElement(ElementName = "REFERENCE")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("reference")]
    public string? Reference
    {
        get; set;
    }

    [XmlElement(ElementName = "VOUCHERTYPENAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("voucher_type")]
    public string VoucherType
    {
        get; set;
    }

    [XmlElement(ElementName = "VOUCHERTYPEID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("voucher_type_id")]
    public string? VoucherTypeId
    {
        get; set;
    }

    [XmlElement(ElementName = "PERSISTEDVIEW")]
    [Column(TypeName = $"nvarchar(30)")]
    [JsonPropertyName("view")]
    public VoucherViewType View
    {
        get; set;
    }

    [XmlElement(ElementName = "VCHGSTCLASS")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("voucher_gstclass")]
    public string? VoucherGSTClass
    {
        get; set;
    }

    [XmlElement(ElementName = "ISCOSTCENTRE")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("is_cost_centre")]
    public TallyYesNo? IsCostCentre
    {
        get; set;
    }

    [XmlElement(ElementName = "COSTCENTRENAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("cost_centre_name")]
    public string? CostCentreName
    {
        get; set;
    }

    [XmlElement(ElementName = "VCHENTRYMODE")]
    [Column(TypeName = $"nvarchar(30)")]
    [JsonPropertyName("voucher_entry_mode")]
    public string? VoucherEntryMode
    {
        get; set;
    }

    [XmlElement(ElementName = "ISINVOICE")]
    [JsonPropertyName("is_invoice")]
    public TallyYesNo IsInvoice
    {
        get; set;
    }

    [XmlElement(ElementName = "VOUCHERNUMBER")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("voucher_number")]
    public string? VoucherNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "ISOPTIONAL")]
    [Column(TypeName = "nvarchar(3)")]
    [JsonPropertyName("is_optional")]
    public TallyYesNo? IsOptional
    {
        get; set;
    }

    [XmlElement(ElementName = "EFFECTIVEDATE")]
    [JsonPropertyName("effective_date")]
    public TallyDate? EffectiveDate
    {
        get; set;
    }

    [XmlElement(ElementName = "NARRATION")]
    [Column(TypeName = $"nvarchar({Constants.MaxNarrLength})")]
    [JsonPropertyName("narration")]
    public string? Narration
    {
        get; set;
    }

    [XmlElement(ElementName = "PRICELEVEL")]
    [Column(TypeName = $"nvarchar({Constants.MaxNarrLength})")]
    [JsonPropertyName("price_level")]
    public string? PriceLevel
    {
        get; set;
    }

    //E-Invoice Details
    [TallyCategory(Constants.Voucher.Category.EInvoiceDetails)]
    [XmlElement(ElementName = "BILLTOPLACE")]
    [Column(TypeName = $"nvarchar({Constants.MaxNarrLength})")]
    [JsonPropertyName("bill_to_place")]
    public string? BillToPlace
    {
        get; set;
    }

    [TallyCategory(Constants.Voucher.Category.EInvoiceDetails)]
    [XmlElement(ElementName = "IRN")]
    [JsonPropertyName("irn")]
    public string? IRN
    {
        get; set;
    }

    [TallyCategory(Constants.Voucher.Category.EInvoiceDetails)]
    [XmlElement(ElementName = "IRNACKNO")]
    [JsonPropertyName("irnack_no")]
    public string? IRNAckNo
    {
        get; set;
    }

    [TallyCategory(Constants.Voucher.Category.EInvoiceDetails)]
    [XmlElement(ElementName = "IRNACKDATE")]
    [JsonPropertyName("irnack_date")]
    public string? IRNAckDate
    {
        get; set;
    }

    //Dispatch Details
    [TallyCategory("DispatchDetails")]
    [XmlIgnore]
    [JsonPropertyName("delivery_note_no")]
    public string? DeliveryNoteNo
    {
        get; set;
    }

    [TallyCategory("DispatchDetails")]
    [XmlIgnore]
    [JsonPropertyName("shipping_date")]
    public TallyDate? ShippingDate
    {
        get; set;
    }

    [JsonPropertyName("_delivery_notes")]
    private DeliveryNotes _DeliveryNotes;

    [TallyCategory("DispatchDetails")]
    [XmlElement(ElementName = "DISPATCHFROMNAME")]
    [JsonPropertyName("dispatch_from_name")]
    public string? DispatchFromName
    {
        get; set;
    }

    [TallyCategory("DispatchDetails")]
    [XmlElement(ElementName = "DISPATCHFROMSTATENAME")]
    [JsonPropertyName("dispatch_from_state_name")]
    public string? DispatchFromStateName
    {
        get; set;
    }

    [TallyCategory("DispatchDetails")]
    [XmlElement(ElementName = "DISPATCHFROMPINCODE")]
    [JsonPropertyName("dispatch_from_pin_code")]
    public string? DispatchFromPinCode
    {
        get; set;
    }

    [TallyCategory("DispatchDetails")]
    [XmlElement(ElementName = "DISPATCHFROMPLACE")]
    [JsonPropertyName("dispatch_from_place")]
    public string? DispatchFromPlace
    {
        get; set;
    }

    //Shipping Details
    [TallyCategory("ShippingDetails")]

    [XmlElement(ElementName = "BASICSHIPDELIVERYNOTE")]
    [JsonPropertyName("delivery_notes")]
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
    [JsonPropertyName("dispatch_doc_no")]
    public string? DispatchDocNo
    {
        get; set;
    }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "BASICSHIPPEDBY")]
    [JsonPropertyName("basic_shipped_by")]
    public string? BasicShippedBy
    {
        get; set;
    }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "BASICFINALDESTINATION")]
    [JsonPropertyName("destination")]
    public string? Destination
    {
        get; set;
    }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "EICHECKPOST")]
    [JsonPropertyName("carrier_name")]
    public string? CarrierName
    {
        get; set;
    }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "BILLOFLADINGNO")]
    [JsonPropertyName("billof_landing_no")]
    public string? BillofLandingNo
    {
        get; set;
    }

    [TallyCategory("ShippingDetails")]
    [XmlElement(ElementName = "BILLOFLADINGDATE")]
    [JsonPropertyName("billof_landing_date")]
    public string? BillofLandingDate
    {
        get; set;
    }

    //Export Shipping Details
    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICPLACEOFRECEIPT")]
    [JsonPropertyName("place_of_receipt")]
    public string? PlaceOfReceipt
    {
        get; set;
    }

    /// <summary>
    /// Vehicle or Ship or Flight Number
    /// </summary>
    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICSHIPVESSELNO")]
    [JsonPropertyName("ship_or_flight_no")]
    public string? ShipOrFlightNo
    {
        get; set;
    }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICPORTOFLOADING")]
    [JsonPropertyName("landing_port")]
    public string? LandingPort
    {
        get; set;
    }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICPORTOFDISCHARGE")]
    [JsonPropertyName("discharge_port")]
    public string? DischargePort
    {
        get; set;
    }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "BASICDESTINATIONCOUNTRY")]
    [JsonPropertyName("desktination_country")]
    public string? DesktinationCountry
    {
        get; set;
    }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "SHIPPINGBILLNO")]
    [JsonPropertyName("shipping_bill_no")]
    public string? ShippingBillNo
    {
        get; set;
    }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "SHIPPINGBILLDATE")]
    [JsonPropertyName("shipping_bill_date")]
    public string? ShippingBillDate
    {
        get; set;
    }

    [TallyCategory("ExportShippingDetails")]
    [XmlElement(ElementName = "PORTCODE")]
    [JsonPropertyName("port_code")]
    public string? PortCode
    {
        get; set;
    }

    //OrderDetails
    [TallyCategory("OrderDetails")]
    [XmlElement(ElementName = "BASICDUEDATEOFPYMT")]
    [JsonPropertyName("basic_due_dateof_payment")]
    public string? BasicDueDateofPayment
    {
        get; set;
    }

    [TallyCategory("OrderDetails")]
    [XmlElement(ElementName = "BASICORDERREF")]
    [JsonPropertyName("order_reference")]
    public string? OrderReference
    {
        get; set;
    }

    //Party Details
    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PARTYNAME")]
    [JsonPropertyName("party_name")]
    public string? PartyName
    {
        get; set;
    }

    [XmlElement(ElementName = "PARTYLEDGERID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("party_ledger_id")]
    public string? PartyLedgerId
    {
        get; set;
    }

    [XmlElement(ElementName = "GSTREGISTRATION")]
    [JsonPropertyName("gstregistration")]
    public GSTRegistration? GSTRegistration
    {
        get; set;
    }

    [XmlElement(ElementName = "VOUCHERNUMBERSERIES")]
    [JsonPropertyName("voucher_number_series")]
    public string? VoucherNumberSeries
    {
        get; set;
    }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PARTYMAILINGNAME")]
    [JsonPropertyName("party_mailing_name")]
    public string? PartyMailingName
    {
        get; set;
    }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "STATENAME")]
    [JsonPropertyName("state")]
    public string? State
    {
        get; set;
    }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "COUNTRYOFRESIDENCE")]
    [JsonPropertyName("country")]
    public string? Country
    {
        get; set;
    }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "GSTREGISTRATIONTYPE")]
    [JsonPropertyName("registration_type")]
    public string? RegistrationType
    {
        get; set;
    }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PARTYGSTIN")]
    [JsonPropertyName("party_gstin")]
    public string? PartyGSTIN
    {
        get; set;
    }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PLACEOFSUPPLY")]
    [JsonPropertyName("place_of_supply")]
    public string? PlaceOfSupply
    {
        get; set;
    }

    [TallyCategory("PartyDetails")]
    [XmlElement(ElementName = "PARTYPINCODE")]
    [JsonPropertyName("pincode")]
    public string? PINCode
    {
        get; set;
    }

    //Consignee Details
    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "BASICBUYERNAME")]
    [JsonPropertyName("consignee_name")]
    public string? ConsigneeName
    {
        get; set;
    }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEEMAILINGNAME")]
    [JsonPropertyName("consignee_mailing_name")]
    public string? ConsigneeMailingName
    {
        get; set;
    }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEESTATENAME")]
    [JsonPropertyName("consignee_state")]
    public string? ConsigneeState
    {
        get; set;
    }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEECOUNTRYNAME")]
    [JsonPropertyName("consignee_country")]
    public string? ConsigneeCountry
    {
        get; set;
    }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEEGSTIN")]
    [JsonPropertyName("consignee_gstin")]
    public string? ConsigneeGSTIN
    {
        get; set;
    }

    [TallyCategory("ConsigneeDetails")]
    [XmlElement(ElementName = "CONSIGNEEPINCODE")]
    [JsonPropertyName("consignee_pin_code")]
    public string? ConsigneePinCode
    {
        get; set;
    }

    [XmlArray(ElementName = "ADDRESS.LIST")]
    [XmlArrayItem(ElementName = "ADDRESS")]
    [JsonPropertyName("address")]
    public List<string>? Address
    {
        get; set;
    }

    [XmlArray(ElementName = "BASICBUYERADDRESS.LIST")]
    [XmlArrayItem(ElementName = "BASICBUYERADDRESS")]
    [JsonPropertyName("buyer_address")]
    public List<string>? BuyerAddress
    {
        get; set;
    }

    [XmlElement(ElementName = "ISCANCELLED")]
    [JsonPropertyName("is_cancelled")]
    public TallyYesNo? IsCancelled
    {
        get; set;
    }

    //EWAY Details
    [XmlElement(ElementName = "OVRDNEWAYBILLAPPLICABILITY")]
    [JsonPropertyName("override_eway_bill_applicability")]
    public TallyYesNo? OverrideEWayBillApplicability
    {
        get; set;
    }

    [XmlElement(ElementName = "EWAYBILLDETAILS.LIST")]
    [JsonPropertyName("eway_bill_details")]
    public List<EwayBillDetail>? EWayBillDetails
    {
        get; set;
    }

    [XmlElement(ElementName = "ALLLEDGERENTRIES.LIST", Type = typeof(VoucherLedger))]
    [XmlElement(ElementName = "LEDGERENTRIES.LIST", Type = typeof(EVoucherLedger))]
    [JsonPropertyName("ledgers")]
    public List<VoucherLedger>? Ledgers
    {
        get; set;
    }

    [XmlElement(ElementName = "ALLINVENTORYENTRIES.LIST", Type = typeof(AllInventoryAllocations))]
    [XmlElement(ElementName = "INVENTORYENTRIES.LIST", Type = typeof(InventoryEntries))]
    [JsonPropertyName("inventory_allocations")]
    public List<AllInventoryAllocations>? InventoryAllocations
    {
        get; set;
    }

    [XmlElement(ElementName = "INVENTORYENTRIESOUT.LIST")]
    [JsonPropertyName("inventories_out")]
    public List<InventoryoutAllocations>? InventoriesOut
    {
        get; set;
    }

    [XmlElement(ElementName = "INVENTORYENTRIESIN.LIST")]
    [JsonPropertyName("inventories_in")]
    public List<InventoryinAllocations>? InventoriesIn
    {
        get; set;
    }

    [XmlElement(ElementName = "CATEGORYENTRY.LIST")]
    [JsonPropertyName("category_entry")]
    public CategoryEntry? CategoryEntry
    {
        get; set;
    }

    [XmlElement(ElementName = "ATTENDANCEENTRIES.LIST")]
    [JsonPropertyName("attendance_entries")]
    public List<AttendanceEntry>? AttendanceEntries
    {
        get; set;
    }


    [XmlAttribute(AttributeName = "DATE")]
    [NotMapped]
    [JsonPropertyName("dt")]
    public string? Dt
    {
        get
        {
            if ( Date != null )
            {
                return ( ( DateTime ) Date! ).ToString("yyyMMdd");
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
    [JsonPropertyName("vch_type")]
    public string? VchType
    {
        get
        {
            return VoucherType;
        }
        set
        {
            VoucherType = value;
        }
    }


    [NotMapped]
    [XmlAttribute(AttributeName = "MASTERID")]
    [JsonPropertyName("_master_id")]
    public string? _MasterId
    {
        get
        {
            return MasterId.ToString();
        }
        set
        {
        }
    }

    public void OrderLedgers ()
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

    public new string GetJson ( bool Indented = false )
    {
        OrderLedgers();

        return base.GetJson(Indented);
    }

    public new string GetXML ( XmlAttributeOverrides? attrOverrides = null )
    {
        OrderLedgers();
        GetJulianday();
        return base.GetXML(attrOverrides);
    }

    public void GetJulianday ()
    {
        Ledgers?.ForEach(ledg =>
        {
            ledg.BillAllocations?.ForEach(billalloc =>
            {
                if ( billalloc.BillCreditPeriod != null )
                {
                    EffectiveDate ??= Date;
                    DateTime dateTime = ( DateTime ) EffectiveDate!;
                    double days = dateTime.Subtract(new DateTime(1900, 1, 1)).TotalDays + 1;
                    // billalloc.BillCP.JD = days.ToString();
                }
            });
        });
    }

    public new void PrepareForExport ()
    {
        OrderLedgers(); //Ensures ledgers are ordered in correct way
        GetJulianday();
        //InventoryAllocations?.ForEach(c => c.BatchAllocations?.ForEach(btch => btch.OrderDueDate = Date));
    }

    /// <inheritdoc/>
    public override void RemoveNullChilds ()
    {
        EWayBillDetails = EWayBillDetails
            ?.Where(Ewaybilldetail => !Ewaybilldetail.IsNull())
            ?.ToList();
        if ( EWayBillDetails?.Count == 0 )
        {
            EWayBillDetails = null;
        }
        AttendanceEntries = AttendanceEntries?.Where(attndentry => !attndentry.IsNull())?.ToList();
        if ( AttendanceEntries != null && AttendanceEntries.Count == 0 )
        {
            AttendanceEntries = null;
        }
        Ledgers = Ledgers?.Where(ledg => !ledg.IsNull())?.ToList();
        if ( Ledgers != null && Ledgers.Count == 0 )
        {
            Ledgers = null;
        }
    }

    public override string ToString ()
    {
        return $"{VoucherType} - {VoucherNumber}";
    }
}

[XmlRoot(ElementName = "LEDGERENTRIES.LIST")]
public class EVoucherLedger : VoucherLedger
{
}

[XmlRoot(ElementName = "ALLLEDGERENTRIES.LIST")]
public class BaseVoucherLedger : TallyBaseObject
{
    public BaseVoucherLedger ()
    {
    }

    [XmlElement(ElementName = "INDEXNUMBER")]
    [JsonPropertyName("index_number")]
    public int IndexNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "LEDGERNAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("ledger_name")]
    public string LedgerName
    {
        get; set;
    }

    [XmlElement(ElementName = "LEDGERID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("ledger_id")]
    public string? LedgerId
    {
        get; set;
    }

    [XmlElement(ElementName = "LEDGERTAXTYPE")]
    [JsonPropertyName("ledger_tax_type")]
    public string? LedgerTaxType
    {
        get; set;
    }

    [XmlElement(ElementName = "VCHLEDGERTYPE")]
    [JsonPropertyName("ledger_type")]
    public string? LedgerType
    {
        get; set;
    }

    [XmlElement(ElementName = "ISDEEMEDPOSITIVE")]

    [JsonPropertyName("is_deemed_positive")]
    public TallyYesNo? IsDeemedPositive
    {
        get
        {
            if ( Amount != null )
            {
                return Amount.IsDebit;
            }
            return null;
        }
        set
        {
        }
    }

    [XmlElement(ElementName = "AMOUNT")]
    [JsonPropertyName("amount")]
    public TallyAmount? Amount
    {
        get; set;
    }

    [XmlElement(ElementName = "CATEGORYALLOCATIONS.LIST")]
    [JsonPropertyName("cost_category_allocations")]
    public List<CostCategoryAllocations>? CostCategoryAllocations
    {
        get; set;
    }
}

[XmlRoot(ElementName = "ALLLEDGERENTRIES.LIST")]
public class VoucherLedger : BaseVoucherLedger
{
    public VoucherLedger ( string name, TallyAmount amount )
    {
        LedgerName = name;
        Amount = amount;
    }

    public VoucherLedger ()
    {
    }

    [XmlElement(ElementName = "ADDLALLOCTYPE")]
    [JsonPropertyName("ad_alloc_type")]
    public AdAllocType AdAllocType
    {
        get; set;
    }

    [XmlElement(ElementName = "ISPARTYLEDGER")]
    [JsonPropertyName("is_party_ledger")]
    public TallyYesNo IsPartyLedger
    {
        get; set;
    }

    [XmlElement(ElementName = "SWIFTCODE")]
    [JsonPropertyName("swiftcode")]
    public string? SWIFTCode
    {
        get; set;
    }

    [XmlElement(ElementName = "BANKALLOCATIONS.LIST")]
    [JsonPropertyName("bank_allocations")]
    public List<BankAllocation>? BankAllocations
    {
        get; set;
    }

    [XmlElement(ElementName = "BILLALLOCATIONS.LIST")]
    [JsonPropertyName("bill_allocations")]
    public List<BillAllocations>? BillAllocations
    {
        get; set;
    }

    [XmlElement(ElementName = "INVENTORYALLOCATIONS.LIST")]
    [JsonPropertyName("inventory_allocations")]
    public List<InventoryAllocations>? InventoryAllocations
    {
        get; set;
    }

    public bool IsNull ()
    {
        if ( string.IsNullOrEmpty(LedgerName) )
        {
            return true;
        }
        BankAllocations = BankAllocations?.Where(bankalloc => !bankalloc.IsNull())?.ToList();
        if ( BankAllocations != null && BankAllocations.Count == 0 )
        {
            BankAllocations = null;
        }
        return false;
    }
}

[XmlRoot(ElementName = "BILLALLOCATIONS.LIST")]
public class BillAllocations : TallyBaseObject
{
    public BillAllocations ()
    {
    }

    [XmlElement(ElementName = "BILLTYPE")]
    [JsonPropertyName("bill_type")]
    public BillRefType? BillType
    {
        get; set;
    }

    [XmlElement(ElementName = "NAME")]
    [JsonPropertyName("name")]
    public string? Name
    {
        get; set;
    }

    [XmlElement(ElementName = "BILLID")]
    [JsonPropertyName("bill_id")]
    public int BillId
    {
        get; set;
    }

    [XmlElement(ElementName = "LEDGERID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("ledger_id")]
    public string? LedgerId
    {
        get; set;
    }

    [XmlElement(ElementName = "BILLCREDITPERIOD")]
    [JsonPropertyName("bill_credit_period")]
    public TallyDueDate? BillCreditPeriod
    {
        get; set;
    }

    [XmlElement(ElementName = "AMOUNT")]
    [JsonPropertyName("amount")]
    public TallyAmount? Amount
    {
        get; set;
    }
}

[XmlRoot(ElementName = "INVENTORYENTRIESIN.LIST")]
public class InventoryinAllocations : InventoryAllocations
{
}

[XmlRoot(ElementName = "INVENTORYENTRIESOUT.LIST")]
public class InventoryoutAllocations : InventoryAllocations
{
}

[XmlRoot(ElementName = "ALLINVENTORYENTRIES.LIST")]
public class AllInventoryAllocations : InventoryAllocations
{
    [XmlElement(ElementName = "ACCOUNTINGALLOCATIONS.LIST")]
    [JsonPropertyName("ledgers")]
    public List<BaseVoucherLedger>? Ledgers
    {
        get; set;
    }
}

[XmlRoot(ElementName = "INVENTORYENTRIES.LIST")]
public class InventoryEntries : AllInventoryAllocations
{
}

[XmlRoot(ElementName = "INVENTORYALLOCATIONS.LIST")]
public class InventoryAllocations : TallyBaseObject
{
    public InventoryAllocations ()
    {
    }

    [XmlArray("BASICUSERDESCRIPTION.LIST")]
    [XmlArrayItem(ElementName = "BASICUSERDESCRIPTION")]
    [JsonPropertyName("user_descriptions")]
    public List<string> UserDescriptions
    {
        get; set;
    }

    [XmlElement(ElementName = "INDEXNUMBER")]
    [JsonPropertyName("index_number")]
    public int IndexNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "STOCKITEMNAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("stock_item_name")]
    public string? StockItemName
    {
        get; set;
    }

    [XmlElement(ElementName = "STOCKITEMID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("stock_item_id")]
    public string? StockItemId
    {
        get; set;
    }

    [XmlElement(ElementName = "BOMNAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("bomname")]
    public string? BOMName
    {
        get; set;
    }

    [XmlElement(ElementName = "ISSCRAP")]
    [JsonPropertyName("is_scrap")]
    public TallyYesNo? IsScrap
    {
        get; set;
    }

    [XmlElement(ElementName = "ISDEEMEDPOSITIVE")]

    [JsonPropertyName("is_deemed_positive")]
    public TallyYesNo? IsDeemedPositive
    {
        get
        {
            if ( Amount != null )
            {
                return Amount.IsDebit;
            }
            return null;
        }
        set
        {
        }
    }

    [XmlElement(ElementName = "RATE")]
    [JsonPropertyName("rate")]
    public TallyRate? Rate
    {
        get; set;
    }

    [XmlElement(ElementName = "ACTUALQTY")]
    [JsonPropertyName("actual_quantity")]
    public TallyQuantity? ActualQuantity
    {
        get; set;
    }

    [XmlElement(ElementName = "BILLEDQTY")]
    [JsonPropertyName("billed_quantity")]
    public TallyQuantity? BilledQuantity
    {
        get; set;
    }

    [XmlElement(ElementName = "AMOUNT")]
    [JsonPropertyName("amount")]
    public TallyAmount? Amount
    {
        get; set;
    }

    [XmlElement(ElementName = "BATCHALLOCATIONS.LIST")]
    [JsonPropertyName("batch_allocations")]
    public List<BatchAllocations>? BatchAllocations
    {
        get; set;
    }

    [XmlElement(ElementName = "CATEGORYALLOCATIONS.LIST")]
    [JsonPropertyName("cost_category_allocations")]
    public List<CostCategoryAllocations>? CostCategoryAllocations
    {
        get; set;
    }
}

[XmlRoot(ElementName = "BATCHALLOCATIONS.LIST")]
public class BatchAllocations : TallyBaseObject //Godown Allocations
{
    [XmlElement(ElementName = "MFDON")]
    [JsonPropertyName("manufactured_on")]
    public TallyDate? ManufacturedOn
    {
        get; set;
    }

    [XmlElement(ElementName = "TRACKINGNUMBER")]
    [JsonPropertyName("tracking_no")]
    public string? TrackingNo
    {
        get; set;
    }

    [XmlElement(ElementName = "ORDERNO")]
    [JsonPropertyName("order_no")]
    public string? OrderNo
    {
        get; set;
    }

    [XmlElement(ElementName = "GODOWNNAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("godown_name")]
    public string? GodownName
    {
        get; set;
    }

    [XmlElement(ElementName = "GODOWNID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("godown_id")]
    public string? GodownId
    {
        get; set;
    }

    [XmlElement(ElementName = "BATCHNAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("batch_name")]
    public string? BatchName
    {
        get; set;
    }

    [XmlElement(ElementName = "ORDERDUEDATE")]
    [JsonPropertyName("order_due_date")]
    public TallyDueDate? OrderDueDate
    {
        get; set;
    }

    [XmlElement(ElementName = "EXPIRYPERIOD")]
    [JsonPropertyName("expiry_period")]
    public TallyDueDate? ExpiryPeriod
    {
        get; set;
    }

    [XmlElement(ElementName = "AMOUNT")]
    [JsonPropertyName("amount")]
    public TallyAmount? Amount
    {
        get; set;
    }

    [XmlElement(ElementName = "ACTUALQTY")]
    [JsonPropertyName("actual_quantity")]
    public TallyQuantity? ActualQuantity
    {
        get; set;
    }

    [XmlElement(ElementName = "BILLEDQTY")]
    [JsonPropertyName("billed_quantity")]
    public TallyQuantity? BilledQuantity
    {
        get; set;
    }
}

[XmlRoot(ElementName = "CATEGORYALLOCATIONS.LIST")]
public class CostCategoryAllocations : TallyBaseObject
{
    public CostCategoryAllocations ()
    {
    }

    public CostCategoryAllocations ( string name, List<CostCenterAllocations> costCenterAllocations )
    {
        CostCategoryName = name;
        CostCenterAllocations = costCenterAllocations;
    }

    [XmlElement(ElementName = "CATEGORY")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("cost_category_name")]
    public string? CostCategoryName
    {
        get; set;
    }

    [XmlElement(ElementName = "COSTCATEGORYID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("cost_category_id")]
    public string? CostCategoryId
    {
        get; set;
    }

    [XmlElement(ElementName = "COSTCENTREALLOCATIONS.LIST")]
    [JsonPropertyName("cost_center_allocations")]
    public List<CostCenterAllocations>? CostCenterAllocations
    {
        get; set;
    }
}

[XmlRoot(ElementName = "COSTCENTREALLOCATIONS.LIST")]
public class CostCenterAllocations : TallyBaseObject
{
    public CostCenterAllocations ()
    {
    }

    public CostCenterAllocations ( string name, TallyAmount amount )
    {
        Name = name;
        Amount = amount;
    }

    [XmlElement(ElementName = "NAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("name")]
    public string? Name
    {
        get; set;
    }

    [XmlElement(ElementName = "COSTCENTREID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("cost_center_id")]
    public string? CostCenterId
    {
        get; set;
    }

    [XmlElement(ElementName = "AMOUNT")]
    [JsonPropertyName("amount")]
    public TallyAmount? Amount
    {
        get; set;
    }
}

[XmlRoot(ElementName = "ATTENDANCEENTRIES.LIST")]
public class AttendanceEntry
{
    [XmlElement(ElementName = "NAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("name")]
    public string? Name
    {
        get; set;
    }

    [XmlElement(ElementName = "EMPLOYEEID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("employee_id")]
    public string? EmployeeId
    {
        get; set;
    }

    [XmlElement(ElementName = "ATTENDANCETYPE")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("attendance_type")]
    public string? AttendanceType
    {
        get; set;
    }

    [XmlElement(ElementName = "ATTENDANCETYPEID")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("attendance_type_id")]
    public string AttendanceTypeId
    {
        get; set;
    }

    [XmlElement(ElementName = "ATTDTYPETIMEVALUE")]
    [Column(TypeName = "decimal(10,4)")]
    [JsonPropertyName("attendance_type_time_value")]
    public decimal? AttendanceTypeTimeValue
    {
        get; set;
    }

    [XmlElement(ElementName = "ATTDTYPEVALUE")]
    [JsonPropertyName("attendance_type_value")]
    public TallyQuantity? AttendanceTypeValue
    {
        get; set;
    }

    public bool IsNull ()
    {
        if (
            string.IsNullOrEmpty(Name)
            && string.IsNullOrEmpty(AttendanceType)
            && AttendanceTypeValue == null
        )
        {
            return true;
        }
        return false;
    }
}

[XmlRoot(ElementName = "INVOICEDELNOTES.LIST")]
public class DeliveryNotes
{
    [XmlElement(ElementName = "BASICSHIPPINGDATE")]
    [JsonPropertyName("shipping_date")]
    public TallyDate? ShippingDate
    {
        get; set;
    }

    [XmlElement(ElementName = "BASICSHIPDELIVERYNOTE")]
    [JsonPropertyName("delivery_note")]
    public string? DeliveryNote
    {
        get; set;
    }
}

[XmlRoot(ElementName = "EWAYBILLDETAILS.LIST")]
public class EwayBillDetail : TallyBaseObject, ICheckNull
{
    [XmlElement(ElementName = "BILLDATE")]
    [JsonPropertyName("bill_date")]
    public TallyDate? BillDate
    {
        get; set;
    }

    [XmlElement(ElementName = "CONSOLIDATEDBILLDATE")]
    [JsonPropertyName("consolidated_bill_date")]
    public TallyDate? ConsolidatedBillDate
    {
        get; set;
    }

    [XmlElement(ElementName = "BILLNUMBER")]
    [JsonPropertyName("bill_number")]
    public string? BillNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "CONSOLIDATEDBILLNUMBER")]
    [JsonPropertyName("consolidated_bill_number")]
    public string? ConsolidatedBillNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "SUBTYPE")]
    [JsonPropertyName("sub_type")]
    public SubSupplyType SubType
    {
        get; set;
    }

    [XmlElement(ElementName = "DOCUMENTTYPE")]
    [JsonPropertyName("document_type")]
    public DocumentType DocumentType
    {
        get; set;
    }

    [XmlElement(ElementName = "CONSIGNORPLACE")]
    [JsonPropertyName("dispatch_from")]
    public string? DispatchFrom
    {
        get; set;
    }

    [XmlElement(ElementName = "CONSIGNEEPLACE")]
    [JsonPropertyName("dispatch_to")]
    public string? DispatchTo
    {
        get; set;
    }

    [XmlElement(ElementName = "ISCANCELLED")]
    [JsonPropertyName("is_cancelled")]
    public string? IsCancelled
    {
        get; set;
    }

    [XmlElement(ElementName = "ISCANCELPENDING")]
    [JsonPropertyName("is_cancelled_pending")]
    public string? IsCancelledPending
    {
        get; set;
    }

    [XmlElement(ElementName = "TRANSPORTDETAILS.LIST")]
    [JsonPropertyName("transporter_details")]
    public List<TransporterDetail>? TransporterDetails
    {
        get; set;
    }

    /// <inheritdoc/>
    public bool IsNull ()
    {
        TransporterDetails = TransporterDetails?.Where(Details => !Details.IsNull())?.ToList();
        if ( TransporterDetails?.Count == 0 )
        {
            TransporterDetails = null;
        }
        if (
            TransporterDetails == null && BillDate is null
            || BillDate == DateTime.MinValue && string.IsNullOrEmpty(BillNumber)
        )
        {
            return true;
        }
        return false;
    }
}

[XmlRoot(ElementName = "TRANSPORTDETAILS.LIST")]
public class TransporterDetail : TallyBaseObject, ICheckNull
{
    [XmlElement(ElementName = "DISTANCE")]
    [JsonPropertyName("distance")]
    public string? Distance
    {
        get; set;
    }

    [XmlElement(ElementName = "TRANSPORTERNAME")]
    [Column(TypeName = $"nvarchar({Constants.MaxNameLength})")]
    [JsonPropertyName("transporter_name")]
    public string? TransporterName
    {
        get; set;
    }

    [XmlElement(ElementName = "TRANSPORTERID")]
    [JsonPropertyName("transporter_id")]
    public string? TransporterId
    {
        get; set;
    }

    [XmlElement(ElementName = "TRANSPORTMODE")]
    [JsonPropertyName("transport_mode")]
    public TransportMode? TransportMode
    {
        get; set;
    }

    /// <summary>
    /// Document/Landing/RR/Airway Number/
    /// </summary>
    [XmlElement(ElementName = "DOCUMENTNUMBER")]
    [JsonPropertyName("document_number")]
    public string? DocumentNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "DOCUMENTDATE")]
    [JsonPropertyName("document_date")]
    public string? DocumentDate
    {
        get; set;
    }

    [XmlElement(ElementName = "VEHICLENUMBER")]
    [JsonPropertyName("vehicle_number")]
    public string? VehicleNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "VEHICLETYPE")]
    [JsonPropertyName("vehicle_type")]
    public VehicleType? VehicleType
    {
        get; set;
    }

    public bool IsNull ()
    {
        if (
            string.IsNullOrEmpty(Distance)
            && string.IsNullOrEmpty(TransporterName)
            && string.IsNullOrEmpty(TransporterId)
            && ( TransportMode is null || TransportMode is Models.TransportMode.None )
            && string.IsNullOrEmpty(DocumentNumber)
            && string.IsNullOrEmpty(VehicleNumber)
            && ( VehicleType is null || VehicleType is Models.VehicleType.None )
        )
        {
            return true;
        }
        return false;
    }
}

[XmlRoot(ElementName = "CATEGORYENTRY.LIST")]
public class CategoryEntry
{
    [XmlElement(ElementName = "CATEGORY")]
    [JsonPropertyName("category")]
    public string Category
    {
        get; set;
    }

    [XmlElement(ElementName = "CATEGORYID")]
    [JsonPropertyName("category_id")]
    public string? CategoryId
    {
        get; set;
    }

    [XmlElement(ElementName = "EMPLOYEEENTRIES.LIST")]
    [JsonPropertyName("employee_entries")]
    public List<EmployeeEntry> EmployeeEntries
    {
        get; set;
    }
}

[XmlRoot(ElementName = "EMPLOYEEENTRIES.LIST")]
public class EmployeeEntry
{
    [XmlElement(ElementName = "EMPLOYEENAME")]
    [JsonPropertyName("employee_name")]
    public string EmployeeName
    {
        get; set;
    }

    [XmlElement(ElementName = "EMPLOYEEID")]
    [JsonPropertyName("employee_id")]
    public string? EmployeeId
    {
        get; set;
    }

    [XmlElement(ElementName = "EMPLOYEESORTORDER")]
    [JsonPropertyName("employee_sort_order")]
    public int EmployeeSortOrder
    {
        get; set;
    }

    [XmlElement(ElementName = "AMOUNT")]
    [JsonPropertyName("amount")]
    public TallyAmount Amount
    {
        get; set;
    }

    [XmlElement(ElementName = "PAYHEADALLOCATIONS.LIST")]
    [JsonPropertyName("pay_head_allocations")]
    public List<PayHeadAllocation> PayHeadAllocations
    {
        get; set;
    }
}

[XmlRoot(ElementName = "PAYHEADALLOCATIONS.LIST")]
public class PayHeadAllocation
{
    [XmlElement(ElementName = "PAYHEADNAME")]
    [JsonPropertyName("pay_head_name")]
    public string PayHeadName
    {
        get; set;
    }

    [XmlElement(ElementName = "LEDGERID")]
    [JsonPropertyName("ledger_id")]
    public string? LedgerId
    {
        get; set;
    }

    [XmlElement(ElementName = "ISDEEMEDPOSITIVE")]

    [JsonPropertyName("is_deemed_positive")]
    public TallyYesNo? IsDeemedPositive
    {
        get
        {
            if ( Amount != null )
            {
                return Amount.IsDebit;
            }
            return null;
        }
        set
        {
        }
    }

    [XmlElement(ElementName = "PAYHEADSORTORDER")]
    [JsonPropertyName("pay_head_sort_order")]
    public int PayHeadSortOrder
    {
        get; set;
    }

    [XmlElement(ElementName = "AMOUNT")]
    [JsonPropertyName("amount")]
    public TallyAmount Amount
    {
        get; set;
    }
}

[XmlRoot(ElementName = "BANKALLOCATIONS.LIST")]
public class BankAllocation
{
    [XmlElement(ElementName = "DATE")]
    [JsonPropertyName("date")]
    public TallyDate Date
    {
        get; set;
    }

    /// <summary>
    /// Use this field for Bank Reconcilliation Date
    /// </summary>
    [XmlElement(ElementName = "BANKERSDATE")]
    [JsonPropertyName("bankers_date")]
    public TallyDate? BankersDate
    {
        get; set;
    }

    [XmlElement(ElementName = "INSTRUMENTDATE")]
    [JsonPropertyName("instrument_date")]
    public TallyDate InstrumentDate
    {
        get; set;
    }

    [XmlElement(ElementName = "INSTRUMENTNUMBER")]
    [JsonPropertyName("instrument_number")]
    public string? InstrumentNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "NAME")]
    [Column(TypeName = $"nvarchar({Constants.GUIDLength})")]
    [JsonPropertyName("name")]
    public string? Name
    {
        get; set;
    }

    [XmlElement(ElementName = "EMAIL")]
    [JsonPropertyName("email")]
    public string? Email
    {
        get; set;
    }

    [XmlElement(ElementName = "TRANSACTIONTYPE")]
    [JsonPropertyName("transaction_type")]
    public BankTransactionType TransactionType
    {
        get; set;
    }

    [XmlElement(ElementName = "BANKNAME")]
    [JsonPropertyName("bank_name")]
    public string? BankName
    {
        get; set;
    }

    [XmlElement(ElementName = "IFSCODE")]
    [JsonPropertyName("ifsccode")]
    public string? IFSCCode
    {
        get; set;
    }

    [XmlElement(ElementName = "ACCOUNTNUMBER")]
    [JsonPropertyName("account_number")]
    public string? AccountNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "BENEFICIARYCODE")]
    [JsonPropertyName("beneficiary_code")]
    public string? BeneficiaryCode
    {
        get; set;
    }

    [XmlElement(ElementName = "NARRATION")]
    [JsonPropertyName("remarks")]
    public string? Remarks
    {
        get; set;
    }

    [XmlElement(ElementName = "TRANSFERMODE")]
    [JsonPropertyName("transfer_mode")]
    public string? TransferMode
    {
        get; set;
    }

    [XmlElement(ElementName = "AMOUNT")]
    [JsonPropertyName("amount")]
    public TallyAmount? Amount
    {
        get; set;
    }

    [XmlElement(ElementName = "PAYMENTFAVOURING")]
    [JsonPropertyName("payment_favouring")]
    public string? PaymentFavouring
    {
        get; set;
    }

    [XmlElement(ElementName = "UNIQUEREFERENCENUMBER")]
    [JsonPropertyName("unique_reference_number")]
    public string? UniqueReferenceNumber
    {
        get; set;
    }

    [XmlElement(ElementName = "BANKPARTYNAME")]
    [JsonPropertyName("bank_party_name")]
    public string? BankPartyName
    {
        get; set;
    }

    internal bool IsNull ()
    {
        if ( Date == null && BankersDate == null && InstrumentDate == null )
        {
            return true;
        }
        return false;
    }
}

public class GSTRegistration
{
    [XmlAttribute(AttributeName = "TAXTYPE")]
    public string TaxType { get; set; } = "GST";

    [XmlAttribute(AttributeName = "TAXREGISTRATION")]
    [JsonPropertyName("tax_registration")]
    public string? TaxRegistration
    {
        get; set;
    }

    [XmlText]
    [JsonPropertyName("registration_name")]
    public string RegistrationName
    {
        get; set;
    }
}

public enum VoucherLookupField
{
    MasterId = 1,
    AlterId = 2,
    VoucherNumber = 3,
    GUID = 4,
}

public enum BillRefType
{
    [XmlEnum(Name = "New Ref")]
    NewRef,

    [XmlEnum(Name = "On Account")]
    OnAccount,

    [XmlEnum(Name = "Agst Ref")]
    AgstRef,

    [XmlEnum(Name = "Advance")]
    Advance
}

/// <summary>
/// <para>Voucher ViewTypes avavailable in Tally</para>
/// <para>TDL Reference -  src\voucher\vchreport.tdl
/// Search using "Set						: SVViewName"</para>
/// </summary>
public enum VoucherViewType
{
    [XmlEnum(Name = "")]
    None = 0,

    [XmlEnum(Name = "Accounting Voucher View")]
    AccountingVoucherView = 1,

    [XmlEnum(Name = "Invoice Voucher View")]
    InvoiceVoucherView = 2,

    [XmlEnum(Name = "PaySlip Voucher View")]
    PaySlipVoucherView = 3,

    [XmlEnum(Name = "Multi Consumption Voucher View")]
    MultiConsumptionVoucherView = 4,

    [XmlEnum(Name = "Consumption Voucher View")]
    ConsumptionVoucherView = 5,
}

/// <summary>
/// <para>e-Waybill SubTypes as per  Tally</para>
/// <para>TDL Reference -  "DEFTDL:src\voucher\vchreport\vchgstewaybillsubforms\vchgstewaybillfunctions.tdl"(496)
/// Search using "subSupplyTypeCode-"</para>
/// </summary>
public enum SubSupplyType
{
    [XmlEnum(Name = "")]
    None = 0,

    [XmlEnum(Name = "Supply")]
    Supply = 1,

    [XmlEnum(Name = "Import")]
    Import = 2,

    [XmlEnum(Name = "Export")]
    Export = 3,

    [XmlEnum(Name = "Job Work")]
    JobWork = 4,

    [XmlEnum(Name = "For Own Use")]
    ForOwnUse = 5,

    [XmlEnum(Name = "Job Work Returns")]
    JobWorkReturns = 6,

    [XmlEnum(Name = "Sales Return")]
    SalesReturn = 7,

    [XmlEnum(Name = "Others")]
    Others = 8,

    [XmlEnum(Name = "SKD/CKD/Lots")]
    SKD_CKD_Lots = 9,

    [XmlEnum(Name = "Lines Sales")]
    LinesSales = 10,

    [XmlEnum(Name = "Recipient Not Known")]
    RecipientNotKnown = 11,

    [XmlEnum(Name = "Exhibition or Fairs")]
    ExhibitionorFairs = 12,
}

/// <summary>
/// <para>e-Waybill DocTypes as per  Tally</para>
/// <para>TDL Reference -  "DEFTDL:src\voucher\vchreport\vchgstewaybillsubforms\vchgstewaybillfunctions.tdl"(496)
/// Search using "docTypeCode-"</para>
/// </summary>
public enum DocumentType
{
    [XmlEnum(Name = "")]
    None = 0,

    [XmlEnum(Name = "Tax Invoice")]
    TaxInvoice = 1,

    [XmlEnum(Name = "Bill of Supply")]
    BillofSupply = 2,

    [XmlEnum(Name = "Bill of Entry")]
    BillofEntry = 3,

    [XmlEnum(Name = "Challan")]
    Challan = 4,

    [XmlEnum(Name = "Delivery Challan")]
    DeliveryChallan = 5,

    [XmlEnum(Name = "Credit Note")]
    CreditNote = 6,

    [XmlEnum(Name = "Others")]
    Others = 7,
}

/// <summary>
/// <para>e-Waybill TransportModes as per  Tally</para>
/// <para>TDL Reference -  "DEFTDL:src\voucher\vchreport\vchgstewaybillsubforms\vchgstewaybillfunctions.tdl"(496)
/// Search using "transModeCode-"</para>
/// </summary>
public enum TransportMode
{
    [XmlEnum(Name = "")]
    None = 0,

    [XmlEnum(Name = "Road")]
    Road = 1,

    [XmlEnum(Name = "1 - Road")]
    Road_InPrime = 1,

    [XmlEnum(Name = "Rail")]
    Rail = 2,

    [XmlEnum(Name = "2 - Rail")]
    Rail_InPrime = 2,

    [XmlEnum(Name = "Air")]
    Air = 3,

    [XmlEnum(Name = "3 - Air")]
    Air_InPrime = 3,

    [XmlEnum(Name = "Ship")]
    Ship = 4,

    [XmlEnum(Name = "4 - Ship")]
    Ship_InPrime = 4,
}

/// <summary>
/// <para>e-Waybill VehicleTypes as per  Tally</para>
///  <para>TDL Reference -  "DEFTDL:src\voucher\vchreport\vchgstewaybillsubforms\vchgstewaybillfunctions.tdl"
///  Search using "Over Dimensional Cargo"</para>
/// </summary>
public enum VehicleType
{
    [XmlEnum(Name = "")]
    None = 0,

    [XmlEnum(Name = "Regular")]
    Regular = 1,

    [XmlEnum(Name = "R - Regular")]
    Regular_InPrime = 1,

    [XmlEnum(Name = "Over Dimensional Cargo")]
    OverDimensionalCargo = 2,

    [XmlEnum(Name = "O - Over Dimensional Cargo")]
    OverDimensionalCargo_InPrime = 2,
}

public enum BankTransactionType
{
    [XmlEnum(Name = "Others")]
    Others = 0,

    [XmlEnum(Name = "ATM")]
    ATM = 1,

    [XmlEnum(Name = "Cash")]
    Cash = 2,

    [XmlEnum(Name = "Cheque")]
    Cheque = 3,

    [XmlEnum(Name = "Card")]
    Card = 4,

    [XmlEnum(Name = "ECS")]
    ECS = 5,

    [XmlEnum(Name = "Electronic Cheque")]
    ElectronicCheque = 6,

    [XmlEnum(Name = "Electronic DD/PO")]
    ElectronicDDPO = 7,

    [XmlEnum(Name = "Inter Bank Transfer")]
    InterBankTransfer = 8,

    [XmlEnum(Name = "Same Bank Transfer")]
    SameBankTransfer = 9,

    [XmlEnum(Name = "Cheque/DD")]
    ChequeDD = 10,
}

