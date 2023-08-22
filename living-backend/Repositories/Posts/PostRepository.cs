using living_backend.Database;
using living_backend.Models.Posts;
using Microsoft.EntityFrameworkCore;

namespace living_backend.Repositories.Posts;

public class PostRepository : IPostRepository
{
    private readonly DatabaseContext context;

    public PostRepository(DatabaseContext context)
    {
        this.context = context;
    }

    public void AddAttachments(Post post, params Attachment[] attachment)
    {
        context.Attachments.AddRange(attachment);
        context.SaveChanges();
    }

    public Post Create(Post post)
    {
        context.Posts.Add(post);
        context.SaveChanges();
        return post;
    }

    public void Delete(int id)
    {
        context.Posts.Where(p => p.Id == id).ExecuteDelete();
    }

    public Post? GetById(int id)
    {
        return context.Posts.FirstOrDefault(p => p.Id == id);
    }

    public Post? GetByIdWithUser(int id)
    {
        return context.Posts.Include(p => p.User).FirstOrDefault(p => p.Id == id);
    }

    public Post? GetByIdWithAttachments(int id)
    {
        return context.Posts.Include(p => p.Attachments).FirstOrDefault(p => p.Id == id);
    }

    public Post? GetByIdWithLikes(int id)
    {
        return context.Posts.Include(p => p.Likes).FirstOrDefault(p => p.Id == id);
    }

    public Post? GetByIdWithUserAndLikes(int id)
    {
        return context.Posts.Include(p => p.User).Include(p => p.Likes).FirstOrDefault(p => p.Id == id);
    }

    public Post? GetByIdWithUserAndAttachments(int id)
    {
        return context.Posts.Include(p => p.User).Include(p => p.Attachments).FirstOrDefault(p => p.Id == id);
    }

    public Post? GetByIdWithUserAndAttachmentsAndLikes(int id)
    {
        return context.Posts.Include(p => p.User).Include(p => p.Attachments).Include(p => p.Likes).FirstOrDefault(p => p.Id == id);
    }

    public void ModifyAccess(int id, Access access)
    {
        context.Posts.Where(p => p.Id == id).ExecuteUpdate(p => p.SetProperty(p => p.Access, access));
    }

    public void RemoveAttachments(Post post, params Attachment[] attachment)
    { 
        context.Attachments.RemoveRange(attachment);
        context.SaveChanges();
    }

    public Post Update(Post post)
    {
        context.Posts.Update(post);
        context.SaveChanges();
        return post;
    }
}
