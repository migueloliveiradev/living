using Living.Domain.Entity.Comments;
using Living.Domain.Entity.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Living.Domain.Entity.Users.Models;
public class UserProfile
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Username { get; init; }
    public string? PhotoFileName { get; set; }
    public string? BannerFileName { get; set; }
    public string? Bio { get; set; }
    public DateOnly Birthday { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<Post> Posts { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
    public IEnumerable<User> Followers { get; set; }
    public IEnumerable<User> Following { get; set; }
    
    public int PostsCount { get; set; }
    public int CommentsCount { get; set; }
    public int FollowersCount { get; set; }
    public int FollowingCount { get; set; }
}
