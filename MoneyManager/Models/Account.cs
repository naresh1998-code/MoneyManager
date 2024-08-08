using System.Text.Json.Serialization;

namespace MoneyManager.Models;

public class Account
{
    public int accountId { get; set; }
    public string accountType { get; set; } = null!;
    public string accountName { get; set; } = null!;
    public string bankName { get; set; } = null!;
    public decimal balance { get; set; }
    public string? remark { get; set; }

}



[JsonSerializable(typeof(List<Account>))]
internal sealed partial class AccountContext : JsonSerializerContext
{

}
