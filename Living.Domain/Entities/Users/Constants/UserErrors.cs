using Living.Domain.Base;

namespace Living.Domain.Entities.Users.Constants;
public class UserErrors
{
    public static Notification USER_NOT_FOUND => new("USER", nameof(USER_NOT_FOUND));
    public static Notification USER_PASSWORD_INVALID => new("USER", nameof(USER_NOT_FOUND));
    public static Notification USER_EMAIL_ALREADY_IN_USE => new("USER", nameof(USER_NOT_FOUND));
    public static Notification USER_USERNAME_ALREADY_IN_USE => new("USER", nameof(USER_NOT_FOUND));
}
