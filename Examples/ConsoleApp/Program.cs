using TallyConnector.Services;
using TallyConnector.Core.Models;
using TallyConnector.Core.Models.Masters;
using ConsoleApp;

var http = new HttpClient(new LoggingHandler(new HttpClientHandler()));
var tally = new TallyService(http);

// var options = new MasterRequestOptions();
// req.LookupField = VoucherLookupField.MasterId;
// req.FetchList = Constants.Voucher.InvoiceViewFetchList.All;
// var voucher = await tally.GetVoucherAsync("3", req);
// options.FetchList = new List<string> { "All" };


// var reqOptions = 
// var ledger = await tally.GetLedgerAsync("TechGearSolutions");
// Console.WriteLine(ledger?.LedgerGSTRegistrationDetails?[0].GSTIN);




var ledger = new Ledger()
{
    OldName = "TallAi - Purchase Account",
    Name = "TallAi - Purchase Account",
    Group = "Sundry Creditors - Purchases",
    LedgerGSTRegistrationDetails = [
        new() {
            GSTIN = "27AACTT0001H1Z5",
            State = "Maharashtra",
            GSTRegistrationType = GSTRegistrationType.Regular,
            ApplicableFrom = DateTime.Now,
        }
    ],
    LedgerMailingDetails = [
        new() {
            Address = "Mumbaii",
            MailingName = "TallAi - Purchase Account",
            State = "Maharashtra",
            Country = "India",
            PinCode = "400001",
            ApplicableFrom = DateTime.Now,
        }
    ],
};
// // ledger.OldName = "TallAi - Purchase Account";
// // ledger.Name = "TallAi - Purchase Account";
// // ledger.Group = "Sundry Creditors - Purchases";
// // ledger.LedgerGSTRegistrationDetails = new List<LedgerGSTRegistrationDetails> {
// //     new LedgerGSTRegistrationDetails {
// //         GSTIN = "27AACTT0001H1Z5",
// //         State = "Maharashtra",
// //         GSTRegistrationType = GSTRegistrationType.Regular,
// //     }
// // };

// // ledger.Ad
// // ledger.GSTRegistrationType = GSTRegistrationType.Regular;
// // ledger.GSTIN = "27AACTT0001H1Z5";
// // ledger.State = "Maharashtra";
// // ledger.Address = "Mumbaii";
// // ledger.MailingName = ledger.Name;
// // ledger.Country = "India";
// // ledger.PinCode = "400001";
// var req = new MasterRequestOptions();

var resp = await tally.PostLedgerAsync(ledger);
Console.WriteLine(resp);
