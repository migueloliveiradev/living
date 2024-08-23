using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Features.Users.Constants;
public class UserIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DefaultError()
        => UserErrors.DEFAULT_ERROR;
    public override IdentityError ConcurrencyFailure()
        => UserErrors.CONCURRENCY_FAILURE;
    public override IdentityError PasswordMismatch()
        => UserErrors.PASSWORD_MISMATCH;
    public override IdentityError InvalidToken()
        => UserErrors.INVALID_TOKEN;
    public override IdentityError LoginAlreadyAssociated()
        => UserErrors.LOGIN_ALREADY_ASSOCIATED;
    public override IdentityError InvalidUserName(string? userName)
        => UserErrors.INVALID_USERNAME;
    public override IdentityError InvalidEmail(string? email)
        => UserErrors.INVALID_EMAIL;
    public override IdentityError DuplicateUserName(string userName)
        => UserErrors.USERNAME_ALREADY_IN_USE;
    public override IdentityError DuplicateEmail(string email)
        => UserErrors.EMAIL_ALREADY_IN_USE;
    public override IdentityError InvalidRoleName(string? role)
        => UserErrors.INVALID_ROLE_NAME;
    public override IdentityError DuplicateRoleName(string role)
        => UserErrors.DUPLICATE_ROLE_NAME;
    public override IdentityError UserAlreadyHasPassword()
        => UserErrors.USER_ALREADY_HAS_PASSWORD;
    public override IdentityError UserLockoutNotEnabled()
        => UserErrors.USER_LOCKOUT_NOT_ENABLED;
    public override IdentityError UserAlreadyInRole(string role)
        => UserErrors.USER_ALREADY_ROLE;
    public override IdentityError UserNotInRole(string role)
        => UserErrors.USER_NOT_IN_ROLE;
    public override IdentityError PasswordTooShort(int length)
        => UserErrors.PASSWORD_TOO_SHORT;
    public override IdentityError PasswordRequiresNonAlphanumeric()
        => UserErrors.PASSWORD_REQUIRES_NON_ALPHANUMERIC;
    public override IdentityError PasswordRequiresDigit()
        => UserErrors.PASSWORD_REQUIRES_DIGIT;
    public override IdentityError PasswordRequiresLower()
        => UserErrors.PASSWORD_REQUIRES_LOWER;
    public override IdentityError PasswordRequiresUpper()
        => UserErrors.PASSWORD_REQUIRES_UPPER;
    public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        => UserErrors.PASSWORD_REQUIRES_UNIQUE_CHARS;
    public override IdentityError RecoveryCodeRedemptionFailed()
        => UserErrors.RECOVERY_CODE_REDEMPTION_FAILED;
}
