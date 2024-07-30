
using System.Text.Json.Serialization;

namespace MoneyManager.Models;

public class AccountUpdate
{
    public int accountId { get; set; }
    public string accountType { get; set; }
    public string accountName { get; set; }
    public string bankName { get; set; }
    public int balance { get; set; }
    public string remark { get; set; }
}

[JsonSerializable(typeof(AccountUpdate))]
internal sealed partial class AccountUpdateContext : JsonSerializerContext
{

}
