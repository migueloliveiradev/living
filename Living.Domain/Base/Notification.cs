namespace Living.Domain.Base;
public class Notification(string key, string code)
{
    public string Key { get; set; } = key;
    public string Code { get; set; } = code;

    public override string ToString()
    {
        return $"{Key}: {Code}";
    }
}
