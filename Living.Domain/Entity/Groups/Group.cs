using Living.Domain.Base.Interface;
using Living.Domain.Entity.Posts;
using Living.Domain.Entity.Users;

namespace Living.Domain.Entity.Groups;
public class Group : IEntity, ITimestamps
{
    public Group(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; init; }
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public string Banner { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public virtual User Owner { get; set; }
    public virtual ICollection<PostGroup> PostGroups { get; set; } = new List<PostGroup>();
    public virtual ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void UpdateOwner(Guid ownerId)
    {
        OwnerId = ownerId;
    }

    public void UpdatePhoto(string photo)
    {
        Photo = photo;
    }

    public void UpdateBanner(string banner)
    {
        Banner = banner;
    }
}
