using TallyConnector.Services;
using TallyConnector.Core.Models;
using TallyConnector.Core.Models.Masters;
using TallyConnector.Core.Models.Masters.Inventory;
using ConsoleApp;

var http = new HttpClient(new LoggingHandler(new HttpClientHandler()));
var tally = new TallyService(http);

// ? Create Ledger
// var ledger = new Ledger()
// {
//     OldName = "TallAi - Purchase Account",
//     Name = "TallAi - Purchase Account",
//     Group = "Sundry Creditors - Purchases",
//     LedgerGSTRegistrationDetails = [
//         new() {
//             GSTIN = "27AACTT0001H1Z5",
//             State = "Maharashtra",
//             GSTRegistrationType = GSTRegistrationType.Regular,
//             ApplicableFrom = DateTime.Now,
//         }
//     ],
//     LedgerMailingDetails = [
//         new() {
//             Address = "Mumbaii",
//             MailingName = "TallAi - Purchase Account",
//             State = "Maharashtra",
//             Country = "India",
//             PinCode = "400001",
//             ApplicableFrom = DateTime.Now,
//         }
//     ],
// };
// await tally.PostLedgerAsync(ledger);

// ? Create IGST Ledger
// var ledger = new Ledger()
// {
//     OldName = "IGST",
//     Name = "IGST",
//     Group = "Duties & Taxes",
//     TaxType = TaxType.GST,
//     GSTTaxType = "IGST",
// };
// await tally.PostLedgerAsync(ledger);

// ? Create StockItem
// var stockItem = new StockItem()
// {
//     OldName = "TallAi - Stock Item",
//     Name = "TallAi - Stock Item",
//     BaseUnit = "Nos",
//     GSTApplicable = "\u0004 Applicable",
//     GSTTypeOfSupply = "Goods",
//     HSNDetails = [
//         new() {
//             HSNCode = "123456",
//             ApplicableFrom = DateTime.Now,
//             SourceOfHSNDetails = "Specify Details Here",
//             HSNDescription = "Description",
//         }
//     ],
//     GSTDetails = [
//         new() {
//             SourceOfGSTDetails = "Specify Details Here",
//             Taxability = GSTTaxabilityType.Taxable,
//             StateWiseDetails = [
//                 new() {
//                     StateName = "\u0004 Any",
//                     GSTRateDetails = [
//                         // new() {
//                         //     DutyHead = "CGST",
//                         //     ValuationType = "Based on Value",
//                         //     GSTRate = 9,
//                         // },
//                         // new() {
//                         //     DutyHead = "SGST/UTGST",
//                         //     ValuationType = "Based on Value",
//                         //     GSTRate = 9,
//                         // },
//                         new() {
//                             DutyHead = "IGST",
//                             ValuationType = "Based on Value",
//                             GSTRate = 18,
//                         },
//                     ],
//                 },
//             ],
//             ApplicableFrom = DateTime.Now,
//         }
//     ],
// };
// await tally.PostStockItemAsync(stockItem);

// ? Create Voucher
var voucher = new Voucher()
{
    VoucherType = "Purchase",
    Reference = "LGF/24/01370",
    Date = DateTime.Now,
    ReferenceDate = "26-04-2024",
    Narration = "Purchase of furniture items from LOOKING GOOD FURNITURE LLP",
    PlaceOfSupply = "Karnataka",
    RegistrationType = "Regular",
    Country = "India",
    State = "Karnataka",
    Ledgers = [
        new EVoucherLedger() {
            LedgerName = "LOOKING GOOD FURNITURE LLP",
            Amount = 10790.01m,
        },
        // new() {
        //     LedgerName = "IGST",
        //     Amount = -28800,
        // },
        new EVoucherLedger() {
            LedgerName = "CGST",
            Amount = -822.97m,
        },
        new EVoucherLedger() {
            LedgerName = "SGST",
            Amount = -822.97m,
        },
    ],
    InventoryAllocations = [
        new() {
            StockItemName = "Center Table A107",
            ActualQuantity = 1,
            BilledQuantity = 1,
            Rate = 9144.07m,
            Amount = -9144.07m,
            IndexNumber = 0,
            Ledgers = [
                new() {
                    LedgerName = "TallAi - Purchase Account",
                    Amount = -9144.07m,
                },
            ],
        },
    ],
};

// ? Create Voucher
// var voucher = new Voucher()
// {
//     VoucherType = "Journal",
//     Date = DateTime.Now,
//     Narration = "Accounting Invoice for April 2024 along courier charges for the documents",
//     View = VoucherViewType.AccountingVoucherView,
//     Ledgers = [
//         new() {
//             LedgerName = "Accounting and Auditing Expenses",
//             Amount = -10000,
//         },
//         new() {
//             LedgerName = "Input CGST Account",
//             Amount = -900,
//         },
//         new() {
//             LedgerName = "Input SGST Account",
//             Amount = -900,
//         },
//         new() {
//             LedgerName = "Courier Charges",
//             Amount = -800,
//         },
//         new() {
//             LedgerName = "SG & Associates",
//             Amount = 12600,
//         },
//     ],
// };

await tally.PostVoucherAsync(voucher);
