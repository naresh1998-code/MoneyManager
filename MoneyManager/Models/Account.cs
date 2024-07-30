using System.Text.Json.Serialization;

namespace MoneyManager.Models;

public class Account
{
    public int Account_id { get; set; }
    public string AccountName { get; set; }
    public string AccountNumber { get; set; }
    public string BankName { get; set; }
    public string Type { get; set; }
    public string? Remark { get; set; }

}

[JsonSerializable(typeof(List<Account>))]
internal sealed partial class AccountContext : JsonSerializerContext
{

}
