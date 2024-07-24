using System.Text.Json.Serialization;

namespace MoneyManager.Models;

public class AccountType
{
    public int id { get; set; }
    public string accountTypes { get; set; }

}

[JsonSerializable(typeof(List<AccountType>))]
internal sealed partial class AccountTypeContext : JsonSerializerContext
{

}
