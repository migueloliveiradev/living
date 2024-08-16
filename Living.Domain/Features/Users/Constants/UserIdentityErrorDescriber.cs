using Microsoft.AspNetCore.Identity;

namespace Living.Domain.Features.Users.Constants;
public class UserIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DefaultError()
        => new() { Code = "DEFAULT_ERROR", Description = $"Um erro desconhecido ocorreu." };
    public override IdentityError ConcurrencyFailure()
        => new() { Code = "CONCURRENCY_FAILURE", Description = "Falha de concorrência otimista, o objeto foi modificado." };
    public override IdentityError PasswordMismatch()
        => new() { Code = "PASSWORD_MISMATCH", Description = "Senha incorreta." };
    public override IdentityError InvalidToken()
        => new() { Code = "INVALID_TOKEN", Description = "Token inválido." };
    public override IdentityError LoginAlreadyAssociated()
        => new() { Code = "LOGIN_ALREADY_ASSOCIATED", Description = "Já existe um usuário com este login." };
    public override IdentityError InvalidUserName(string? userName)
        => new() { Code = "INVALID_USERNAME", Description = $"Login '{userName}' é inválido, pode conter apenas letras ou dígitos." };
    public override IdentityError InvalidEmail(string? email)
        => new() { Code = "INVALID_EMAIL", Description = $"Email '{email}' é inválido." };
    public override IdentityError DuplicateUserName(string userName)
        => new() { Code = "DUPLICATE_USERNAME", Description = $"Login '{userName}' já está sendo utilizado." };
    public override IdentityError DuplicateEmail(string email)
        => new() { Code = "DUPLICATE_EMAIL", Description = $"Email '{email}' já está sendo utilizado." };
    public override IdentityError InvalidRoleName(string? role)
        => new() { Code = "INVALID_ROLE_NAME", Description = $"A permissão '{role}' é inválida." };
    public override IdentityError DuplicateRoleName(string role)
        => new() { Code = "DUPLICATE_ROLE_NAME", Description = $"A permissão '{role}' já está sendo utilizada." };
    public override IdentityError UserAlreadyHasPassword()
        => new() { Code = "USER_ALREADY_HAS_PASSWORD", Description = "Usuário já possui uma senha definida." };
    public override IdentityError UserLockoutNotEnabled()
        => new() { Code = "USER_LOCKOUT_NOT_ENABLED", Description = "Lockout não está habilitado para este usuário." };
    public override IdentityError UserAlreadyInRole(string role)
        => new() { Code = "USER_ALREADY_ROLE", Description = $"Usuário já possui a permissão '{role}'." };
    public override IdentityError UserNotInRole(string role)
        => new() { Code = "USER_NOT_IN_ROLE", Description = $"Usuário não tem a permissão '{role}'." };
    public override IdentityError PasswordTooShort(int length)
        => new() { Code = "PASSWORD_TOO_SHORT", Description = $"Senhas devem conter ao menos {length} caracteres." };
    public override IdentityError PasswordRequiresNonAlphanumeric()
        => new() { Code = "PASSWORD_REQUIRES_NON_ALPHANUMERIC", Description = "Senhas devem conter ao menos um caracter não alfanumérico." };
    public override IdentityError PasswordRequiresDigit()
        => new() { Code = "PASSWORD_REQUIRES_DIGIT", Description = "Senhas devem conter ao menos um digito ('0'-'9')." };
    public override IdentityError PasswordRequiresLower()
        => new() { Code = "PASSWORD_REQUIRES_LOWER", Description = "Senhas devem conter ao menos um caracter em caixa baixa ('a'-'z')." };
    public override IdentityError PasswordRequiresUpper()
        => new() { Code = "PASSWORD_REQUIRES_UPPER", Description = "Senhas devem conter ao menos um caracter em caixa alta ('A'-'Z')." };
    public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        => new() { Code = "PASSWORD_REQUIRES_UNIQUE_CHARS", Description = $"Senhas devem conter ao menos {uniqueChars} caracteres únicos." };
    public override IdentityError RecoveryCodeRedemptionFailed()
        => new() { Code = "RECOVERY_CODE_REDEMPTION_FAILED", Description = "Falha ao resgatar o código de recuperação." };
}
