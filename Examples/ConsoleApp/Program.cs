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
// var resp = await tally.PostLedgerAsync(ledger);
// Console.WriteLine(resp);

// // ? Create StockItem
// var stockItem = new StockItem()
// {
//     OldName = "TallAi - Stock Item",
//     Name = "TallAi - Stock Item",
//     BaseUnit = "Nos",
//     GSTApplicable = "Applicable",
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
// var resp = await tally.PostStockItemAsync(stockItem);
// Console.WriteLine(resp);

// ? View Voucher
// var options = new MasterRequestOptions();
// req.LookupField = VoucherLookupField.MasterId;
// req.FetchList = Constants.Voucher.InvoiceViewFetchList.All;
// var voucher = await tally.GetVoucherAsync("3", req);
// options.FetchList = new List<string> { "All" };

// ? Create Voucher
var voucher = new Voucher()
{
    VoucherType = "Purchase",
    Reference = "Ref2as",
    Date = DateTime.Now,
    ReferenceDate = "2021-04-01",
    Narration = "Bought some items",
    PartyLedgerName = "TechGear Solutions",
    Ledgers = [
        new() {
            LedgerName = "TechGear Solutions",
            Amount = 188800,
        },
        new() {
            LedgerName = "CGST",
            Amount = -14400,
        },
        new() {
            LedgerName = "SGST",
            Amount = -14400,
        },
    ],
    InventoryAllocations = [
        new() {
            StockItemName = "Business Laptop Model X",
            ActualQuantity = 2,
            BilledQuantity = 2,
            Rate = 6000,
            Amount = -120000,
            Ledgers = [
                new() {
                    LedgerName = "IT Equipment",
                    Amount = -120000,
                },
            ],
        },
        new() {
            StockItemName = "24-inch LED Monitor",
            ActualQuantity = 4,
            BilledQuantity = 4,
            Rate = 10000,
            Amount = -40000,
            Ledgers = [
                new() {
                    LedgerName = "IT Equipment",
                    Amount = -40000,
                },
            ],
        }
    ],
};

await tally.PostVoucherAsync(voucher);
