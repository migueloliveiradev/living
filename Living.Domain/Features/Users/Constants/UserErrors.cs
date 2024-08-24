namespace Living.Domain.Features.Users.Constants;
public static class UserErrors
{
    public static Notification NAME_IS_REQUIRED => new("NAME");
    public static Notification NAME_LENGTH_INVALID => new("NAME");

    public static Notification EMAIL_ALREADY_IN_USE => new("EMAIL");
    public static Notification EMAIL_IS_REQUIRED => new("EMAIL");
    public static Notification INVALID_EMAIL => new("EMAIL");
    public static Notification EMAIL_LENGTH_INVALID => new("USER");

    public static Notification USERNAME_ALREADY_IN_USE => new("USERNAME");
    public static Notification USERNAME_IS_REQUIRED => new("USERNAME");
    public static Notification USERNAME_LENGTH_INVALID => new("USERNAME");

    public static Notification NOT_FOUND => new("USER");
    public static Notification INVALID_LOGIN => new("PASSWORD");
    public static Notification LOCKED_OUT => new("USER");
    public static Notification NOT_ALLOWED => new("USER");
    public static Notification REQUIRES_TWO_FACTOR => new("USER");
    public static Notification INVALID_REFRESH_TOKEN => new("USER");
    public static Notification INVALID_USER_ID => new("USER");
    public static Notification NOT_AUTHORIZED => new("USER");


    public static Notification DEFAULT_ERROR => new("USER");
    public static Notification CONCURRENCY_FAILURE => new("USER");
    public static Notification PASSWORD_MISMATCH => new("USER");
    public static Notification INVALID_TOKEN => new("USER");
    public static Notification LOGIN_ALREADY_ASSOCIATED => new("USER");
    public static Notification INVALID_USERNAME => new("USERNAME");
    public static Notification INVALID_ROLE_NAME => new("ROLE");
    public static Notification DUPLICATE_ROLE_NAME => new("ROLE");
    public static Notification USER_ALREADY_HAS_PASSWORD => new("USER");
    public static Notification USER_LOCKOUT_NOT_ENABLED => new("USER");
    public static Notification USER_ALREADY_ROLE => new("USER");
    public static Notification USER_NOT_IN_ROLE => new("USER");
    public static Notification PASSWORD_TOO_SHORT => new("PASSWORD");
    public static Notification PASSWORD_REQUIRES_NON_ALPHANUMERIC => new("PASSWORD");
    public static Notification PASSWORD_REQUIRES_DIGIT => new("PASSWORD");
    public static Notification PASSWORD_REQUIRES_LOWER => new("PASSWORD");
    public static Notification PASSWORD_REQUIRES_UPPER => new("PASSWORD");
    public static Notification PASSWORD_REQUIRES_UNIQUE_CHARS => new("PASSWORD");
    public static Notification RECOVERY_CODE_REDEMPTION_FAILED => new("USER");
}
