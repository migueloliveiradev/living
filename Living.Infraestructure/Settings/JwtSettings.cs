using System.ComponentModel.DataAnnotations;

namespace Living.Infraestructure.Settings;
public class JwtSettings
{

    [Required, MinLength(50)]
    public string Secret { get; set; }

    [Required, MinLength(16)]
    public string Issuer { get; set; }

    [Required, MinLength(16)]
    public string Audience { get; set; }

    [Required, Range(1, 60)]
    public int AccessTokenExpireInMinutes { get; set; }

    [Required, Range(1, 12)]
    public int RefreshTokenExpireInMonth { get; set; }
}
