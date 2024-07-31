using System.Text.Json.Serialization;

namespace MoneyManager.Models;

public class Account
{
    public int accountId { get; set; }
    public string accountType { get; set; }
    public string accountName { get; set; }
    public string bankName { get; set; }
    public decimal balance { get; set; }
    public string? remark { get; set; }

}



[JsonSerializable(typeof(List<Account>))]
internal sealed partial class AccountContext : JsonSerializerContext
{

}
