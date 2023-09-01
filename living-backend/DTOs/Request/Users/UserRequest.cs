using living_backend.Database;
using living_backend.Models.Users;
using living_backend.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace living_backend.DTOs.Request.Users;

public class UserRequest
{
    [JsonPropertyName("username")]
    [Required(ErrorMessage = "Username é obrigatório")]
    [MinLength(3, ErrorMessage = "Username deve conter pelo menos 3 caracteres")]
    [MaxLength(15, ErrorMessage = "Username deve conter no máximo 20 caracteres")]
    public string Username { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Name é obrigatório")]
    [MinLength(3, ErrorMessage = "Name deve conter pelo menos 3 caracteres")]
    [MaxLength(30, ErrorMessage = "Name deve conter no máximo 30 caracteres")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email deve ser um email válido")]
    public string Email { get; set; }

    [JsonPropertyName("password")]
    [Required(ErrorMessage = "Password é obrigatório")]
    [MinLength(6, ErrorMessage = "Password deve conter pelo menos 6 caracteres")]
    [MaxLength(20, ErrorMessage = "Password deve conter no máximo 20 caracteres")]
    public string Password { get; set; }

    [JsonPropertyName("password_confirmed")]
    [Required(ErrorMessage = "ConfirmPassword é obrigatório")]
    [Compare("Password", ErrorMessage = "ConfirmPassword deve ser igual ao campo Password")]
    public string PasswordConfirmed { get; set; }

    [JsonPropertyName("bio")]
    [Required(ErrorMessage = "Bio é obrigatório")]
    [MaxLength(100, ErrorMessage = "Bio deve conter no máximo 100 caracteres")]
    public string? Bio { get; set; }

    [JsonPropertyName("birth_day")]
    [Required(ErrorMessage = "Data de nascimento é obrigatório")]
    public DateTime Birthday { get; set; }

    public User ToUser() => new()
    {
        Username = Username,
        Name = Name,
        Email = Email,
        Password = Password,
        Bio = Bio,
        Birthday = Birthday
    };
}
