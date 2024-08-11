using System.Runtime.CompilerServices;

namespace Living.Domain.Base;
public class Notification(string key, [CallerMemberName] string code = "")
{
    public string Key { get; set; } = key;
    public string Code { get; set; } = code;

    public override string ToString()
    {
        return $"{Key}: {Code}";
    }
}
