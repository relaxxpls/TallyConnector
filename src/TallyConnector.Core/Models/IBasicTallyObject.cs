namespace TallyConnector.Core.Models;

public interface IBasicTallyObject
{
    string? GUID { get; set; }
    ulong? MasterId { get; set; }
}
