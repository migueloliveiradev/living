namespace Living.Domain.Entities.Users.Constants;
public class UserErrors
{
    public static Notification NOT_FOUND => new("USER");
    public static Notification PASSWORD_INVALID => new("USER");
    public static Notification EMAIL_ALREADY_IN_USE => new("USER");
    public static Notification USERNAME_ALREADY_IN_USE => new("USER");
    public static Notification LOCKED_OUT => new("USER");
    public static Notification NOT_ALLOWED => new("USER");
    public static Notification REQUIRES_TWO_FACTOR => new("USER");
    public static Notification INVALID_REFRESH_TOKEN => new("USER");
    public static Notification INVALID_USER_ID => new("USER");
}
