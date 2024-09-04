namespace Living.Domain.Features.Users.Models;
public class UserAuthorItem
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
}
