using System.Security.Cryptography;
using System.Text;

namespace living_backend.Shared.Password;

public class Hash
{
    public static string Make(string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = SHA512.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
    public static bool Check(string password, string hashedPassword)
    {
        return Make(password) == hashedPassword;
    }
}
