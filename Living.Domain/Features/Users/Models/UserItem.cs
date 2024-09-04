namespace Living.Domain.Features.Users.Models;
public class UserItem
{
    public required Guid Id { get; init; }
    public required string Name { get; set; }
    public required string Username { get; set; }
}
