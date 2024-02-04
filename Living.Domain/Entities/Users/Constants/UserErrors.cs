using Living.Domain.Base;

namespace Living.Domain.Entities.Users.Constants;
public class UserErrors
{
    public static Notification NOT_FOUND => new("USER", nameof(NOT_FOUND));
    public static Notification PASSWORD_INVALID => new("USER", nameof(NOT_FOUND));
    public static Notification EMAIL_ALREADY_IN_USE => new("USER", nameof(NOT_FOUND));
    public static Notification USERNAME_ALREADY_IN_USE => new("USER", nameof(NOT_FOUND));
}
