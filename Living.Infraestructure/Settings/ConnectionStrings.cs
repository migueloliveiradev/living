using System.ComponentModel.DataAnnotations;

namespace Living.Infraestructure.Settings;
public class ConnectionStrings
{
    [Required]
    public string PostgresConnection { get; set; }

    [Required]
    public string RabbitMqConnection { get; set; }
}
