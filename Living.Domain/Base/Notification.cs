using Microsoft.AspNetCore.Identity;
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

    public static implicit operator Notification(IdentityError error)
    {
        return new Notification(error.Code, error.Description);
    }

    public static implicit operator IdentityError(Notification notification)
    {
        return new IdentityError { Code = notification.Key, Description = notification.Code };
    }
}
